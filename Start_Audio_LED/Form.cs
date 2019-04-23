using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Ports;
using AudioClient_Core;
using ArduinoUploader;

namespace AudioClient_Form
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
            UpdateAvailableComPorts();
            UpdateAvailableArduinos();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDeviceChange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceRemovalComplete:
                        UpdateAvailableComPorts();
                        break;
                    case UsbNotification.DbtDeviceArrival:
                        UpdateAvailableComPorts();
                        break;
                }
            }
        }

        private void UpdateAvailableArduinos()
        {
            foreach (int i in Enum.GetValues(typeof(ArduinoUploader.Hardware.ArduinoModel)))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = menuItem.Text = Enum.GetName(typeof(ArduinoUploader.Hardware.ArduinoModel), i);
                menuItem.Click += new EventHandler(menuItem_click);

                void menuItem_click(object sender, EventArgs e)
                {
                    uploadArduinoCode((ArduinoUploader.Hardware.ArduinoModel)Enum.Parse(typeof(ArduinoUploader.Hardware.ArduinoModel), menuItem.Name));
                }

                uploadArduinoCodeToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void uploadArduinoCode(ArduinoUploader.Hardware.ArduinoModel ArduinoModel)
        {
            var options = new ArduinoSketchUploaderOptions
            {
                PortName = listBox1.SelectedItem.ToString(),
                FileName = "./ArduinoStreamReciever/ArduinoStreamReciever.ino.standard.hex",
                ArduinoModel = ArduinoModel
            };

            var progress = new Progress<double>(
                p => {
                    Log.ChangeLast("Log", $"Upload progress: {p * 100:F1}% ...");
                    if(p + 0.01 >= 1) { Log.Print("Log", "Done uploading, Arduino is ready to go!"); }
                });

            var uploader = new ArduinoUploader.ArduinoSketchUploader(options, null, progress);
            try
            {
                Log.Print("Log", "Uploading Code to " + options.ArduinoModel + " on Port " + options.PortName);
                Log.Print("Log", $"Upload progress: 0.0% ...");
                uploader.UploadSketch();
            }
            catch (ArduinoUploaderException)
            {
            }
            catch (Exception ex)
            {
                Log.Print("Log", $"Unexpected exception: {ex.Message}!");
            }
        }

        //Start Audio Stream
        private void Start_Click(object sender, EventArgs e)
        {
            Program.Client.StartStream();

            ToggleElement.Enable(StopButton);
            ToggleElement.Enable(StartButton);
            ToggleElement.Enable(RestartButton);
        }

        //Stop Audio Stream
        private void Stop_Click(object sender, EventArgs e)
        {
            Program.Client.StopStream();

            ToggleElement.Enable(StopButton);
            ToggleElement.Enable(StartButton);
            ToggleElement.Enable(RestartButton);
        }

        //Restart Audio Stream
        private void Restart_Click(object sender, EventArgs e)
        {
            Program.Client.RestartStream();
        }

        private void ConnectToComPort_Click(object sender, EventArgs e)
        {
            if (ConnectToComPort.Text == "Connect")
            {
                Program.Arduino.SetConnection(listBox1.SelectedItem.ToString());
            }

            if (ConnectToComPort.Text == "Disconnect")
            {
                Program.Arduino.DisconnectSerial();

                if (Program.Client.isActive)
                {
                    Program.Client.StopStream();

                    ToggleElement.Enable(StopButton);
                    ToggleElement.Enable(StartButton);
                    ToggleElement.Enable(RestartButton);
                }
            }

            ToggleElement.Enable(uploadArduinoCodeToolStripMenuItem);
            ToggleElement.Text(ConnectToComPort, new string[] { "Connect", "Disconnect" }); //Fix so that the button doesn't toggle before the port is actually able to connect****
        }

        public Int32 SampleRate()
        {
            return Convert.ToInt32("32");
        }

        //Toggle Button Enabled state
        public class ToggleElement
        {
            public static void Enable(dynamic element, bool state)
            {
                element.Enabled = state;
            }

            public static void Enable(dynamic element)
            {
                element.Enabled = element.Enabled ? false : true;
            }

            public static void Visible(dynamic element)
            {
                element.Visible = element.Enabled ? false : true;
            }

            public static void Text(dynamic element, string[] text)
            {
                for (int i = 0; i <= text.Length - 1; i++)
                {
                    if (element.Text == text[i])
                    {
                        int newIndex = (i + 1) % text.Length;
                        element.Text = text[newIndex];
                        break;
                    }
                }
            }
        }

        //Log messages to the TextBox
        public class Log
        {
            public static void Print(string key, dynamic msg)
            {
                RichTextBox element = null;

                if (key == "Log") { element = Program.Form.TextBoxLog; }
                if (key == "Serial") { element = Program.Form.SerialOutputLog; }
                if (key == "CSCore") { element = Program.Form.CSCoreOutputLog; }

                if (element.Visible)
                {
                    element.AppendText(Environment.NewLine + Convert.ToString(msg));
                    element.SelectionStart = element.TextLength;
                    element.ScrollToCaret();

                    if (element.TextLength >= element.MaxLength)
                    {
                        element.Lines[0] = null;
                    }
                }
            }

            public static void ChangeLast(string key, dynamic msg)
            {
                RichTextBox element = null;

                if (key == "Log") { element = Program.Form.TextBoxLog; }
                if (key == "Serial") { element = Program.Form.SerialOutputLog; }
                if (key == "CSCore") { element = Program.Form.CSCoreOutputLog; }

                if (element.Visible)
                {
                    string[] lines = element.Lines;
                    lines[element.Lines.Length - 1] = msg;
                    element.Lines = lines;
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.Visible)
            {
                Program.Client.GenerateLineSpectrum();
            }
        }

        public Timer GetTimer()
        {
            return timer1;
        }

        public int GetTimerInterval()
        {
            return (int)SampleRateMS.Value;
        }

        public PictureBox GetPictureBox()
        {
            return pictureBox1;
        }

        public void UpdateAvailableComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            listBox1.Items.Clear();
            foreach (var port in ports)
            {
                listBox1.Items.Add(port);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                ToggleElement.Enable(ConnectToComPort, false);
            }
            else
            {
                ToggleElement.Enable(ConnectToComPort, true);
                ToggleElement.Enable(uploadArduinoCodeToolStripMenuItem, true);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialOutputLog.ResetText();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CSCoreOutputLog.ResetText();
        }

        private void clearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextBoxLog.ResetText();
        }

        private void clearAllLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxLog.ResetText();
            SerialOutputLog.ResetText();
            CSCoreOutputLog.ResetText();
        }

        private void SampleRateMS_ValueChanged(object sender, EventArgs e)
        {
            Program.Arduino.UpdateAmpValuesArraySize();
        }

        public int GetBufferReadSize()
        {
            return (int)BufferReadSize.Value;
        }

        public int GetVolumeSensitivity()
        {
            return (int)VolumeSensitivity.Value;
        }

        private void BufferReadSize_ValueChanged(object sender, EventArgs e)
        {
            Program.Arduino.UpdateAmpValuesArraySize();
        }

        private void uploadArduinoCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //On Closing application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Client.StopStream();
            Program.Arduino.DisconnectSerial();
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Client.StopStream();
            Program.Arduino.DisconnectSerial();
            Application.Exit();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Program.Client.StopStream();
            Program.Arduino.DisconnectSerial();
            base.OnClosing(e);
        }
    }
}
