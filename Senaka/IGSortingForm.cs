using Senaka.component;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class IGSortingForm : Form
    {
        private int scaned_number;
        private DateTime start_time;
        MessageBoxDialog error_message;
        Timer timer, scan_timer, error_timer;

        public IGSortingForm()
        {
            InitializeComponent();
            MinimumSize = new Size(1024, 768);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iSortDate.Text = date;
            iSortTime.Text = today.ToString("HH:mm:ss");

            Settings.IG_Sorting_Scanned_Total = scaned_number = 0;
            iSortLblCompletedTotal.Text = Settings.IG_Sorting_Scanned_Total.ToString();
            string start_date = Settings.Selected_Date[0].ToString("yyyy/MM/dd");
            string end_date = Settings.Selected_Date[1].ToString("yyyy/MM/dd");
            if (start_date != end_date) iSortLblListDateValue.Text = start_date + " - " + end_date;
            else iSortLblListDateValue.Text = start_date;

            for (int i = 0; i < Settings.IG_Sorting_Scanned.Count; i++)
            {
                iSortHistoryData.Rows.Add(Settings.IG_Sorting_Scanned[i].Key, Settings.IG_Sorting_Scanned[i].Value);
            }
            
            start_time = DateTime.Now;

            scan_timer = new Timer();
            scan_timer.Interval = Settings.IG_Sorting_Scan_Interval * 60 * 1000;
            scan_timer.Tick += Scan_timer_Tick;
            scan_timer.Start();

            error_timer = new Timer();
            error_timer.Interval = Settings.IG_Sorting_Error_Time * 1000;
            error_timer.Tick += Error_timer_Tick;

            error_message = new MessageBoxDialog();
        }

        private void IGSortingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            scan_timer.Stop();
            error_timer.Stop();

            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iSortDate.Text = today.ToString("yyyy-MM-dd");
            iSortTime.Text = today.ToString("HH:mm:ss");
        }

        private void Scan_timer_Tick(object sender, EventArgs e)
        {
            DateTime end_time = DateTime.Now;
            iSortHistoryData.Rows.Add(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"), scaned_number);
            Settings.IG_Sorting_Scanned.Add(new KeyValuePair<string, int>(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"), scaned_number));

            scaned_number = 0;
            start_time = end_time;
        }

        private void Error_timer_Tick(object sender, EventArgs e)
        {
            error_timer.Stop();
            iSortLblMessage.Text = "";
            iSortLblStatus1.Text = iSortLblStatusValue1.Text = "";
            iSortLblStatus2.Text = iSortLblStatusValue2.Text = "";
            iSortLblStatus3.Text = iSortLblStatusValue3.Text = "";
            iSortLblStatus4.Text = iSortLblStatusValue4.Text = "";
            iSortLblStatus5.Text = iSortLblStatusValue5.Text = "";
            iSortLblStatus6.Text = iSortLblStatusValue6.Text = "";
        }

        private void iSortTxtDataInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = iSortTxtDataInput.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }

        private void scanInput(string data)
        {
            bool exist_prefix = false;
            string[] prefix_data = null, optimize_data;

            string prefix = data.Substring(0, 1);
            string sealed_unit_id = data.Substring(1);
            string error_text = "";

            foreach (string[] r in Settings.IG_Sorting_Prefix_Table)
            {
                if (r[(int)PREFIX.PREFIX] == prefix)
                {
                    exist_prefix = true;
                    prefix_data = r;
                    break;
                }
            }

            iSortLblRackID.Text = "";
            iSortLblRackID.BackColor = Color.White;
            iSortLblRackID.ForeColor = Color.Red;

            iSortLblStatus1.Text = iSortLblStatusValue1.Text = "";
            iSortLblStatus2.Text = iSortLblStatusValue2.Text = "";
            iSortLblStatus3.Text = iSortLblStatusValue3.Text = "";
            iSortLblStatus4.Text = iSortLblStatusValue4.Text = "";
            iSortLblStatus5.Text = iSortLblStatusValue5.Text = "";
            iSortLblStatus6.Text = iSortLblStatusValue6.Text = "";

            iSortRacks.Text = "";

            DateTime now = DateTime.Now;
           
            if (exist_prefix)
            {
                string name = "";
                name = prefix_data[(int)PREFIX.NAME]; string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
                optimize_data = DB.fetchRow("glassreport", "sealed_unit_id", sealed_unit_id, false);
                if (optimize_data != null)
                {
                  
                    int qty = Convert.ToInt32(optimize_data[(int)GLASS.QTY]);
                    List<string[]> ig_sortings = DB.fetchRows("ig_sorting", "sealed_unit_id", sealed_unit_id);
                    int scanned_qty = ig_sortings.Count;
                    if (scanned_qty < qty)
                    {
                        string rack_id = optimize_data[(int)GLASS.RACK_ID];
                        if (DB.saveIGSortingData(sealed_unit_id, date, time, name) == 0)
                        {
                          
                        
                            labelLastNumber.Text = sealed_unit_id;
                            if (scanned_qty + 1 == qty) DB.completeGlassBySealedUnit(sealed_unit_id);
                            if (iSortScanedData.Rows.Count == 10) iSortScanedData.Rows.RemoveAt(9);
                            iSortScanedData.Rows.Insert(0, sealed_unit_id, date, time, name);

                            iSortLblRackID.ForeColor = DefaultForeColor;
                            if (optimize_data[(int)GLASS.DESCRIPTION] == "RUSH" && !rack_id.Contains("SU"))
                            {
                                iSortLblRackID.Text = "RUSH";
                                iSortLblRackID.BackColor = Color.Firebrick;
                            }
                            else
                            {
                                iSortLblRackID.Text = rack_id;
                                if (rack_id.Contains("SHAPE"))
                                {
                                    iSortLblRackID.BackColor = Color.DarkKhaki;
                                }
                                else if (rack_id.Contains("SU"))
                                {
                                    iSortLblRackID.BackColor = Color.Gold;
                                }
                                else if (rack_id.Contains("BG"))
                                {
                                    iSortLblRackID.Text = "BG";
                                    iSortLblRackID.BackColor = Color.SlateBlue;
                                }
                                else if (rack_id.Contains("MD"))
                                {
                                    iSortLblRackID.Text = "MD";
                                    iSortLblRackID.BackColor = Color.Cyan;
                                }
                                else
                                {
                                    iSortLblRackID.BackColor = Color.Lime;

                                    List<string[]> glasses = DB.importGlassByListDate(Settings.Selected_Date, "glass_type", optimize_data[(int)GLASS.GLASS_TYPE]);
                                    List<string> in_progress_rack = new List<string>();
                                    string rack_letter="";
                                    string[] rack;
                                    foreach (string[] row in glasses)
                                    {
                                        rack = row[(int)GLASS.RACK_ID].Split('-');
                                        if (rack.Length > 2) continue;
                                         
                                       if((rack.Length - 2)>=0) rack_letter = rack[rack.Length - 2];
                                        if (!in_progress_rack.Contains(rack_letter)) in_progress_rack.Add(rack_letter);
                                    }
                                    iSortRacks.Text = string.Join(" ", in_progress_rack.ToArray());
                                }
                            }

                            if (optimize_data[(int)GLASS.NOTE_1] != "")
                            {
                                iSortLblStatus1.Text = "Note1:";
                                iSortLblStatusValue1.Text = optimize_data[(int)GLASS.NOTE_1];
                            }
                            if (optimize_data[(int)GLASS.NOTE_2] != "")
                            {
                                iSortLblStatus2.Text = "Note2:";
                                iSortLblStatusValue2.Text = optimize_data[(int)GLASS.NOTE_2];
                            }

                            Settings.IG_Sorting_Last_Scanned_Order = optimize_data[(int)GLASS.ORDER];

                            scaned_number++;
                            Settings.IG_Sorting_Scanned_Total++;
                            iSortLblCompletedTotal.Text = Settings.IG_Sorting_Scanned_Total.ToString();

                            if (optimize_data[(int)GLASS.DESCRIPTION] != "RUSH" || rack_id.Contains("SU"))
                            {
                                DateTime list_date = Convert.ToDateTime(optimize_data[(int)GLASS.LIST_DATE]);
                                if (DateTime.Compare(Settings.Selected_Date[0], list_date) > 0 || DateTime.Compare(Settings.Selected_Date[1], list_date) < 0)
                                {
                                    iSortLblRackID.Text = "ERROR";
                                    iSortLblRackID.BackColor = Color.White;
                                    iSortLblRackID.ForeColor = Color.Red;
                                    error_text = "SEALED UNIT NOT BELONGS CURRENT BATCH";

                                    iSortLblStatus1.Text = "Order Number:"; iSortLblStatusValue1.Text = optimize_data[(int)GLASS.ORDER];
                                    iSortLblStatus2.Text = "List Date:"; iSortLblStatusValue2.Text = optimize_data[(int)GLASS.LIST_DATE];
                                    iSortLblStatus3.Text = "Order Date:"; iSortLblStatusValue3.Text = optimize_data[(int)GLASS.ORDER_DATE];
                                    iSortLblStatus4.Text = "Sealed Unit ID:"; iSortLblStatusValue4.Text = sealed_unit_id;
                                }
                            }
                        }
                        else
                        {
                            iSortLblRackID.Text = "ERROR";
                            error_text = "CANNOT SAVE DATA. PLEASE TRY AGAIN";
                        }
                    }
                    else
                    {
                        iSortLblRackID.Text = "ERROR";
                        error_text = "ALREADY SCANNED ALL QUANTITIES";

                        iSortLblStatus1.Text = "Order Number:"; iSortLblStatusValue1.Text = optimize_data[(int)GLASS.ORDER];
                        iSortLblStatus2.Text = "Sealed Unit ID:"; iSortLblStatusValue2.Text = sealed_unit_id;
                        iSortLblStatus3.Text = "List Date:"; iSortLblStatusValue3.Text = optimize_data[(int)GLASS.LIST_DATE];
                        iSortLblStatus4.Text = "Scanned Date:"; iSortLblStatusValue4.Text = ig_sortings[scanned_qty - 1][(int)IG_SORTING.DATE];
                        iSortLblStatus5.Text = "Time:"; iSortLblStatusValue5.Text = ig_sortings[scanned_qty - 1][(int)IG_SORTING.TIME];
                        iSortLblStatus6.Text = "Name:"; iSortLblStatusValue6.Text = ig_sortings[scanned_qty - 1][(int)IG_SORTING.NAME];
                    }
                    List<string[]> glass_recut = DB.getIncompleteGlassRecut(sealed_unit_id);
                    if (glass_recut.Count != 0)
                    {
                        string recutName = glass_recut[glass_recut.Count - 1][4];
                        string recutReason = glass_recut[glass_recut.Count - 1][5];
                        foreach (string[] item in Settings.Receiving_Emails_Table)
                            if (item[2].Contains("IG-Sorting"))
                            {
                                SendMail(item[1], optimize_data[(int)GLASS.ORDER], optimize_data[(int)GLASS.WINDOW_TYPE], optimize_data[(int)GLASS.LINE_3], recutName, recutReason);
                            }
                    }
                    DB.UpdateGlassRecut(sealed_unit_id);

                }
                else
                {
                    iSortLblRackID.Text = "ERROR";
                    error_text = "INVALID SEALED UNIT ID";
                }
            }
            else
            {
                iSortLblRackID.Text = "ERROR";
                error_text = "INVALID PREFIX LETTER";
            }
            //error_timer.Start();

            iSortLblMessage.Text = error_text;
            iSortTxtDataInput.Text = "";
        }
        private void SendMail(string address, string order, string window_type, string line_number, string name, string reason)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(Settings.sender_email);

            message.To.Add(new MailAddress(address));

            message.Subject = order + " GLASS READY TO PICK UP!";




            string body = "<b>Order Numer</b>: " + order +
                "<br> <b>Window type</b>: " + window_type +
                "<br><b>Line number</b>: " + line_number +
                "<br> <b>Date Time</b>: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                "<br><b>Name</b>: " + name +
                "<br><b>Reason</b>: " + reason;



            message.Body = body;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  

            message.IsBodyHtml = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Settings.sender_email, Settings.sender_pass);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

        }
        private void iSortTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = iSortTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar)) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                iSortTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
                                )
                            ) ||
                            (iSortTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar))
                        )
                    )
                )
            )
            {
                e.Handled = true;
                return;
            }
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
