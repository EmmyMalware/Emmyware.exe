using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Emmyware
{
    public class ExceptionLogger
    {
        private static readonly string logFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "encryption_log.txt"
    );

        public static void Log(Exception ex)
        {
            try
            {
                File.AppendAllText(logFilePath,
                    $"[{DateTime.Now}] {ex.GetType().Name}: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}{Environment.NewLine}"
                );
            }
            catch
            {
                // Silent fail — can't log the error if logging itself fails
            }
        }
    }
}
