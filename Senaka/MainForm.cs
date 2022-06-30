
using Microsoft.Reporting.WinForms;
using Senaka.component;
using Senaka.data_sets;
using Senaka.lib;
using Senaka.OrderForms;
using Senaka.print_forms;
using Senaka.ProductionFrameCut;
using Senaka.ReportForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class MainForm : Form
    {
        Timer timer = new Timer(), shutdown_timer = new Timer(), thread = new Timer();
        ProgressDialog progress = new ProgressDialog();
        List<Tuple<string,string, string>> PageControls = new List<Tuple<string, string, string>>();
        List<ToolStripMenuItem> controlCollection = new List<ToolStripMenuItem>();
        List<string[]> controlsToUser = new List<string[]>(), listControls = new List<string[]>();

        string[] order_numbers;
      
        public class Variables
        {
            public static DateTime start_date, end_date;
            public static string paint_company;
        }

        public MainForm()
        {
            InitializeComponent();

            MinimumSize = new Size(800, 600);
            
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            DateTime today = DateTime.Now;
            mainCurrentDate.Text = today.ToString("yyyy-MM-dd");
            mainCurrentTime.Text = today.ToString("HH:mm:ss");
            
            shutdown_timer.Interval = 5000;
            shutdown_timer.Tick += Shutdown_timer_Tick;
            listControls = DB.getControls();
            if (Settings.user.Username != "admin")
            {
                GetControls(Controls);
                HideControls(Controls);
                controlsToUser = DB.getControlsToUser(Settings.user.Id.ToString());
                ShowControls(Controls);
            }
            if (Settings.CloseAppBoolean == "True")
            {
                var hour = Int32.Parse(Settings.Shutdown_Time.Substring(0, Settings.Shutdown_Time.IndexOf(':')));
                var minute = Int32.Parse(Settings.Shutdown_Time.Substring(Settings.Shutdown_Time.LastIndexOf(':') + 1));
                var date = DateTime.Now;
                if (DateTime.Now.Hour > hour) date = DateTime.Now.AddDays(1);
                var timeToShutdown = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0).Subtract(DateTime.Now);

                var timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = timeToShutdown.TotalMilliseconds;
                timer.Start();
            }

            thread.Interval = 1;
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Exit();
        }

        private void ShowControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ShowControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStipItems(menuStrip.Items);
                }
                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage)
                {
                    var Control = listControls.Where(x => x[1] == c.Name).FirstOrDefault();
                    if (Control != null && controlsToUser.Any(x => x[2] == Control[0]))
                        c.Visible = true;
                }
            }
        }

        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                mi.ToolTipText = mi.Name;
                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }
                var Control = listControls.Where(x => x[1] == mi.Name).FirstOrDefault();
                if (Control != null && controlsToUser.Any(x => x[2] == Control[0]))
                {
                    ToolStripMenuItem parent = (ToolStripMenuItem)mi.OwnerItem;
                    while (parent != null)
                    {
                        parent.Visible = true;
                        parent = (ToolStripMenuItem)parent.OwnerItem;
                    }
                    mi.Visible = true;
                }
            }
        }

        private void HideControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    HideControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    HideToolStipItems(menuStrip.Items, c.Text);
                }

                if (c is Button || c is ComboBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage)
                {
                    c.Visible = false;
                }
            }
        }

        private void HideToolStipItems(ToolStripItemCollection toolStripItems, string parent)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {

                mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    HideToolStipItems(mi.DropDownItems, mi.Text);
                }  
                //if (parent != "Settings" && mi.Text != "Date Settings")
                    mi.Visible = false;
            }
        }

        private void GetControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    GetControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    GetToolStipItems(menuStrip.Items, c.Name);
                }
                if (c is Button || c is ComboBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage)
                {
                    if(!listControls.Any(x => x[1]== c.Name))
                    PageControls.Add((new Tuple<string, string, string>(c.Name, c.Text, "")));
                }
            }
        }

        private void GetToolStipItems(ToolStripItemCollection toolStripItems,string parent)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                mi.ToolTipText = mi.Name;
                if (mi.DropDownItems.Count > 0)
                {
                    GetToolStipItems(mi.DropDownItems, mi.Text);
                }
                if (!(new[] { "Settings", "mainMenu", "Database", "Accounts"}).Contains(parent, StringComparer.OrdinalIgnoreCase)
                    || mi.Name== "DateSettingstoolStripMenuItem")
                {
                    if (!listControls.Any(x => x[1] == mi.Name))
                    {
                        PageControls.Add((new Tuple<string, string, string>(mi.Name, mi.Text, parent)));
                        controlCollection.Add(mi);
                    }
                }
            }
        }

        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            mainCurrentDate.Text = today.ToString("yyyy-MM-dd");
            mainCurrentTime.Text = today.ToString("HH:mm:ss");
            if (today.ToString("HH:mm:ss") == Settings.Shutdown_Time + ":00")
            {
                shutdown_timer.Start();
                if (new MessageBoxDialog().Show("The program will close automatically in 5 seconds.", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    shutdown();
                }
                else
                {
                    shutdown_timer.Stop();
                }
            }
        }

        private void Shutdown_timer_Tick(object sender, EventArgs e)
        {
            shutdown();
        }

        private void shutdown()
        {
            timer.Stop();
            shutdown_timer.Stop();
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shutdown();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.G)
            {
                //glass inquire
                glassToolStripMenuItem.PerformClick();
            }
            else if (e.Alt && e.KeyCode == Keys.F)
            {
                //frame inquire
                frameClearingToolStripMenuItem3.PerformClick();
            }
            else if (e.Alt && e.KeyCode == Keys.W)
            {
                //windows assembly
                windowsAssemblyToolStripMenuItem.PerformClick();
            }
            else if (e.Alt && e.KeyCode == Keys.L)
            {
                //frame clearing
                frameClearingToolStripMenuItem.PerformClick();
            }
            else if (e.Alt && e.KeyCode == Keys.H)
            {
                //casement hardware
                CasementHardwareToolStripMenuItem1.PerformClick();
            }
        }

        private void mainBtnProductionReport_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateorDateRangeDialog().InputBox();
            if (list_date != null)
            {
                Variables.start_date = list_date[0];
                Variables.end_date = list_date[1];

                Hide();
                new ProductionForm().Show();
            }
        }

        private void mainBtnGlassReport_Click(object sender, EventArgs e)
        {
            string result = new SelectOrderOrListDate().InputBox();
            List<string[]> data = new List<string[]>();
            DateTime[] date = new SelectDateRangeDialog().InputBox();
            if (date != null)
            {
                data = DB.getGlassLeftOrderSummaryByDate(date, result);
                if (data.Count == 0)
                {
                    new MessageBoxDialog().Show("Not Found Data!", "Error");
                    return;
                }
            }

            Hide();
            new GlassReportForm(data).Show();
        }

        private void mainBtnUrban_Click(object sender, EventArgs e)
        {
            MessageBoxDialog error_message = new MessageBoxDialog();
            string result = new SelectProductionOrListDate().InputBox();
            List<string[]> data = new List<string[]>();
            List<string> numbs = new List<string>();
            if (result == "production")
            {
                DateTime[] list_date = new SelectDateRangeDialog().InputBox();
                if (list_date != null)
                {
                    data = DB.getFrameCutting(list_date);
                    if (data.Count == 0)
                    {
                        error_message.Show("Not Found Data!", "Error");
                        return;
                    }
                }
            }
            else if (result == "current")
            {
                List<string[]> data_FrameClearing = DB.getFrameClearingByDate(DateTime.Today);
                if (data_FrameClearing.Count == 0)
                {
                    error_message.Show("Not Found Data!", "Error");
                    return;
                }
                else
                {
                    for (int i = 0; i < data_FrameClearing.Count; i++) numbs.Add(data_FrameClearing[i][0]);
                    data = DB.getFrameCuttingByNumbs(numbs);
                }
            }
            else if (result == "list")
            {
                DateTime[] list_date = new SelectDateRangeDialog().InputBox();
                if (list_date != null)
                {
                    List<string[]> data_glass = DB.getGlassByDates(list_date);
                    if (data_glass.Count == 0)
                    {
                        error_message.Show("Not Found Data!", "Error");
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < data_glass.Count; i++) numbs.Add(data_glass[i][20]);
                        data = DB.getFrameCuttingByOrder(numbs);
                        if (data.Count == 0)
                        {
                            error_message.Show("Not Found Data!", "Error");
                            return;
                        }
                    }
                }
            }
            Hide();
            new FrameClearingReportForm(data, numbs).Show();
        }

        private void mainBtnForel_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            List<string[]> data = DB.importGlassByListDate(new DateTime[] { today, today });
            Hide();
            new CurrentProductionForm(data).Show();
        }

        private void mainBtnGlassInquire_Click(object sender, EventArgs e)
        {
            Hide();
            new IGInquireForm().Show();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                scanInput(searchBox.Text);
            }
        }

        private void scanInput(string data)
        {
            if (data == "") return;

            IFormatProvider culture = new CultureInfo("en-US", true);
            try
            {
                List<string[]> production_report_data = DB.importProductionReport(data);
                List<string[]> work_order_data = new List<string[]>();
                if (production_report_data.Count != 0)
                {
                    work_order_data = DB.importWorkOrderbyOrderNumb(data);
                }
                else if ((work_order_data = DB.importWorkOrderbyPO(data)).Count != 0)
                {
                    production_report_data = DB.importProductionReport(work_order_data[0][0]);
                }
                int completed = 0, windows_assembled = 0, complete_c_w_c = 0;
                string paint_company = "", paint_company_name = "", send_date = "", received_date = "", order_number = "", frame_send = "";
                if (work_order_data.Count != 0)
                {
                    List<string[]> glass = DB.importGlassyOrderNumb(work_order_data[0][0]);
                    if (glass.Count != 0)
                    {
                        List<string> su_id = new List<string>();
                        for (var i = 0; i < glass.Count; i++)
                        {
                            su_id.Add(glass[i][2]);
                        }
                        completed = DB.importIgSorting(su_id).Count;

                    }
                    windows_assembled = DB.importFrameReport(data).Count;
                    order_number = work_order_data[0][0];
                }
                else order_number = data;
                List<string[]> frames_cutting_data = DB.getFrameCuttingByOrderNumber(order_number);
                if (frames_cutting_data.Count != 0)
                {
                    List<string> ids = new List<string>();
                    DateTime temp = DateTime.ParseExact(frames_cutting_data[0][21], "yyyyMMdd", CultureInfo.InvariantCulture);
                    frame_send = temp.ToString("yyyy-MM-dd");
                    for (var i = 0; i < frames_cutting_data.Count; i++)
                    {
                        ids.Add(frames_cutting_data[i][6]);
                    }
                    complete_c_w_c = DB.getFrameClearingByIds(ids).Count;
                    string[] ColourShipping = DB.getColourShippingByIds(ids);
                    if (ColourShipping != null)
                    {
                        paint_company_name = ColourShipping[3];
                        string[] ColourShippingPrefix = DB.getColourShippingPrefix(paint_company_name);
                        if (ColourShippingPrefix != null) paint_company = ColourShippingPrefix[2];
                        send_date = ColourShipping[1].Substring(0, 10);
                    }
                    string[] ColourReceiving = DB.getColourReceivingByIds(ids);
                    if (ColourReceiving != null)
                    {
                        received_date = ColourReceiving[1].ToString().Substring(0, 10);
                    }
                }
                Hide();
                new SearchResult(
                    production_report_data,
                    completed,
                    windows_assembled,
                    paint_company,
                    send_date,
                    received_date,
                    frame_send,
                    complete_c_w_c,
                    work_order_data
                ).Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        /*
            Menu Event
        */

        /*
            Data Input Menu
        */
        //IG Shipping
        private void mnuIGShipping_Click(object sender, EventArgs e)
        {
            Hide();
            new IGShippingForm().Show();
        }

        //IG Sorting
        private void mnuIGSorting_Click(object sender, EventArgs e)
        {
            Hide();
            new IGSortingForm().Show();
        }

        //Windows Assembly
        private void windowsAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new WindowsAssebly().Show();
        }

        //Frame Clearing
        private void frameClearingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            new FrameClearingForm().Show();
        }

        //Casement Hardware
        private void casementHardwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new CasementHardwareForm().Show();
        }

        //Colour Shipping
        private void colourShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new ColourShipping().Show();
        }

        //Colour Received
        private void colourDeliveredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new ColourReceiving().Show();
        }

        //WindowsShipping
        private void windowsShippingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new WindowsShipping().Show();
        }

        //Frame Assembly
        private void frameAssemblyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new FrameAssembly().Show();
        }

        //Windows Wrapping
        private void windowsWrappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new WindowsWrapping().Show();
        }

        //Patio Doors Receiving
        private void patioDoorsReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new PatioDoorsReceiving().Show();
        }

        //Patio Doors Shipping
        private void patioDoorsShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new PatioDoorsShipping().Show();
        }

        //Glass Recut
        private void glassRecutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new GlassRecut().Show();
        }

        //DV Coatex Color Shipping
        private void dVCoatexColorShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new DVCoatexColorShipping().Show();
        }

        //DV Coatex Color Receiving
        private void dVCoatexColorReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new DVCoatexColorReceiving().Show();
        }

        //Express Coating Color Receving
        private void expressCoatingColorReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new ExpressCoatingColorReceiving().Show();
        }

        //Express Coating Color Shipping
        private void expressCoatingColorShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new ExpressCoatingColorShipping().Show();
        }

        //Vinylpro Frame Receving
        private void vinylproFrameReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new VinylproFrameReceiving().Show();
        }

        //Vinylpro Frame Shipping
        private void vinylproFrameShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new VinylproFrameShipping().Show();
        }

        //Frame Recut
        private void frameRecutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new FrameRecut().Show();
        }

        /*
            Booking Menu
        */
        //3350 Langstaff
        private void langstaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            DateTime from = DateTime.Today, to = from.AddDays(Int32.Parse(Settings.BookDueDate) - 1);
            List<string[]> orders_duedate = DB.getOrderSummaryByDueDate(from, to);
            List<string> order_numbers = new List<string>();
            foreach (var element in orders_duedate)
            {
                order_numbers.Add(element[1]);
            }
            new MessageBoxDueDateOrders(order_numbers).ShowDialog();
            DateTime? list_date = new SelectDateDialogBooking().InputBox();
            if (list_date != null)
            {
                if (!(list_date.Value > from && list_date.Value <= to.AddDays(1)))
                {
                    new BookingListMessageBox(Settings.BookListDate_Message).ShowDialog();
                }
                new BookingForm(list_date, "3350 Langstaff").Show();
            }
            else
            {
                Show();
            }
        }

        //100 Jacob Keffer
        private void jacobKefferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            DateTime from = DateTime.Today, to = from.AddDays(Int32.Parse(Settings.BookDueDate) - 1);
            List<string[]> orders_duedate = DB.getOrderSummaryByDueDate(from, to);
            List<string> order_numbers = new List<string>();
            foreach (var element in orders_duedate)
            {
                order_numbers.Add(element[1]);
            }
            new MessageBoxDueDateOrders(order_numbers).ShowDialog();
            DateTime? list_date = new SelectDateDialogBooking().InputBox();
            if (list_date != null)
            {
                if (!(list_date.Value > from && list_date.Value <= to.AddDays(1)))
                {
                    new BookingListMessageBox(Settings.BookListDate_Message).ShowDialog();
                }
                new BookingForm(list_date, "100 Jacob Keffer").Show();
            }
            else
            {
                Show();
            }
        }


        /*
            Place an order Menu
        */
        //24 Hour Thermal Glass
        private void hourThermalGlassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new HourThermalGlassForm().Show();
        }

        //Woodbridge Glass
        private void woodbridgeGlassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new WoodbridgeForm().Show();
        }

        //Vista Patio Doors
        private void vistaPatioDoorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new VistaPatioDoorsForm().Show();
        }

        //Oceanview Patio Doors
        private void oceanviewPatioDoorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new OceanviewPatioDoorsForm().Show();
        }

        //Energi Woodbridge

        /*
            Order received Menu
        */
        //24 Hour Thermal Glass

        //Woodbridge Glass

        //Energi Woodbridge


        /*
            Data Processing
        */
        //Glass Optimize
        private void glassOptimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new OptimizeForm().Show();
        }

        //Paint Schedule
        private void paintScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            if (list_date != null)
            {
                List<string[]> data_order = DB.getOrderByDates(list_date);
                if (data_order.Count == 0)
                {
                    new MessageBoxDialog().Show("Not Found Data!", "Error");
                    return;
                }
                else
                {
                    Hide();
                    new PaintScheduleForm(data_order, list_date).Show();
                }
            }
        }

        private void hardwareAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        /*
            Production cut list Menu
        */
        //Colour Frame Cut
        private void colourFrameCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateorDateRangeDialog().InputBox();
            if (list_date != null)
            {
                string paintCompany = new SelectPaintCompanyDialog().InputBox();
                if (paintCompany != null)
                {
                    Variables.start_date = list_date[0];
                    Variables.end_date = list_date[1];
                    Variables.paint_company = paintCompany;
                    Hide();
                    new ColourFrameCut().Show();
                }
            }
        }

        //Urban Frame Cut

        //Urban Frame Cut- Rush

        //Bottero Glass Cut

        //Bottero Glass Cut- Rush

        /*
            Reports Menu
        */
        //Windows assembly
        private void windowsAssemblyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            DateTime start, end = new DateTime();
            string type;
            if (list_date != null)
            {
                start = list_date[0];
                if (list_date.Length == 1)
                {
                    type = "date";
                }
                else
                {
                    end = list_date[1];
                    type = "range";
                }
                Hide();
                new WindowsAssemblyReport(start, end, type).Show();
            }
        }

        //Frame clearing
        private void frameClearingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            DateTime start, end = new DateTime();
            string type;
            if (list_date != null)
            {
                start = list_date[0];
                if (list_date.Length == 1)
                {
                    type = "date";
                }
                else
                {
                    end = list_date[1];
                    type = "range";
                }
                Hide();
                new FrameClearingReport(start, end).Show();
            }
        }

        //Colour shipping
        private void colourShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new ColourShippingReport(start, end, batch_numb, onlyBatch).Show();
            }
            else
            {
                MessageBox.Show("No orders!", "Error");
            }
        }

        //Colour receiving
        private void colourReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new ColourReceivingReport(start, end, batch_numb, onlyBatch).Show();
            }
        }

        //Casement Hardware
        private void casementHardwareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            if (list_date != null)
            {
                Hide();
                new CasementHardwareReport(list_date[0], list_date[1]).Show();
            }
        }

        //Glass Recut
        private void glassRecutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new GlassRecutReport().Show();
        }

        //Work schedule
        private void workScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime? list_date = new SelectDateDialogBooking().InputBox();
            if (list_date != null)
            {
                Hide();
                new WorkScheduleReport(list_date).Show();
            }
        }

        //Rush Order
        private void rushOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new RushOrderReport().Show();
        }

        //DV Coatex Color Receiving
        private void dVCoatexColorReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalReceivingReport("DVCoatexColorReceiving", start, end, batch_numb, onlyBatch).Show();
            }
        }

        //DV Coatex Color Shipping
        private void dVCoatexColorShippingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalShippingReport("DVCoatexColorShipping", start, end, batch_numb, onlyBatch).Show();
            }
            else MessageBox.Show("No orders!", "Error");
        }

        //Express Coating Color Receiving
        private void expressCoatingColorReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalReceivingReport("ExpressCoatingColorReceiving", start, end, batch_numb, onlyBatch).Show();
            }
        }

        //Express Coating Color Shipping
        private void expressCoatingColorShippingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalShippingReport("ExpressCoatingColorShipping", start, end, batch_numb, onlyBatch).Show();
            }
            else MessageBox.Show("No orders!", "Error");
        }

        //Vinylpro Frame Receiving
        private void vinylproFrameReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalReceivingReport("VinylproFrameReceiving", start, end, batch_numb, onlyBatch).Show();
            }
        }

        //Vinylpro Frame Shipping
        private void vinylproFrameShippingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog().InputBox();
            if (result != null)
            {
                DateTime start = result.Item1[0], end = result.Item1[1];
                string batch_numb = result.Item2, onlyBatch = result.Item3;

                Hide();
                new UniversalShippingReport("VinylproFrameShipping", start, end, batch_numb, onlyBatch).Show();
            }
            else MessageBox.Show("No orders!", "Error");
        }

        //Frame Recut
        private void frameRecutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new FrameRecutReport().Show();
        }

        //Production Count
        private void productionCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateorDateRangeDialog().InputBox();
            if (list_date != null)
            {
                Variables.start_date = list_date[0];
                Variables.end_date = list_date[1];

                Hide();
                new ProductionCountReport().Show();
            }
        }

        //Frame shipping 
        private void frameShippingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            if (list_date != null)
            {
                List<string[]> data_order = DB.getOrderByDates(list_date);
                if (data_order.Count == 0)
                {
                    new MessageBoxDialog().Show("Not Found Data!", "Error");
                    return;
                }
                else
                {
                    Hide();
                    new FrameShippingReportForm(data_order, list_date[0], list_date[1]).Show();
                }
            }
        }

        //Frame receiving
        private void frameReceivingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] list_date = new SelectDateRangeDialog().InputBox();
            if (list_date != null)
            {
                List<string[]> data_order = DB.getOrderByDates(list_date);
                if (data_order.Count == 0)
                {
                    new MessageBoxDialog().Show("Not Found Data!", "Error");
                    return;
                }
                else
                {
                    Hide();
                    new FrameReceivingReportForm(data_order, list_date[0], list_date[1]).Show();
                }
            }
        }

        //Shipping summary
        private void shippingSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime[] dates = new SelectDateRangeDialog().InputBox();
            if (dates != null)
            {
                List<string[]> shippingsummary = DB.getWindowsShippingByDate(dates);
                if (shippingsummary.Count == 0)
                {
                    new MessageBoxDialog().Show("Not Found Data!", "Error");
                    return;
                }
                else
                {
                    Hide();
                    new ShippingSummaryForm(shippingsummary, dates).Show();
                }
            }
        }

        //Shipping report
        private void shippingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string[]> reference = DB.getReferenceFromWindowsShipping();
            Tuple<DateTime[], string, string> result = new SelectDateRangeAndNumberDialog(reference).InputBox();
            if (result == null) return;
            DateTime start = result.Item1[0], end = result.Item1[1];
            string batch_numb = result.Item2;
            if (batch_numb == "")
            {
                MessageBox.Show("Please input batch number!", "Error");
                return;
            }
            List<string[]> report_data = DB.getShippingReportByBatchDate(new DateTime[] { start, end }, batch_numb);
            if (report_data.Count == 0)
            {
                MessageBox.Show("Not found data!", "Error");
                return;
            }
            Hide();
            new ShippingReportForm(new DateTime[] { start, end }, batch_numb, report_data).Show();
        }

        /*
            Inquire 
        */
        //Glass
        private void glassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Glass Inquire").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("glassreport", "order", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new IGInquireSubForm(data).Show();
            }
        }

        //Frame clearing
        private void frameClearingToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Frame Clearing Inquire").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }
                foreach (var element in Settings.Casing)
                {
                    data.RemoveAll(x => x[7] == element[2]);
                }

                Hide();
                new InquireForm(data, "frameClearing").Show();
            }
        }

        //Windows assembly
        private void windowsAssemblyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Windows Assembly Inquire").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.importFrameReportbyLine(order_number);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new InquireForm(data, "windowsAssembly").Show();
            }
        }

        //Colour Frame
        private void colourFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Colour Frame Inquire").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }
                foreach (var element in Settings.Casing)
                {
                    data.RemoveAll(x => x[7] == element[2]);
                }

                Hide();
                new InquireForm(data, "Colour").Show();
            }
        }

        //Casement Hardware
        private void casementHardwareToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Casement Hardware Inquire").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new InquireForm(data, "CasementHardware").Show();
            }
        }

        //DVCoatex Color
        private void dVCoatexColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("DVCoatex Color").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }
                foreach (var element in Settings.Casing)
                {
                    data.RemoveAll(x => x[7] == element[2]);
                }

                Hide();
                new UniversalInquireForm(data, "DVCoatexColor").Show();
            }
        }

        //Express Coating Color
        private void expressCoatingColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Express Coating Color").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }
                foreach (var element in Settings.Casing)
                {
                    data.RemoveAll(x => x[7] == element[2]);
                }

                Hide();
                new UniversalInquireForm(data, "ExpressCoatingColor").Show();
            }
        }

        //Vinylpro Frame
        private void vinylproFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Vinylpro Frame").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }
                foreach (var element in Settings.Casing)
                {
                    data.RemoveAll(x => x[7] == element[2]);
                }

                Hide();
                new UniversalInquireForm(data, "VinylproFrame").Show();
            }
        }

        //List Date
        private void listDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("List Date").InputBox();
            if (string.IsNullOrEmpty(order_number))
            {
                Hide();
                new OrderSummaryInquireForm(order_number).Show();
            }
        }

        //Windows Shipping
        private void windowsShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Windows Shipping").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("workorder", "ORDER #", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new WindowsShippingInquireForm(data).Show();
            }
        }

        /*
            Notification
        */
        //Complete Orders
        private void completeOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Notification_Active_Password && new BookingPasswordForm().InputBox() != Settings.Notification_Password)
            {
                MessageBox.Show("Incorrect Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            order_numbers = new SelectOrderDialog(30, "Send Text").InputBox();
            if (order_numbers.Length == 0) return;
            timer.Tick += Notification_Tick;
            timer.Start();

            progress.Show();
        }

        private async void Notification_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= Notification_Tick;

            List<string[]> data = DB.getWorkOrderDataGroupByOrder(order_numbers);
            if (data.Count == 0)
            {
                progress.Hide();
                MessageBox.Show("Invalid Order Number!", "Error");
                return;
            }
            string message, body, campaignId = Settings.TrueDialog_CampaignId;
            foreach (string[] order in data)
            {
                foreach (string[] dealer in Settings.Notification_Dealers)
                {
                    if (order[4] == dealer[0] && !string.IsNullOrWhiteSpace(dealer[2])
                        && (!Settings.Notification_Consider_Tag || (order[3] == dealer[1])))
                    {
                        message = Settings.Notification_Upper_Message
                            + "\nOrder Number: " + order[1]
                            + "\nCustomer PO: " + order[2]
                            + "\n" + Settings.Notification_Down_Message;
                        body = "{\"channels\":[22],\"roundRobinById\":false,\"globalRoundRobin\":false,\"targets\":[\"" + dealer[2] + "\"],\"campaignId\":" + campaignId + ",\"message\":\"" + message + "\",\"forceOptIn\":true,\"ignoreInvalidTargets\":true,\"execute\":true}";

                        using (var httpClient = new HttpClient { BaseAddress = new Uri(Settings.TrueDialog_APIURL) })
                        {
                            string authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(Settings.TrueDialog_KEY + ":" + Settings.TrueDialog_SECRET));
                            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Basic " + authorization);
                            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "account/" + Settings.TrueDialog_AccountId + "/action-pushcampaign");
                            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                            await httpClient.SendAsync(request).ContinueWith(responseTask => {});
                        }
                    }
                }
            }
            progress.Hide();
            MessageBox.Show("Successfully sent", "Notification");
        }

        /*
            Document
        */
        //Shape PDF
        private void shapePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.ShapePDF_Path))
            {
                MessageBox.Show("Cannot find directory. Please input direct for Shape PDF in settings page.");
                Hide();
                new SettingForm(42).Show();
                return;
            }
            new ShapePDFDialog().ShowDialog();
        }

        //Bay -> Option1
        private void option1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new BayCalculatorForm().Show();
        }

        /*
            Service
        */

        /*
            Task Board
        */
        private void taskBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new TaskBoardForm().Show();
        }

        /*
            Print Labels
        */
        //Glass
        private void glassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Glass Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("glassreport", "order", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new GlassLabelPrint(data).Show();
            }
        }

        //Windows Assembly
        private void windowsAssemblyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Windows Assembly Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.importFrameReportbyLine(order_number);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new WindowsAssemblyPrint(data).Show();
            }
        }

        //Frame
        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Frame Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new FramePrint(data).Show();
            }
        }

        //Custom
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new CustomLabelForm().Show();
        }

        //Casement Assembly
        private void casementAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Casement Assembly Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string> casements = Settings.Casement.Select(x => x[2]).ToList();
                List<string[]> data = DB.importFramereportbyIDandType(order_number, casements);
                if (data.Count == 0)
                {
                    MessageBox.Show("No data!", "Error");
                    return;
                }

                Hide();
                new WindowsAssemblyPrint(data).Show();
            }
        }

        //Slider Assembly
        private void sliderAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Slider Assembly Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string> sliders = Settings.Slider.Select(x => x[2]).ToList();
                List<string[]> data = DB.importFramereportbyIDandType(order_number, sliders);
                if (data.Count == 0)
                {
                    MessageBox.Show("No data!", "Error");
                    return;
                }

                Hide();
                new WindowsAssemblyPrint(data).Show();
            }
        }

        //Shape Assembly
        private void shapeAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Shape Assembly Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string> shapes = Settings.Shape.Select(x => x[2]).ToList();
                List<string[]> data = DB.importFramereportbyIDandType(order_number, shapes);
                if (data.Count == 0)
                {
                    MessageBox.Show("No data!", "Error");
                    return;
                }

                Hide();
                new WindowsAssemblyPrint(data).Show();
            }
        }

        //Casing
        private void casingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Case Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new CasingPrint(data).Show();
            }
        }

        //Casing by orders
        private void casingByOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] order_numbers = new SelectOrderDialog().InputBox();
            if (order_numbers.Length == 0) return;
            
            List<string[]> data = DB.getFrameCuttingByOrder(order_numbers.ToList());
            List<string> lineNumbers = new List<string>();
            foreach (var element in data)
            {
                lineNumbers.Add(element[19]);
            }
            if (lineNumbers.Count == 0) return;
            CasingDataSet casingDataSet = new CasingDataSet();
            List<string[]> workOrderData = DB.importWorkOrderByLines(lineNumbers);
            foreach (var element in data)
            {
                string compnayName = "", customerPO = "";
                List<string[]> currentWorkOrder = workOrderData.Where(x => x[9] == element[19]).ToList();
                if (currentWorkOrder.Count > 0)
                {
                    compnayName = currentWorkOrder[0][3];
                    customerPO = currentWorkOrder[0][1];
                }
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, element[6], 360, 80);
                byte[] barcode = ImageToByteArray(img);
                casingDataSet.Tables[0].Rows.Add(new Tuple<byte[], string, string, string>(barcode, element[19], compnayName, customerPO));
            }
            if (casingDataSet.Tables[0].Rows.Count != 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = casingDataSet.Tables[0];
                new UniversalPrint(rds, null, @"reports\CasingLabel.rdlc").Show();
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        //Work Order
        private void workOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Work Order Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("workorder", "ORDER #", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new WorkOrderPrint(data).Show();
            }
        }

        //Production
        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string order_number = new InsertOrderDialog("Case Print").InputBox();
            if (!string.IsNullOrEmpty(order_number))
            {
                List<string[]> data = DB.fetchRows("glassreport", "order", order_number, false);
                if (data.Count == 0)
                {
                    MessageBox.Show("Invalid Order Number!", "Error");
                    return;
                }

                Hide();
                new ProductionByOrdersPrint(data).Show();
            }
        }

        //Production by orders
        private void productionByOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] order_numbers = new SelectOrderDialog().InputBox();
            if (order_numbers.Length == 0) return;
            List<string[]> data = DB.fetchRows("glassreport", "order", order_numbers, false);
            if (data.Count == 0)
            {
                MessageBox.Show("Invalid Order Number!", "Error");
                return;
            }

            Hide();
            new ProductionByOrdersPrint(data).Show();
        }

        /*
            Print reports
        */
        //Frame reports
        private void frameReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] order_numbers = new SelectOrderDialog().InputBox();
            if (order_numbers.Length == 0) return;

            Hide();
            new FrameReportPrint(order_numbers.ToList()).Show();
        }

        /*
            Edit record
        */
        //Glass Report
        private void glassEditRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new GlassEditRecordForm().Show();
        }

        /*
            Accounts
        */
        //Users
        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new AccountForm().Show();
        }

        /*
            Settings
        */
        //General Setting
        private void mnuGeneralSetting_Click(object sender, EventArgs e)
        {
            Hide();
            SettingForm settingForm = new SettingForm(0);
            settingForm.Show();
        }

        //Optimize
        private void mnuOptimizeSetting_Click(object sender, EventArgs e)
        {
            Hide();
            SettingForm settingForm = new SettingForm(1);
            settingForm.Show();
        }

        //IG Sorting
        private void mnuIGSoringSetting_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(2).Show();
        }

        //IG Shipping
        private void mnuIGShippingSetting_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(3).Show();
        }

        //Windows Assembly
        private void WindowsAssemblyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(4).Show();
        }

        //Frame Clearing
        private void frameClearingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(5).Show();
        }

        //Frame Clearing Types
        private void frameClearingTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(6).Show();
        }

        //Casement Hardware
        private void casementHardwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(7).Show();
        }

        //Colour Shipping
        private void colourShippingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(8).Show();
        }

        //Colour Shipping
        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(9).Show();
        }

        //Email
        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(10).Show();
        }

        //Oceanview Patio Doors Fields
        private void oceanviewPatioDoorsFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(11).Show();
        }

        //Vista Patio Doors Fields
        private void vistaPatioDoorsFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(12).Show();
        }

        //24Hour Thermal Glass Cut To Size
        private void hourThermalGlassCutToSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(13).Show();
        }

        //24 Hour Thermal Glass Sheets
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(14).Show();
        }

        //24Hour Thermal Glass Unit
        private void hourThermalGlassUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(15).Show();
        }

        //Woodbridge- Stock Sheet
        private void woodbridgeStockSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(16).Show();
        }

        //Woodbridge - Cut to Size
        private void woodbridgeCutToSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(17).Show();
        }

        //Date Settings
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new DateSettingsForm().Show();
        }

        //Oceanview Patio Doors Email
        private void oceanviewPatioDoorsEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(20).Show();
        }

        //Vista Patio Email
        private void vistaPatioEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(18).Show();
        }

        //Woodbridge Email
        private void woodbridgeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(21).Show();
        }

        //24Hour Thermal Glass Email
        private void hourThermalGlassEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(19).Show();
        }

        //Task Board Email
        private void taskBoardEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(22).Show();
        }

        //Windows Shipping
        private void windowsShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(23).Show();
        }

        //Frame Assembly
        private void frameAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(24).Show();
        }

        //Windows Wrapping
        private void windowsWrappingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(25).Show();
        }

        //Patio Doors Receiving
        private void patioDoorsReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(26).Show();
        }

        //Patio Doors Shipping
        private void patioDoorsShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            SettingForm settingForm = new SettingForm(27);
            settingForm.Show();
        }

        //Glass Recut
        private void glassRecutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(28).Show();
        }

        //Booking
        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(29).Show();
        }

        //Slider Types
        private void sliderTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(30).Show();
        }

        //Express Coating Color Shipping
        private void expressCoatingColorShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(31).Show();
        }

        //Express Coating Color Receiving
        private void expressCoatingColorReceivingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(32).Show();
        }

        //DV Coatex Color Shipping
        private void dVCoatexColorShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(33).Show();
        }

        //DV Coatex Color Receiving
        private void dVCoatexColorReceivingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(34).Show();
        }

        //Vinylpro Frame Shipping
        private void vinylproFrameShippingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(35).Show();
        }

        //Vinylpro Frame Receiving
        private void vinylproFrameReceivingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(36).Show();
        }

        //Frame Recut
        private void FrameRecutMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(37).Show();
        }

        //Production Cut
        private void ProductionCutMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(38).Show();
        }

        //Paint Companies
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(39).Show();
        }

        //Production Frame Types
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(40).Show();
        }

        //Notification
        private void textNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(41).Show();
        }

        //Shape PDF
        private void ShapePDFSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(42).Show();
        }

        //Shipping Report
        private void shippingReportSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            new SettingForm(43).Show();
        }


        /*
            Database
        */
        //Settings
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Hide();
            new DatabaseSettingsForm().Show();
        }
    }
}