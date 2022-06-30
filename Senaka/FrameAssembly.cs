using Senaka.component;
using Senaka.lib;
using System;
using System.Collections;
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
    public partial class FrameAssembly : Form
    {
        List<string> list = new List<string>();
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        int qtytotal = 0;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();
        public FrameAssembly()
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

            string[] small_fix = Settings.Small_Fix.Select(x => x[2]).ToArray();

            string[] large_fix = Settings.Large_Fix.Select(x => x[2]).ToArray();

            string[] casements = Settings.Casement_Frame.Select(x => x[2]).ToArray();


            list.AddRange(small_fix.ToArray());
            list.AddRange(large_fix.ToArray());
            list.AddRange(casements.ToArray());
            error_message = new MessageBoxDialog();
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;
            FrameLblNumber.Text = "0";

            //  PrefixQtyData.Rows.Add("a", "1");
        }
        private void WindowsAssembly_FormClosing(object sender, FormClosingEventArgs e)
        {
          

            MainForm mainform = new MainForm();
            mainform.Show();
        }
        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iShippingDate.Text = today.ToString("yyyy-MM-dd");
            iShippingTime.Text = today.ToString("HH:mm:ss");
        }

     
        private void iShippingTxtDataInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = iShippingTxtDataInput.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }
        private void scanInput(string data)
        {
            bool exist_prefix = false;
            string[] prefix_data = null, framereport_data, type_data;
            int i;
            string prefix = data.Substring(0, 1);
            string line_number = data.Substring(1);
            string error_text = null;
            string[] framescutting_data;
            List<string[]> production_report_data;
            foreach (string[] r in Settings.Frame_Assembly_Prefix_Table)
            {

                if (r[(int)PREFIX.PREFIX] == prefix)
                {
                    exist_prefix = true;
                    prefix_data = r;
                    break;
                }
            }

            if (exist_prefix)
            {
                framescutting_data = DB.fetchRow("framescutting", "F", line_number, false);

                if (framescutting_data == null)
                {
                   
                    error_text = "INVALID LINE NUMBER!";
                    iShippingTxtDataInput.Text = null;
                }
                else
                {


                    string window_type = "";
                
                    int qtyorder = 0;
                    int qtycurrentorder = 0;

                    bool exists = false, exists_order = false;

                    string[] type_codes = null;

                    string[] small_fix = Settings.Small_Fix.Select(x => x[2]).ToArray();

                    string[] large_fix = Settings.Large_Fix.Select(x => x[2]).ToArray();

                    string[] casements = Settings.Casement_Frame.Select(x => x[2]).ToArray();



                    List<string[]> frame_assembly_data = DB.fetchRows("FrameAssembly", "Line_id", line_number);
                    string name = prefix_data[(int)PREFIX.NAME-1];
                    DateTime now = DateTime.Now;
                    string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
                    string order_number = framescutting_data[9];
                    if (frame_assembly_data.Count == 0) {
                        if (small_fix.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)) || large_fix.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)) || casements.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            type_codes = small_fix.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)) ? type_codes = small_fix :
                                large_fix.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)) ? type_codes = large_fix :
                                 casements.Any(s => framescutting_data[7].Equals(s, StringComparison.InvariantCultureIgnoreCase)) ? type_codes = casements : null;
                            if (DB.saveFrameAssemblyData(line_number, date, time, name) == 0)
                            {
                              
                                if (FrameScanedData.Rows.Count < 10)
                                    FrameScanedData.Rows.Insert(0, line_number, date, time, name);
                                else
                                {
                                    FrameScanedData.Rows.RemoveAt(FrameScanedData.Rows.Count - 1);
                                    FrameScanedData.Rows.Insert(0, line_number, date, time, name);
                                }
                           
                              
                                List<string[]> frameCutting_order = DB.getFrameCuttingByOrderType(list, order_number);
                                qtyorder = frameCutting_order.Count;
                                for (i = 0; i < OrderScanedData.Rows.Count; i++)
                                    if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == order_number && OrderScanedData.Rows[i].Cells[1].Value.ToString().ToLower() == name)
                                    {
                                        qtycurrentorder = Int32.Parse(OrderScanedData.Rows[i].Cells[2].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[2].Value.ToString().IndexOf('/'))) + 1;
                                        OrderScanedData.Rows[i].Cells[2].Value = qtycurrentorder + "/" + qtyorder;

                                        exists = true;

                                        if (qtycurrentorder == qtyorder)
                                        {
                                            OrderScanedData.Rows[i].Cells[2].Style.BackColor = Color.Lime;
                                           
                                        }
                                    }
                                else if(OrderScanedData.Rows[i].Cells[0].Value.ToString() == order_number)
                                        exists_order = true;

                                if (!exists && !exists_order)
                                {
                                  
                                    List<string> ids = new List<string>();
                                    foreach (var entry in frameCutting_order)
                                    {
                                        ids.Add(entry[6]);
                                    }
                                    List<string[]> frame_assembly_table = DB.importFrameAssemblyAssemblyByIds(ids);

                                   
                                       
                                            OrderScanedData.Rows.Insert(0, order_number,name, frame_assembly_table.Count + "/" + qtyorder);
                                            if (frame_assembly_table.Count() == qtyorder)
                                            {
                                                OrderScanedData.Rows[0].Cells[2].Style.BackColor = Color.Lime;
                                               

                                            

                                    }
                                }
                                else if (exists_order)
                                        {
                                    List<string> ids = new List<string>();
                                    foreach (var entry in frameCutting_order)
                                    {
                                        ids.Add(entry[6]);
                                    }
                                    List<string[]> frame_assembly_table = DB.importFrameAssemblyAssemblyByIds(ids);
                                   
                                    OrderScanedData.Rows.Insert(0, order_number,name, frame_assembly_table.Count + "/" + qtyorder);

                                }
                                qtytotal++;
                            }
                            exists = false;
                            for (int j = 0; j < PrefixQtyData.Rows.Count; j++)
                                if (PrefixQtyData.Rows[j].Cells[0].Value.ToString() == name)
                                {
                                    PrefixQtyData.Rows[j].Cells[1].Value = (Int32.Parse(PrefixQtyData.Rows[j].Cells[1].Value.ToString()) + 1).ToString();
                                    exists = true;
                                    break;
                                }

                            if (!exists)
                            {
                                PrefixQtyData.Rows.Add(name, "1");

                            }
                        }
                        else
                        {
                            error_text = "FRAME TYPE ERROR";
                        }

                    }
                   else {
                        error_text = "ALREADY SCANNED ALL QUANTITIES";
                    }





                }

            }
            else
            {
                
                error_text = "INVALID PREFIX LETTER!";
            }

            iShippingTxtDataInput.Text = null;
            ErrorLblMessage.Text = error_text;
            FrameLblNumber.Text = qtytotal.ToString();

            //    if(error_text!=null)  error_message.Show(error_text, "Error");
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
            string data = iShippingTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar)) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                iShippingTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-'))
                                )
                            ) ||
                            (iShippingTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-') && !char.IsLetter(e.KeyChar))
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
            this.OrderScanedData.ClearSelection();
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
            this.PrefixQtyData.ClearSelection();
        }

        private void WindowsAssebly_Load(object sender, EventArgs e)
        {

        }


    }
}
