using MathNet.Numerics.IntegralTransforms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPlotter
{
    public partial class FrmMain : Form
    {
        public String[] SerialPortsList
        {
            get;
            private set;
        }
        public bool Running
        {
            get;
            set;
        }
        public SerialPort Port
        {
            get;
            set;
        }
        public LineSeries AmplitudeData
        {
            get;
            set;
        }
        public PlotModel Model
        {
            get;
            set;
        }
        public LineSeries FFTData
        {
            get;
            set;
        }
        public PlotModel FFTModel
        {
            get;
            set;
        }
        public List<Complex> FFTSamples = new List<Complex>();
        public FrmMain()
        {
            InitializeComponent();
            AmplitudeData = new LineSeries("Amplitude (Volts)");
            Model = new PlotModel { Title = "ADC Channel 11" };
            Model.Series.Add(AmplitudeData);
            Model.Axes.Add(new LinearAxis(AxisPosition.Left, 0.0, 5.0));
            this.plotAmplitude.Model = Model;


            FFTData = new LineSeries("Magnitude");
            FFTData.Color = OxyPlot.OxyColors.SteelBlue;
            FFTModel = new PlotModel { Title = "FFT" };
            FFTModel.Series.Add(FFTData);
            //FFTModel.Axes.Add(new LinearAxis(AxisPosition.Left, 0.0, 5));
            this.plotFFT.Model = FFTModel;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.SerialPortsList = SerialPort.GetPortNames();
            cbComPorts.DataSource = this.SerialPortsList;
            this.Running = true;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Port != null && Port.IsOpen)
            {
                Port.Close();
                btnConnect.Text = "Connect";
                return;
            }
            if (cbComPorts.SelectedItem == null || String.IsNullOrEmpty((string)cbComPorts.SelectedItem))
            {
                return;
            }
            string comPort = (string)cbComPorts.SelectedItem;

            Port = new SerialPort(comPort, 4800);

            try
            {
                Port.Open();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return;
            }

            Thread t = new Thread(new ParameterizedThreadStart(
                delegate(object serialPort)
                {
                    SerialPort sp = (SerialPort)serialPort;
                    while (this.Running)
                    {
                        try
                        {
                            int lowByte = 0;
                            int highByte = 0;
                            List<int> data = new List<int>();
                            while (sp.BytesToRead > 0) {
                                int input = sp.ReadByte();
                                if (input >> 5 == 0)
                                {
                                    lowByte = input & 0x1F;
                                }
                                else if (input >> 5 == 1)
                                {
                                    highByte = input & 0x1F;
                                    int b = (highByte << 5) | lowByte;
                                    data.Add(b);
                                }
                                else
                                {
                                    Console.WriteLine("Bit error!");
                                }
                            }
                            if (data.Count > 0)
                            {
                                Invoke(new EventHandler(ProcessData), data, EventArgs.Empty);
                            }
                        }
                        catch (Exception)
                        {
                            sp.Close();
                            return;
                        }
                    }
                }
            ));
            t.Start(Port);

            this.btnConnect.Text = "Disconnect";

            lblError.Text = "";
        }
        int x = 0;
        const int FFT_SAMPLES = 512;
        const double SAMPLE_FREQ = 300;
        private void ProcessData(object sender, EventArgs e)
        {
            List<int> dataPoints = (List<int>)sender;

            foreach (int y in dataPoints)
            {
                x++;
                if (AmplitudeData.Points.Count > 127)
                {
                    AmplitudeData.Points.RemoveAt(0);
                }
                if (FFTSamples.Count > FFT_SAMPLES - 1)
                {
                    FFTSamples.RemoveAt(0);
                }
                AmplitudeData.Points.Add(new DataPoint((double)x, (double)(y)*5/1024.0));
                FFTSamples.Add(new Complex(y,0));
            }
            Model.InvalidatePlot(true);

            if ((x%3) == 0 && FFTSamples.Count == FFT_SAMPLES)
            {
                Complex[] fftOut = new Complex[FFTSamples.Count];
                FFTSamples.CopyTo(fftOut);

                Fourier.Forward(fftOut, FourierOptions.Default);
                FFTData.Points.Clear();
                for (int i = 1; i < fftOut.Length / 2; i++)
                {
                    double freq = i * SAMPLE_FREQ / FFT_SAMPLES;
                    FFTData.Points.Add(new DataPoint(freq, fftOut[i].Magnitude));
                }
                FFTModel.InvalidatePlot(true);
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Running = false;
        }
    }
}
