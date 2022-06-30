
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class DatabaseSettingsForm : Form
    {
        public DatabaseSettingsForm()
        {
            InitializeComponent();
            textBoxServer.Text= Properties.Settings.Default.Server;
            textBoxDatabase.Text = Properties.Settings.Default.DatabaseName;
            textBoxUserName.Text = Properties.Settings.Default.UserName;
            textBoxPassword.Text = Properties.Settings.Default.Password;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Server = textBoxServer.Text;
            Properties.Settings.Default.DatabaseName=textBoxDatabase.Text;
            Properties.Settings.Default.UserName= textBoxUserName.Text;
            Properties.Settings.Default.Password= textBoxPassword.Text;
            Properties.Settings.Default.Save();
            Close();
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
