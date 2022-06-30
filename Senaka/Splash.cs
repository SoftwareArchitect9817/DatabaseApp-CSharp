using Senaka.lib;
using System;
using System.Windows.Forms;

namespace Senaka
{
    public partial class Splash : Form
    {
        Timer thread = new Timer();

        public Splash()
        {
            InitializeComponent();
            
            thread.Interval = 1;
            thread.Tick += Init_Tick;
            thread.Start();
        }

        private void Init_Tick(object sender, EventArgs e)
        {
            thread.Stop();

            initProgram();

            Hide();
            new MainForm().Show();
        }

        private static void initProgram()
        {
            //string server = "www.vpwglass.com", database = "u370015874_senaka", username = "u370015874_senaka", password = "z@VY0RLZ;[";
            //server = "localhost"; database = "u370015874_senaka"; username = "root"; password = "";

            //DB.initialize(server, database, username, password);

            Settings.initSettings();
        }
    }
}
