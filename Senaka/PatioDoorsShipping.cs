
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
    public partial class PatioDoorsShipping : Form
    {
        int Windowqty = 0, Casing=0, Patiodoors = 0;
        MessageBoxDialog error_message;
        Timer timer, error_timer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();
        string OrderNumber_mandatory;
        public PatioDoorsShipping()
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
            OrderNumber_mandatory = Settings.PatioDoors_Shipping_Obligatory_Order_boolean;

             error_message = new MessageBoxDialog();
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;
         
            PatioDoorsLblNumber.Text = "0";
         
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
                    if(OrderNumber_mandatory=="True")
                    textBoxOrderNumber.Focus();
                    else scanInput();

                }
            }
        }
        private void scanInput()
        {
            string data = iShippingTxtDataInput.Text;
            bool exist_prefix = false;
            string[] prefix_data = null, framereport_data, type_data;
            //  int i;
            string prefix = data.Substring(0, 1);
            string door_number = data.Substring(1);
            string error_text = null;
            List<string[]> windowsassembly_data;
            List<string[]> production_report_data;
            foreach (string[] r in Settings.PatioDoors_Shipping_Prefix_Table)
            {

                if (r[(int)PREFIX.PREFIX] == prefix)
                {
                    exist_prefix = true;
                    prefix_data = r;
                    break;
                }
            }
          
            string ordNumber = textBoxOrderNumber.Text;

           
            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
            if (exist_prefix)
            {
                string name = prefix_data[(int)PREFIX.NAME-1];
                List<string[]> Vista_Total = new List<string[]>(), Oceanview_Total = new List<string[]>();
                List<string> vista = new List<string>(), oceanView = new List<string>();
                if (OrderNumber_mandatory == "True" || ordNumber != "")
                {
                    string[] vistas=DB.getVistaDoorByDoorOrderNumb(door_number, ordNumber);
                    if (vistas != null)
                        vista = vistas.ToList();
                    string[] oceanViews = DB.getOceanviewDoorByDoorOrderNumb(door_number, ordNumber);
                    if (oceanViews != null)
                        oceanView = oceanViews.ToList();
                }
                else
                {
                    string[] vistas = DB.fetchRow("VistaPatioDoors", "Door number", door_number);
                    if (vistas != null)
                        vista = vistas.ToList();
                    string[] oceanViews = DB.fetchRow("OceanviewPatioDoors", "Door number", door_number);
                    if (oceanViews != null)
                        oceanView = oceanViews.ToList();
                }
                if (vista.Count != 0 || oceanView.Count != 0)
                {
                    string[] PatioDoorsShipping = DB.fetchRow("PatioDoorsShipping", "Door_number", door_number);
                    if (PatioDoorsShipping == null)
                    {
                        if (DB.savePatioDoorsShippingData(door_number, date, time, name)==0)
                        {
                            string CompanyName = "";
                            int doorqty = 0, comapnyqty = 0;
                            bool exist = false, existInDatabase = false;
                            int r = 0;
                            CompanyName = vista.Count != 0 ? vista[30] : oceanView.Count != 0 ? oceanView[21] : null;
                            Vista_Total = DB.fetchRows("VistaPatioDoors", "Company", CompanyName);
                            Oceanview_Total = DB.fetchRows("OceanviewPatioDoors", "Company", CompanyName);
                            comapnyqty = Vista_Total.Count + Oceanview_Total.Count;
                            for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                                if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == CompanyName)
                                {
                                    r = i;
                                    exist = true;

                                    doorqty = Int32.Parse(OrderScanedData.Rows[i].Cells[1].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[1].Value.ToString().IndexOf('/')));
                                    comapnyqty = Int32.Parse(OrderScanedData.Rows[i].Cells[1].Value.ToString().Substring(OrderScanedData.Rows[i].Cells[1].Value.ToString().LastIndexOf('/') + 1));
                                    OrderScanedData.Rows[i].Cells[1].Value = doorqty + 1 + "/" + comapnyqty;
                                    if (doorqty + 1 == comapnyqty)
                                        OrderScanedData.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                                }
                            if (!exist)
                            {
                                List<string> ids = new List<string>();
                                foreach (var entry in Vista_Total)
                                {
                                    ids.Add(entry[7]);
                                }
                                foreach (var entry in Oceanview_Total)
                                {
                                    ids.Add(entry[7]);
                                }
                                int scanned_doors = DB.importPatioDoorsShippingByIds(ids).Count;
                                OrderScanedData.Rows.Add(CompanyName, scanned_doors+"/"+comapnyqty);
                                if (doorqty + 1 == comapnyqty)
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[1].Style.BackColor = Color.Lime;
                            }




                            iShippingScanedData.Rows.Add(door_number, date, time, name,ordNumber);

                            PatioDoorsLblNumber.Text = (Int32.Parse(PatioDoorsLblNumber.Text)+1).ToString();
                        }
                        else
                        {
                           
                            error_text = "ERROR SAVING!";
                        }
                    }

                    else
                    {
                     
                        error_text = "DOOR NUMBER SCANNED!";
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

        private void textBoxOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxOrderNumber.Text;
                if (data != "")
                {
                  
                    scanInput();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     

      

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void WindowsAssebly_Load(object sender, EventArgs e)
        {

        }

      
    }
}
