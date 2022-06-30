using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Senaka
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            string server = Properties.Settings.Default.Server, database = Properties.Settings.Default.DatabaseName, username = Properties.Settings.Default.UserName, password = Properties.Settings.Default.Password;
            DB.initialize(server, database, username, password);

            txt_UserName.Text = "admin"; txt_Password.Text = "admin1";
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                List<string[]> user_login = DB.LogIn(txt_UserName.Text, txt_Password.Text);
                int count = user_login.Count;
                if (count == 1)
                {
                    Data_user data_user_login = new Data_user(Int32.Parse(user_login[0][0]), user_login[0][1], user_login[0][2], user_login[0][3], user_login[0][4], user_login[0][5], user_login[0][6], user_login[0][7], user_login[0][8], user_login[0][9], user_login[0][10], user_login[0][11]);
                    
                    Hide();
                    new Splash().Show();
                  
                    Settings.user = data_user_login;
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
