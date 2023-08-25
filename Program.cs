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

namespace AutoServers
{
    public class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync()
        {
            while (true)
            {
                var _client = new DiscordSocketClient();
                var token = "NzQ3MDYwMDU2ODYzODAxMzk1.X0JX5Q.EAzd2clkAie1pN11YwGdOukW-d8";
                ulong channelId = 846430101318533180;
                ulong channelId2 = 1088880001618804776;
                ulong channelId3 = 883756518573490258;
                ulong channelId4 = 1109229097856540743;
                var message = (DateTime.Now + "\nQuantum I Started");
                var message1 = (DateTime.Now + "\nQuantum II Started");
                var message2 = (DateTime.Now + "\nVanilla Started");
                var message3 = (DateTime.Now + "\nQuantum NPC Started");
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();


                // Block this task until the program is closed.
                Int64 x;
                bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
                bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER11-GALAXY2")) != default(Process);
                bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\TORCH-Server_14")) != default(Process);
                bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
                string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
                string exePath2 = @"C:\SERVER11-GALAXY2\Torch.Server.exe";
                string exePath3 = @"C:\TORCH-Server_14\Torch.Server.exe";
                string exePath4 = @"C:\SERVER10-NPC\Torch.Server.exe";
                int serv1, serv2, serv3;
//                string filePath = @"G:\Logs Server AutoStart\";
//                StreamWriter lg = new StreamWriter(filePath + "logServerAutostarts.txt", true, Encoding.ASCII);
                if (isRunning == true)
                {
                    Console.WriteLine("Quantum I Ready");
                    serv1 = 1;
                }
                else
                {
                    Process.Start(exePath1);
                    var channel = await _client.GetChannelAsync(channelId) as IMessageChannel;
                    await channel!.SendMessageAsync(message);
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
                if (isRunning2 == true)
                {
                    Console.WriteLine("Quantum II Ready");
                    serv2 = 1;
                }
                else
                {
                    Process.Start(exePath2);
                    var channel = await _client.GetChannelAsync(channelId2) as IMessageChannel;
                    await channel!.SendMessageAsync(message1);
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
                if (isRunning3 == true)
                {
                    Console.WriteLine("Quantum NPC Ready");
                    serv3 = 1;
                }
                else
                {
                    Process.Start(exePath3);
                    TimeSpan ts3 = TimeSpan.Zero;
                    serv3 = 0;
                    var channel = await _client.GetChannelAsync(channelId4) as IMessageChannel;
                    await channel!.SendMessageAsync(message3);
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
                if (isRunning4 == true)
                {
                    Console.WriteLine("Vanilla Ready");
                }
                else
                {
                    Process.Start(exePath4);
                    TimeSpan ts3 = TimeSpan.Zero;
                    var channel = await _client.GetChannelAsync(channelId3) as IMessageChannel;
                    await channel!.SendMessageAsync(message2);
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
                var servin = serv1 + serv2 + serv3;
                await _client.SetGameAsync("Servers " + servin + "/3 Quantum");
                Thread.Sleep(30000);
            }       
        }

    }
}