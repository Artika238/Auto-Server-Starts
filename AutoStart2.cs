using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using AutoServers;
using System.Threading.Tasks;

namespace Auto_Server_Start
{
    public class Program2
    {
        public static int serv1, serv2, serv3, server4;
        public static string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        public static string exePath2 = @"G:\SERVER11-GALAXY2\Torch.Server.exe";
        public static string exePath3 = @"G:\TORCH-Server_14\Torch.Server.exe";
        public static string exePath4 = @"C:\SERVER10-NPC\Torch.Server.exe";
        public static string exePath5 = @"E:\TORCH-Server_13\Torch.Server.exe";
        Int64 x;

        public static void Quantum()
        {
            do
            {
                bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
                bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"G:\SERVER11-GALAXY2")) != default(Process);
                bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"G:\TORCH-Server_14")) != default(Process);
                bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
                bool isRunning5 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"E:\TORCH-Server_13")) != default(Process);
                int Hour9 = 12; int Minute9 = 00; int Seconds9 = 00; if ((Hour9 == System.DateTime.Now.Hour) && (Minute9 == System.DateTime.Now.Minute) && (Seconds9 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                int Hour10 = 18; int Minute10 = 00; int Seconds10 = 00; if ((Hour10 == System.DateTime.Now.Hour) && (Minute10 == System.DateTime.Now.Minute) && (Seconds10 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                int Hour11 = 00; int Minute11 = 00; int Seconds11 = 00; if ((Hour11 == System.DateTime.Now.Hour) && (Minute11 == System.DateTime.Now.Minute) && (Seconds11 == System.DateTime.Now.Second))
                {
                    ;
                    Thread.Sleep(60000);
                }
                int Hour12 = 06; int Minute12 = 00; int Seconds12 = 00; if ((Hour12 == System.DateTime.Now.Hour) && (Minute12 == System.DateTime.Now.Minute) && (Seconds12 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                {
                    if (isRunning == true)
                    {
                        Console.WriteLine("Quantum I Ready");
                        serv1 = 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Process.Start(exePath1);
                        Thread.Sleep(50000);
                        serv1 = 0;
                    }
                    if (isRunning2 == true)
                    {
                        Console.WriteLine("Quantum II Ready");
                        serv2 = 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Process.Start(exePath2);
                        serv2 = 0;
                        Thread.Sleep(50000);
                    }
                    if (isRunning3 == true)
                    {
                        Console.WriteLine("Quantum NPC Ready");
                        serv3 = 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Process.Start(exePath3);
                        TimeSpan ts3 = TimeSpan.Zero;
                        serv3 = 0;
                        Thread.Sleep(50000);
                    }

                    if (isRunning4 == true)
                    {
                        Console.WriteLine("Vanilla Ready");
                        server4 = 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Process.Start(exePath4);
                        TimeSpan ts3 = TimeSpan.Zero;
                        server4 = 0;
                        Thread.Sleep(50000);
                    }
                    if (isRunning5 == true)
                    {
                        Console.WriteLine("Lobby Ready");
                        server4 = 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Process.Start(exePath5);
                        TimeSpan ts3 = TimeSpan.Zero;
                        server4 = 0;
                        Thread.Sleep(50000);
                    }
                }
            }
            while (true);
        }
    }
}
