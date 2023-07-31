using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Linq;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using AutoServers;
using System.Text;

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
                bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\TORCH-Server_14")) != default(Process);
                string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
                string exePath2 = @"C:\SERVER11-GALAXY2\Torch.Server.exe";
                string exePath3 = @"C:\TORCH-Server_14\Torch.Server.exe";
                string filePath = @"G:\Logs Server AutoStart\";
                StringBuilder lg = new StringBuilder();
                if (isRunning == true)
                {
                    Console.WriteLine("Quantum I Ready");
                }
                else
                {
                    Process.Start(exePath1);
                    Thread.Sleep(10000);
                    
                    TimeSpan ts = TimeSpan.Zero;
                    lg.AppendJoin("Quantum I Started {0}h, {1}m, {2}s.", ts.Hours, ts.Minutes, ts.Seconds);
                }
                if (isRunning2 == true)
                {
                    Console.WriteLine("Quantum II Ready");
                }
                else
                {
                    Process.Start(exePath2);
                    Thread.Sleep(10000);
                    TimeSpan ts2 = TimeSpan.Zero;
                    lg.AppendJoin("Quantum II Started {0}h, {1}m, {2}s.", ts2.Hours, ts2.Minutes, ts2.Seconds);
                }
                if (isRunning3 == true)
                {
                    Console.WriteLine("Quantum NPC Ready");
                }
                else
                {
                    Process.Start(exePath3);
                    Thread.Sleep(10000);
                    TimeSpan ts3 = TimeSpan.Zero;
                    lg.AppendJoin("Quantum NPC Started {0}h, {1}m, {2}s.", ts3.Hours, ts3.Minutes, ts3.Seconds);
                }
                Thread.Sleep(30000);
                File.AppendAllText(filePath + "logServerAutostarts.txt", lg.ToString());
            }       
        }

    }
}