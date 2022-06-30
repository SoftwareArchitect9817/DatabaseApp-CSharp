
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
    public partial class WindowsWrapping : Form
    {
        DateTime startTime;
        int Windowqty = 0, Casing=0, Patiodoors = 0;
        MessageBoxDialog error_message;
        Timer timer, error_timer, updateTableTimer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();
        List<Data_order> TotalOrders = new List<Data_order>();
        List<string> excludeOrders = new List<string>();
        public class Data_order
        {
            public string Order { get; set; }
            public string Company { get; set; }
            public string Casement { get; set; }
            public int Casement_Done { get; set; }
            public int Casement_Total { get; set; }
            public string Slider { get; set; }
            public int Slider_Done { get; set; }
            public int Slider_Total { get; set; }
            public string Shape { get; set; }
            public int Shape_Done { get; set; }
            public int Shape_Total { get; set; }
            public string Total_str { get; set; }
            public int Total_Done { get; set; }
            public int Total { get; set; }
        }
        public WindowsWrapping()
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            updateTableTimer = new Timer();
            updateTableTimer.Interval = Settings.WindowsWrappingUpdateTime * 60 * 1000;
            updateTableTimer.Tick += UpdateTable;
            updateTableTimer.Start();
            startTime = DateTime.Now;
            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iShippingDate.Text = date;
            iShippingTime.Text = today.ToString("HH:mm:ss");

             error_message = new MessageBoxDialog();
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;

            OrderScannedTotal.DefaultCellStyle.SelectionBackColor = OrderScannedTotal.DefaultCellStyle.BackColor;
            OrderScannedTotal.DefaultCellStyle.SelectionForeColor = OrderScannedTotal.DefaultCellStyle.ForeColor;
            WindowLblNumber.Text = "0";
            OrderScannedTotal.AutoGenerateColumns = false;


        }
        private void UpdateTable(object sender, EventArgs e)
        {
            TotalOrders = new List<Data_order>();
            List<string[]> WindowsAssembly_data = DB.getWindowsAssemblyData(startTime);
            List<string> line_numbers = new List<string>(), orders = new List<string>();
            foreach (var row in WindowsAssembly_data)
            {
                if (!excludeOrders.Any(x=> x == row[0].Substring(0, 5)))
                {
                    line_numbers.Add(row[0]);
                    orders.Add(row[0].Substring(0, 5));
                }
            }
            List<string[]> FrameReport_dataDone = DB.getFrameReportDataDone(line_numbers);
            List<string[]> FrameReport_dataTotal = DB.getFrameReportDataTotal(orders);
            List<string[]> Companies = DB.getCompanyFromWorkOrder(orders);
            foreach (var row in FrameReport_dataTotal)
            {
            
                string order = row[0];
                string total = row[1];
                string type = row[2];
                string company = Companies.Where(x => x[0] == order).FirstOrDefault()[1];
                string[] done_element = FrameReport_dataDone.Find(x => x[0] == order && x[2] == type);
                string done = "0";
                if (done_element != null) done = done_element[1];
                Data_order existingElement = TotalOrders.Find(x => x.Order == order);

                if (existingElement == null)
                {
                    Data_order element = new Data_order();
                    element.Order = order;
                    element.Company = company; 
                    switch (type)
                    {
                        case "CASEMENT":
                            element.Casement_Done = Int32.Parse(done);
                            element.Casement_Total = Int32.Parse(total);
                            element.Casement = done + "/" + total;
                            break;
                        case "SLIDER":
                            element.Slider_Done = Int32.Parse(done);
                            element.Slider_Total = Int32.Parse(total);
                            element.Slider = done + "/" + total;
                            break;
                        case "SHAPE":
                            element.Shape_Done = Int32.Parse(done);
                            element.Shape_Total = Int32.Parse(total);
                            element.Shape = done + "/" + total;
                            break;
                    }
                    element.Total_Done += Int32.Parse(done);
                    element.Total += Int32.Parse(total);
                    element.Total_str = element.Total_Done + "/" + element.Total;

                    TotalOrders.Add(element);

                }
                else
                {
                    switch (type)
                    {
                        case "CASEMENT":
                            existingElement.Casement_Done = Int32.Parse(done);
                            existingElement.Casement_Total = Int32.Parse(total);
                            existingElement.Casement = done + "/" + total;
                            break;
                        case "SLIDER":
                            existingElement.Slider_Done = Int32.Parse(done);
                            existingElement.Slider_Total = Int32.Parse(total);
                            existingElement.Slider = done + "/" + total;
                            break;
                        case "SHAPE":
                            existingElement.Shape_Done = Int32.Parse(done);
                            existingElement.Shape_Total = Int32.Parse(total);
                            existingElement.Shape = done + "/" + total;
                            break;
                    }
                    existingElement.Total_Done += Int32.Parse(done);
                    existingElement.Total += Int32.Parse(total);
                    existingElement.Total_str = existingElement.Total_Done + "/" + existingElement.Total;
                }


                if (row[1] == total)
                {
                    //OrderScannedTotal.Rows[OrderScannedTotal.Rows.Count - 1].Cells[1].Style.BackColor = Color.Lime;
                    
                }
                (OrderScannedTotal.BindingContext[TotalOrders] as CurrencyManager).Refresh();
                OrderScannedTotal.DataSource = TotalOrders;
            }
            for (int i = 0; i < TotalOrders.Count; i++)
            {
                if (TotalOrders[i].Casement_Done == TotalOrders[i].Casement_Total && TotalOrders[i].Casement_Done != 0)
                    OrderScannedTotal.Rows[i].Cells[2].Style.BackColor = Color.Lime;
                if (TotalOrders[i].Slider_Done == TotalOrders[i].Slider_Total && TotalOrders[i].Slider_Done != 0)
                    OrderScannedTotal.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                if (TotalOrders[i].Shape_Done == TotalOrders[i].Shape_Total && TotalOrders[i].Shape_Done != 0)
                    OrderScannedTotal.Rows[i].Cells[4].Style.BackColor = Color.Lime;
                if (TotalOrders[i].Total == TotalOrders[i].Total_Done)
                {

                    OrderScannedTotal.Rows[i].Cells[5].Style.BackColor = Color.Lime;
                  
                }
            }

        }
        private void HideAll_timer_Tick(object sender, EventArgs e)
        {
            if (timers.Count != 0)
            {
                foreach (Timer timer in timers)
                {
                    if (timer.Enabled == true)
                    {
                        string ord_numb = timer.Tag.ToString();

                        TotalOrders.RemoveAll(x => x.Order == ord_numb);
                        excludeOrders.Add(ord_numb);
                        (OrderScannedTotal.BindingContext[TotalOrders] as CurrencyManager).Refresh();
                        OrderScannedTotal.DataSource = TotalOrders;
                        timer.Enabled = false;
                        timer.Stop();
                        for (int i = 0; i < TotalOrders.Count; i++)
                        {
                            if (TotalOrders[i].Casement_Done == TotalOrders[i].Casement_Total && TotalOrders[i].Casement_Done != 0)
                                OrderScannedTotal.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                            if (TotalOrders[i].Slider_Done == TotalOrders[i].Slider_Total && TotalOrders[i].Slider_Done != 0)
                                OrderScannedTotal.Rows[i].Cells[2].Style.BackColor = Color.Lime;
                            if (TotalOrders[i].Shape_Done == TotalOrders[i].Shape_Total && TotalOrders[i].Shape_Done != 0)
                                OrderScannedTotal.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                            if (TotalOrders[i].Total == TotalOrders[i].Total_Done)

                                OrderScannedTotal.Rows[i].Cells[4].Style.BackColor = Color.Lime;
                        }
                    }
                }
            }
        }
        private void WindowsWrapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            updateTableTimer.Stop();
            foreach (Timer timer in timers) timer.Stop();

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
                string data = iWrappingTxtDataInput.Text;
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
         
            foreach (string[] r in Settings.Windows_Wrapping_Prefix_Table)
            {
               
                  if (r[(int)PREFIX.PREFIX] == prefix)
                  {
                      exist_prefix = true;
                      prefix_data = r;
                      break;
                  }
              }
         
            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
            if (exist_prefix)
            {
                string name = prefix_data[2];
                int windowqtyTotal = 0;
                string[] workorder = DB.fetchRow("workorder", "LINE #1", line_number);
                if (workorder != null)
                {
                    string[] WindowsWrapping = DB.getLastWindowsWrappingData(line_number);
                    if (WindowsWrapping == null|| Int32.Parse(WindowsWrapping[6])< Int32.Parse(workorder[9]))
                    { 
                        int windowqtyDoneLine = 0, windowqtyDoneOrder = 0;
                    bool exist = false, existInDatabase=false;
                    int r = 0;
                    string ordNumb = workorder[1];
                    for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                        if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ordNumb)
                        {
                            r = i;
                            exist = true;

                                windowqtyDoneOrder = Int32.Parse(OrderScanedData.Rows[i].Cells[1].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[1].Value.ToString().IndexOf('/')));

                        }
                    List<string[]> WorkorderData = DB.fetchRows("workorder", "ORDER #", ordNumb);
                    try
                    {
                        foreach (var item in WorkorderData)
                            windowqtyTotal += Int32.Parse(item[9]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message+ Environment.NewLine + "In the qty column in workorder it is text");
                        return;
                    }
                  

              
                        if (!exist)
                        {
                            List<string[]> windowswrapping = DB.fetchRows("WindowsWrapping", "ORDER", ordNumb);
                            if (windowswrapping.Count != 0)

                            {
                                existInDatabase = true;
                                windowqtyDoneLine = Int32.Parse(windowswrapping[windowswrapping.Count - 1][6]);

                                foreach (var item in windowswrapping)
                                    windowqtyDoneOrder += Int32.Parse(item[6]);


                            }
                        }


                        if (windowqtyDoneOrder < windowqtyTotal)
                        {
                            windowqtyDoneOrder++;
                            windowqtyDoneLine++;
                            Windowqty++;
                        }
                      
                        int TotalperLine = WindowsWrapping != null ? (Int32.Parse(WindowsWrapping[6]) + 1) : 1;

                        if (!exist)
                        {
                            if (DB.saveWindowsWrappingData(line_number, date, time, name, ordNumb, TotalperLine.ToString(), textBoxReference.Text) == 0)
                            {
                                OrderScanedData.Rows.Add(ordNumb, windowqtyDoneOrder + "/" + windowqtyTotal, name);
                                if (windowqtyDoneOrder == windowqtyTotal && windowqtyTotal != 0)
                                {
                                    OrderScanedData.Rows[OrderScanedData.Rows.Count - 1].Cells[1].Style.BackColor = Color.Lime;
                                    if (Settings.WindowsWrappingHide == "True")
                                    {
                                        Timer scan_timer = new Timer();
                                        string data_timer = ordNumb;
                                        scan_timer.Tag = data_timer;
                                        scan_timer.Interval = Settings.WindowsWrappingHideTime * 60 * 1000;
                                        //   scan_timer.Interval = 30000;
                                        scan_timer.Tick += HideAll_timer_Tick;
                                        scan_timer.Start();
                                        timers.Add(scan_timer);

                                    }
                                }
                            }
                            }
                        else
                        {
                            if (DB.saveWindowsWrappingData(line_number, date, time, name, ordNumb, TotalperLine.ToString(), textBoxReference.Text) == 0)
                            {
                              
                                OrderScanedData.Rows[r].Cells[1].Value = windowqtyDoneOrder + "/" + windowqtyTotal;

                                if (windowqtyDoneOrder == windowqtyTotal && windowqtyTotal != 0)
                                {
                                    OrderScanedData.Rows[r].Cells[1].Style.BackColor = Color.Lime;
                                    if (Settings.WindowsWrappingHide == "True")
                                    {
                                        Timer scan_timer = new Timer();
                                        string data_timer = ordNumb;
                                        scan_timer.Tag = data_timer;
                                        scan_timer.Interval = Settings.WindowsWrappingHideTime * 60 * 1000;
                                        //   scan_timer.Interval = 30000;
                                        scan_timer.Tick += HideAll_timer_Tick;
                                        scan_timer.Start();
                                        timers.Add(scan_timer);

                                    }
                                }
                            
                            }
                        }
                        iShippingScanedData.Rows.Add(line_number,date,time,name);
                       WindowLblNumber.Text = Windowqty.ToString();
                        bool exists = false;
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
          
            iWrappingTxtDataInput.Text = null;
          
            WindowLblMessage.Text = error_text;
         
          
    //    if(error_text!=null)  error_message.Show(error_text, "Error");
        }
        private void Hide_timer_Tick(object sender, EventArgs e)
        {
            if (timers.Count != 0)
            {
                foreach (Timer timer in timers)
                {
                    string ord_numb = timer.Tag.ToString();
                  
                    for (var i = 0; i < OrderScannedTotal.Rows.Count; i++)
                    {
                        if (OrderScannedTotal.Rows[i].Cells[0].Value.ToString() == ord_numb)
                            OrderScannedTotal.Rows.RemoveAt(i);
                    }
                    timer.Enabled = false;
                    timers.Remove(timer);
                }
            }
        }
            private void iShippingTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = iWrappingTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar)) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                iWrappingTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-'))
                                )
                            ) ||
                            (iWrappingTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('-') && !char.IsLetter(e.KeyChar))
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

        private void PrefixQtyData_SelectionChanged(object sender, EventArgs e)
        {
            this.PrefixQtyData.ClearSelection();
        }

        private void OrderScannedTotal_SelectionChanged(object sender, EventArgs e)
        {
            this.OrderScannedTotal.ClearSelection();
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

       

        private void WindowsAssebly_Load(object sender, EventArgs e)
        {

        }

      
    }
}
