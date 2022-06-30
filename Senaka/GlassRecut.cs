
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
    public partial class GlassRecut : Form
    {
        
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();

        public GlassRecut()
        {
            InitializeComponent();

            MinimumSize = new Size(800, 600);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            if (Properties.Settings.Default.GlassRecutPath == "" || Properties.Settings.Default.GlassRecutPath == null)
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
                    if (Settings.GlassRecut_Obligatory_Name_boolean == "True" && textBoxName.Text == "")
                        error_text = "Please complete name";
                    else if (Settings.GlassRecut_Obligatory_Reason_boolean == "True" && textBoxReason.Text == "")
                        error_text = "Please complete reason";
                    else
                        scanInput(data, textBoxName.Text, textBoxReason.Text);
                }
            }
            GlassLblMessage.Text += error_text;

        }
        private void scanInput(string data, string name, string reason)
        {

            string[] framereport_data, type_data;

            string su_id = data;
            string error_text = null;



            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");

            int glassqtyTotal = 0;
            string[] glassreport = DB.fetchRow("glassreport", "sealed_unit_id", su_id);
            List<string[]> GlassRecut = new List<string[]>();
            if (glassreport != null)
            {

                GlassRecut = DB.fetchRows("GlassRecut", "sealed_unit_id", su_id);
               
                    List<string[]> ig_sortings = DB.fetchRows("ig_sorting", "sealed_unit_id", su_id);
                    int scanned_qty = ig_sortings.Count;
                int qty = Convert.ToInt32(glassreport[(int)GLASS.QTY+1]);
                if (scanned_qty >= 1)
                    {
                        int glassqty = 0;
                        bool exist = false, existInDatabase = false;
                        int r = 0;
                        string ordNumb = glassreport[20];
                        string glassType = glassreport[19];
                        string glassThickness = glassreport[4];
                        string size = "Width= " + glassreport[21] + " Height= " + glassreport[22];
                        for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                            if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ordNumb && OrderScanedData.Rows[i].Cells[1].Value.ToString() == glassType && OrderScanedData.Rows[i].Cells[2].Value.ToString() == glassThickness)
                            {
                                r = i;
                                exist = true;

                                glassqty = Int32.Parse(OrderScanedData.Rows[i].Cells[3].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[3].Value.ToString().IndexOf('/')));

                            }

                        List<string[]> GlassReporData = DB.getGlassReportByTTO(glassThickness, ordNumb, glassType);
                        try
                        {
                            foreach (var item in GlassReporData)
                                glassqtyTotal += Int32.Parse(item[23]);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message + Environment.NewLine + "In the qty column in workorder it is text");
                            return;
                        }


                        if (!exist)
                        {
                            List<string[]> glassRecut = DB.fetchRows("GlassRecut", "Order_number", ordNumb);
                            glassqty = glassRecut.Count;
                        }
                        glassqty++;
                        if (!exist)
                        {
                            if (DB.saveGlassRecutData(su_id, date, time, ordNumb, name, reason) == 0)
                            {
                                OrderScanedData.Rows.Add(ordNumb, glassType, glassThickness, glassqty + "/" + glassqtyTotal);
                                if (glassqty == glassqtyTotal && glassqtyTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[3].Style.BackColor = Color.Lime;
                                foreach (string[] item in Settings.Receiving_Emails_Table)
                                    if (item[2].Contains("GlassRecut"))
                                    {
                                        SendMail(item[1], ordNumb, glassType, size, glassThickness, name, reason);
                                    }
                            }
                        }
                        else
                        {
                            if (DB.saveGlassRecutData(su_id, date, time, ordNumb, name, reason) == 0)
                            {

                                OrderScanedData.Rows[r].Cells[1].Value = glassqty + "/" + glassqtyTotal;

                                if (glassqty == glassqtyTotal && glassqtyTotal != 0)
                                    OrderScanedData.Rows[r].Cells[3].Style.BackColor = Color.Lime;

                                foreach (string[] item in Settings.Receiving_Emails_Table)
                                    if (item[2].Contains("GlassRecut"))
                                    {
                                        SendMail(item[1], ordNumb, glassType, size, glassThickness, name, reason);
                                    }

                            }
                        }
                        DB.deleteIgSorting(su_id);
                        DB.UpdateDealerGlassReport(glassreport[0]);
                        Create_File(glassreport);
                        DB.updateRow("glassreport", "sealed_unit_id", su_id, "complete", "");

                        iShippingScanedData.Rows.Add(su_id, date, time, name);
                        GlassLblNumber.Text = (Int32.Parse(GlassLblNumber.Text) + 1).ToString();

                    }
                    else
                    {
                        // WindowsLblRackID.Text = "ERROR";
                        error_text = "LINE NUMBER IN IG SORTING IS NOT COMPLETE!";
                    }
               
            }



            else
            {
                // WindowsLblRackID.Text = "ERROR";
                error_text = "INVALID LINE NUMBER!";
            }



            iWrappingTxtDataInput.Text = null;

            GlassLblMessage.Text = error_text;


            //    if(error_text!=null)  error_message.Show(error_text, "Error");
        }
        private void SendMail(string address, string order, string glass_type, string size, string OT, string name, string reason)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(Settings.sender_email);

            message.To.Add(new MailAddress(address));

            message.Subject = "Glass type: " + glass_type;




            string body = "<b>Order Number</b>: " + order +
                "<br> <b>Glass type</b>: " + glass_type +
                "<br> <b>Size</b>: " + size +
                "<br> <b>OT</b>: " + OT +
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
      
        public  string StringToLength(string value, int maxChars)
        {
            if (value.Length < maxChars)
                return value += new string(' ', maxChars - value.Length);
            else
                return value?.Substring(0, Math.Min(value.Length, maxChars));
        }
        private int Create_File(string[] glassreport)
        {
            int count = 0;
            string[] GlassRecutCounting = DB.getGlassRecutCounting();
            if (GlassRecutCounting == null)
            {
                count = 1;

                DB.insertGlassRecutCounting();
            }
            else
            {
                count = Int32.Parse(GlassRecutCounting[2]) + 1;
                DB.updateGlassRecutCounting(count);

            }
            string fileName = Properties.Settings.Default.GlassRecutPath + @"\" + DateTime.Today.ToString("MMMdd") + "_" + count + ".asc";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();

                    byte[] newline = encoding.GetBytes(Environment.NewLine);

                  
                    string title = "Orders sent to Opty-way on";
                    string date = DateTime.Today.ToString("ddMMyyyy");
                    string version = "V4";
                    string numb = "1";
                    string material = glassreport[19];
                    string customer = "1" + glassreport[11];
                    string order = glassreport[20];
                    string tag = glassreport[13];
                    string default_string = "1Y00000001  9999.0";
                    string width = glassreport[21];
                    string height = glassreport[22];
                    //  1
                    string list_date = DateTime.Parse(glassreport[2]).ToString("ddMMyyyy");
                    string line2 = glassreport[7];
                    string glass_comment = glassreport[12];
                    string ot = glassreport[4];
                    string window_type = glassreport[5];
                    string spacer = glassreport[10];
                    string line1 = glassreport[6];
                    string grills = glassreport[9];
                    string recut_date = "RECUT-" + DateTime.Now.ToString("yyyy-MM-dd");
                    string sealed_unit_id = glassreport[3];
                    string zones = glassreport[14];
                    string u_value = glassreport[15];
                    string solar_heat_gain = glassreport[16];
                    string visual_trasmittance = glassreport[17];
                    string energy_rating = glassreport[18];
                    string line3 = glassreport[8];

                    var first_line_list = new List<KeyValuePair<string, int>>() {
                        new KeyValuePair<string, int>(title, 0),
                        new KeyValuePair<string, int>(date, 32),
                        new KeyValuePair<string, int>(version, 56),

                    };

                    var third_line_list = new List<KeyValuePair<string, int>>() {
                        new KeyValuePair<string, int>(material, 0),
                        new KeyValuePair<string, int>(customer, 20),
                        new KeyValuePair<string, int>(order, 34),
                        new KeyValuePair<string, int>(default_string, 63),
                        new KeyValuePair<string, int>(width, 82),
                        new KeyValuePair<string, int>(height, 90),
                        new KeyValuePair<string, int>(numb, 151),
                        new KeyValuePair<string, int>(list_date, 158),
                        new KeyValuePair<string, int>(line2, 178),
                        new KeyValuePair<string, int>(tag, 209),
                        new KeyValuePair<string, int>(ot, 273),
                        new KeyValuePair<string, int>(window_type, 305),
                        new KeyValuePair<string, int>(spacer, 337),
                        new KeyValuePair<string, int>(line1, 369),
                        new KeyValuePair<string, int>(grills, 401),
                        new KeyValuePair<string, int>(recut_date, 433),
                        new KeyValuePair<string, int>(sealed_unit_id, 467),
                        new KeyValuePair<string, int>(zones, 537),
                        new KeyValuePair<string, int>(u_value, 569),
                        new KeyValuePair<string, int>(solar_heat_gain, 602),
                        new KeyValuePair<string, int>(visual_trasmittance, 634),
                        new KeyValuePair<string, int>(energy_rating, 665),
                        new KeyValuePair<string, int>(line3, 698),
                        new KeyValuePair<string, int>(glass_comment, 730),
                        new KeyValuePair<string, int>(date, 913),

                    };

                    int maxLength = 0;
                    for (int i = 0; i < first_line_list.Count; i++)
                    {
                        if (i == first_line_list.Count - 1) maxLength = 15;
                        else maxLength = first_line_list[i + 1].Value - first_line_list[i].Value;
                        stream.Position = first_line_list[i].Value;
                        stream.Write(encoding.GetBytes(StringToLength(first_line_list[i].Key, maxLength-1)+" "), 0, maxLength);
                     
                    }
                   
                    stream.Write(newline, 0, newline.Length);
                    stream.Write(encoding.GetBytes("      "+numb.ToString()),0,7);
                    stream.Write(newline, 0, newline.Length);

                    long linepos = stream.Position;
                    for (int i = 0; i < third_line_list.Count; i++)
                    {
                        if (i == third_line_list.Count - 1) maxLength = 15;
                        else maxLength = third_line_list[i + 1].Value - third_line_list[i].Value;
                        stream.Position = linepos+ third_line_list[i].Value;
                        string text = StringToLength(third_line_list[i].Key, maxLength - 1) + " ";
                        stream.Write(encoding.GetBytes(text), 0, maxLength);
                    }
                }
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
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
