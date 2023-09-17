using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace GetTrustedInstaller
{
    class Program
    {
    
        
        static int Main(string[] args)
        {

            // I use TrustedInstaller process that is in the background only when the TrustedInstaller service is running to pass its ID to py7hagoras code
            ServiceController sc = new ServiceController
            {
                ServiceName = "TrustedInstaller",
            };
            if (sc.Status != ServiceControllerStatus.Running)
            sc.Start();
            Process[] proc = Process.GetProcessesByName("TrustedInstaller");
            string commandLine = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (i != 0) commandLine += " ";
                commandLine += args[i];
            }

            Console.WriteLine($"Línea de comandos: {commandLine}");
            Console.WriteLine(string.Empty);

            if (commandLine != string.Empty) {
                return IamYourDaddy.Run(proc[0].Id, commandLine, false);
            } else {
                return 3;
            }
        }



    }
}
