using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Buscador.Processes
{
    static class Program
    {
        private static string _serverUrl;
        private static Timer _timer;
        private static string _pathProperties;
        private static bool _isRunning = true;

        public static int Main(string[] args)
        {
            _serverUrl = args[0];
            _pathProperties = args[1];
            _timer = new Timer(5000);//5 seg

            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            _timer.AutoReset = true;

            _timer.Start();

            while (_isRunning)
            {
                ;
            }

            return 0;
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (SolrUtils.IsIndexing(_serverUrl)) return;

            _timer.Stop();

            var lastStartDataImportTimestamp = SolrUtils.GetLastDataImportStartTimestamp(_serverUrl);
            SolrUtils.UpdateDataImportTimestamp(_pathProperties, lastStartDataImportTimestamp.Replace(":", @"\:"));

            _isRunning = false;
        }
    }
}
