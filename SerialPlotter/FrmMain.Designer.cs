namespace SerialPlotter
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plotAmplitude = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.plotFFT = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // plotAmplitude
            // 
            this.plotAmplitude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotAmplitude.BackColor = System.Drawing.Color.White;
            this.plotAmplitude.Location = new System.Drawing.Point(0, 39);
            this.plotAmplitude.Name = "plotAmplitude";
            this.plotAmplitude.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotAmplitude.Size = new System.Drawing.Size(872, 461);
            this.plotAmplitude.TabIndex = 0;
            this.plotAmplitude.Text = "plot1";
            this.plotAmplitude.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotAmplitude.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotAmplitude.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // cbComPorts
            // 
            this.cbComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(71, 12);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(94, 21);
            this.cbComPorts.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(171, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 21);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(252, 16);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 4;
            // 
            // plotFFT
            // 
            this.plotFFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotFFT.BackColor = System.Drawing.Color.White;
            this.plotFFT.Location = new System.Drawing.Point(0, 506);
            this.plotFFT.Name = "plotFFT";
            this.plotFFT.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotFFT.Size = new System.Drawing.Size(872, 259);
            this.plotFFT.TabIndex = 5;
            this.plotFFT.Text = "plot1";
            this.plotFFT.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotFFT.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotFFT.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 766);
            this.Controls.Add(this.plotFFT);
            this.Controls.Add(this.plotAmplitude);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbComPorts);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "2DP4 Serial Plotter - John Reimers 2015";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbComPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblError;
        private OxyPlot.WindowsForms.PlotView plotAmplitude;
        private OxyPlot.WindowsForms.PlotView plotFFT;
    }
}

