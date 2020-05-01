using System;
using CSCore;
using CSCore.DSP;
using CSCore.Streams;
using CSCore.SoundIn;
using System.Drawing;
using CSCore.SoundOut;
using WinformsVisualization.Visualization;
using AudioClient_Core;
using AudioClient_Form;

namespace AudioClient_Controller
{
    public class AudioClient
    {
        private WasapiCapture _soundIn;
        private ISoundOut _soundOut;
        private IWaveSource _source;
        private SoundInSource soundInSource;
        private LineSpectrum _lineSpectrum;

        System.Windows.Forms.Timer timer = Program.Form.GetTimer();

        public bool isActive = false;
        public double RunningAverage;

        public void StartStream()
        {
            if (isActive)
            {
                Form1.Log.Print("Log", "Client is already started");
                return;
            }

            isActive = true;
            Form1.Log.Print("Log", "Starting Audio Client...");

            timer.Interval = Program.Form.GetTimerInterval();

            _soundIn = new WasapiLoopbackCapture();
            _soundIn.Initialize();

            soundInSource = new SoundInSource(_soundIn);
            ISampleSource source = soundInSource.ToSampleSource();

            SetupSampleSource(source);

            byte[] buffer = new byte[_source.WaveFormat.SampleRate / 2];

            /////////////////////////////////////////////////////////////////////
            //This part does all the thinking
            soundInSource.DataAvailable += (s, aEvent) =>
            {
                int read;
                while ((read = _source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (isActive && Program.Arduino.serialIsActive)
                    {
                        double result = 0;

                        //Add all values from buffer
                        foreach(int i in buffer)
                        {
                            //Cut off some of the higher and lower frequencies; 
                            if (i > 40 && i < buffer.Length - 40)
                            {
                                result += Math.Sqrt(buffer[i] * buffer[i]);
                            }
                        }

                        //Average the total buffer values
                        result /= buffer.Length;

                        //Set the buffer average
                        RunningAverage = result;
                    }
                }
            };
            /////////////////////////////////////////////////////////////////////

            _soundIn.Start();
            timer.Start();
            Form1.Log.Print("Log", "RecordingState: " + _soundIn.RecordingState);
        }

        public void StopStream()
        {
            if (!isActive)
            {
                Form1.Log.Print("Log", "Client is already stopped");
                return;
            }
            isActive = false;
            Form1.Log.Print("Log", "Stopping Audio Client...");

            timer.Stop();

            if (_soundOut != null)
            {
                _soundOut.Stop();
                _soundOut.Dispose();
                _soundOut = null;
            }
            if (_soundIn != null)
            {
                _soundIn.Stop();
                Form1.Log.Print("Log", "RecordingState: " + _soundIn.RecordingState);
                _soundIn.Dispose();
                _soundIn = null;
            }
            if (_source != null)
            {
                _source.Dispose();
                _source = null;
            }
        }
        
        public void RestartStream()
        {
            StopStream();
            StartStream();
        }
        
        private void SetupSampleSource(ISampleSource aSampleSource)
        {
            const FftSize fftSize = FftSize.Fft1024;
            var spectrumProvider = new BasicSpectrumProvider(aSampleSource.WaveFormat.Channels, aSampleSource.WaveFormat.SampleRate, fftSize);

            _lineSpectrum = new LineSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                BarCount = 50,
                BarSpacing = 2,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Sqrt
            };

            var notificationSource = new SingleBlockNotificationStream(aSampleSource);
            notificationSource.SingleBlockRead += (s, a) => spectrumProvider.Add(a.Left, a.Right);

            _source = notificationSource.ToWaveSource(16);
        }

        public void GenerateLineSpectrum()
        {
            var pictureBox = Program.Form.GetPictureBox();
            var oldImage = pictureBox.Image;
            var newImage = _lineSpectrum.CreateSpectrumLine(pictureBox.Size, Color.Green, Color.Red, Color.Black, true);

            if(newImage == null)
            {
                return;
            }

            pictureBox.Image = newImage;

            if (oldImage != null)
            {
                oldImage.Dispose();
                Console.WriteLine("DISPOSED::::");
            } else
            {
                Console.WriteLine("NOPE!::::");
            }

        }


        public int GetSampleRate()
        {
            if (_source != null)
            {
                return (int)_source.WaveFormat.SampleRate;
            }

            return 256;
        }
    }
}
