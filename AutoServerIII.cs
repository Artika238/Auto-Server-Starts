﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using AutoServers;
using System.Threading.Tasks;
namespace Auto_Server_Start
{
    public class Program4
    {
        public static string exePath4 = @"C:\SERVER10-NPC\Torch.Server.exe";
        public static void QuantumIII()
        {
            do
            {
                bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
                int Hour9 = 11; int Minute9 = 59; int Seconds9 = 50; if ((Hour9 == System.DateTime.Now.Hour) && (Minute9 == System.DateTime.Now.Minute) && (Seconds9 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                int Hour10 = 17; int Minute10 = 59; int Seconds10 = 50; if ((Hour10 == System.DateTime.Now.Hour) && (Minute10 == System.DateTime.Now.Minute) && (Seconds10 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                int Hour11 = 23; int Minute11 = 59; int Seconds11 = 50; if ((Hour11 == System.DateTime.Now.Hour) && (Minute11 == System.DateTime.Now.Minute) && (Seconds11 == System.DateTime.Now.Second))
                {
                    ;
                    Thread.Sleep(60000);
                }
                int Hour12 = 05; int Minute12 = 59; int Seconds12 = 50; if ((Hour12 == System.DateTime.Now.Hour) && (Minute12 == System.DateTime.Now.Minute) && (Seconds12 == System.DateTime.Now.Second))
                {
                    Thread.Sleep(60000);
                }
                else
                {
                    if (isRunning4 == true)
                    {
                        Thread.Sleep(1);
                    }
                    else
                    {
                        Console.WriteLine("Vanilla Start");
                        Process.Start(exePath4);
                        TimeSpan ts3 = TimeSpan.Zero;
                        Thread.Sleep(50000);
                    }
                }
            }
            while (true);
        }
    }
}
