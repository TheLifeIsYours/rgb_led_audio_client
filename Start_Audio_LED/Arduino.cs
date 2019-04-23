using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using AudioClient_Core;
using AudioClient_Form;

namespace AudioClient_Arduino
{
    public class ArduinoClient
    {
        SerialPort serial;

        //Serial Settings
        string[] ports;
        string selectedPort;
        int baudRate = 115200;

        System.Windows.Forms.Timer timer;
        List<double> ampValues = new List<double>();
        public int ampValuesArraySize = Program.Form.GetBufferReadSize();

        int maxBrightness = 256;
        public bool serialIsActive = false;
        public bool readyToRecieve = false;
        public byte lastReadData;

        public void SetConnection(string port)
        {
            if (serialIsActive)
            {
                Form1.Log.Print("Log", "Serial is already connected. Disconnect the current serial to connect a new one");
                return;
            }

            selectedPort = port;
            serial = new SerialPort(selectedPort, baudRate, Parity.None, 8, StopBits.One);
            serial.Open();

            if (serial.IsOpen)
            {
                SendSerialData(1);
                Form1.Log.Print("Serial", "[Client]: 1");
                serialIsActive = true;
                serial.DataReceived += new SerialDataReceivedEventHandler(readSerialData);

                timer = new System.Windows.Forms.Timer();
                timer.Interval = Program.Form.GetTimerInterval();
                timer.Start();
                timer.Tick += new EventHandler(SendAmp);

                Form1.Log.Print("Log", "Successfully connected to " + selectedPort);
            }
            else
            {
                Form1.Log.Print("Log", "Failed connection with " + selectedPort);
            }
        }

        public void DisconnectSerial()
        {
            SendSerialData(1); //Tell Arduino to stop listening for audio stream, and wait for a new connection
            Form1.Log.Print("Serial", "[Client]: 1");

            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }

            if (serial != null)
            {
                serial.Close();
                Form1.Log.Print("Log", "Successfully disconnected " + selectedPort);
                serialIsActive = false;
                readyToRecieve = false;
                serial = null;
            }
        }

        public string[] GetAvaialbleComPorts()
        {
            ports = SerialPort.GetPortNames();
            return ports;
        }

        //Read serialdata Method
        private void readSerialData(object sender, SerialDataReceivedEventArgs e)
        {
            //Read byte buffer
            byte byteBuffer = (byte)serial.ReadByte();

            //Echo serial data
            Form1.Log.Print("Serial", "[" + selectedPort + "]: "+ byteBuffer);

            //If serial prints a 0, respond with a 0 as the we want to connect to the arduino
            if (byteBuffer == 0)//Arduino is pinging and waiting for response
            {
                Form1.Log.Print("Log", "Recieved ping from arduino");
                SendSerialData(0); //Tell Arduino "I heard you, and want to connect"
                Form1.Log.Print("Serial", "[Client] 0");
            }

            //Check if the stream hasn't started yet
            if (readyToRecieve == false)
            {
                //If serial prints a 1, we are ready to stream data
                if (byteBuffer == 1)//Arduino understood and start listening for audio stream
                {
                    Form1.Log.Print("Log", "Arduino is ready to recieve data stream");
                    readyToRecieve = true;
                }
            }

            //If audioclient is inactive
            if (readyToRecieve == true && Program.Client.isActive == false)
            {
                //Send to Arduino that the audio stream has ended
                SendSerialData(3);
                Form1.Log.Print("Serial", "[Client]: 3");
            }
        }

        public void SendSerialData(byte data)
        {
            byte[] buffer = new byte[] { data };
            if (serial != null)
            {
                if (serial.IsOpen)
                {
                    serial.Write(buffer, 0, 1);
                }
            }
        }

        public void SendAmp(object sender, EventArgs e)
        {
            //If aduioClient is active
            if (Program.Client.isActive)
            {
                byte amp = GetAmp();
                if (readyToRecieve)
                {
                    // Send audio stream to the Arduino
                    SendSerialData(amp);
                }
            }
        }

        public byte GetAmp()
        {
            timer.Interval = Program.Form.GetTimerInterval();

            double RAVRG = Program.Client.RunningAverage;
            double RMVAL = runningMaxValue(RAVRG) + Program.Form.GetVolumeSensitivity();
            byte amp = (byte)constrain((int)Math.Floor(map(RAVRG, 0, RMVAL, 4, maxBrightness)), 4, maxBrightness);

            if (amp > 4)
            {
                Form1.Log.Print("CSCore", "[Amp IN]: " + (int)RAVRG);
                Form1.Log.Print("CSCore", "[Max AMP]: " + (int)RMVAL);
                Form1.Log.Print("CSCore", "[Amp OUT]: " + (int)amp);
            }

            return amp;
        }

        public int UpdateAmpValuesArraySize()
        {
            Form1.Log.Print("CSCore", "[BufferReadSize]: " + Program.Form.GetBufferReadSize());
            return Program.Form.GetBufferReadSize();
        }

        public double runningMaxValue(double newAmpValue)
        {
            //Remove last value from AmpValues Array
            if (ampValues.Count-1 >= ampValuesArraySize)
                ampValues.RemoveRange(0, 1);
            //Add new AmpValue to Array
            ampValues.Add(newAmpValue);
            //Return highest AmpValue in Array
            return ampValues.Max();
        }

        //Re-Map function
        double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

    //Constrain values function
    double constrain(int e, int t, int r) { return e > r ? r : e < t ? t : e; }

    }
}
