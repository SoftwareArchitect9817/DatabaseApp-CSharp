
using Senaka.component;
using Senaka.lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class FrameRecut : Form
    {
        int Windowqty = 0, Casing = 0, Patiodoors = 0;
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();

        public FrameRecut()
        {
            InitializeComponent();

            MinimumSize = new Size(800, 600);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();
            if (Properties.Settings.Default.FrameRecutPath == "" || Properties.Settings.Default.FrameRecutPath == null)
                MessageBox.Show("The path for glass path is null.", "WARNING");
            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iShippingDate.Text = date;
            iShippingTime.Text = today.ToString("HH:mm:ss");

            error_message = new MessageBoxDialog();
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;
            GlassLblNumber.Text = "0";


        }
        private void WindowsWrapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();

            MainForm mainform = new MainForm();
            mainform.Show();
        }
        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iShippingDate.Text = today.ToString("yyyy-MM-dd");
            iShippingTime.Text = today.ToString("HH:mm:ss");
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
        private void iShippingTxtDataInput_KeyDown(object sender, KeyEventArgs e)
        {
            string error_text = null;
            if (e.KeyCode == Keys.Enter)
            {
                string data = iWrappingTxtDataInput.Text;
                if (data != "")
                {
                    if (Settings.Frame_Recut_Obligatory_Name_boolean == "True" && textBoxName.Text == "")
                        error_text = "Please complete name";
                    else if (Settings.Frame_Recut_Obligatory_Reason_boolean == "True" && textBoxReason.Text == "")
                        error_text = "Please complete reason";
                    else
                        scanInput(data, textBoxName.Text, textBoxReason.Text);
                }
            }

            GlassLblMessage.Text += error_text;

        }
        private void scanInput(string data, string name, string reason)
        {                   
            string id = data;
            string error_text = null;
            int frameqtyTotal = 0;
            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");

           
            string[] frameCutting = DB.fetchRow("framescutting", "F", id);
            List<string[]> FrameRecut;

            if (frameCutting != null)
            {

                FrameRecut = DB.fetchRows("FrameRecut", "Order_id", id);

                if (FrameRecut.Count == 0 || FrameRecut.Last()[7] == "Complete")
                {
                    int frameqty = 0;
                    bool exist = false, existInDatabase = false;
                    int r = 0;
                    string ordNumb = frameCutting[10];

                    for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                        if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ordNumb)
                        {
                            r = i;
                            exist = true;

                            frameqty = Int32.Parse(OrderScanedData.Rows[i].Cells[1].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[1].Value.ToString().IndexOf('/')));

                        }

                    List<string[]> FramesCuttingData = DB.getFrameCuttingByOrderNumber(ordNumb);

                    frameqtyTotal = FramesCuttingData.Count;

                    if (!exist)
                    {
                        List<string[]> frameRecut = DB.fetchRows("FrameRecut", "Order_number", ordNumb);
                        frameqty = frameRecut.Where(x => x[7] != "Complete").Count();
                    }

                    frameqty++;
                    if (!exist)
                    {
                        if (DB.saveFrameRecutData(id, date, time, ordNumb, name, reason) == 0)
                        {
                            OrderScanedData.Rows.Add(ordNumb, frameqty + "/" + frameqtyTotal);
                            if (frameqty == frameqtyTotal && frameqtyTotal != 0)
                                OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[3].Style.BackColor = Color.Lime;

                        }
                    }
                    else
                    {
                        if (DB.saveFrameRecutData(id, date, time, ordNumb, name, reason) == 0)
                        {

                            OrderScanedData.Rows[r].Cells[1].Value = frameqty + "/" + frameqtyTotal;

                            if (frameqty == frameqtyTotal && frameqtyTotal != 0)
                                OrderScanedData.Rows[r].Cells[3].Style.BackColor = Color.Lime;

                        }
                    }

                    DB.deleteFrameClearing(id);
                    DB.deleteVinylProFrameShipping(id);
                    DB.deleteColourShipping(id);
                    DB.deleteCasementHardware(id);
                    DB.deleteColourReceiving(id);
                    DB.deleteFrameAssembly(id);
                    DB.deleteDVCoatexColorShipping(id);
                    DB.deleteDVCoatexColorReceiving(id);
                    DB.deleteExpressCoatingColourShipping(id);
                    DB.deleteExpressCoatingColorReceiving(id);
                    DB.deleteVinylProFrameReceiving(id);

                    foreach (string[] item in Settings.Receiving_Emails_Table)
                        if (item[2].Contains("FrameRecut"))
                        {
                            SendMail(item[1], ordNumb, frameCutting[19], frameCutting[1], frameCutting[17], frameCutting[18], frameCutting[8], date + " " + time, name, reason);
                        }

                    iShippingScanedData.Rows.Add(id, date, time, name);
                    GlassLblNumber.Text = (Int32.Parse(GlassLblNumber.Text) + 1).ToString();
                    Create_File(frameCutting);
                }
                else
                {

                    error_text = "LINE NUMBER SCANNED!";
                }
            }

            else
            {

                error_text = "INVALID LINE NUMBER!";
            }

            iWrappingTxtDataInput.Text = null;

            GlassLblMessage.Text = error_text;

        }
        private void SendMail(string address, string order, string line_number, string size, string color_In, string color_Out, string frame_type, string date_time, string name, string reason)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(Settings.sender_email);
            message.To.Add(new MailAddress(address));
            message.Subject = frame_type + " Recut";


            string body = "<b>Order number</b>: " + order +
                "<br> <b>Frame line number</b>: " + line_number +
                "<br> <b>Frame Size</b>: " + size +
                "<br> <b>Color IN</b>: " + color_In +
                "<br> <b>Color OUT</b>: " + color_Out +
                "<br> <b>Date and Time</b>: " + date_time +
                "<br> <b>Name</b>: " + name +
                "<br> <b>Reason</b>: " + reason;

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
        private int Create_File(string[] framecutting)
        {

            int count = 0;
            Boolean AddFirstLetter = false, scsProp = false, ucsProp = false;

            string FirstLetter = "", type = "", strSeperator = ",", frow, srow;
            string[] framecutting_Original = new string[framecutting.Length];
            framecutting.CopyTo(framecutting_Original, 0);
            StringBuilder sbOutput = new StringBuilder();
            string[] FrameRecutCounting = DB.getFrameRecutCounting();

            if (FrameRecutCounting == null)
            {
                count = 1;

                DB.insertFrameRecutCounting();
            }
            else
            {
                count = Int32.Parse(FrameRecutCounting[2]) + 1;
                DB.updateFrameRecutCounting(count);

            }

            string[] Frame_Recut_File_Naming_Table = Settings.Frame_Recut_File_Naming_Table.Find(x => x[2] == framecutting[8]);

            if (Frame_Recut_File_Naming_Table != null)
            {
                if (Frame_Recut_File_Naming_Table[3] == "1" || Frame_Recut_File_Naming_Table[3] == "0")
                    AddFirstLetter = Convert.ToBoolean(Int32.Parse(Frame_Recut_File_Naming_Table[3]));
                else AddFirstLetter = Convert.ToBoolean(Frame_Recut_File_Naming_Table[3]);
                type = Frame_Recut_File_Naming_Table[1];

                if (Frame_Recut_File_Naming_Table[6] == "1" || Frame_Recut_File_Naming_Table[6] == "0")
                    scsProp = Convert.ToBoolean(Int32.Parse(Frame_Recut_File_Naming_Table[6]));
                else scsProp = Convert.ToBoolean(Frame_Recut_File_Naming_Table[6]);

                if (Frame_Recut_File_Naming_Table[5] == "1" || Frame_Recut_File_Naming_Table[5] == "0")
                    ucsProp = Convert.ToBoolean(Int32.Parse(Frame_Recut_File_Naming_Table[5]));
                else ucsProp = Convert.ToBoolean(Frame_Recut_File_Naming_Table[5]);
            }
            if (AddFirstLetter) FirstLetter = framecutting[20].Substring(0, 1) + "_";

            string fileName = Properties.Settings.Default.FrameRecutPath + @"\" + FirstLetter + type + DateTime.Today.ToString("yyyy-MM-dd") + "_" + count + ".csv";
           
            if (scsProp)
            {
                frow = framecutting[1].Substring(0, framecutting[1].IndexOf('/'));
                srow = framecutting[1].Substring(framecutting[1].IndexOf('/') + 1, framecutting[1].Length - framecutting[1].IndexOf('/') - 1);
                framecutting[framecutting.Length - 2] = framecutting[2];
                framecutting[framecutting.Length - 1] = framecutting[3];
                string colF = framecutting[6];
                framecutting[6] = framecutting[framecutting.Length - 3];
                framecutting[framecutting.Length - 3] = colF;
                framecutting[11] = "RECUT-" + DateTime.Now.ToString("MM-dd");
                framecutting = framecutting.Skip(4).ToArray();
                framecutting[5] = "0";
                sbOutput.AppendLine(frow + strSeperator + "1" + strSeperator + "0" + strSeperator + string.Join(strSeperator, framecutting));
                framecutting[5] = "1";
                sbOutput.AppendLine(srow + strSeperator + "1" + strSeperator + "0" + strSeperator + string.Join(strSeperator, framecutting));
              
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, sbOutput.ToString());
            }
            if (ucsProp)
            {
                sbOutput = new StringBuilder();
                framecutting = new string[framecutting_Original.Length];
                framecutting_Original.CopyTo(framecutting, 0);
                fileName = Properties.Settings.Default.FrameRecutPath + @"\" + FirstLetter + type + "UCS_" + DateTime.Today.ToString("yyyy-MM-dd") + "_" + count + ".csv";
                frow = framecutting[1].Substring(0, framecutting[1].IndexOf('/'));
                srow = framecutting[1].Substring(framecutting[1].IndexOf('/') + 1, framecutting[1].Length - framecutting[1].IndexOf('/') - 1);
                Array.Resize(ref framecutting, framecutting.Length + 2);
                string colF = framecutting[6];
                framecutting[6] = framecutting[framecutting.Length - 5];
                framecutting[framecutting.Length - 2] = framecutting[2];
                framecutting[framecutting.Length - 1] = framecutting[3];

                for (int i = 20; i >= 13; i--)
                    framecutting[i] = framecutting[i - 2];

                framecutting[12] = framecutting[10];
                framecutting[9] = Frame_Recut_File_Naming_Table[4];
                framecutting[10] = "WH";
                framecutting[11] = "0";
                framecutting[framecutting.Length - 3] = colF;
                framecutting[13] = "RECUT-" + DateTime.Now.ToString("MM-dd");
                
                framecutting = framecutting.Skip(4).ToArray();
                sbOutput.AppendLine(frow + strSeperator + "1" + strSeperator + "0" + strSeperator + string.Join(strSeperator, framecutting));
                framecutting[7] = "1";
                sbOutput.AppendLine(srow + strSeperator + "1" + strSeperator + "0" + strSeperator + string.Join(strSeperator, framecutting));
                
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, sbOutput.ToString());
            }

            return 0;

        }
        private void Scan_timer_Tick(object sender, EventArgs e)
        {
            if (timers.Count != 0)
            {
                string[] arr = ((IEnumerable)timers[0].Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
                string ord_numb = arr[0];
                string name = arr[1];

                for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                {
                    if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ord_numb && OrderScanedData.Rows[i].Cells[2].Value.ToString() == name)
                        OrderScanedData.Rows.RemoveAt(i);
                }
                timers[0].Enabled = false;
                timers.RemoveAt(0);
            }
        }
        private void iShippingTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = iWrappingTxtDataInput.Text;
            UInt64 number;

        }

      

        private void OrderScanedData_SelectionChanged(object sender, EventArgs e)
        {
            this.OrderScanedData.ClearSelection();
        }

       





    }
}
