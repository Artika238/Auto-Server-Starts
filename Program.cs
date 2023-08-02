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
                Int64 x;
                bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
                bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER11-GALAXY2")) != default(Process);
                bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\TORCH-Server_14")) != default(Process);
                string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
                string exePath2 = @"C:\SERVER11-GALAXY2\Torch.Server.exe";
                string exePath3 = @"C:\TORCH-Server_14\Torch.Server.exe";
                string filePath = @"G:\Logs Server AutoStart\";
                StreamWriter lg = new StreamWriter(filePath + "logServerAutostarts.log", true, Encoding.ASCII);
                if (isRunning == true)
                {
                    Console.WriteLine("Quantum I Ready");
                }
                else
                {
                    Process.Start(exePath1);
                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum I Started");
                    for (x = 0; x < 10; x++)
                    {
                        lg.Write(x);
                    }

                    //close the file
                    lg.Close();
                    Thread.Sleep(10000);
                }
                if (isRunning2 == true)
                {
                    Console.WriteLine("Quantum II Ready");
                }
                else
                {
                    Process.Start(exePath2);
                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum II Started");
                    for (x = 0; x < 10; x++)
                    {
                        lg.Write(x);
                    }

                    //close the file
                    lg.Close();
                    Thread.Sleep(10000);
                }
                if (isRunning3 == true)
                {
                    Console.WriteLine("Quantum NPC Ready");
                }
                else
                {
                    Process.Start(exePath3);
                    TimeSpan ts3 = TimeSpan.Zero;
                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum NPC Started");
                    for (x = 0; x < 10; x++)
                    {
                        lg.Write(x);
                    }

                    //close the file
                    lg.Close();
                    Thread.Sleep(10000);
                }

                Thread.Sleep(30000);
            }       
        }

    }
}