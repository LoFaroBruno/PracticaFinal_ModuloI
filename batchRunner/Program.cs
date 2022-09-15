using System.Diagnostics;
using System;

namespace batchRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LaunchCommandLineApp();
            Console.ReadKey();
        }
        static void LaunchCommandLineApp()
        {
            const string param1 = "../../transferencias.txt";
            const string param2 = "../../transferencias_completo.txt";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "../../../CompletadorDeTransferencias/bin/Debug/CompletadorDeTransferencias.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-i" + " " + param1 + " " + "-o" + " " + param2;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    if (exeProcess.ExitCode == 0)
                        Console.WriteLine("The program executed successfully.");
                    else
                        Console.WriteLine($"The program exited with status: {exeProcess.ExitCode}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex} {ex?.InnerException} {ex.StackTrace}");
            }
        }
    }
}
