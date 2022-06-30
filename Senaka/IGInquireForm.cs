using Senaka.component;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Senaka
{
    public partial class IGInquireForm : Form
    {
        MessageBoxDialog error_message;
        Timer error_timer;
        public DateTime[] list_date;
        List<string[]> data;

        public IGInquireForm()
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            error_timer = new Timer();
            error_timer.Interval = Settings.IG_Sorting_Error_Time * 1000;
            error_timer.Tick += Error_timer_Tick;

            error_message = new MessageBoxDialog();
        }

        private void IGInquireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void Error_timer_Tick(object sender, EventArgs e)
        {
            error_timer.Stop();
            FormCollection forms = Application.OpenForms;
            foreach (Form f in forms)
            {
                if (f.Name == "ErrorMessageBox")
                {
                    error_message.Close();
                }
            }
        }

        private void IGInquireBtnProductionDate_Click(object sender, EventArgs e)
        {
            SelectDateRangeDialog select_daterange = new SelectDateRangeDialog();
            list_date = select_daterange.InputBox();
            if (list_date != null)
            {
                data = DB.importGlassByOrderDate(list_date);
                if (data.Count == 0)
                {
                    error_message.Show("Not Found Data!", "Error");
                    return;
                }
                Hide();
                CurrentProductionForm curProduction = new CurrentProductionForm(data, this);
                curProduction.Show();
            }
        }

        private void IGInquireBtnListDate_Click(object sender, EventArgs e)
        {
            SelectDateRangeDialog select_daterange = new SelectDateRangeDialog();
            list_date = select_daterange.InputBox();
            if (list_date != null)
            {
                data = DB.importGlassByListDate(list_date);
                if (data.Count == 0)
                {
                    error_message.Show("Not Found Data!", "Error");
                    return;
                }
                Hide();
                CurrentProductionForm curProduction = new CurrentProductionForm(data, this);
                curProduction.Show();
            }
        }

        private void IGInquireBtnRushOrders_Click(object sender, EventArgs e)
        {
            SelectDateRangeDialog select_daterange = new SelectDateRangeDialog();
            list_date = select_daterange.InputBox();
            if (list_date != null)
            {
                data = DB.importGlassByRushOrder(list_date);
                if (data.Count == 0)
                {
                    error_message.Show("Not Found Data!", "Error");
                    return;
                }
                Hide();
                CurrentProductionForm curProduction = new CurrentProductionForm(data, this);
                curProduction.Show();
            }
        }

        private void IGInquireBtnIncompleteOrders_Click(object sender, EventArgs e)
        {
            data = DB.importIncompleteOrdersGlass();
            if (data.Count == 0)
            {
                error_message.Show("No Incomplete Orders!", "Error");
                return;
            }
            Hide();
            CurrentProductionForm curProduction = new CurrentProductionForm(data, this);
            curProduction.Show();
        }

        private void IGInquireTxtSearchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string order = IGInquireTxtSearchOrder.Text;
                if (order != "")
                {
                    List<string[]> data = DB.fetchRows("glassreport", "order", order, false);
                    if (data.Count == 0)
                    {
                        error_message.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    Hide();
                    IGInquireSubForm subform = new IGInquireSubForm(this, data);
                    subform.Show();
                }
            }
        }

        private void IGInquireTxtSearchOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (int)(Keys.Back) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
