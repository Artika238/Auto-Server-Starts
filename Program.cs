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
using Discord.Utils;
using System.Threading.Channels;
using Windows.Media.Protection.PlayReady;

namespace AutoServers
{
    public class Program
    {
        static void Main()
        {
            Thread Main = new Thread(Main2);
            Thread quant1 = new Thread(QuantumI);
            Thread quant2 = new Thread(QuantumII);
            Thread quantNPC = new Thread(QuantumNPC);
            Thread quantVANILLA = new Thread(QuantumVanilla);
            Main.Start();
            quant1.Start();
            quant2.Start();
            quantNPC.Start();
            quantVANILLA.Start();
        }

        public static int serv1, serv2, serv3;
        public static bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
        public static bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(g => g.MainModule.FileName.StartsWith(@"C:\SERVER11-GALAXY2")) != default(Process);
        public static bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(j => j.MainModule.FileName.StartsWith(@"C:\TORCH-Server_14")) != default(Process);
        public static bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
        public static string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        public static string exePath2 = @"C:\SERVER11-GALAXY2\Torch.Server.exe";
        public static string exePath3 = @"C:\TORCH-Server_14\Torch.Server.exe";
        public static string exePath4 = @"C:\SERVER10-NPC\Torch.Server.exe";
        Int64 x;

        public static void QuantumI()
        {
            do
            {
                if (isRunning == true)
                {
                    Console.WriteLine("Quantum I Ready");
                    serv1 = 1;
                    Thread.Sleep(10000);
                }
                else
                {
                    Process.Start(exePath1);
                    //var channel = await _client.GetChannelAsync(channelId) as IMessageChannel;
                    //await channel!.SendMessageAsync(message);
                    serv1 = 0;
                    //                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum I Started");
                    //                    for (x = 0; x < 10; x++)
                    //                    {
                    //                        lg.Write(x);
                    //                    }

                    //close the file
                    //                    lg.Close();
                    Thread.Sleep(10000);
                }
            }
            while (true);
        }
        public static void QuantumII()
        {
            do
            {
                if (isRunning2 == true)
                {
                    Console.WriteLine("Quantum II Ready");
                    serv2 = 1;
                    Thread.Sleep(10000);
                }
                else
                {
                    Process.Start(exePath2);
                    //var channel = await _client.GetChannelAsync(channelId2) as IMessageChannel;
                    //await channel!.SendMessageAsync(message1);
                    serv2 = 0;
                    //                   lg.WriteLine("\n" + DateTime.Now + "\nQuantum II Started");
                    //                   for (x = 0; x < 10; x++)
                    //                   {
                    //                       lg.Write(x);
                    //                   }
                    //
                    //close the file
                    //                    lg.Close();
                    Thread.Sleep(10000);
                }
            }
            while (true);
        }

        public static void QuantumNPC()
        {
            do
            {
                if (isRunning3 == true)
                {
                    Console.WriteLine("Quantum NPC Ready");
                    serv3 = 1;
                    Thread.Sleep(10000);
                }
                else
                {
                    Process.Start(exePath3);
                    TimeSpan ts3 = TimeSpan.Zero;
                    serv3 = 0;
                    //var channel = await _client.GetChannelAsync(channelId4) as IMessageChannel;
                    //await channel!.SendMessageAsync(message3);
                    //                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum NPC Started");
                    //                    for (x = 0; x < 10; x++)
                    //                    {
                    //                        lg.Write(x);
                    //                    }
                    //
                    //close the file
                    //                    lg.Close();
                    Thread.Sleep(10000);
                }
            }
            while (true);
        }
        public static void QuantumVanilla()
        {
            do
            {
                if (isRunning4 == true)
                {
                    Console.WriteLine("Vanilla Ready");
                    Thread.Sleep(10000);
                }
                else
                {
                    Process.Start(exePath4);
                    TimeSpan ts3 = TimeSpan.Zero;
                    //var channel = await _client.GetChannelAsync(channelId3) as IMessageChannel;
                    //await channel!.SendMessageAsync(message2);
                    //                    lg.WriteLine("\n" + DateTime.Now + "\nQuantum NPC Started");
                    //                    for (x = 0; x < 10; x++)
                    //                    {
                    //                        lg.Write(x);
                    //                    }
                    //
                    //close the file
                    //                    lg.Close();
                    Thread.Sleep(10000);
                }
            }
            while (true);
        }

        public static void Main2()
        {
            while (true)
            {
                //var _client = new DiscordSocketClient();
                //var token = "";
                Console.WriteLine("А я жру процессор по приколу");
                Thread.Sleep(150000);
                //ulong channelId = 1;
                //ulong channelId2 = 1;
                //ulong channelId3 = 1;
                //ulong channelId4 = 1;
                //var message = (DateTime.Now + "\nQuantum I Started");
                //var message1 = (DateTime.Now + "\nQuantum II Started");
                //var message2 = (DateTime.Now + "\nVanilla Started");
                //var message3 = (DateTime.Now + "\nQuantum NPC Started");
                //await _client.LoginAsync(TokenType.Bot, token);
                //await _client.StartAsync();
                {
                    // Block this task until the program is closed.


                    //                string filePath = @"G:\Logs Server AutoStart\";
                    //                StreamWriter lg = new StreamWriter(filePath + "logServerAutostarts.txt", true, Encoding.ASCII);
                }
            }

        }
    }

}

