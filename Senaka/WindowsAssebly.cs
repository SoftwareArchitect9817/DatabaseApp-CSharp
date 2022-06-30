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
    public partial class WindowsAssebly : Form
    {
        DateTime startTime;
        int  windows_number, casement_qty = 0, slider_qty = 0, shape_qty = 0;
        MessageBoxDialog error_message;
        Timer timer, error_timer, updateTableTimer;
        List<string[]> names = new List<string[]>();
        List<Timer> timers = new List<Timer>();
        List<Data_order> TotalOrders = new List<Data_order>();

        public class Data_order
        {
            public string Order { get; set; }
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

        public WindowsAssebly()
        {
            InitializeComponent();

            error_message = new MessageBoxDialog();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            error_timer = new Timer();
            error_timer.Interval = Settings.Windows_Assembly_Error_Time * 1000;
            error_timer.Tick += Error_timer_Tick;

            updateTableTimer = new Timer();
            updateTableTimer.Interval = Settings.WindowsAssemblyUpdateTime *60* 1000;
            updateTableTimer.Tick += UpdateTable;
            updateTableTimer.Start();
            
            startTime = DateTime.Now;
            iShippingDate.Text = startTime.ToString("yyyy-MM-dd");
            iShippingTime.Text = startTime.ToString("HH:mm:ss");
            /*
            List<string[]> data = DB.fetchRows("ig_shipping", "date", date, new string[] { "time", "DESC" });
            string[] glass;
            foreach (string[] row in data)
            {
                glass = DB.fetchRow("glassreport", "sealed_unit_id", row[(int)IG_SHIPPING.SEALED_UNIT_ID], false);
                iShippingScanedData.Rows.Add(
                    row[(int)IG_SHIPPING.SEALED_UNIT_ID], Convert.ToDateTime(row[(int)IG_SHIPPING.DATE]).ToString("yyyy-MM-dd"),
                    row[(int)IG_SHIPPING.TIME], row[(int)IG_SHIPPING.NAME], glass[(int)GLASS.RACK_ID]);
            }
            */
            OrderScanedData.DefaultCellStyle.SelectionBackColor = OrderScanedData.DefaultCellStyle.BackColor;
            OrderScanedData.DefaultCellStyle.SelectionForeColor = OrderScanedData.DefaultCellStyle.ForeColor;
            WindowLblNumber.Text = "0";
            ShapeLblNumber.Text = shape_qty.ToString();
            SliderLblNumber.Text = slider_qty.ToString();
            CasementLblNumber.Text = casement_qty.ToString();
            //PrefixQtyData.Rows.Add("a", "1");
            OrderScannedTotal.AutoGenerateColumns = false;
        }

        private void UpdateTable(object sender, EventArgs e)
        {
            List<string> line_numbers = new List<string>(), orders = new List<string>();
            List<string[]> WindowsAssembly_data = DB.getWindowsAssemblyData(startTime);
            foreach (var row in WindowsAssembly_data)
            {
                line_numbers.Add(row[0]);
                orders.Add(row[0].Substring(0, 5));
            }
            TotalOrders = new List<Data_order>();
            List<string[]> FrameReport_dataDone = DB.getFrameReportDataDone(line_numbers);
            List<string[]> FrameReport_dataTotal = DB.getFrameReportDataTotal(orders);
            foreach (var row in FrameReport_dataTotal)
            {
                string order = row[0];
                string total = row[1];
                string type = row[2];
                string[] done_element = FrameReport_dataDone.Find(x => x[0] == order && x[2] == type);
                string done ="0";
                if (done_element != null) done = done_element[1];
                Data_order existingElement = TotalOrders.Find(x => x.Order == order);
                
                if (existingElement == null)
                {
                    Data_order element = new Data_order();
                    element.Order = order;
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
                     if (Settings.WindowsWrappingHide == "True")
                     {
                         Timer scan_timer = new Timer();
                         string data_timer = row[0];
                         scan_timer.Tag = data_timer;
                         scan_timer.Interval = Settings.WindowsAssemblyHideTime * 60 * 1000;
                         //   scan_timer.Interval = 30000;
                         scan_timer.Tick += HideAll_timer_Tick;
                         scan_timer.Start();
                         timers.Add(scan_timer);

                     }
                }
                (OrderScannedTotal.BindingContext[TotalOrders] as CurrencyManager).Refresh();
                OrderScannedTotal.DataSource = TotalOrders;
            }
            for (int i = 0; i < TotalOrders.Count; i++)
            { 
                if(TotalOrders[i].Casement_Done== TotalOrders[i].Casement_Total && TotalOrders[i].Casement_Done != 0)
                {
                    OrderScannedTotal.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                }
                if (TotalOrders[i].Slider_Done == TotalOrders[i].Slider_Total && TotalOrders[i].Slider_Done != 0)
                {
                    OrderScannedTotal.Rows[i].Cells[2].Style.BackColor = Color.Lime;
                }
                if (TotalOrders[i].Shape_Done == TotalOrders[i].Shape_Total && TotalOrders[i].Shape_Done != 0)
                {
                    OrderScannedTotal.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                }
                if (TotalOrders[i].Total == TotalOrders[i].Total_Done)
                {
                    OrderScannedTotal.Rows[i].Cells[4].Style.BackColor = Color.Lime;
                    if (Settings.WindowsAssemblyHide == "True")
                    {
                        Timer scan_timer = new Timer();
                        string data_timer = TotalOrders[i].Order;
                        scan_timer.Tag = data_timer;
                        scan_timer.Interval = Settings.WindowsAssemblyHideTime * 60 * 1000;
                        //   scan_timer.Interval = 30000;
                        scan_timer.Tick += HideAll_timer_Tick;
                        scan_timer.Start();
                        timers.Add(scan_timer);

                    }
                }
            }
        }

        private void WindowsAssembly_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            error_timer.Stop();
            updateTableTimer.Stop();
            foreach (Timer timer in timers) timer.Stop();
            new MainForm().Show();
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
                scanInput(iShippingTxtDataInput.Text);
            }
        }

        private void scanInput(string data)
        {
            if (data == "") return;
            bool exist_prefix = false;
            string[] prefix_data = null;
            string prefix = data.Substring(0, 1);
            foreach (string[] r in Settings.Windows_Assembly_Prefix_Table)
            {
                if (r[(int)PREFIX.PREFIX] == prefix)
                {
                    exist_prefix = true;
                    prefix_data = r;
                    break;
                }
            }
            
            string error_text = null;
            if (exist_prefix)
            {
                string sealed_unit_id = data.Substring(1);
                string[] glassreport = DB.fetchRow("glassreport", "sealed_unit_id", sealed_unit_id);
                if (glassreport == null)
                {
                    //WindowsLblRackID.Text = "ERROR";
                    error_text = "INVALID SEALED UNIT ID!";
                    iShippingTxtDataInput.Text = null;
                }
                else
                {
                    string line_number = glassreport[8];
                    string[] framereport_data = DB.fetchRow("framereport", "LINE #1", line_number, false);
                    if (framereport_data == null)
                    {
                        //WindowsLblRackID.Text = "ERROR";
                        error_text = "INVALID LINE NUMBER!";
                        iShippingTxtDataInput.Text = null;
                    }
                    else
                    {
                        int qty = Convert.ToInt32(framereport_data[1]);
                        List<string[]> windowsassembly_data = DB.importWindowsAssembly(line_number);
                        if (windowsassembly_data != null && windowsassembly_data.Count() >= qty)
                        {
                            //WindowsLblRackID.Text = "ERROR";
                            error_text = "ALREADY SCANNED ALL QUANTITIES";
                        }
                        else
                        {
                            string window_type = "";
                            string qtytotal = null;
                            int qtyorder = 0;
                            int qtycurrentorder = 0;
                            bool exists = false;

                            string[] type_codes = null;
                            string[] sliders = Settings.Slider.Select(x => x[2]).ToArray();
                            string[] casements = Settings.Casement.Select(x => x[2]).ToArray();
                            string[] sus = Settings.SU.Select(x => x[2]).ToArray();
                            string[] shapes = Settings.Shape.Select(x => x[2]).ToArray();

                            string order_number = framereport_data[0].Substring(0, 5);
                            List<string[]> production_report_data = DB.fetchRows("productionreport", "ORDER", order_number);
                            if (production_report_data.Count != 0)
                            {
                                if (Array.IndexOf(sliders, framereport_data[4]) > -1)
                                {
                                    slider_qty++;
                                    SliderLblNumber.Text = slider_qty.ToString();
                                    window_type = "slider";
                                    type_codes = sliders;
                                    qtyorder = Int32.Parse(production_report_data[0][5]);
                                }
                                else if (Array.IndexOf(casements, framereport_data[4]) > -1)
                                {
                                    casement_qty++;
                                    CasementLblNumber.Text = casement_qty.ToString();
                                    window_type = "casement";
                                    type_codes = casements;
                                    qtyorder = Int32.Parse(production_report_data[0][4]);
                                }
                                else if (Array.IndexOf(sus, framereport_data[4]) > -1)
                                {
                                    window_type = "sealed_unit";
                                    type_codes = sus;
                                    qtyorder = Int32.Parse(production_report_data[0][7]);
                                }
                                else if (Array.IndexOf(shapes, framereport_data[4]) > -1)
                                {
                                    shape_qty++;
                                    ShapeLblNumber.Text = shape_qty.ToString();
                                    window_type = "shape";
                                    type_codes = shapes;
                                    qtyorder = Int32.Parse(production_report_data[0][6]);
                                }

                                //type_data = DB.fetchRow("types", "value", framereport_data[4], false);

                                string name = prefix_data[(int)PREFIX.NAME];
                                DateTime now = DateTime.Now;
                                string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");

                                /*for (i = 0; i <frame_report_data.Count(); i++)
                                qtyorder = qtyorder+ Int32.Parse(frame_report_data[i][1]);*/
                                if (windowsassembly_data == null)
                                {
                                    qtytotal = "1 out of " + qty;
                                }
                                else
                                {
                                    qtytotal = windowsassembly_data.Count() + 1 + " out of " + qty;
                                }
                                if (iShippingScanedData.Rows.Count < 10)
                                {
                                    iShippingScanedData.Rows.Insert(0, framereport_data[0], date, time, name);
                                }
                                else
                                {
                                    iShippingScanedData.Rows.RemoveAt(iShippingScanedData.Rows.Count - 1);
                                    iShippingScanedData.Rows.Insert(0, framereport_data[0], date, time, name);
                                }
                                if (DB.saveWindowsAssemblyData(framereport_data[0], date, time, name) == 0)
                                {
                                    for (int i = 0; i < OrderScanedData.Rows.Count; i++)
                                        if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == order_number && OrderScanedData.Rows[i].Cells[1].Value.ToString().ToLower() == window_type)
                                        {
                                            qtycurrentorder = Int32.Parse(OrderScanedData.Rows[i].Cells[3].Value.ToString().Substring(0, OrderScanedData.Rows[i].Cells[3].Value.ToString().IndexOf('/'))) + 1;
                                            OrderScanedData.Rows[i].Cells[3].Value = qtycurrentorder + "/" + qtyorder;
                                            exists = true;
                                            if (qtycurrentorder == qtyorder)
                                            {
                                                OrderScanedData.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                                                if (Settings.WindowsAssemblyHide == "True")
                                                {
                                                    Timer scan_timer = new Timer();
                                                    string[] data_timer = new string[] { order_number, OrderScanedData.Rows[i].Cells[2].Value.ToString() };
                                                    scan_timer.Tag = data_timer;
                                                    scan_timer.Interval = Settings.WindowsAssemblyHideTime * 60 * 1000;
                                                    //scan_timer.Interval = 30000;
                                                    scan_timer.Tick += Hide_timer_Tick;
                                                    scan_timer.Start();
                                                    timers.Add(scan_timer);

                                                }
                                            }
                                        }

                                    if (!exists)
                                    {
                                        List<string> list = new List<string>();
                                        if (type_codes != null)
                                        {
                                            list.AddRange(type_codes.ToArray());
                                        }
                                        List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                                        List<string> su_ids = new List<string>();
                                        foreach (var entry in IDS)
                                        {
                                            su_ids.Add(entry[0]);
                                        }
                                        List<string[]> windows_assembly_table = DB.importWindowsAssemblyByIds(su_ids);

                                        if (windows_assembly_table != null)
                                        {
                                            var result = windows_assembly_table.AsEnumerable()
                                                       .GroupBy(r => r[3])
                                                       .Select(r => new
                                                       {
                                                           Str = r.Key,
                                                           Count = r.Count()
                                                       });
                                            foreach (var element in result)
                                            {
                                                OrderScanedData.Rows.Insert(0, order_number, window_type.ToUpper(), element.Str, element.Count + "/" + qtyorder);
                                                if (windows_assembly_table.Count() == qtyorder)
                                                {
                                                    OrderScanedData.Rows[0].Cells[3].Style.BackColor = Color.Lime;
                                                    if (Settings.WindowsAssemblyHide == "True")
                                                    {
                                                        Timer scan_timer = new Timer();
                                                        string[] data_timer = new string[] { order_number, element.Str };
                                                        scan_timer.Tag = data_timer;
                                                        scan_timer.Interval = Settings.WindowsAssemblyHideTime * 60 * 1000;
                                                        //   scan_timer.Interval = 30000;
                                                        scan_timer.Tick += Hide_timer_Tick;
                                                        scan_timer.Start();
                                                        timers.Add(scan_timer);

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                exists = false;
                                for (int j = 0; j < PrefixQtyData.Rows.Count; j++)
                                {
                                    if (PrefixQtyData.Rows[j].Cells[0].Value.ToString() == name)
                                    {
                                        PrefixQtyData.Rows[j].Cells[1].Value = (Int32.Parse(PrefixQtyData.Rows[j].Cells[1].Value.ToString()) + 1).ToString();
                                        exists = true;
                                        break;
                                    }
                                }
                                if (!exists)
                                {
                                    PrefixQtyData.Rows.Add(name, "1");

                                }
                                windows_number += 1;
                                WindowLblNumber.Text = windows_number.ToString();
                            }
                            else
                            {
                                error_text = "ITEM DOES NOT EXIST IN PRODUCTION REPORT!";
                            }
                        }
                    }
                }
            }
            else
            {
               // WindowsLblRackID.Text = "ERROR";
                error_text = "INVALID PREFIX LETTER!";
            }

            iShippingTxtDataInput.Text = null;
            WindowLblMessage.Text = error_text;
            error_timer.Start();
          
            //if(error_text!=null)  error_message.Show(error_text, "Error");
        }

        private void Hide_timer_Tick(object sender, EventArgs e)
        {
            if (timers.Count != 0)
            {
                foreach (Timer timer in timers)
                {
                    if (timer.Enabled == true)
                    {
                        string[] arr = ((IEnumerable)timer.Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
                        string ord_numb = arr[0];
                        string name = arr[1];

                        for (var i = 0; i < OrderScanedData.Rows.Count; i++)
                        {
                            if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == ord_numb && OrderScanedData.Rows[i].Cells[2].Value.ToString() == name)
                                OrderScanedData.Rows.RemoveAt(i);
                        }
                        timer.Stop();
                        timer.Enabled = false;
                    }
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
                        (OrderScannedTotal.BindingContext[TotalOrders] as CurrencyManager).Refresh();
                        OrderScannedTotal.DataSource = TotalOrders;
                        timer.Enabled = false;
                        timer.Stop();
                        for (int i = 0; i < TotalOrders.Count; i++)
                        {
                            if (TotalOrders[i].Casement_Done == TotalOrders[i].Casement_Total && TotalOrders[i].Casement_Done != 0)
                            {
                                OrderScannedTotal.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                            }
                            if (TotalOrders[i].Slider_Done == TotalOrders[i].Slider_Total && TotalOrders[i].Slider_Done != 0)
                            {
                                OrderScannedTotal.Rows[i].Cells[2].Style.BackColor = Color.Lime;
                            }
                            if (TotalOrders[i].Shape_Done == TotalOrders[i].Shape_Total && TotalOrders[i].Shape_Done != 0)
                            {
                                OrderScannedTotal.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                            }
                            if (TotalOrders[i].Total == TotalOrders[i].Total_Done)
                            {
                                OrderScannedTotal.Rows[i].Cells[4].Style.BackColor = Color.Lime;
                            }
                        }
                    }
                }
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

        private void OrderScanedData_SelectionChanged(object sender, EventArgs e)
        {
            OrderScanedData.ClearSelection();
        }

        private void OrderScannedTotal_SelectionChanged(object sender, EventArgs e)
        {
            OrderScannedTotal.ClearSelection();
        }

        private void PrefixQtyData_SelectionChanged(object sender, EventArgs e)
        {
            PrefixQtyData.ClearSelection();
        }
    }
}
