using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace XPSPrintService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.SetServiceName("LiuJuPrintTest");
                x.SetDisplayName("LiuJuPrintTest");
                x.SetDescription("刘巨打印测试");
                x.Service<PrintService>();
                x.StartAutomatically();
                x.RunAsLocalSystem();
                x.UseNLog();
                x.EnableShutdown();
                x.OnException((ex) =>
                {
                    Console.WriteLine(ex.Message);
                });
            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode()); //11
            Environment.ExitCode = exitCode;
        }
    }
}
