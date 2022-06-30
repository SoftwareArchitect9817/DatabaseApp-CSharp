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
    public partial class ShippingReportAddtionalForm : Form
    {
        string _company, _batch;
        bool create = true;

        public ShippingReportAddtionalForm(string company, string batch)
        {
            InitializeComponent();

            _company = company;
            _batch = batch;

            string[] additional = DB.getShippingReportAdditionalInfo(_company, _batch);
            if (additional != null)
            {
                create = false;

                textBoxTruckArrived.Text = additional[2] + " " + additional[3];
                textBoxTruckLeft.Text = additional[4] + " " + additional[5];
                textBoxTrailerLicense.Text = additional[6];
                textBoxTrailerSerial.Text = additional[7];
                textBoxLoadingStart.Text = additional[8] + " " + additional[9];
                textBoxLoadingFinish.Text = additional[10] + " " + additional[11];
                textBoxLoadingPeople.Text = additional[12];
                textBoxCompanyPeople.Text = additional[13];
                textBoxComment.Text = additional[14];
                textBoxShipperName.Text = additional[15];
            }
        }

        private void textBoxTruckArrived_Click(object sender, EventArgs e)
        {
            DateTime? date = new SelectDateTimeDialog().InputBox(textBoxTruckArrived.Text);
            if (date == null)
            {
                textBoxTruckArrived.Text = "";
            }
            else
            {
                textBoxTruckArrived.Text = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void textBoxTruckLeft_Click(object sender, EventArgs e)
        {
            DateTime? date = new SelectDateTimeDialog().InputBox(textBoxTruckLeft.Text);
            if (date == null)
            {
                textBoxTruckLeft.Text = "";
            }
            else
            {
                textBoxTruckLeft.Text = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void textBoxLoadingStart_Click(object sender, EventArgs e)
        {
            DateTime? date = new SelectDateTimeDialog().InputBox(textBoxLoadingStart.Text);
            if (date == null)
            {
                textBoxLoadingStart.Text = "";
            }
            else
            {
                textBoxLoadingStart.Text = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void textBoxLoadingFinish_Click(object sender, EventArgs e)
        {
            DateTime? date = new SelectDateTimeDialog().InputBox(textBoxLoadingFinish.Text);
            if (date == null)
            {
                textBoxLoadingFinish.Text = "";
            }
            else
            {
                textBoxLoadingFinish.Text = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxShipperName.Text == "" || textBoxTruckArrived.Text == "" || textBoxTruckLeft.Text == ""
                || textBoxTrailerLicense.Text == "" || textBoxTrailerSerial.Text == ""
                || textBoxLoadingStart.Text == "" || textBoxLoadingFinish.Text == ""
                || textBoxLoadingPeople.Text == "" || textBoxCompanyPeople.Text == "")
            {
                MessageBox.Show("Please input all fields.", "Error");
                return;
            }
            string[] truck_arrived = textBoxTruckArrived.Text.Split(' ');
            string truck_arrived_date = truck_arrived[0], truck_arrived_time = truck_arrived.Length == 2 ? truck_arrived[1] : "";
            string[] truck_left = textBoxTruckLeft.Text.Split(' ');
            string truck_left_date = truck_left[0], truck_left_time = truck_left.Length == 2 ? truck_left[1] : "";
            string[] loading_start = textBoxLoadingStart.Text.Split(' ');
            string loading_start_date = loading_start[0], loading_start_time = loading_start.Length == 2 ? loading_start[1] : "";
            string[] loading_finish = textBoxLoadingFinish.Text.Split(' ');
            string loading_finish_date = loading_finish[0], loading_finish_time = loading_finish.Length == 2 ? loading_finish[1] : "";

            DB.saveShippingReportAdditionalInfo(
                new string[] {
                    _company,
                    _batch,
                    truck_arrived_date,
                    truck_arrived_time,
                    truck_left_date,
                    truck_left_time,
                    textBoxTrailerLicense.Text,
                    textBoxTrailerSerial.Text,
                    loading_start_date,
                    loading_start_time,
                    loading_finish_date,
                    loading_finish_time,
                    textBoxLoadingPeople.Text,
                    textBoxCompanyPeople.Text,
                    textBoxComment.Text,
                    textBoxShipperName.Text
                }
                , create);
            DialogResult = DialogResult.OK;
        }
    }
}
