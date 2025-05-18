using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Emmyware
{
    public partial class LoginFrm : Form
    {
        string Username = "EmmyMalware";
        string Password = "ILuvCatz!!";
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameField.Text == "")
            {
                MessageBox.Show("Enter a username, asshat", "Comfirm", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            else if (PasswordField.Text == "")
            {
                MessageBox.Show("Enter a password, asshat", "Comfirm", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            if (UsernameField.Text == Username)
            {
                MessageBox.Show("OK, let's see about the password", "Comfirm");
            }

            else
            {
                MessageBox.Show("Not the username dickface!", "Comfirm", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            if (PasswordField.Text == Password)
            {
                MessageBox.Show("You ARE Emmy! I let you go.", "Comfirm");
                ControlBox = true;
            }

            else
            {
                MessageBox.Show("Not the password dickface!", "Comfirm", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            PasswordField.UseSystemPasswordChar = true;
        }
    }
}
