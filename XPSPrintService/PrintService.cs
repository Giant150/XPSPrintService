using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace XPSPrintService
{
    public class PrintService : ServiceControl
    {
        public System.Timers.Timer PrintTimer { get; set; }
        public PrintService()
        {
            this.PrintTimer = new System.Timers.Timer(10000);
            PrintTimer.Elapsed += PrintTimer_Elapsed;
        }

        private void PrintTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.xps");
            XpsPrintHelper.Print(file, "KONICA MINOLTA bizhub C226 PCL (10.76.20.30) UPD", "liujuTestJob1", false);
        }

        public bool Start(HostControl hostControl)
        {
            this.PrintTimer.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            this.PrintTimer.Stop();
            return true;
        }
    }
}
