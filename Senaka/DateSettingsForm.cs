using Senaka.component;
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
    public partial class DateSettingsForm : Form
    {
        public DateSettingsForm()
        {
            InitializeComponent();
            if (Settings.Selected_Date != null)
            {
                string start_date = Settings.Selected_Date[0].ToString("yyyy-MM-dd");
                string end_date = Settings.Selected_Date[1].ToString("yyyy-MM-dd");
                if (start_date != end_date) setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
                else setGeneralLblSelectedDate.Text = start_date;
            }
        }

        private void setGeneralBtnSelectDate_Click(object sender, EventArgs e)
        {
            SelectDateRangeDialog select_daterange = new SelectDateRangeDialog();
            DateTime[] list_date = select_daterange.InputBox();
            if (list_date != null)
            {
                string start_date = list_date[0].ToString("yyyy-MM-dd");
                string end_date = list_date[1].ToString("yyyy-MM-dd");
                if (start_date != end_date) setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
                else setGeneralLblSelectedDate.Text = start_date;
                Settings.Selected_Date = list_date;

                saveBtn.Enabled = true;
            }
        }

        private void setBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DB.saveSetting("list_start_date", Settings.Selected_Date[0].ToString("yyyy-MM-dd"));
                DB.saveSetting("list_end_date", Settings.Selected_Date[1].ToString("yyyy-MM-dd"));
                MessageBox.Show("Data saved successfully");
            }
            catch (Exception error) {
                MessageBox.Show(error.Message,"ERROR");
            }

        }

        private void DateSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
