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
        //public static int isRunnin4g = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.Equals(@"C:\SERVER9-HARD")).Id;
        public static bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(g => g.MainModule.FileName.StartsWith(@"G:\SERVER11-GALAXY2")) != default(Process);
        public static bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(j => j.MainModule.FileName.StartsWith(@"G:\TORCH-Server_14")) != default(Process);
        public static bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(t => t.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
        public static string exePath1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        public static string exePath2 = @"G:\SERVER11-GALAXY2\Torch.Server.exe";
        public static string exePath3 = @"G:\TORCH-Server_14\Torch.Server.exe";
        public static string exePath4 = @"C:\SERVER10-NPC\Torch.Server.exe";

        public static string exePath1Save = @"C:\SERVER9-HARD\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath2Save = @"G:\SERVER11-GALAXY2\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath3Save = @"G:\TORCH-Server_14\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath4Save = @"C:\SERVER10-NPC\Instance\Saves\Vanilla\SANDBOX_0_0_0_.sbsB5";

        public static string exePath1Logs = @"C:\SERVER9-HARD\Logs\Keen-Quantum1.log";
        public static string exePath2Logs = @"G:\SERVER11-GALAXY2\Logs\Keen-Quantum2.log";
        public static string exePath3Logs = @"G:\TORCH-Server_14\Logs\Keen-QuantumNPC.log";
        public static string exePath4Logs = @"C:\SERVER10-NPC\Logs\Keen-Quantum3.log";

        public static DateTime dataTimeQ1 = File.GetLastWriteTime(exePath1Save);
        public static DateTime dataTimeQ2 = File.GetLastWriteTime(exePath2Save);
        public static DateTime dataTimeVanilla = File.GetLastWriteTime(exePath4Save);
        public static DateTime dataTimeNPC = File.GetLastWriteTime(exePath3Save);
        public static DateTime dataTimeQ1Logs = File.GetLastWriteTime(exePath1Logs);
        public static DateTime dataTimeQ2Logs = File.GetLastWriteTime(exePath2Logs);
        public static DateTime dataTimeVanillaLogs = File.GetLastWriteTime(exePath4Logs);
        public static DateTime dataTimeNPCLogs = File.GetLastWriteTime(exePath3Logs);
        public static DateTime now = DateTime.Now;
        public static DateTime MIN = DateTime.MinValue;
        public static DateTime MAX = DateTime.MaxValue;
        public static int servers1;
        public static int servers1_2;
        public static int servers2;
        public static int servers3;
        public static int servers4;

        Int64 x;

        public static void QuantumI()
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
                            Console.WriteLine("Quantum I Ready");
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
                                            Console.WriteLine("Quantum I - Попытка закрыть несуществующий торч");
                                            runningProcesses = null;
                                        }
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
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
                                        Console.WriteLine("Quantum I - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                }
                                finally
                                {
                                    Thread.ResetAbort();
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
                            Console.WriteLine("Quantum I Ready / процесс не захвачен, работает в обходном методе");
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
                                        Console.WriteLine("Quantum I - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
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
                        Console.WriteLine("Quantum I Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath1);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath1 + " Запуск / 5 минут ожидания данных");
                    }
                }
            }
            while (true);
        }
        public static void QuantumII()
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
                            Console.WriteLine("Quantum II Ready");
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
                                        Console.WriteLine("Quantum II - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
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
                                    Console.WriteLine("Quantum II - Попытка закрыть несуществующий торч");
                                    runningProcesses = null;
                                }
                                finally
                                {
                                    Thread.ResetAbort();
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
                            Console.WriteLine("Quantum II Ready / процесс не захвачен, работает в обходном методе");
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
                                        Console.WriteLine("Quantum II - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
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
                        Console.WriteLine("Quantum II Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath2);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath2 + " Запуск / 5 минут ожидания данных");
                    }
                }
            }
            while (true);
        }

        public static void QuantumNPC()
        {
            do
            {
                var saveLOGNPC = new FileInfo(exePath3Logs);
                var saveQNPC = new FileInfo(exePath3Save);
                if (isRunning3 == true)
                {
                    Console.WriteLine("==================\n" + "Phase 1 OK Q NPC. Процесс существует");
                    if (saveLOGNPC.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOGNPC.LastWriteTime + " " + saveLOGNPC.FullName);
                        if (saveQNPC.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQNPC.LastWriteTime + " " + saveQNPC.FullName);
                            Console.WriteLine("Quantum NPC Ready");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath3;
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
                                        Console.WriteLine("Quantum NPC - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
                                        Thread.Sleep(1000);
                                    }

                                    Console.WriteLine(exePath3 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath3);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath3 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        string targetProcessPath = exePath3;
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
                                    Console.WriteLine("Quantum NPC - Попытка закрыть несуществующий торч");
                                    runningProcesses = null;
                                }
                                finally
                                {
                                    Thread.ResetAbort();
                                    Thread.Sleep(1000);
                                }

                                Console.WriteLine(exePath3 + " Закрыт - НЕТ ЛОГОВ \n Phase 2 не пройден");
                                Thread.Sleep(10000);
                                Process.Start(exePath3);
                                Thread.Sleep(360000);
                                Console.WriteLine(exePath3 + " Запуск / 5 минут ожидания данных");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("==================\n" + "Phase 1 не пройдена Q NPC. Процесс не найден, либо он не запущен. Игнорируем и ждем проверку логов/сохранений");
                    if (saveLOGNPC.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOGNPC.LastWriteTime + " " + saveLOGNPC.FullName);
                        if (saveQNPC.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQNPC.LastWriteTime + " " + saveQNPC.FullName);
                            Console.WriteLine("Quantum NPC Ready / процесс не захвачен, работает в обходном методе");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath3;
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
                                        Console.WriteLine("Quantum NPC - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
                                        Thread.Sleep(1000);
                                    }

                                    Console.WriteLine(exePath3 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath3);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath3 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantum NPC Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath3);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath3 + " Запуск / 5 минут ожидания данных");
                    }
                }
            }
            while (true);
        }
        public static void QuantumVanilla()
        {
            do
            {
                var saveLOG4 = new FileInfo(exePath4Logs);
                var saveQ4 = new FileInfo(exePath4Save);
                if (isRunning4 == true)
                {
                    Console.WriteLine("==================\n" + "Phase 1 OK Q Vanilla. Процесс существует");
                    if (saveLOG4.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG4.LastWriteTime + " " + saveLOG4.FullName);
                        if (saveQ4.LastWriteTime > DateTime.Now.AddMinutes(-11))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ4.LastWriteTime + " " + saveQ4.FullName);
                            Console.WriteLine("Quantum Vanilla Ready");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath4;
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
                                        Console.WriteLine("Quantum Vanilla - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
                                        Thread.Sleep(1000);
                                    }

                                    Console.WriteLine(exePath4 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath4);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath4 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        string targetProcessPath = exePath4;
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
                                    Console.WriteLine("Quantum Vanilla - Попытка закрыть несуществующий торч");
                                    runningProcesses = null;
                                }
                                finally
                                {
                                    Thread.ResetAbort();
                                    Thread.Sleep(1000);
                                }

                                Console.WriteLine(exePath4 + " Закрыт - НЕТ ЛОГОВ \n Phase 2 не пройден");
                                Thread.Sleep(10000);
                                Process.Start(exePath4);
                                Thread.Sleep(360000);
                                Console.WriteLine(exePath4 + " Запуск / 5 минут ожидания данных");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("==================\n" + "Phase 1 не пройдена Q Vanilla. Процесс не найден, либо он не запущен. Игнорируем и ждем проверку логов/сохранений");
                    if (saveLOG4.LastWriteTime > DateTime.Now.AddMinutes(-6))
                    {
                        Console.WriteLine("Phase 2 OK \n" + saveLOG4.LastWriteTime + " " + saveLOG4.FullName);
                        if (saveQ4.LastWriteTime > DateTime.Now.AddMinutes(-6))
                        {
                            Console.WriteLine("Phase 3 OK \n" + saveQ4.LastWriteTime + " " + saveQ4.FullName);
                            Console.WriteLine("Quantum Vanilla Ready / процесс не захвачен, работает в обходном методе");
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            string targetProcessPath = exePath4;
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
                                        Console.WriteLine("Quantum Vanilla - Попытка закрыть несуществующий торч");
                                        runningProcesses = null;
                                    }
                                    finally
                                    {
                                        Thread.ResetAbort();
                                        Thread.Sleep(1000);
                                    }

                                    Console.WriteLine(exePath4 + " Закрыт - НЕТ СОХРАНЕНИЙ \n Phase 3 не пройден");
                                    Thread.Sleep(10000);
                                    Process.Start(exePath4);
                                    Thread.Sleep(360000);
                                    Console.WriteLine(exePath4 + " Запуск / 5 минут ожидания данных");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantum Vanilla Start. НЕТ ЛОГОВ = СОХРАНЕНИЙ. Phase 1-2 не пройдены. 3я фаза не исполняется, отсутствует ЛОГ изменения");
                        Process.Start(exePath4);
                        Thread.Sleep(360000);
                        Console.WriteLine(exePath4 + " Запуск / 5 минут ожидания данных");
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

