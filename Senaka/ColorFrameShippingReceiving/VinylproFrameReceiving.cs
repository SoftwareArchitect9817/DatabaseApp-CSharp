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
    public partial class VinylproFrameReceiving : Form
    {
        
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        List<System.Windows.Forms.DataGridView> dataGridViews = new List<System.Windows.Forms.DataGridView>();
        int scaned_number=0;
        public class Data_order
        {
            public Data_order(string order_number, int cs_f, int cs_s, int s_f, int l_f, int sl_f, int sl_s, int bmd, int bmd_done, int cs_f_done, int cs_s_done, int s_f_done, int l_f_done, int sl_f_done, int sl_s_done, string bmd_info, string cs_f_info, string cs_s_info, string s_f_info, string l_f_info, string sl_f_info, string sl_s_info)
             {

                Order_numb = order_number;
                Cs_F = cs_f;
                Cs_S = cs_s;
                S_F = s_f;
                L_F = l_f;
                Sl_F = sl_f;
                Sl_S = sl_s;
                Bmd = bmd;
                Cs_F_done = cs_f_done;
                Cs_S_done = cs_s_done;
                S_F_done = s_f_done;
                L_F_done = l_f_done;
                Sl_F_done = sl_f_done;
                Sl_S_done = sl_s_done;
                Bmd_done = bmd_done;


                Cs_F_info = cs_f_info;
                Cs_S_info = cs_s_info;
                S_F_info = s_f_info;
                L_F_info = l_f_info;
                Sl_F_info = sl_f_info;
                Sl_S_info = sl_s_info;
                Bmd_info = bmd_info;
            }
            public string Status { get; set; }
            public string Order_numb { get; set; }
            public int Cs_F { get; set; }
            public int Cs_S { get; set; }
            public int S_F { get; set; }
            public int L_F { get; set; }
            public int Sl_F { get; set; }
            public int Sl_S { get; set; }
            public int Bmd { get; set; }
            public int Bmd_done { get; set; }
            public int Cs_F_done { get; set; }
            public int Cs_S_done { get; set; }
            public int S_F_done { get; set; }
            public int L_F_done { get; set; }
            public int Sl_F_done { get; set; }
            public int Sl_S_done { get; set; }
            public string Bmd_info { get; set; }
            public string Cs_F_info { get; set; }
            public string Cs_S_info { get; set; }
            public string S_F_info { get; set; }
            public string L_F_info { get; set; }
            public string Sl_F_info { get; set; }
            public string Sl_S_info { get; set; }

        }

        public class Data_grid
        {
            public Data_grid(string order_number, string bmd_info, string cs_f_info, string cs_s_info, string s_f_info, string l_f_info, string sl_f_info, string sl_s_info)
            {

                Order_numb = order_number;
               


                Cs_F_info = cs_f_info;
                Cs_S_info = cs_s_info;
                S_F_info = s_f_info;
                L_F_info = l_f_info;
                Sl_F_info = sl_f_info;
                Sl_S_info = sl_s_info;
                Bmd_info = bmd_info;
            }
           
            public string Order_numb { get; set; }
           
            public string Bmd_info { get; set; }
            public string Cs_F_info { get; set; }
            public string Cs_S_info { get; set; }
            public string S_F_info { get; set; }
            public string L_F_info { get; set; }
            public string Sl_F_info { get; set; }
            public string Sl_S_info { get; set; }

        }
        List<Data_order> list = new List<Data_order>();
        int cs_f_total = 0, cs_s_total = 0, s_f_total = 0, l_f_total = 0, sl_f_total = 0, sl_s_total = 0, bmd_total = 0;
        public VinylproFrameReceiving()
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iShippingDate.Text = date;
            iShippingTime.Text = today.ToString("HH:mm:ss");

            error_timer = new Timer();
            error_timer.Interval = Settings.ExpressCoating_Color_Receiving_Error_Time * 1000;
            error_timer.Tick += Error_timer_Tick;

             error_message = new MessageBoxDialog();
          
            OrderScanedData.AutoGenerateColumns = false;
            OrderScanedData2.AutoGenerateColumns = false;
        }
        private void WindowsAssembly_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            error_timer.Stop();

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
            if (e.KeyCode == Keys.Enter)
            {
                string data = ColourTxtDataInput.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }
        private void scanInput(string data)
        {
            bool exist_prefix = false;
            string[] prefix_data = null, frame_cutting_data;
            int i;
            string prefix = data.Substring(0, 1);
            string id = data.Substring(1);
         
            string error_text=null;
         
            foreach (string[] r in Settings.VinylPro_Frame_Receiving_Prefix_Table)
            {
               
                  if (r[(int)PREFIX.PREFIX] == prefix)
                  {
                      exist_prefix = true;
                      prefix_data = r;
                      break;
                  }
              }
            DateTime now = DateTime.Now;
            if (exist_prefix)
            {
                string name = prefix_data[3], batch_number = textBoxBatchNumber.Text, date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
                frame_cutting_data = DB.fetchRow("framescutting", "F", id, false);
                if (frame_cutting_data != null)
                {

                    List<string[]> dvcoatex_shipping = DB.fetchRows("VinylProFrameReceiving", "line", id);
                    int scanned_qty = dvcoatex_shipping.Count;
                    if (scanned_qty < 1)
                    {
                        if (frame_cutting_data[16] == "WHT" && frame_cutting_data[17] == "WHT")
                        {
                            //   string rack_id = frame_cutting_data[(int)GLASS.RACK_ID];
                            if (DB.saveVinylProFrameReceivingData(id, date, time, name, batch_number) == 0)
                            {
                                bool exists = false;

                                for (int j = 0; j < list.Count; j++)
                                {
                                    if (list[j].Order_numb == frame_cutting_data[9])
                                    {
                                        if (Settings.Brickmould.Any(type => type[2].Equals(frame_cutting_data[7].ToString(), StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            //   list[j].Bmd += 1;
                                            //  list[j].Bmd_done += count;
                                            //    category = "Brickmould";
                                            list[j].Bmd_done += 1;
                                            list[j].Bmd_info = list[j].Bmd_done + "/" + list[j].Bmd;
                                            bmd_total += 1;
                                            //   list_type.Add(new List_order_type(list[j].Order_numb, cs_f, cs_s, fx_f, sl_f, sl_s, bmd, count));
                                        }
                                        else if (Settings.Casement_Frame.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            list[j].Cs_F_done += 1;
                                            list[j].Cs_F_info = list[j].Cs_F_done + "/" + list[j].Cs_F;
                                            cs_f_total += 1;
                                        }
                                        else if (Settings.Casement_Sash.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            list[j].Cs_S_done += 1;
                                            list[j].Cs_S_info = list[j].Cs_S_done + "/" + list[j].Cs_S;
                                            cs_s_total += 1;
                                        }
                                        else if (Settings.Slider_Frame.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            list[j].Sl_F_done += 1;
                                            list[j].Sl_F_info = list[j].Sl_F_done + "/" + list[j].Sl_F;
                                            sl_f_total += 1;
                                        }
                                        else if (Settings.Slider_sash.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            list[j].Sl_S_done += 1;
                                            list[j].Sl_S_info = list[j].Sl_S_done + "/" + list[j].Sl_S;
                                            sl_s_total += 1;
                                        }
                                        else if (Settings.Small_Fix.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            list[j].S_F_done += 1;
                                            list[j].S_F_info = list[j].S_F_done + "/" + list[j].S_F;
                                            s_f_total += 1;
                                        }
                                        else if (Settings.Large_Fix.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            list[j].L_F_done += 1;
                                            list[j].L_F_info = list[j].L_F_done + "/" + list[j].L_F;
                                            l_f_total += 1;
                                        }


                                        exists = true;
                                    }

                                }
                                if (!exists)
                                {
                                    int cs_f = 0, cs_s = 0, s_f = 0, l_f = 0, sl_f = 0, sl_s = 0, bmd = 0, bmd_done = 0, cs_f_done = 0, cs_s_done = 0, s_f_done = 0, l_f_done = 0, sl_f_done = 0, sl_s_done = 0;
                                    List<string[]> frame_cutting_order_data = DB.fetchRows("framescutting", "J", frame_cutting_data[9], false);
                                    for (int j = 0; j < frame_cutting_order_data.Count; j++)
                                    {
                                        if (Settings.Brickmould.Any(type => type[2].Equals(frame_cutting_order_data[j][7].ToString(), StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            //   list[j].Bmd += 1;
                                            //  list[j].Bmd_done += count;
                                            //    category = "Brickmould";
                                            bmd += 1;

                                            //   list_type.Add(new List_order_type(list[j].Order_numb, cs_f, cs_s, fx_f, sl_f, sl_s, bmd, count));
                                        }
                                        else if (Settings.Casement_Frame.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            cs_f += 1;

                                        }
                                        else if (Settings.Casement_Sash.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            cs_s += 1;

                                        }
                                        else if (Settings.Slider_Frame.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            sl_f += 1;

                                        }
                                        else if (Settings.Slider_sash.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {

                                            sl_s += 1;

                                        }
                                        else if (Settings.Small_Fix.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            s_f += 1;

                                        }
                                        else if (Settings.Large_Fix.Any(type => type[2].Equals(frame_cutting_order_data[j][7], StringComparison.InvariantCultureIgnoreCase)))
                                        {
                                            l_f += 1;

                                        }
                                    }
                                    if (Settings.Brickmould.Any(type => type[2].Equals(frame_cutting_data[7].ToString(), StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        //   list[j].Bmd += 1;
                                        //  list[j].Bmd_done += count;
                                        //    category = "Brickmould";
                                        bmd_done += 1;
                                        bmd_total += 1;
                                        //   list_type.Add(new List_order_type(list[j].Order_numb, cs_f, cs_s, fx_f, sl_f, sl_s, bmd, count));
                                    }
                                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {

                                        cs_f_done += 1;
                                        cs_f_total += 1;
                                    }
                                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {

                                        cs_s_done += 1;
                                        cs_s_total += 1;
                                    }
                                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        sl_f_done += 1;
                                        sl_f_total += 1;
                                    }
                                    else if (Settings.Slider_sash.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {

                                        sl_s_done += 1;
                                        sl_s_total += 1;
                                    }
                                    else if (Settings.Small_Fix.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        s_f_done += 1;
                                        s_f_total += 1;
                                    }
                                    else if (Settings.Large_Fix.Any(type => type[2].Equals(frame_cutting_data[7], StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        l_f_done += 1;
                                        l_f_total += 1;
                                    }
                                    //   for (int k = 0; k < 30; k++)
                                    list.Add(new Data_order(frame_cutting_data[9], cs_f, cs_s, s_f, l_f, sl_f, sl_s, bmd, bmd_done, cs_f_done, cs_s_done, s_f_done, l_f_done, sl_f_done, sl_s_done, bmd_done + "/" + bmd, cs_f_done + "/" + cs_f, cs_s_done + "/" + cs_s, s_f_done + "/" + s_f, l_f_done + "/" + l_f, sl_f_done + "/" + sl_f, sl_s_done + "/" + sl_s));
                                    //  list.Add(new Data_order(k.ToString(), cs_f, cs_s, fx_f, sl_f, sl_s, bmd, bmd_done, cs_f_done, cs_s_done, fx_f_done, sl_f_done, sl_s_done, bmd_done + "/" + bmd, cs_f_done + "/" + cs_f, cs_s_done + "/" + cs_s, fx_f_done + "/" + fx_f, sl_f_done + "/" + sl_f, sl_s_done + "/" + sl_s));

                                    exists = true;

                                }

                                exists = false;
                                ScanedData.Rows.Insert(0, id, date, time, name, batch_number);


                                List<Data_order> list_grid = new List<Data_order>();

                                List<Data_order> list_grid2 = new List<Data_order>();
                                for (int k = 0; k < list.Count; k++)
                                {
                                    if (k < 30)

                                        list_grid.Add(list[k]);


                                    else if (k >= 30)

                                        list_grid2.Add(list[k]);


                                }
                                OrderScanedData.DataSource = list_grid;
                                OrderScanedData2.DataSource = list_grid2;
                                for (int k = 0; k < list.Count; k++)
                                {
                                    if (k < 30)
                                    {
                                        list_grid.Add(list[k]);
                                        if ((list[k].Bmd_done + list[k].Cs_F_done + list[k].Cs_S_done + list[k].S_F_done + list[k].L_F_done + list[k].Sl_F_done + list[k].Sl_S_done) >= (list[k].Bmd + list[k].Cs_F + list[k].Cs_S + list[k].S_F + list[k].L_F + list[k].Sl_F + list[k].Sl_S)) OrderScanedData.Rows[k].Cells[0].Style.BackColor = Color.Lime;
                                    }

                                    else if (k >= 30)
                                    {
                                        list_grid2.Add(list[k]);
                                        if ((list[k].Bmd_done + list[k].Cs_F_done + list[k].Cs_S_done + list[k].S_F_done + list[k].L_F_done + list[k].Sl_F_done + list[k].Sl_S_done) >= (list[k].Bmd + list[k].Cs_F + list[k].Cs_S + list[k].S_F + list[k].L_F + list[k].Sl_F + list[k].Sl_S)) OrderScanedData2.Rows[30 - k].Cells[0].Style.BackColor = Color.Lime;

                                    }
                                }
                                if (list_grid2.Count != 0)
                                    OrderScanedData2.Visible = true;

                                scaned_number++;

                                total_frames_data.Text = scaned_number.ToString();
                                cs_f_data.Text = cs_f_total.ToString();
                                cs_s_data.Text = cs_s_total.ToString();
                                sl_f_data.Text = sl_f_total.ToString();
                                sl_s_data.Text = sl_s_total.ToString();
                                bmd_data.Text = bmd_total.ToString();
                                s_f_data.Text = s_f_total.ToString();
                                l_f_data.Text = l_f_total.ToString();

                                string order, profile_type, window_type, size, colorIn, colorOut;
                                List<string[]> frame_recut = DB.getIncompleteFrameRecut(id);
                                if (frame_recut.Count != 0)
                                {
                                    string recutName = frame_recut[frame_recut.Count - 1][4];
                                    string recutReason = frame_recut[frame_recut.Count - 1][5];

                                    foreach (string[] item in Settings.Receiving_Emails_Table)
                                        if (item[2].Contains("VinylProFrameReceiving"))
                                        {
                                            order = frame_cutting_data[9];
                                            profile_type = frame_cutting_data[7];
                                            window_type = frame_cutting_data[11];
                                            size = frame_cutting_data[0];
                                            colorIn = frame_cutting_data[16];
                                            colorOut = frame_cutting_data[17];
                                            SendMail(item[1], order, profile_type, window_type, size, colorIn, colorOut, recutName, recutReason);
                                        }
                                }
                                DB.UpdateFrameRecut(id);
                            }
                        
                        else
                        {
                            //iSortLblRackID.Text = "ERROR";
                            error_text = "CANNOT SAVE DATA. PLEASE TRY AGAIN";
                        }
                    }

                    else
                    {
                        //iSortLblRackID.Text = "ERROR";
                        error_text = "IT IS COLOUR!";
                    }
                }
                    else
                    {
                        // iSortLblRackID.Text = "ERROR";
                        error_text = "ALREADY SCANNED ALL QUANTITIES";

                    }
                }
                else
                {
                    //  iSortLblRackID.Text = "ERROR";
                    error_text = "INVALID FRAME ID";
                }
            }
            else
            {
                // iSortLblRackID.Text = "ERROR";
                error_text = "INVALID PREFIX LETTER";
            }
           
            ColourTxtDataInput.Text = null;
            ColourlblMessage.Text = error_text;
          
        }
        private void SendMail(string address, string order, string profile_type, string window_type, string size, string colorIn, string colorOut, string name, string reason)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(Settings.sender_email);

            message.To.Add(new MailAddress(address));

            message.Subject = order + " - " + profile_type + " Vinyl Pro Received";




            string body = "<b>Window typw</b>: " + window_type +
                "<br><b>Size</b>: " + size +
                "<br><b>Colour in</b>: " + colorIn +
                "<br><b>Colour out</b>: " + colorOut +
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
        private void iShippingTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = ColourTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar)) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                ColourTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-'))
                                )
                            ) ||
                            (ColourTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-') && !char.IsLetter(e.KeyChar))
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

        private void iShippingMiddlePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iShippingTxtDataInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void iShippingScanedData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iShippingTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iShippingMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderScanedData_SelectionChanged(object sender, EventArgs e)
        {
            this.OrderScanedData2.ClearSelection();
        }

        private void OrderScanedData_SelectionChanged_1(object sender, EventArgs e)
        {
            this.OrderScanedData.ClearSelection();
        }

        private void textBoxBatchNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBatchNumber.Text != "")
                ColourTxtDataInput.Enabled = true;
            else
                ColourTxtDataInput.Enabled = false;
        }

        private void iSortLblMessage_Click(object sender, EventArgs e)
        {

        }

        private void iSortLblMessage_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrefixQtyData_SelectionChanged(object sender, EventArgs e)
        {
          //  this.PrefixQtyData.ClearSelection();
        }

        private void WindowsAssebly_Load(object sender, EventArgs e)
        {

        }

      
    }
}
