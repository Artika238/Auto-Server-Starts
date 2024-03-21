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
using System.ComponentModel;

namespace AutoServers
{
    public class Program
    {
        //CONFIG ZONE
        //EXE Torch
        public static string TourchEXEPATCH1 = @"C:\SERVER9-HARD\Torch.Server.exe";
        public static string exePathServer1 = @"C:\SERVER9-HARD";

        public static string TourchEXEPATCH2 = @"G:\SERVER11-GALAXY2\Torch.Server.exe";
        public static string exePathServer2 = @"G:\SERVER11-GALAXY2";

        public static string TourchEXEPATCH3 = @"G:\TORCH-Server_14\Torch.Server.exe";
        public static string exePathServer3 = @"G:\TORCH-Server_14";

        public static string TourchEXEPATCH4 = @"G:\TORCH-Server-15\Torch.Server.exe";
        public static string exePathServer4 = @"G:\TORCH-Server-15";

        public static string TourchEXEPATCH5 = @"E:\TORCH-Server_13\Torch.Server.exe";
        public static string exePathServer5 = @"E:\TORCH-Server_13";

        //Save
        public static string exePath1Save = @"C:\SERVER9-HARD\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath2Save = @"G:\SERVER11-GALAXY2\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath3Save = @"G:\TORCH-Server_14\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";
        public static string exePath4Save = @"G:\TORCH-Server-15\Instance\Saves\QuantumNPC\SANDBOX_0_0_0_.sbs";
        public static string exePath5Save = @"E:\TORCH-Server_13\Instance\Saves\Quantum\SANDBOX_0_0_0_.sbs";

        //Logs
        public static string exePath1Logs = @"C:\SERVER9-HARD\Logs\Keen-Quantum1.log";
        public static string exePath2Logs = @"G:\SERVER11-GALAXY2\Logs\Keen-Quantum2.log";
        public static string exePath3Logs = @"G:\TORCH-Server_14\Logs\Keen-QuantumNPC.log";
        public static string exePath4Logs = @"G:\TORCH-Server-15\Logs\Keen-QuantumNPCII.log";
        public static string exePath5Logs = @"E:\TORCH-Server_13\Logs\Keen-QuantumLobby.log";

        //DATA SAVE & LOGS
        public static DateTime dataTimeQ1Logs = File.GetLastWriteTime(exePath1Logs);
        public static DateTime dataTimeQ1Save = File.GetLastWriteTime(exePath1Save);

        public static DateTime dataTimeQ2Logs = File.GetLastWriteTime(exePath2Logs);
        public static DateTime dataTimeQ2Save = File.GetLastWriteTime(exePath2Save);

        public static DateTime dataTimeQ3Logs = File.GetLastWriteTime(exePath3Logs);
        public static DateTime dataTimeQ3Save = File.GetLastWriteTime(exePath3Save);

        public static DateTime dataTimeQ4Logs = File.GetLastWriteTime(exePath4Logs);
        public static DateTime dataTimeQ4Save = File.GetLastWriteTime(exePath4Save);

        public static DateTime dataTimeQ5Logs = File.GetLastWriteTime(exePath5Logs);
        public static DateTime dataTimeQ5Save = File.GetLastWriteTime(exePath5Save);
        //BOOLs
        public static bool CheckQ1 = true || false;
        public static bool CheckQ1LOG = true || false;
        public static bool CheckQ1SAVE = true || false;

        public static bool CheckQ2 = true || false;
        public static bool CheckQ2LOG = true || false;
        public static bool CheckQ2SAVE = true || false;

        public static bool CheckQ3 = true || false;
        public static bool CheckQ3LOG = true || false;
        public static bool CheckQ3SAVE = true || false;

        public static bool CheckQ4 = true || false;
        public static bool CheckQ4LOG = true || false;
        public static bool CheckQ4SAVE = true || false;

        public static bool CheckQ5 = true || false;
        public static bool CheckQ5LOG = true || false;
        public static bool CheckQ5SAVE = true || false;

