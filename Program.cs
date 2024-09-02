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

        public static string TourchEXEPATCH6 = @"C:\SERVER10-NPC\Torch.Server.exe";
        public static string exePathServer6 = @"C:\SERVER10-NPC";

        public static string TourchEXEPATCH7 = @"G:\TORCH-SERVER-16\Torch.Server.exe";
        public static string exePathServer7 = @"G:\TORCH-SERVER-16";

        //Save
        public static string exePath1Save = @"C:\SERVER9-HARD\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath2Save = @"G:\SERVER11-GALAXY2\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath3Save = @"G:\TORCH-Server_14\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath4Save = @"G:\TORCH-Server-15\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath5Save = @"E:\TORCH-Server_13\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath6Save = @"C:\SERVER10-NPC\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";
        public static string exePath7Save = @"G:\TORCH-SERVER-16\Instance\Saves\Orion\SANDBOX_0_0_0_.sbs";

        //Logs
        public static string exePath1Logs = @"C:\SERVER9-HARD\Logs\Keen-OrionPVE.log";
        public static string exePath2Logs = @"G:\SERVER11-GALAXY2\Logs\Keen-OrionSpace.log";
        public static string exePath3Logs = @"G:\TORCH-Server_14\Logs\Keen-OrionS2.log";
        public static string exePath4Logs = @"G:\TORCH-Server-15\Logs\Keen-OrionS3.log";
        public static string exePath5Logs = @"E:\TORCH-Server_13\Logs\Keen-OrionLobby.log";
        public static string exePath6Logs = @"C:\SERVER10-NPC\Logs\Keen-OrionS1.log";
        public static string exePath7Logs = @"G:\TORCH-SERVER-16\Logs\Keen-OrionSPVP.log";

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

        public static DateTime dataTimeQ6Logs = File.GetLastWriteTime(exePath6Logs);
        public static DateTime dataTimeQ6Save = File.GetLastWriteTime(exePath6Save);

        public static DateTime dataTimeQ7Logs = File.GetLastWriteTime(exePath7Logs);
        public static DateTime dataTimeQ7Save = File.GetLastWriteTime(exePath7Save);
        //BOOLs
        public static bool CheckO1 = true || false;
        public static bool CheckO1LOG = true || false;
        public static bool CheckO1SAVE = true || false;

        public static bool CheckO2 = true || false;
        public static bool CheckO2LOG = true || false;
        public static bool CheckO2SAVE = true || false;

        public static bool CheckO3 = true || false;
        public static bool CheckO3LOG = true || false;
        public static bool CheckO3SAVE = true || false;

        public static bool CheckO4 = true || false;
        public static bool CheckO4LOG = true || false;
        public static bool CheckO4SAVE = true || false;

        public static bool CheckO5 = true || false;
        public static bool CheckO5LOG = true || false;
        public static bool CheckO5SAVE = true || false;

        public static bool CheckO6 = true || false;
        public static bool CheckO6LOG = true || false;
        public static bool CheckO6SAVE = true || false;

        public static bool CheckO7 = true || false;
        public static bool CheckO7LOG = true || false;
        public static bool CheckO7SAVE = true || false;

        static void Main()
        {
            Thread Q_I_C = new Thread(Orion_PVE_Check);
            Thread Q_I_CL = new Thread(Orion_PVE_Check_LOG);
            Thread Q_I_CS = new Thread(Orion_PVE_Check_SAVE);
            Thread Q_I_KILL = new Thread(Orion_PVE_Killer);
            Q_I_C.Start();
            Q_I_CL.Start();
            Q_I_CS.Start();
            Q_I_KILL.Start();

            Thread Q_II_C = new Thread(Orion_Space_Check);
            Thread Q_II_CL = new Thread(Orion_Space_Check_LOG);
            Thread Q_II_CS = new Thread(Orion_Space_Check_SAVE);
            Thread Q_II_KILL = new Thread(Orion_Space_Killer);
            Q_II_C.Start();
            Q_II_CL.Start();
            Q_II_CS.Start();
            Q_II_KILL.Start();

            Thread Q_NPC_C = new Thread(Orion_S2_Check);
            Thread Q_NPC_CL = new Thread(Orion_S2_Check_LOG);
            Thread Q_NPC_CS = new Thread(Orion_S2_Check_SAVE);
            Thread Q_NPC_KILL = new Thread(Orion_S2_Killer);
            Q_NPC_C.Start();
            Q_NPC_CL.Start();
            Q_NPC_CS.Start();
            Q_NPC_KILL.Start();

            Thread Q_NPC_II_C = new Thread(Orion_S3_Check);
            Thread Q_NPC_II_CL = new Thread(Orion_S3_Check_LOG);
            Thread Q_NPC_II_CS = new Thread(Orion_S3_Check_SAVE);
            Thread Q_NPC_II_KILL = new Thread(Orion_S3_Killer);
            Q_NPC_II_C.Start();
            Q_NPC_II_CL.Start();
            Q_NPC_II_CS.Start();
            Q_NPC_II_KILL.Start();

            Thread Q_LOB_C = new Thread(Orion_LOB_Check);
            Thread Q_LOB_CL = new Thread(Orion_LOB_Check_LOG);
            Thread Q_LOB_CS = new Thread(Orion_LOB_Check_SAVE);
            Thread Q_LOB_KILL = new Thread(Orion_LOB_Killer);
            Q_LOB_C.Start();
            Q_LOB_CL.Start();
            Q_LOB_CS.Start();
            Q_LOB_KILL.Start();

            Thread Q_S1_C = new Thread(Orion_S1_Check);
            Thread Q_S1_CL = new Thread(Orion_S1_Check_LOG);
            Thread Q_S1_CS = new Thread(Orion_S1_Check_SAVE);
            Thread Q_S1_KILL = new Thread(Orion_S1_Killer);
            Q_S1_C.Start();
            Q_S1_CL.Start();
            Q_S1_CS.Start();
            Q_S1_KILL.Start();

            Thread Q_SPVP_C = new Thread(Orion_SPVP_Killer);
            Thread Q_SPVP_CL = new Thread(Orion_SPVP_Check_LOG);
            Thread Q_SPVP_CS = new Thread(Orion_SPVP_Check_SAVE);
            Thread Q_SPVP_KILL = new Thread(Orion_SPVP_Killer);
            Q_SPVP_C.Start();
            Q_SPVP_CL.Start();
            Q_SPVP_CS.Start();
            Q_SPVP_KILL.Start();
        }

        public static void Orion_PVE_Check()
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
                        CheckO1 = true;
                    }
                    else
                    {
                        CheckO1 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO1 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Orion_PVE_Check_LOG()
        {
            while (true)
            {
                var LogQ1 = new FileInfo(exePath1Logs);
                if (LogQ1.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckO1LOG = true;
                }
                else
                {
                    CheckO1LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_PVE_Check_SAVE()
        {
            while (true)
            {
                var SaveQ1 = new FileInfo(exePath1Save);
                if (SaveQ1.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO1SAVE = true;
                }
                else
                {
                    CheckO1SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_Space_Check()
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
                        CheckO2 = true;
                    }
                    else
                    {
                        CheckO2 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO1 = false;
                    Thread.Sleep(1000);
                }

            }
        }

        public static void Orion_Space_Check_LOG()
        {
            while (true)
            {
                var LogQ2 = new FileInfo(exePath2Logs);
                if (LogQ2.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckO2LOG = true;
                }
                else
                {
                    CheckO2LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_Space_Check_SAVE()
        {
            while (true)
            {
                var SaveQ2 = new FileInfo(exePath2Save);
                if (SaveQ2.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO2SAVE = true;
                }
                else
                {
                    CheckO2SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S2_Check()
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
                        CheckO3 = true;
                    }
                    else
                    {
                        CheckO3 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO3 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Orion_S2_Check_LOG()
        {
            while (true)
            {
                var LogQ3 = new FileInfo(exePath3Logs);
                if (LogQ3.LastWriteTime > DateTime.Now.AddMinutes(-3))
                {
                    CheckO3LOG = true;
                }
                else
                {
                    CheckO3LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S2_Check_SAVE()
        {
            while (true)
            {
                var SaveQ3 = new FileInfo(exePath3Save);
                if (SaveQ3.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO3SAVE = true;
                }
                else
                {
                    CheckO3SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S3_Check()
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
                        CheckO4 = true;
                    }
                    else
                    {
                        CheckO4 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO4 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Orion_S3_Check_LOG()
        {
            while (true)
            {
                var LogQ4 = new FileInfo(exePath4Logs);
                if (LogQ4.LastWriteTime > DateTime.Now.AddMinutes(-3))
                {
                    CheckO4LOG = true;
                }
                else
                {
                    CheckO4LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S3_Check_SAVE()
        {
            while (true)
            {
                var SaveQ4 = new FileInfo(exePath4Save);
                if (SaveQ4.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO4SAVE = true;
                }
                else
                {
                    CheckO4SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_LOB_Check()
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
                        CheckO5 = true;
                    }
                    else
                    {
                        CheckO5 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO5 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Orion_LOB_Check_LOG()
        {
            while (true)
            {
                var LogQ5 = new FileInfo(exePath5Logs);
                if (LogQ5.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckO5LOG = true;
                }
                else
                {
                    CheckO5LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_LOB_Check_SAVE()
        {
            while (true)
            {
                var SaveQ5 = new FileInfo(exePath5Save);
                if (SaveQ5.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO5SAVE = true;
                }
                else
                {
                    CheckO5SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S1_Check()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    bool isRunning6 = Process.GetProcessesByName("Torch.Server").FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"C:\SERVER10-NPC")) != default(Process);
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        process.Refresh();
                    }

                    if (isRunning6 == true)
                    {
                        CheckO6 = true;
                    }
                    else
                    {
                        CheckO6 = false;
                    }
                    Thread.Sleep(100);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Потерян процесс");
                }
                finally
                {
                    CheckO5 = false;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Orion_S1_Check_LOG()
        {
            while (true)
            {
                var LogQ6 = new FileInfo(exePath6Logs);
                if (LogQ6.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckO6LOG = true;
                }
                else
                {
                    CheckO6LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_S1_Check_SAVE()
        {
            while (true)
            {
                var SaveQ6 = new FileInfo(exePath6Save);
                if (SaveQ6.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO6SAVE = true;
                }
                else
                {
                    CheckO6SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_SPVP_Check_LOG()
        {
            while (true)
            {
                var LogQ7 = new FileInfo(exePath7Logs);
                if (LogQ7.LastWriteTime > DateTime.Now.AddMinutes(-2))
                {
                    CheckO7LOG = true;
                }
                else
                {
                    CheckO7LOG = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_SPVP_Check_SAVE()
        {
            while (true)
            {
                var SaveQ7 = new FileInfo(exePath7Save);
                if (SaveQ7.LastWriteTime > DateTime.Now.AddMinutes(-11))
                {
                    CheckO7SAVE = true;
                }
                else
                {
                    CheckO7SAVE = false;
                }
                Thread.Sleep(1000);
            }
        }

        public static void Orion_PVE_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO1 == true)
                {
                    if (CheckO1LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion PVE GOOD");
                        if (CheckO1SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion PVE GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion PVE - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                            
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Log Check Orion PVE - NO LOG");
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
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH1 + " Закрыт - НЕТ Логов");
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
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                        
                    }
                }
                else
                {
                    if (CheckO1LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion PVE GOOD");
                        if (CheckO1SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion PVE GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion PVE - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Orion PVE - NO LOG");

                                    Process.Start(TourchEXEPATCH1);
                                    Console.WriteLine(TourchEXEPATCH1 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Orion_Space_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO2 == true)
                {
                    if (CheckO2LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion Space GOOD");
                        if (CheckO2SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion Space GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion Space - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                            
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Log Check Orion Space - NO LOG");
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
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH2 + " Закрыт - НЕТ Логов");
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
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    if (CheckO2LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion Space GOOD");
                        if (CheckO2SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion Space GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion Space - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Orion Space - NO LOG");
                                    Process.Start(TourchEXEPATCH2);
                                    Console.WriteLine(TourchEXEPATCH2 + " Запуск / 5 минут ожидания данных");
                                    Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Orion_S2_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO3 == true)
                {
                    if (CheckO3LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check OrionS2 GOOD");
                        if (CheckO3SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check OrionS2 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check OrionS2 - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Save Check OrionS2 - NO LOGS");
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
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH3 + " Закрыт - НЕТ Логов");
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
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }

                    }

                }
                else
                {
                    if (CheckO3LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check OrionS2 GOOD");
                        if (CheckO3SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check OrionS2 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check OrionS2 - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check OrionS2 - NO LOG"); //7см 4см (11,4см)

                        Process.Start(TourchEXEPATCH3);
                        Console.WriteLine(TourchEXEPATCH3 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Orion_S3_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO4 == true)
                {
                    if (CheckO4LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check OrionS3 GOOD");
                        if (CheckO4SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check OrionS3 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check OrionS3 - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Log Check OrionS3 - NO LOG");
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
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH4 + " Закрыт - НЕТ Логов");
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
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    if (CheckO4LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check OrionS3 GOOD");
                        if (CheckO4SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check OrionS3 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check OrionS3 - NO SAVE");
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check OrionS3 - NO LOG");
                        Process.Start(TourchEXEPATCH4);
                        Console.WriteLine(TourchEXEPATCH4 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Orion_LOB_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO5 == true)
                {
                    if (CheckO5LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check LOB GOOD");
                        if (CheckO5SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check LOB GOOD");
                        }
                        else
                        {
                            try
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Save Check LOB - NO Logs");
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
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH5 + " Закрыт - НЕТ Логов");
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
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    if (CheckO5LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check LOB GOOD");
                        if (CheckO5SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check LOB GOOD");
                        }
                        else
                        {
                            try
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
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
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



        public static void Orion_S1_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO6 == true)
                {
                    if (CheckO6LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion S1 GOOD");
                        if (CheckO6SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion S1 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion S1 - NO SAVE");
                                string targetProcessPath = TourchEXEPATCH6;
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
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (Win32Exception)
                                        {
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        finally
                                        {
                                            Process.Start(TourchEXEPATCH6);
                                            Console.WriteLine(TourchEXEPATCH6 + " Запуск / 5 минут ожидания данных");
                                            Thread.Sleep(360000);
                                            process.Refresh();
                                        }
                                    }
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Save Check Orion S1 - NO Logs");
                            string targetProcessPath = TourchEXEPATCH6;
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
                                        Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH6);
                                        Console.WriteLine(TourchEXEPATCH6 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    if (CheckO6LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion S1 GOOD");
                        if (CheckO6SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion S1 GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion S1 - NO SAVE");
                                string targetProcessPath = TourchEXEPATCH6;
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
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (Win32Exception)
                                        {
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            Console.WriteLine(TourchEXEPATCH6 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        finally
                                        {
                                            Process.Start(TourchEXEPATCH6);
                                            Console.WriteLine(TourchEXEPATCH6 + " Запуск / 5 минут ожидания данных");
                                            Thread.Sleep(360000);
                                            process.Refresh();
                                        }
                                    }
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Orion S1 - NO LOG");
                        Process.Start(TourchEXEPATCH6);
                        Console.WriteLine(TourchEXEPATCH6 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

        public static void Orion_SPVP_Killer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (CheckO7 == true)
                {
                    if (CheckO7LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion SPVP GOOD");
                        if (CheckO7SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion SPVP GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion SPVP - NO SAVE");
                                string targetProcessPath = TourchEXEPATCH7;
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
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (Win32Exception)
                                        {
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        finally
                                        {
                                            Process.Start(TourchEXEPATCH7);
                                            Console.WriteLine(TourchEXEPATCH7 + " Запуск / 5 минут ожидания данных");
                                            Thread.Sleep(360000);
                                            process.Refresh();
                                        }
                                    }
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Save Check Orion SPVP - NO Logs");
                            string targetProcessPath = TourchEXEPATCH7;
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
                                        Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (Win32Exception)
                                    {
                                        Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ Логов");
                                        Thread.Sleep(10000);
                                    }
                                    finally
                                    {
                                        Process.Start(TourchEXEPATCH7);
                                        Console.WriteLine(TourchEXEPATCH7 + " Запуск / 5 минут ожидания данных");
                                        Thread.Sleep(360000);
                                        process.Refresh();
                                    }
                                }
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    if (CheckO7LOG == true)
                    {
                        Console.WriteLine(DateTime.Now + " Log Check Orion SPVP GOOD");
                        if (CheckO7SAVE == true)
                        {
                            Console.WriteLine(DateTime.Now + " Save Check Orion SPVP GOOD");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Save Check Orion SPVP - NO SAVE");
                                string targetProcessPath = TourchEXEPATCH7;
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
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (Win32Exception)
                                        {
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            Console.WriteLine(TourchEXEPATCH7 + " Закрыт - НЕТ СЕЙВОВ");
                                            Thread.Sleep(10000);
                                        }
                                        finally
                                        {
                                            Process.Start(TourchEXEPATCH7);
                                            Console.WriteLine(TourchEXEPATCH7 + " Запуск / 5 минут ожидания данных");
                                            Thread.Sleep(360000);
                                            process.Refresh();
                                        }
                                    }
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Log Check Orion SPVP - NO LOG");
                        Process.Start(TourchEXEPATCH7);
                        Console.WriteLine(TourchEXEPATCH7 + " Запуск / 5 минут ожидания данных");
                        Thread.Sleep(360000);
                    }
                }
                Thread.Sleep(500);
            }
        }

    }


}