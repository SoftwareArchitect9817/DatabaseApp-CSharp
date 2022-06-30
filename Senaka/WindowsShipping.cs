
using Senaka.component;
using Senaka.lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class WindowsShipping : Form
    {
        int Windowqty = 0, Casing=0, Patiodoors = 0;
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();
        public WindowsShipping()
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

            /*  List<string[]> data = DB.fetchRows("ig_shipping", "date", date, new string[] { "time", "DESC" });
              string[] glass;
              foreach (string[] row in data)
              {
                  glass = DB.fetchRow("glassreport", "sealed_unit_id", row[(int)IG_SHIPPING.SEALED_UNIT_ID], false);
                  iShippingScanedData.Rows.Add(
                      row[(int)IG_SHIPPING.SEALED_UNIT_ID], Convert.ToDateTime(row[(int)IG_SHIPPING.DATE]).ToString("yyyy-MM-dd"),
                      row[(int)IG_SHIPPING.TIME], row[(int)IG_SHIPPING.NAME], glass[(int)GLASS.RACK_ID]);
              }
              */
         

             error_message = new MessageBoxDialog();
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;
            WindowLblNumber.Text = "0";
            CasingLblNumber.Text = "0";
            PatioDoorsLblNumber.Text = "0";
            SULblNumber.Text = "0";
         
        }
        private void WindowsAssembly_FormClosing(object sender, FormClosingEventArgs e)
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
            string[] prefix_data = null, framereport_data,type_data;
          //  int i;
            string prefix = data.Substring(0, 1);
            string line_number = data.Substring(1);
            string error_text=null;
            List<string[]> windowsassembly_data;
            List<string[]> production_report_data;
            foreach (string[] r in Settings.Windows_Shipping_Prefix_Table)
            {
               
                  if (r[(int)PREFIX.PREFIX] == prefix)
                  {
                      exist_prefix = true;
                      prefix_data = r;
                      break;
                  }
              }
            string name = prefix_data[2];
            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
            if (exist_prefix)
            {
                int windowqtyTotal = 0, patiodoorsTotal = 0, casingTotal = 0, SUTotal = 0;
                string[] workorder = DB.fetchRow("workorder", "LINE #1", line_number);
                if (workorder != null)
                {
                    string[] WindowsShipping = DB.getLastWindowsShippingData(line_number);
                    if (WindowsShipping == null|| Int32.Parse(WindowsShipping[6])< Int32.Parse(workorder[9]))
                    { 
                        int windowqty = 0, patiodoors = 0, casing = 0, SUQty = 0;
                    bool exist = false, existInDatabase=false;
                    int r = 0;
                    string ordNumb = workorder[1];
                    for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                        if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ordNumb)
                        {
                            r = i;
                            exist = true;

                            windowqty = Int32.Parse(OrderScanedData.Rows[i].Cells[1].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[1].Value.ToString().IndexOf('/')));
                            patiodoors = Int32.Parse(OrderScanedData.Rows[i].Cells[2].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[2].Value.ToString().IndexOf('/')));
                            casing = Int32.Parse(OrderScanedData.Rows[i].Cells[3].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[3].Value.ToString().IndexOf('/')));
                            SUQty = Int32.Parse(OrderScanedData.Rows[i].Cells[4].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[4].Value.ToString().IndexOf('/')));

                            }
                        List<string[]> WorkorderData = DB.fetchRows("workorder", "ORDER #", ordNumb);
                    try
                    {
                            foreach (var item in WorkorderData)
                                if (item[7].Contains("SU"))
                                    SUTotal += Int32.Parse(item[9]);
                                else
                                    windowqtyTotal += Int32.Parse(item[9]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                    List<string[]> framesCutting = DB.getFrameCuttingByOrderType(Settings.Casing.Where(x => x[1] == "Casing").Select(x => x[2]).ToList(), ordNumb);
                    if (framesCutting != null)
                            casingTotal = framesCutting.Count();

                    string[] productionReport = DB.fetchRow("productionreport", "ORDER", ordNumb);
                    if (productionReport != null)
                       patiodoorsTotal  = Int32.Parse(productionReport[8]);
                        if (!exist)
                        {
                            List<string[]> windowsshipping = DB.fetchRows("WindowsShipping", "ORDER", ordNumb);
                            if (windowsshipping.Count != 0)

                            {
                                existInDatabase = true;
                                windowqty = Int32.Parse(windowsshipping[windowsshipping.Count - 1][6]);
                                patiodoors = Int32.Parse(windowsshipping[windowsshipping.Count - 1][7]);
                                casing = Int32.Parse(windowsshipping[windowsshipping.Count - 1][8]);
                            }
                        }


                        if (windowqty < windowqtyTotal)
                        {
                            windowqty++;
                            Windowqty++;
                        }
                       
                        
                        int TotalperLine = WindowsShipping != null ? (Int32.Parse(WindowsShipping[6]) + 1) : 1;

                        if (!exist)
                        {
                            if (DB.saveWindowsShippingData(line_number, date, time, name, ordNumb, TotalperLine.ToString(), patiodoors.ToString(), casing.ToString(), textBoxReference.Text) == 0)
                            {
                                OrderScanedData.Rows.Add(ordNumb, windowqty + "/" + windowqtyTotal, patiodoors + "/" + patiodoorsTotal, casing + "/" + casingTotal, SUQty + "/" + SUTotal, name);
                                if (windowqty == windowqtyTotal && windowqtyTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[1].Style.BackColor = Color.Lime;
                                if (patiodoors == patiodoorsTotal && patiodoorsTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[2].Style.BackColor = Color.Lime;
                                if (casing == casingTotal && casingTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[3].Style.BackColor = Color.Lime;
                                if (SUQty == SUTotal && SUTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[4].Style.BackColor = Color.Lime;

                            }
                            }
                        else
                        {
                            if (DB.saveWindowsShippingData(line_number, date, time, name, ordNumb, TotalperLine.ToString(), patiodoors.ToString(), casing.ToString(), textBoxReference.Text) == 0)
                            {
                              
                                OrderScanedData.Rows[r].Cells[1].Value = windowqty + "/" + windowqtyTotal;
                                OrderScanedData.Rows[r].Cells[2].Value = patiodoors + "/" + patiodoorsTotal;
                                OrderScanedData.Rows[r].Cells[3].Value = casing + "/" + casingTotal;
                                OrderScanedData.Rows[r].Cells[4].Value = SUQty + "/" + SUTotal;
                                if (windowqty == windowqtyTotal && windowqtyTotal != 0)
                                    OrderScanedData.Rows[r].Cells[1].Style.BackColor = Color.Lime;
                                if (patiodoors == patiodoorsTotal && patiodoorsTotal != 0)
                                    OrderScanedData.Rows[r].Cells[2].Style.BackColor = Color.Lime;
                                if (casing == casingTotal && casingTotal != 0)
                                    OrderScanedData.Rows[r].Cells[3].Style.BackColor = Color.Lime;
                                if (SUQty == SUTotal && SUTotal != 0)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[4].Style.BackColor = Color.Lime;

                            }
                        }
                        iShippingScanedData.Rows.Add(line_number,date,time,name);
                       WindowLblNumber.Text = Windowqty.ToString();
                        CasingLblNumber.Text = Casing.ToString();
                        PatioDoorsLblNumber.Text = Patiodoors.ToString();
                        SULblNumber.Text = SUQty.ToString();
                    }
                    else
                    {
                        // WindowsLblRackID.Text = "ERROR";
                        error_text = "LINE NUMBER SCANNED!";
                    }
                }
               


            else
            {
                // WindowsLblRackID.Text = "ERROR";
                error_text = "INVALID LINE NUMBER!";
            }
            }
            else
            {
                // WindowsLblRackID.Text = "ERROR";
                error_text = "INVALID PREFIX LETTER!";
            }
          
            iShippingTxtDataInput.Text = null;
          
            WindowLblMessage.Text = error_text;
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
        private void WindowsAssebly_Load(object sender, EventArgs e)
        {

        }

      
    }
}
