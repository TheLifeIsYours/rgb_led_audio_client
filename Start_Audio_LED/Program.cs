using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioClient_Form;
using AudioClient_Controller;
using AudioClient_Arduino;

namespace AudioClient_Core
{
    
    public class Program
    {
        public static Form1 Form;
        public static AudioClient Client;
        public static ArduinoClient Arduino;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form = new Form1();
            Form1.CheckForIllegalCrossThreadCalls = false;

            Client = new AudioClient();
            Arduino = new ArduinoClient();

           Application.Run(Form);
        }
    }
}
