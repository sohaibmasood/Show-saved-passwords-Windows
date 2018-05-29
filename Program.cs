using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WIFI_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                string user;
                Console.Write("WIFI Name:  ");
                user = Console.ReadLine();
                if (user == "clsme")
                {
                    Console.Clear();
                    continue;
                }
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C netsh wlan show profile name=\"" + user + "\" key=clear";
                startInfo.UseShellExecute = false;
                process.StartInfo = startInfo;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();


                string result = process.StandardOutput.ReadToEnd();
                Console.Write("\nPassword:   ");
                for (int i = result.IndexOf("Key Content") + 25; i < result.LastIndexOf("Cost settings"); i++)
                {
                    Console.Write(result[i]);
                }
                Console.ReadKey(true);

            }
        }
    }
}
