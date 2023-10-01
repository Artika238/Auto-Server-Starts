using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using AutoServers;
using System.Threading.Tasks;
using System.Text;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Rest;
using Auto_Server_Start;
using Discord.Utils;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace AutoServers
{
    public class Program
    {
        public static int serv1, serv2, serv3, server4;
        //public static bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(a => a.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
        //public static int isRunnin4g = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.Equals(@"C:\SERVER9-HARD")).Id;
        //public static bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(k => k.MainModule.FileName.StartsWith(@"C:\SERVER11-GALAXY2")) != default(Process);
        //public static bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(j => j.MainModule.FileName.StartsWith(@"C:\TORCH-Server_14")) != default(Process);
        //public static bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
        static AutoResetEvent ResetEvent = new AutoResetEvent(true);
        static object locker = new object();
        //public static string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        //public static string exePath2 = @"G:\SERVER11-GALAXY2\Torch.Server.exe";
        //public static string exePath3 = @"G:\TORCH-Server_14\Torch.Server.exe";
        public static string exePath6 = @"C:\Users\Администратор\Desktop\Server Starts\Auto Server Start.exe";
        //public static DateTime dataTimeQ1 = File.GetLastWriteTime(exePath1);
        //public static DateTime dataTimeQ2 = File.GetLastWriteTime(exePath2);
        //public static DateTime dataTimeVanilla = File.GetLastWriteTime(exePath3);
        //public static DateTime dataTimeNPC = File.GetLastWriteTime(exePath4);
        public static DateTime now = DateTime.Now;
        public static DateTime MIN = DateTime.MinValue;
        public static DateTime MAX = DateTime.MaxValue;
        public static int servers1;
        public static int servers1_2;
        public static int servers2;
        public static int servers3;
        public static int servers4;
        public static ulong channelId = 857635825301585933;
        public static ulong channelId2 = 857635825301585933;
        public static ulong channelId3 = 857635825301585933;
        public static ulong channelId4 = 857635825301585933;







        public static string SaveQ1 = @"C:\SERVER9-HARD\Inctance";
        public static string SaveVanilla = @"C:\SERVER10-NPC\Inctance";
        public static string SaveQ2 = @"G:\SERVER11-GALAXY2\Inctance";
        public static string SaveNPC = @"G\TORCH-Server_14\Inctance";
        Int64 x;

        static void Main()
        {
            Thread Main = new Thread(Main2);
            Thread quant1 = new Thread(Program2.QuantumI);
            Thread quant2 = new Thread(Program2.QuantumII);
            Thread quant3 = new Thread(Program2.QuantumIII);
            Thread quantNPC = new Thread(Program2.QuantumNPC);
            Thread quantLOBBY = new Thread(Program2.QuantumLobby);
            Thread TimerS = new Thread(TimerConsole);
            Main.Start();
            quant1.Start();
            quant2.Start();
            quant3.Start();
            quantNPC.Start();
            quantLOBBY.Start();
            TimerS.Start();
        }

        public static void TimerConsole()
        {
            do
            {
                Thread.Sleep(50000);
                Console.Clear();
                Thread.Sleep(900000);
            }
            while (true);
        }
        public static void Main2()
        {
            Console.WriteLine("Бот Включен");
            while (true)
            {
                int Hour9 = 12; int Minute9 = 00; int Seconds9 = 00; if ((Hour9 == System.DateTime.Now.Hour) && (Minute9 == System.DateTime.Now.Minute) && (Seconds9 == System.DateTime.Now.Second))
                {
                    Process.Start(exePath6);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                    //_client.SetGameAsync("Servers restarted");
                }
                else
                {
                    var servin = serv1 + serv2 + serv3;
                    //_client.SetGameAsync("Servers " + servin + "/3 Quantum");
                }
                int Hour10 = 18; int Minute10 = 00; int Seconds10 = 00; if ((Hour10 == System.DateTime.Now.Hour) && (Minute10 == System.DateTime.Now.Minute) && (Seconds10 == System.DateTime.Now.Second))
                {
                    //_client.SetGameAsync("Servers restarted");
                    Process.Start(exePath6);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                else
                {
                    var servin = serv1 + serv2 + serv3;
                    //_client.SetGameAsync("Servers " + servin + "/3 Quantum");
                }
                int Hour11 = 00; int Minute11 = 00; int Seconds11 = 00; if ((Hour11 == System.DateTime.Now.Hour) && (Minute11 == System.DateTime.Now.Minute) && (Seconds11 == System.DateTime.Now.Second))
                {
                    //_client.SetGameAsync("Servers restarted");
                    Process.Start(exePath6);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                else
                {
                    var servin = serv1 + serv2 + serv3;
                    //_client.SetGameAsync("Servers " + servin + "/3 Quantum");
                }
                int Hour12 = 06; int Minute12 = 00; int Seconds12 = 00; if ((Hour12 == System.DateTime.Now.Hour) && (Minute12 == System.DateTime.Now.Minute) && (Seconds12 == System.DateTime.Now.Second))
                {
                    //_client.SetGameAsync("Servers restarted");
                    Process.Start(exePath6);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                else
                {
                    var servin = serv1 + serv2 + serv3;
                    //_client.SetGameAsync("Servers " + servin + "/3 Quantum");
                }
                var message = (DateTime.Now + "\nQuantum I Started");
                var message1 = (DateTime.Now + "\nQuantum II Started");
                var message2 = (DateTime.Now + "\nVanilla Started");
                var message3 = (DateTime.Now + "\nQuantum NPC Started");

                Thread.Sleep(1);
                {
                    // Block this task until the program is closed.


                    //                string filePath = @"G:\Logs Server AutoStart\";
                    //                StreamWriter lg = new StreamWriter(filePath + "logServerAutostarts.txt", true, Encoding.ASCII);
                }
            }
            }

        }

}

