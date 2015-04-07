# serialplotter
2DP4 final project, reads in packed 10 bit ADC samples over serial and displays the amplitude and FFT

![Screenshot](http://i.imgur.com/8OMMyEU.png)


# Dependencies

Math.NET and Oxyplot, available in Nuget.

# Expected Data Format
For a 10 bit ADC reading stored as an unsigned short `sample`
```c
char lowByte = (sample & 0x1F); // take low 5 bits
char highByte = 0x20 | ((sample >> 5) & 0x1F); // take high 5 bits and prepend bits 001
```
lowByte then highByte are sent over serial as raw bytes
