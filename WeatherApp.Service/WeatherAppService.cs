using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using WeatherApp.Handler;
using WeatherApp;

namespace WeatherApp.Service
{
    public partial class WeatherAppService : ServiceBase
    {
        private readonly Timer timer;
        private readonly HandlingData _handler;

        public WeatherAppService()
        {
            InitializeComponent();
            timer = new Timer();
            _handler = new HandlingData();
        }

        protected override void OnStart(string[] args)
        {

            WrittingToFile($"The service was started at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");

            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000; //ONLY FOR EXAMPLE.
            //timer.Interval = (1000 * 60 * 60); //Miliseconds value.
            timer.Enabled = true;
        }

        protected override void OnStop()
        {

            WrittingToFile($"The service was stopped at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");

        }

        private async void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            WrittingToFile($"The service was executed again at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");
            var response = await _handler.HandData();
            var a = response;

        }

        private void WrittingToFile(string message)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";

            if (!File.Exists(filepath))
            {
                using (StreamWriter streamWriter = File.CreateText(filepath))
                {
                    streamWriter.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(filepath))
                {
                    streamWriter.WriteLine(message);
                }
            }

        }

        public void RunAsConsole(string[] args)
        {
            OnStart(args);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            OnStop();
        }
    }
}
