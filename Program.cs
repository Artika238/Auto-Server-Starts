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

namespace AutoServers
{
    public class Program
    {
        static void Main()
        {
            //Thread Main = new Thread(Main2);
            Thread Elys1 = new Thread(ElysiumI);
            Thread ElysNPC = new Thread(ElysiumNPC);
            //Main.Start();
            Elys1.Start();
            ElysNPC.Start();
        }

        public static int serv1, serv2, serv3;
        public static bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"D:\SE_Elysium_01")) != default(Process);
        //public static int isRunnin4g = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.Equals(@"C:\SERVER9-HARD")).Id;
        public static bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(g => g.MainModule.FileName.StartsWith(@"D:\SE_Elysium_NPC")) != default(Process);
        public static string exePath1 = @"D:\SE_Elysium_01\Torch.Server.exe";
        public static string exePath2 = @"D:\SE_Elysium_NPC\Torch.Server.exe";

        public static string exePath1Save = @"D:\SE_Elysium_01\Instance\Saves\Elysium_Server\SANDBOX_0_0_0_.sbs";
        public static string exePath2Save = @"D:\SE_Elysium_NPC\Instance\Saves\Elysium_Server_NPC\SANDBOX_0_0_0_.sbs";

        public static string exePath1Logs = @"D:\SE_Elysium_01\Logs\Keen-%_year%-%_month%-%_day%.log";
        public static string exePath2Logs = @"D:\SE_Elysium_NPC\Logs\Keen-%_year%-%_month%-%_day%.log";

        public static DateTime dataTimeQ1 = File.GetLastWriteTime(exePath1Save);
        public static DateTime dataTimeQ2 = File.GetLastWriteTime(exePath2Save);
        public static DateTime dataTimeQ1Logs = File.GetLastWriteTime(exePath1Logs);
        public static DateTime dataTimeQ2Logs = File.GetLastWriteTime(exePath2Logs);
        public static DateTime now = DateTime.Now;
        public static DateTime MIN = DateTime.MinValue;
        public static DateTime MAX = DateTime.MaxValue;
        public static int servers1;
        public static int servers1_2;
        public static int servers2;
        public static int servers3;
        public static int servers4;

        Int64 x;

        public static void ElysiumI()
        {
            do
            {
                var saveLOG1 = new FileInfo(exePath1Logs);
                var saveQ1 = new FileInfo(exePath1Save);
                if (isRunning == true)
                {
                    Console.WriteLine("==================\n" + "Phase 1 OK Q1. Процесс существует");
                    if (saveLOG1.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG1.LastWriteTime + " " + saveLOG1.FullName);
                        if (saveQ1.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ1.LastWriteTime + " " + saveQ1.FullName);
                            Console.WriteLine("Elysium I Ready");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath1;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName &&
                                    process.MainModule != null &&
                                    string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.CloseMainWindow();
                                        process.Close();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        if (isRunning == false)
                                        {
                                            Console.WriteLine("Elysium I - Попытка закрыть несуществующий торч");
                                            runningProcesses = null;
                                        }
                                    }
                                    finally
                                    {
                                        Thread.Sleep(10000);
                                    }

                                    Console.WriteLine(exePath1 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath1);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath1 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        string targetProcessPath = exePath1;
                        string targetProcessName = "Torch.Server";

                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            if (process.ProcessName == targetProcessName &&
                                process.MainModule != null &&
                                string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                try
                                {
                                    process.CloseMainWindow();
                                    process.Close();
                                }
                                catch (NullReferenceException)
                                {
                                    if (isRunning == false)
                                    {
                                        Console.WriteLine("Elysium I - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                }
                                finally
                                {
                                    Thread.Sleep(10000);
                                }

                                Console.WriteLine(exePath1 + " Закрыт - НЕТ ЛОГОВ \n Phase 2 не пройден");
                                Thread.Sleep(10000);
                                Process.Start(exePath1);
                                Thread.Sleep(360000);
                                Console.WriteLine(exePath1 + " Запуск / 5 минут ожидания данных");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("==================\n" + "Phase 1 не пройдена Q1. Процесс не найден, либо он не запущен. Игнорируем и ждем проверку логов/сохранений");
                    if (saveLOG1.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG1.LastWriteTime + " " + saveLOG1.FullName);
                        if (saveQ1.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ1.LastWriteTime + " " + saveQ1.FullName);
                            Console.WriteLine("Elysium I Ready / процесс не захвачен, работает в обходном методе");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath1;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName &&
                                    process.MainModule != null &&
                                    string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.CloseMainWindow();
                                        process.Close();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine("Elysium I - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.Sleep(10000);
                                    }

                                    Console.WriteLine(exePath1 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath1);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath1 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Elysium I Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath1);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath1 + " Запуск / 5 минут ожидания данных");
                    }
                }
            }
            while (true);
        }
        public static void ElysiumNPC()
        {
            do
            {
                var saveLOG2 = new FileInfo(exePath2Logs);
                var saveQ2 = new FileInfo(exePath2Save);
                if (isRunning2 == true)
                {
                    Console.WriteLine("==================\n" + "Phase 1 OK Q2. Процесс существует");
                    if (saveLOG2.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG2.LastWriteTime + " " + saveLOG2.FullName);
                        if (saveQ2.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ2.LastWriteTime + " " + saveQ2.FullName);
                            Console.WriteLine("Elysium NPC Ready");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath2;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName &&
                                    process.MainModule != null &&
                                    string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.CloseMainWindow();
                                        process.Close();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine("Elysium NPC - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.Sleep(10000);
                                    }
                                    Console.WriteLine(exePath2 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath2);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath2 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        string targetProcessPath = exePath2;
                        string targetProcessName = "Torch.Server";

                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            if (process.ProcessName == targetProcessName &&
                                process.MainModule != null &&
                                string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                try
                                {
                                    process.CloseMainWindow();
                                    process.Close();
                                }
                                catch (NullReferenceException)
                                {
                                    Console.WriteLine("Elysium NPC - Попытка закрыть несуществующий торч");
                                    runningProcesses = null;
                                }
                                finally
                                {
                                    Thread.Sleep(1000);
                                }

                                Console.WriteLine(exePath2 + " Закрыт - НЕТ ЛОГОВ \n Phase 2 не пройден");
                                Thread.Sleep(10000);
                                Process.Start(exePath2);
                                Thread.Sleep(360000);
                                Console.WriteLine(exePath2 + " Запуск / 5 минут ожидания данных");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("==================\n" + "Phase 1 не пройдена Q2. Процесс не найден, либо он не запущен. Игнорируем и ждем проверку логов/сохранений");
                    if (saveLOG2.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG2.LastWriteTime + " " + saveLOG2.FullName);
                        if (saveQ2.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ2.LastWriteTime + " " + saveQ2.FullName);
                            Console.WriteLine("Elysium NPC Ready / процесс не захвачен, работает в обходном методе");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath2;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName &&
                                    process.MainModule != null &&
                                    string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.CloseMainWindow();
                                        process.Close();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine("Elysium NPC - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.Sleep(1000);
                                    }
                                    Console.WriteLine(exePath2 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath2);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath2 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Elysium NPC Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath2);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath2 + " Запуск / 5 минут ожидания данных");
                    }
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
                //Console.WriteLine("А я жру процессор по приколу");
                //Thread.Sleep(150000);
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