        static void Main()
        {
            Thread Q_I_C = new Thread(Quantum_I_Check);
            Thread Q_I_CL = new Thread(Quantum_I_Check_LOG);
            Thread Q_I_CS = new Thread(Quantum_I_Check_SAVE);
            Thread Q_I_KILL = new Thread(Quantum_I_Killer);
            Q_I_C.Start();
            Q_I_CL.Start();
            Q_I_CS.Start();
            Q_I_KILL.Start();

            Thread Q_II_C = new Thread(Quantum_II_Check);
            Thread Q_II_CL = new Thread(Quantum_II_Check_LOG);
            Thread Q_II_CS = new Thread(Quantum_II_Check_SAVE);
            Thread Q_II_KILL = new Thread(Quantum_II_Killer);
            Q_II_C.Start();
            Q_II_CL.Start();
            Q_II_CS.Start();
            Q_II_KILL.Start();

            Thread Q_NPC_C = new Thread(Quantum_NPC_Check);
            Thread Q_NPC_CL = new Thread(Quantum_NPC_Check_LOG);
            Thread Q_NPC_CS = new Thread(Quantum_NPC_Check_SAVE);
            Thread Q_NPC_KILL = new Thread(Quantum_NPC_Killer);
            Q_NPC_C.Start();
            Q_NPC_CL.Start();
            Q_NPC_CS.Start();
            Q_NPC_KILL.Start();

            Thread Q_NPC_II_C = new Thread(Quantum_NPC_II_Check);
            Thread Q_NPC_II_CL = new Thread(Quantum_NPC_II_Check_LOG);
            Thread Q_NPC_II_CS = new Thread(Quantum_NPC_II_Check_SAVE);
            Thread Q_NPC_II_KILL = new Thread(Quantum_NPC_II_Killer);
            Q_NPC_II_C.Start();
            Q_NPC_II_CL.Start();
            Q_NPC_II_CS.Start();
            Q_NPC_II_KILL.Start();

            Thread Q_LOB_C = new Thread(Quantum_LOB_Check);
            Thread Q_LOB_CL = new Thread(Quantum_LOB_Check_LOG);
            Thread Q_LOB_CS = new Thread(Quantum_LOB_Check_SAVE);
            Thread Q_LOB_KILL = new Thread(Quantum_LOB_Killer);
            Q_LOB_C.Start();
            Q_LOB_CL.Start();
            Q_LOB_CS.Start();
            Q_LOB_KILL.Start();
        }

