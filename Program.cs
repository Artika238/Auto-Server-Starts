using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Linq;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using AutoServers;

namespace AutoServers
{
    public class Program
    {
        static void Main (string[] args)
        {
            while (true)
            {
                bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
                bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER11-GALAXY2")) != default(Process);
                string exePath2 = @"C:\SERVER11-GALAXY2\Torch.Server.exe";
                string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
                if (isRunning == true)
                {
                    Console.WriteLine("Quantum II Ready");
                }
                else
                {
                    Process.Start(exePath2);
                    Thread.Sleep(10000);
                }
                if (isRunning2 == true)
                {
                    Console.WriteLine("Quantum I Ready");
                }
                else
                {
                    Process.Start(exePath1);
                    Thread.Sleep(10000);
                }
                //                Process[] procesesList = Process.GetProcessesByName("Torch.Server");
                //               if (procesesList.Length > 0)
                //                {
                //                    Console.WriteLine("Приложение запущено");
                //                }
                //                else
                //                {
                //                   Console.WriteLine("Запуск производится");
                //                   // Process.Start(@"E:\TORCH-Server_14\Torch.Server.exe");
                //                   // Process.Start(@"C:\SERVER10-NPC\Torch.Server.exe");
                //                   // Process.Start(@"C:\SERVER9-HARD\Torch.Server.exe");
                //                   // Process.Start(@"C:\SERVER11-GALAXY2\Torch.Server.exe");
                //                }
                Thread.Sleep(30000);
            }       
        }

    }
}