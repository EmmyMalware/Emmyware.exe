using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Emmyware
{
    public class CMDOperations
    {
        public static bool ExecuteCommand(string command, bool IsVisible = false)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c" + command,
                    RedirectStandardOutput = !IsVisible,
                    RedirectStandardInput = !IsVisible,
                    UseShellExecute = false,
                    CreateNoWindow = !IsVisible
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CreateBatFile(string commands, string filename, string fileext = ".bat")
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (!fileext.StartsWith("."))
                    fileext = "." + fileext;

                string fullPath = Path.Combine(desktopPath, filename + fileext);

                string normalized = commands.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);

                File.WriteAllText(fullPath, normalized);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
