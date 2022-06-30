﻿using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class FrameClearingForm : Form
    {
        private int scaned_number;
        private DateTime start_time, end_time;
     List<System.Windows.Forms.DataGridView> dataGridViews = new List<System.Windows.Forms.DataGridView>();
        List<string[]> names= new List<string[]>();
        List<string[]> namesqty = new List<string[]>();
        List<string> names_prefix = new List<string>();
        int numb = 0;
        Timer timer, scan_timer;
        public FrameClearingForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();
            string start_date = Settings.Selected_Date[0].ToString("yyyy/MM/dd");
            string end_date = Settings.Selected_Date[1].ToString("yyyy/MM/dd");
            //   if (start_date != end_date) iSortLblListDateValue.Text = start_date + " - " + end_date;
            /*    if(Settings.Frame_Clearing_Scanned != null)
                for (int i = 0; i < Settings.Frame_Clearing_Scanned.Count; i++)
                 {
                     iSortHistoryData.Rows.Add(Settings.Frame_Clearing_Scanned[i][0], Settings.Frame_Clearing_Scanned[i][1], Settings.Frame_Clearing_Scanned[i][2]);

                 }*/

            start_time = DateTime.Now;
            scan_timer = new Timer();
           
           scan_timer.Interval = Settings.Frame_Clearing_Scan_Interval * 60 * 1000;
          //  scan_timer.Interval = 30000;
           scan_timer.Tick += Scan_timer_Tick;
            scan_timer.Start();

            PrefixLayoutPanel.HorizontalScroll.Maximum = 0;
            PrefixLayoutPanel.AutoScroll = false;
            PrefixLayoutPanel.VerticalScroll.Enabled = false;
            PrefixLayoutPanel.VerticalScroll.Visible = false;
            PrefixLayoutPanel.AutoScroll = true;
     


        }
        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iSortDate.Text = today.ToString("yyyy-MM-dd");
            iSortTime.Text = today.ToString("HH:mm:ss");
        }
        private void FrameClearing_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            scan_timer.Stop();
           //F error_timer.Stop();

            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void iFrameTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = iFrameTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar) && !e.KeyChar.Equals('_')) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                iFrameTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('_'))
                                )
                            ) ||
                            (iFrameTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('_') && !char.IsLetter(e.KeyChar))
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
        private void scanInput(string data)
        {
            bool exist_prefix = false;
            string[] prefix_data = null, frame_cutting_data;

            string prefix = data.Substring(0, 1);
            string id = data.Substring(1);
            string error_text = "";
            start_time = DateTime.Now;
            end_time = start_time.AddMinutes(Settings.Frame_Clearing_Scan_Interval);
            foreach (string[] r in Settings.Frame_Clearing_Prefix_Table)
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
                string name = prefix_data[(int)PREFIX.NAME], machineid = prefix_data[4], date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
                frame_cutting_data = DB.fetchRow("framescutting", "F", id, false);
                if (frame_cutting_data != null)
                {
                   
                    List<string[]> frame_clearings = DB.fetchRows("FrameClearing", "id", id);
                    int scanned_qty = frame_clearings.Count;
                    if (scanned_qty < 1)
                    {
                     //   string rack_id = frame_cutting_data[(int)GLASS.RACK_ID];
                        if (DB.saveFrameClearingData(id, date, time, name) == 0)
                        {
                            bool exists = false;
                         
                            for (int j = 0; j < names_prefix.Count; j++)
                            {
                                if (names_prefix[j] == name)
                                {
                                    PrefixQtyData.Rows[j].Cells[1].Value = (Int32.Parse(PrefixQtyData.Rows[j].Cells[1].Value.ToString()) + 1).ToString();


                                    exists = true;
                                }

                            }
                            if (!exists)
                            {
                                PrefixQtyData.Rows.Add(name, "1");
                               
                                    CreateGrid(numb, name);
                                numb++;
                                names_prefix.Add(name);


                                exists = true;

                            }
                            exists = false;
                            FrameClearingData.Rows.Insert(0, id, date, time, name, machineid);
                            if (names.Count != 0)
                            {
                               
                                for (var i = 0; i < names.Count(); i++)
                                    if (names[i][0] == name)
                                    {
                                        names[i][1] = (Int32.Parse(names[i][1]) + 1).ToString();
                                        for (int j = 0; j < names_prefix.Count; j++)
                                        {
                                            if (names_prefix[j] == name)
                                            {
                                                dataGridViews[j].Rows[dataGridViews[j].RowCount-2].Cells[1].Value= (Int32.Parse(dataGridViews[j].Rows[dataGridViews[j].RowCount - 2].Cells[1].Value.ToString()) + 1).ToString();
                                                exists = true;
                                            }

                                        }
                                        exists = true;
                                        break;
                                    }
                                if (!exists)
                                {

                                    List<string> namesdata = new List<string>();
                                    namesdata.Add(name);
                                    namesdata.Add("1");
                                    names.Add(namesdata.ToArray());
                                    for (int j = 0; j < names_prefix.Count; j++)
                                    {
                                      
                                            if (names_prefix[j] == name)
                                            {

                                                dataGridViews[j].Rows.Add(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"), "1");
                                                exists = true;
                                            }
                                    

                                    }
                                }
                               
                            }
                            else
                            {
                             
                                List<string> namesdata = new List<string>();
                                namesdata.Add(name);
                                namesdata.Add("1");
                                names.Add(namesdata.ToArray());
                                for (int j = 0; j < names_prefix.Count; j++)
                                {
                                 
                                        if (names_prefix[j] == name)
                                        {

                                            dataGridViews[j].Rows.Add(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"), "1");
                                            exists = true;
                                        
                                    }

                                }
                            }
                            string order, profile_type, window_type, size, colorIn, colorOut;
                            scaned_number++;
                            List<string[]> frame_recut = DB.getIncompleteFrameRecut(id);
                            if (frame_recut.Count != 0)
                            {
                                string recutName = frame_recut[frame_recut.Count - 1][4];
                                string recutReason = frame_recut[frame_recut.Count - 1][5];

                                foreach (string[] item in Settings.Receiving_Emails_Table)
                                    if (item[2].Contains("FrameClearing"))
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
                       // iSortLblRackID.Text = "ERROR";
                        error_text = "ALREADY SCANNED ALL QUANTITIES";

                    }
                }
                else
                {
                  //  iSortLblRackID.Text = "ERROR";
                    error_text = "INVALID SEALED UNIT ID";
                }
            }
            else
            {
               // iSortLblRackID.Text = "ERROR";
                error_text = "INVALID PREFIX LETTER";
            }
            //error_timer.Start();
            iFrameTxtDataInput.Text=null;
            iFrameClearingblMessage.Text = error_text;
            CompleteLblNumber.Text = scaned_number.ToString();
           // iSortTxtDataInput.Text = "";
        }
        private void SendMail(string address, string order, string profile_type, string window_type, string size, string colorIn, string colorOut, string name, string reason)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(Settings.sender_email);

            message.To.Add(new MailAddress(address));

            message.Subject = order + " - "+ profile_type+ " READY TO PICKUP!";




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
        private void Scan_timer_Tick(object sender, EventArgs e)
        {
          
            List<string> data = new List<string>();
             DateTime end_time = DateTime.Now;
           
            for (int i = 0; i < names.Count; i++)
            {
              
                bool exists = false;
                
                    data.Add(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"));
                    data.Add(names[i][1]);
                    data.Add(names[i][0]);
                
            }
            for (int i = 0; i < names_prefix.Count; i++)
            {
                var match_prefix = names.FirstOrDefault(stringToCheck => stringToCheck[0].Contains(names_prefix[i]));
                if(match_prefix==null) dataGridViews[i].Rows.Add(start_time.ToString("H.mm") + " - " + end_time.ToString("H.mm"), "0");
            }
                int a = data.Count;
           
            Settings.Frame_Clearing_Scanned.Add(data.ToArray());

            names = new List<string[]>();
            start_time = end_time;
        }
        private void CreateGrid(int id,string name)
        {
            PrefixLayoutPanel.VerticalScroll.Visible = false;
            PrefixLayoutPanel.ColumnCount += 1;
         //   PrefixLayoutPanel.Col[PrefixLayoutPanel.ColumnCount].SizeType = SizeType.AutoSize;
            this.PrefixLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize,100));
            //    PrefixLayoutPanel.SEt
            // PrefixLayoutPanel.
            Label lblTitle = new Label();
            lblTitle.Text = name;
         //   lblTitle.Anchor = AnchorStyles.Left;
            TableLayoutPanelCellPosition cellPoslbl = new TableLayoutPanelCellPosition(0+ id, 0 );
         //  lblTitle.Dock = DockStyle.Left;
          PrefixLayoutPanel.SetCellPosition(lblTitle, cellPoslbl);
            lblTitle.Parent = PrefixLayoutPanel;
            lblTitle.Margin=  new Padding(40, 0, 0, 0);
         //   lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            lblTitle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            System.Windows.Forms.DataGridView NameGrid= new System.Windows.Forms.DataGridView();
         
            ((System.ComponentModel.ISupportInitialize)(NameGrid)).BeginInit();
            this.SuspendLayout();
           TableLayoutPanelCellPosition cellPos = new TableLayoutPanelCellPosition(0 + id, 1);
            PrefixLayoutPanel.SetCellPosition(NameGrid, cellPos);
            NameGrid.Parent = PrefixLayoutPanel;
          //  NameGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
           
          //  NameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    NameGrid.Name = "dataGridViews"+numb;
           NameGrid.Size = new System.Drawing.Size(190, 1000); 
           NameGrid.TabIndex = 0;
           NameGrid.ColumnHeadersVisible = true; 
           NameGrid.RowHeadersVisible = false;
           NameGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //  NameGrid.Anchor = AnchorStyles.Left;
            //     NameGrid.Dock = DockStyle.Top;
            NameGrid.BackgroundColor = SystemColors.Control;
            NameGrid.Columns.Add("Time", "  Time");
            NameGrid.Columns.Add("Total", "   Total");
    //       NameGrid.AutoSize = true;
            NameGrid.Visible = true;
            NameGrid.BorderStyle = BorderStyle.None;
            NameGrid.GridColor = SystemColors.Control;
            NameGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            NameGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            NameGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            NameGrid.RowsDefaultCellStyle.BackColor = SystemColors.Control;
            NameGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //   NameGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //   NameGrid.ColumnHeadersDefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleCenter;
            NameGrid.DefaultCellStyle.SelectionBackColor = SystemColors.Control;
            NameGrid.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            //    NameGrid.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            NameGrid.EnableHeadersVisualStyles = false;
            //      NameGrid.DefaultCellStyle.BackColor = SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)(NameGrid)).EndInit();
              this.ResumeLayout(false);
           
            dataGridViews.Add(NameGrid);
        }
            private void FrameClearingForm_Load(object sender, EventArgs e)
        {

        }

        private void iFrameTxtDataInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = iFrameTxtDataInput.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }

        private void iSortMiddleLeftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iSortLeftPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrefixQtyData_SelectionChanged(object sender, EventArgs e)
        {
            this.PrefixQtyData.ClearSelection();
        }

        private void PrefixQtyData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrefixQtyData_SelectionChanged_1(object sender, EventArgs e)
        {
            this.PrefixQtyData.ClearSelection();


        }

        private void PrefixLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrefixQtyData_SelectionChanged_2(object sender, EventArgs e)
        {
            this.PrefixQtyData.ClearSelection();
        }

        private void PrefixQtyData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void iFrameClearingblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
