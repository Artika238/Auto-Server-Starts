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
    public class Program2
    {
        public static int serv1, serv2, serv3, server4;
        public static string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        Int64 x;

        public static void QuantumI()
        {
            do
            {
                bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
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
                    if (isRunning == true)
                    {
                        Thread.Sleep(1);
                    }
                    else
                    {
                        Console.WriteLine("Quantum I Start");
                        Process.Start(exePath1);
                        Thread.Sleep(50000);
                        serv1 = 0;
                    }
                }
            }
            while (true);
        }
    }
}