        public static void Quantum_I_Check()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    bool isRunning = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER9-HARD")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning == true)
                    {
                        CheckQ1 = true;
                    }
                    else
                    {
                        CheckQ1 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckQ1 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Quantum_I_Check_LOG()
        {
            while (true)
            {
                var LogQ1 = new FileInfo(exePath1Logs);
                if (LogQ1.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckQ1LOG = true;
                }
                else
                {
                    CheckQ1LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_I_Check_SAVE()
        {
            while (true)
            {
                var SaveQ1 = new FileInfo(exePath1Save);
                if (SaveQ1.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckQ1SAVE = true;
                }
                else
                {
                    CheckQ1SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_II_Check()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(100);
                    bool isRunning2 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"G:\SERVER11-GALAXY2")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning2 == true)
                    {
                        CheckQ2 = true;
                    }
                    else
                    {
                        CheckQ2 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckQ1 = false;
                    Thread.Sleep(1000);
                }

            }
        }

        public static void Quantum_II_Check_LOG()
        {
            while (true)
            {
                var LogQ2 = new FileInfo(exePath2Logs);
                if (LogQ2.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckQ2LOG = true;
                }
                else
                {
                    CheckQ2LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_II_Check_SAVE()
        {
            while (true)
            {
                var SaveQ2 = new FileInfo(exePath2Save);
                if (SaveQ2.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckQ2SAVE = true;
                }
                else
                {
                    CheckQ2SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_NPC_Check()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    bool isRunning3 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"G:\TORCH-Server_14")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning3 == true)
                    {
                        CheckQ3 = true;
                    }
                    else
                    {
                        CheckQ3 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckQ3 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Quantum_NPC_Check_LOG()
        {
            while (true)
            {
                var LogQ3 = new FileInfo(exePath3Logs);
                if (LogQ3.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckQ3LOG = true;
                }
                else
                {
                    CheckQ3LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_NPC_Check_SAVE()
        {
            while (true)
            {
                var SaveQ3 = new FileInfo(exePath3Save);
                if (SaveQ3.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckQ3SAVE = true;
                }
                else
                {
                    CheckQ3SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_NPC_II_Check()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    bool isRunning4 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"G:\TORCH-Server-15")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning4 == true)
                    {
                        CheckQ4 = true;
                    }
                    else
                    {
                        CheckQ4 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckQ4 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Quantum_NPC_II_Check_LOG()
        {
            while (true)
            {
                var LogQ4 = new FileInfo(exePath4Logs);
                if (LogQ4.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckQ4LOG = true;
                }
                else
                {
                    CheckQ4LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_NPC_II_Check_SAVE()
        {
            while (true)
            {
                var SaveQ4 = new FileInfo(exePath4Save);
                if (SaveQ4.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckQ4SAVE = true;
                }
                else
                {
                    CheckQ4SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_LOB_Check()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    bool isRunning5 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"E:\TORCH-Server_13")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning5 == true)
                    {
                        CheckQ5 = true;
                    }
                    else
                    {
                        CheckQ5 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckQ5 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Quantum_LOB_Check_LOG()
        {
            while (true)
            {
                var LogQ5 = new FileInfo(exePath5Logs);
                if (LogQ5.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckQ5LOG = true;
                }
                else
                {
                    CheckQ5LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_LOB_Check_SAVE()
        {
            while (true)
            {
                var SaveQ5 = new FileInfo(exePath5Save);
                if (SaveQ5.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckQ5SAVE = true;
                }
                else
                {
                    CheckQ5SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Quantum_I_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckQ1 == true)
                {
                    if (CheckQ1LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Q1 GOOD");
                        if (CheckQ1SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Q1 GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check Q1 - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH1;
                            string targetProcessName = "Torch.Server";
                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH1);
                                        Console.WriteLine(TourchEXEPATCH1 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Q1 - NO LOG");
                                    Process.Start(TourchEXEPATCH1);
                                    Console.WriteLine(TourchEXEPATCH1 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                else
                {
                    if (CheckQ1LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Q1 GOOD");
                        if (CheckQ1SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Q1 GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check Q1 - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH1;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH1);
                                        Console.WriteLine(TourchEXEPATCH1 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Q1 - NO LOG");

                                    Process.Start(TourchEXEPATCH1);
                                    Console.WriteLine(TourchEXEPATCH1 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Quantum_II_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckQ2 == true)
                {
                    if (CheckQ2LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Q2 GOOD");
                        if (CheckQ2SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Q2 GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check Q2 - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH2;
                            string targetProcessName = "Torch.Server";
                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH2);
                                        Console.WriteLine(TourchEXEPATCH2 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Q2 - NO LOG");
                                    Process.Start(TourchEXEPATCH2);
                                    Console.WriteLine(TourchEXEPATCH2 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                else
                {
                    if (CheckQ2LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Q2 GOOD");
                        if (CheckQ2SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Q2 GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check Q2 - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH2;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH2);
                                        Console.WriteLine(TourchEXEPATCH2 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Q2 - NO LOG");
                                    Process.Start(TourchEXEPATCH2);
                                    Console.WriteLine(TourchEXEPATCH2 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Quantum_NPC_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckQ3 == true)
                {
                    if (CheckQ3LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check QNPC GOOD");
                        if (CheckQ3SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check QNPC GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check QNPC - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH3;
                            string targetProcessName = "Torch.Server";
                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH3);
                                        Console.WriteLine(TourchEXEPATCH3 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check QNPC - NO LOG");
                        Process.Start(TourchEXEPATCH3);
                        Console.WriteLine(TourchEXEPATCH3 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                else
                {
                    if (CheckQ3LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check QNPC GOOD");
                        if (CheckQ3SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check QNPC GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check QNPC - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH3;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH3);
                                        Console.WriteLine(TourchEXEPATCH3 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check QNPC - NO LOG");

                        Process.Start(TourchEXEPATCH3);
                        Console.WriteLine(TourchEXEPATCH3 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Quantum_NPC_II_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckQ4 == true)
                {
                    if (CheckQ4LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check QNPCII GOOD");
                        if (CheckQ4SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check QNPCII GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check QNPCII - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH4;
                            string targetProcessName = "Torch.Server";
                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH4);
                                        Console.WriteLine(TourchEXEPATCH4 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check QNPCII - NO LOG");
                        Process.Start(TourchEXEPATCH4);
                        Console.WriteLine(TourchEXEPATCH4 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                else
                {
                    if (CheckQ4LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check QNPCII GOOD");
                        if (CheckQ4SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check QNPCII GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check QNPCII - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH4;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH4);
                                        Console.WriteLine(TourchEXEPATCH4 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check QNPCII - NO LOG");
                        Process.Start(TourchEXEPATCH4);
                        Console.WriteLine(TourchEXEPATCH4 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Quantum_LOB_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckQ5 == true)
                {
                    if (CheckQ5LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check LOB GOOD");
                        if (CheckQ5SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check LOB GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check LOB - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH5;
                            string targetProcessName = "Torch.Server";
                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH5);
                                        Console.WriteLine(TourchEXEPATCH5 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check LOB - NO LOG");
                        Process.Start(TourchEXEPATCH5);
                        Console.WriteLine(TourchEXEPATCH5 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                else
                {
                    if (CheckQ5LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check LOB GOOD");
                        if (CheckQ5SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check LOB GOOD");
                        }
                        else
                        {
                            Console.WriteLine("Save Check LOB - NO SAVE");
                            string targetProcessPath = TourchEXEPATCH5;
                            string targetProcessName = "Torch.Server";

                            Process[] runningProcesses = Process.GetProcesses();
                            foreach (Process process in runningProcesses)
                            {
                                if (process.ProcessName == targetProcessName && process.MainModule != null && string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch (NullReferenceException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ СЕЙВОВ");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH5);
                                        Console.WriteLine(TourchEXEPATCH5 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check LOB - NO LOG");
                        Process.Start(TourchEXEPATCH5);
                        Console.WriteLine(TourchEXEPATCH5 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

    }


}