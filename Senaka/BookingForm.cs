using Microsoft.Reporting.WinForms;
using Senaka.component;
using Senaka.data_sets;
using Senaka.lib;
using Senaka.print_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Senaka
{
    public partial class BookingForm : Form
    {
        public static System.Windows.Forms.Timer IdleTimer = new System.Windows.Forms.Timer();
        private int mDialogCount;
        DateTime? _date;
        string _location;
        List<string> columns;
        int TotalBWhiteWindows, TotalBColourWindows, TotalNBWhiteWindows, TotalNBColourWindows, TotalBooked, TotalNotBooked;
        List<string[]> ordersummary;
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        object CellValue;
       
        public class Data_order
        {
            public string Status { get; set; }
            public string Order { get; set; }
            public string Company { get; set; }
            public int CS { get; set; }
            public int VF { get; set; }
            public int SL { get; set; }
            public int SH { get; set; }
            public int BY { get; set; }
            public int BW { get; set; }
            public int DW { get; set; }
            public int SU { get; set; }
            public int SS { get; set; }
            public int GRL { get; set; }
            public int SDL { get; set; }
            public int BOW { get; set; }
            public string EXT { get; set; }
            public string Casing { get; set; }
            public int PDoor { get; set; }
            public string ColourIn { get; set; }
            public string ColourOut { get; set; }
            public string Addition_info { get; set; }
            public string Note { get; set; }
            public int Windows_done { get; set; }
            public int Windows_total { get; set; }
        }

        public BookingForm(DateTime? date, string location)
        {
            InitializeComponent();

            _date = date;
            labelDate.Text = _date.Value.ToString("dd- MMMM yyyy");
            _location = location;
            labelLocation.Text = _location;

            DataTable schema = DB.GetTableSchema("ordersummary");
            columns = new List<string>();
            foreach (DataRow col in schema.Rows)
            {
               columns.Add(col.Field<String>("ColumnName"));
            }

            int i;
            int NBCasement = 0, NBSlider = 0, NBShape = 0, NBBayBow = 0, NBSU = 0, NBPDoor = 0,
                NBWhiteWindows = 0, NBColourWindows = 0;
            List<string[]> NotBooked_ordersummary = DB.getNotBookedOrderSummary(Settings.BookDateFilterType, Settings.BookDateFilter);
            foreach (var element in NotBooked_ordersummary)
            {
                Data_order row = new Data_order();
                foreach (var name_type in Settings.Window_Casement)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.CS += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Fix)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.VF += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Slider)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SL += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Shape)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Sdwind)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Dummy)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.DW += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SU)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SU += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SUSHP)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SS += Int32.Parse(c);
                }
                string co = element[columns.IndexOf("PATIO DOOR")];
                if (co != "") row.PDoor = Int32.Parse(co);
                co = element[columns.IndexOf("BAY")];
                if (co != "") row.BY = Int32.Parse(co);
                co = element[columns.IndexOf("BOW")];
                if (co != "") row.BOW += Int32.Parse(co);
                row.ColourIn = element[columns.IndexOf("COLOUR IN")];
                row.ColourOut = element[columns.IndexOf("COLOUR OUT")];
                NBCasement += row.CS;
                NBCasement += row.VF;
                NBCasement += row.DW;
                NBSlider += row.SL;
                NBShape += row.SH;
                NBBayBow += row.BY;
                NBBayBow += row.BOW;
                NBSU += row.SU;
                NBSU += row.SS;
                NBPDoor += row.PDoor;
                if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
                {
                    NBWhiteWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                }
                else
                {
                    NBColourWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                }
            }
            TotalNotBooked = NBCasement + NBSlider + NBShape;
            labelTotalNotBooked.Text = TotalNotBooked.ToString();
            labelCasementNotBooked.Text = NBCasement.ToString();
            labelSliderNotBooked.Text = NBSlider.ToString();
            labelShapeNotBooked.Text = NBShape.ToString();
            labelBayBowNotBooked.Text = NBBayBow.ToString();
            labelSUNotBooked.Text = NBSU.ToString();
            labelPDoorNotBooked.Text = NBPDoor.ToString();
            TotalNBWhiteWindows = NBWhiteWindows;
            TotalNBColourWindows = NBColourWindows;
            if (NBWhiteWindows != 0 || NBColourWindows != 0)
            {
                DrawPieChart(chartNotBooked, NBWhiteWindows, NBColourWindows, "Not Booked");
            }

            int BCasement = 0, BSlider = 0, BShape = 0, BBayBow = 0, BSU = 0, BPDoor = 0,
                BWhiteWindows = 0, BColourWindows = 0;
            List<Data_order> BookingList = new List<Data_order>();
            List<string> order_numbers = new List<string>();
            ordersummary = DB.getBookedOrderSummary(_date.Value.ToString("yyyyMMdd"), _location);
            foreach (var element in ordersummary)
            {
                Data_order row = new Data_order();
                row.Order = element[columns.IndexOf("ORDER#")];
                row.Company = element[columns.IndexOf("COMPANY")];
                foreach (var name_type in Settings.Window_Casement)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.CS += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Fix)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.VF += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Slider)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SL += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Shape)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Sdwind)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Dummy)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.DW += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SU)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SU += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SUSHP)
                {
                    i = columns.IndexOf(name_type[2]);
                    string c = (i >= 0 && i < element.Length) ? element[i] : "";
                    if (c != "") row.SS += Int32.Parse(c);
                }
                string co;
                co = element[columns.IndexOf("GRILL")];
                if (co != "") row.GRL = Int32.Parse(co);
                co = element[columns.IndexOf("GRILL")];
                if (co != "") row.GRL = Int32.Parse(co);
                co = element[columns.IndexOf("SDL")];
                if (co != "") row.SDL = Int32.Parse(co);
                row.EXT = element[columns.IndexOf("EXT")];
                row.Casing = element[columns.IndexOf("CASING")];
                co = element[columns.IndexOf("BAY")];
                if (co != "") row.BY = Int32.Parse(co);
                co = element[columns.IndexOf("PATIO DOOR")];
                if (co != "") row.PDoor = Int32.Parse(co);
                co = element[columns.IndexOf("BOW")];
                if (co != "") row.BOW += Int32.Parse(co);
                row.ColourIn = element[columns.IndexOf("COLOUR IN")];
                row.ColourOut = element[columns.IndexOf("COLOUR OUT")];
                row.Addition_info = element[columns.IndexOf("STATUS")];
                row.Note = element[columns.IndexOf("NOTE")];
                BCasement += row.CS;
                BCasement += row.VF;
                BCasement += row.DW;
                BSlider += row.SL;
                BShape += row.SH;
                BBayBow += row.BY;
                BBayBow += row.BOW;
                BSU += row.SU;
                BSU += row.SS;
                BPDoor += row.PDoor;
                if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
                {
                    BWhiteWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                }
                else
                {
                    BColourWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                }
                BookingList.Add(row);
                order_numbers.Add(row.Order);
            }
            TotalBooked = BCasement + BSlider + BShape;
            labelTotalBooked.Text = TotalBooked.ToString();
            labelCasementBooked.Text = BCasement.ToString();
            labelSliderBooked.Text = BSlider.ToString();
            labelShapeBooked.Text = BShape.ToString();
            labelBayBowBooked.Text = BBayBow.ToString();
            labelSUBooked.Text = BSU.ToString();
            labelPDoorBooked.Text = BPDoor.ToString();
            TotalBWhiteWindows = BWhiteWindows;
            TotalBColourWindows = BColourWindows;
            if (BWhiteWindows != 0 || BColourWindows != 0)
            {
                DrawPieChart(chartBooked, BWhiteWindows, BColourWindows, "Booked");
            }
            List<string[]> windowsAssembly_report = DB.importWindowsAssemblybyOrder(order_numbers);
            if(windowsAssembly_report != null)
            {
                for (i = 0; i < windowsAssembly_report.Count; i++)
                {
                    string order_numb = windowsAssembly_report[i][0].Substring(0, 5);
                    BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_done += 1;
                }
            }
            List<string[]> FrameReport = DB.importFramereportbyIDs(order_numbers);
            if (FrameReport != null)
            {
                for (i = 0; i < FrameReport.Count; i++)
                {
                    string order_numb = FrameReport[i][0].Substring(0, 5);
                    BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_total += Int32.Parse(FrameReport[i][1]);
                }
            }
            for (i = 0; i < BookingList.Count; i++)
            {
                if (BookingList[i].Windows_total != 0)
                {
                    if (BookingList[i].Windows_done == BookingList[i].Windows_total)
                    {
                        BookingList[i].Status = "COMPLETE";
                    }
                    else if (BookingList[i].Windows_done < BookingList[i].Windows_total)
                    {
                        BookingList[i].Status = "IN PROGRESS";
                    }
                }
                dataGridViewOrders.Rows.Add(
                    BookingList[i].Status,
                    false,
                    BookingList[i].Order,
                    BookingList[i].Company,
                    BookingList[i].CS,
                    BookingList[i].VF,
                    BookingList[i].SL,
                    BookingList[i].SH,
                    BookingList[i].BY,
                    BookingList[i].BW,
                    BookingList[i].DW,
                    BookingList[i].SU,
                    BookingList[i].SS,
                    BookingList[i].GRL,
                    BookingList[i].SDL,
                    BookingList[i].EXT,
                    BookingList[i].Casing,
                    BookingList[i].PDoor,
                    BookingList[i].ColourIn,
                    BookingList[i].ColourOut,
                    BookingList[i].Note,
                    BookingList[i].Addition_info
                );
                if (BookingList[i].Status == "COMPLETE")
                {
                    dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                }
                else if (BookingList[i].Status == "IN PROGRESS")
                {
                    dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                }
                if (BookingList[i].Addition_info != "")
                {
                    DataGridViewButtonCell c = (DataGridViewButtonCell)dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnAdditionalInformation_button"].Index];
                    c.Style.BackColor = Color.Green;
                    c.Style.SelectionBackColor = Color.Green;
                    c.FlatStyle = FlatStyle.Popup;
                }
            }
            labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();

            textBoxBookOrder.Select();
            if (Settings.BookCheckPassword == "True" && Settings.BookPswdTime != "")
            {
                Application.Idle += new EventHandler(Application_Idle);
                IdleTimer.Interval = Int32.Parse(Settings.BookPswdTime) * 1000;  
                IdleTimer.Tick += TimeDone;
                IdleTimer.Start();
                Application.Idle -= new EventHandler(Application_Idle);
            }
        }

        private void DrawPieChart(Chart chart, int value1, int value2, string title)
        {
            //reset your chart series and legends
            chart.Series.Clear();
            chart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart.Legends.Add("MyLegend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Right;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].IsTextAutoFit = true;
            chart.Legends[0].Title = title;
            chart.Legends[0].BorderColor = Color.Black;
            chart.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
            //Add a new chart-series
            string seriesname = "MySeriesName";
            chart.Series.Add(seriesname);
            chart.Series[seriesname].ChartType = SeriesChartType.Pie;
            chart.Series[seriesname].IsValueShownAsLabel = false;
            //chart.Series[seriesname].LegendText = "";
            chart.Series[seriesname].LegendText = "#VALX\n#VAL - #PERCENT";
            //Add some datapoints so the series. in this case you can pass the values to this method
            int indexWhite = chart.Series[seriesname].Points.AddXY("White", value1);
            int indexColour = chart.Series[seriesname].Points.AddXY("Colour", value2);
            chart.Series[seriesname].Points[indexWhite].Color = Color.Green;
            chart.Series[seriesname].Points[indexColour].Color = Color.Orange;
            chart.Series[seriesname]["PieLabelStyle"] = "Disabled";
            //chart.Series[seriesname].LEFont= new System.Drawing.Font("Microsoft Sans Serif", 16f);
        }

        static private void Application_Idle(Object sender, EventArgs e)
        {
            if (!IdleTimer.Enabled) IdleTimer.Start();
        }

        void TimeDone(object sender, EventArgs e)
        {
            IdleTimer.Enabled = false;
            IdleTimer.Stop();
            Enabled = false;

            if (new BookingPasswordForm().InputBox() == Settings.BookPassword)
            {
                Enabled = true;
                IdleTimer.Enabled = true;
                IdleTimer.Stop();
                IdleTimer.Start();
            }
            else Close();
        }

        void IdleTimer_Tick(object sender, EventArgs e)
        {
            IdleTimer.Enabled=false;
            IdleTimer.Stop();
            this.Enabled = false;

            if (new BookingPasswordForm().InputBox() == Settings.BookPassword)
            {
                this.Enabled = true;
                IdleTimer.Enabled = true;
                IdleTimer.Stop();
                IdleTimer.Start();
            }
            else Close();
        }

        private void BookingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdleTimer.Enabled = false;
            IdleTimer.Stop();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }

        private void DisableTimer()
        {
            IdleTimer.Enabled = false;
            IdleTimer.Stop();
        }

        private void BookingForm_KeyDown(object sender, KeyEventArgs e)
        {
            DisableTimer();
        }

        private void BookingForm_MouseMove(object sender, MouseEventArgs e)
        {
            DisableTimer();
        }

        private void textBoxBookOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxBookOrder.Text;
                if (data != "")
                {
                    BookOrder(data);
                }
            }
        }

        private void BookOrder(string data)
        {
            string[] Order = DB.getOrderSummaryBYNumber(data);
            if (Order != null)
            {
                if (Order[columns.IndexOf("LIST DATE")] != "")
                {
                    MessageBox.Show("Order " + data + "is already booked on " + Order[columns.IndexOf("LIST DATE")], "ERROR");
                }
                else
                {
                    if (DB.BookOrderSummary(Order[columns.IndexOf("id")], _date.Value.ToString("yyyyMMdd"), _location) == 0)
                    {
                        UpdateBook(Order);
                        textBoxBookOrder.Text = "";
                    }
                    else MessageBox.Show("Error when booking!", "ERROR");
                }
            }
            else MessageBox.Show("This order number doesn't exist!!", "WARNING!");
        }

        public void UpdateBook(string[] order)
        {
            int i;
            int BWhiteWindows = 0, BColourWindows = 0,
                BCasement = 0, BSlider = 0, BShape = 0, BBayBow = 0, BSU = 0, BPDoor = 0;

            Data_order row = new Data_order();
            row.Order = order[columns.IndexOf("ORDER#")];
            row.Company = order[columns.IndexOf("COMPANY")];
            foreach (var name_type in Settings.Window_Casement)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.CS += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Fix)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.VF += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Slider)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SL += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Shape)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SH += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Sdwind)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SH += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Dummy)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.DW += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_SU)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SU += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_SUSHP)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SS += Int32.Parse(c);
            }
            string co;
            co = order[columns.IndexOf("GRILL")];
            if (co != "") row.GRL = Int32.Parse(co);
            co = order[columns.IndexOf("GRILL")];
            if (co != "") row.GRL = Int32.Parse(co);
            co = order[columns.IndexOf("SDL")];
            if (co != "") row.SDL = Int32.Parse(co);
            row.EXT = order[columns.IndexOf("EXT")];
            row.Casing = order[columns.IndexOf("CASING")];
            co = order[columns.IndexOf("BAY")];
            if (co != "") row.BY = Int32.Parse(co);
            co = order[columns.IndexOf("PATIO DOOR")];
            if (co != "") row.PDoor = Int32.Parse(co);
            row.ColourIn = order[columns.IndexOf("COLOUR IN")];
            row.ColourOut = order[columns.IndexOf("COLOUR OUT")];
            row.Addition_info = order[columns.IndexOf("STATUS")];
            row.Note = order[columns.IndexOf("NOTE")];

            BCasement += row.CS;
            BCasement += row.VF;
            BCasement += row.DW;
            BSlider += row.SL;
            BShape += row.SH;
            BBayBow += row.BY;
            co = order[columns.IndexOf("BOW")];
            if (co != "") BBayBow += Int32.Parse(co);
            BSU += row.SU;
            BSU += row.SS;
            BPDoor += row.PDoor;

            TotalNotBooked -= (BCasement + BSlider + BShape);
            labelTotalNotBooked.Text = TotalNotBooked.ToString();
            labelCasementNotBooked.Text = (Int32.Parse(labelCasementNotBooked.Text) - BCasement).ToString();
            labelSliderNotBooked.Text = (Int32.Parse(labelSliderNotBooked.Text) - BSlider).ToString();
            labelShapeNotBooked.Text = (Int32.Parse(labelShapeNotBooked.Text) - BShape).ToString();
            labelBayBowNotBooked.Text = (Int32.Parse(labelBayBowNotBooked.Text) - BBayBow).ToString();
            labelSUNotBooked.Text = (Int32.Parse(labelSUNotBooked.Text) - BSU).ToString();
            labelPDoorNotBooked.Text = (Int32.Parse(labelPDoorNotBooked.Text) - BPDoor).ToString();

            TotalBooked += (BCasement + BSlider + BShape);
            labelTotalBooked.Text = TotalBooked.ToString();
            labelCasementBooked.Text = (Int32.Parse(labelCasementBooked.Text) + BCasement).ToString();
            labelSliderBooked.Text = (Int32.Parse(labelSliderBooked.Text) + BSlider).ToString();
            labelShapeBooked.Text = (Int32.Parse(labelShapeBooked.Text) + BShape).ToString();
            labelBayBowBooked.Text = (Int32.Parse(labelBayBowBooked.Text) + BBayBow).ToString();
            labelSUBooked.Text = (Int32.Parse(labelSUBooked.Text) + BSU).ToString();
            labelPDoorBooked.Text = (Int32.Parse(labelPDoorBooked.Text) + BPDoor).ToString();
            if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
            {
                BWhiteWindows += BCasement + BSlider + BShape + BBayBow;
            }
            else
            {
                BColourWindows += BCasement + BSlider + BShape + BBayBow;
            }
            TotalNBWhiteWindows -= BWhiteWindows;
            TotalNBColourWindows -= BColourWindows;
            DrawPieChart(chartNotBooked, TotalNBWhiteWindows, TotalNBColourWindows, "Not Booked");
            TotalBWhiteWindows += BWhiteWindows;
            TotalBColourWindows += BColourWindows;
            DrawPieChart(chartBooked, TotalBWhiteWindows, TotalBColourWindows, "Booked");
            ordersummary.Add(order);

            List<string> order_numbers = new List<string>() { row.Order };
            List<string[]> windowsAssembly_report = DB.importWindowsAssemblybyOrder(order_numbers);
            if (windowsAssembly_report != null)
            {
                for (i = 0; i < windowsAssembly_report.Count; i++)
                {
                    string order_numb = windowsAssembly_report[i][0].Substring(0, 5);
                    row.Windows_done += 1;
                }
            }
            List<string[]> FrameReport = DB.importFramereportbyIDs(order_numbers);
            if (FrameReport != null)
            {
                for (i = 0; i < FrameReport.Count; i++)
                {
                    string order_numb = FrameReport[i][0].Substring(0, 5);
                    row.Windows_total += Int32.Parse(FrameReport[i][1]);
                }
            }
            if (row.Windows_total != 0)
            {
                if (row.Windows_done == row.Windows_total) row.Status = "COMPLETE";
                else if (row.Windows_done < row.Windows_total) row.Status = "IN PROGRESS";
            }
            dataGridViewOrders.Rows.Insert(
                0,
                row.Status,
                false,
                row.Order,
                row.Company,
                row.CS,
                row.VF,
                row.SL,
                row.SH,
                row.BY,
                row.BW,
                row.DW,
                row.SU,
                row.SS,
                row.GRL,
                row.SDL,
                row.EXT,
                row.Casing,
                row.PDoor,
                row.ColourIn,
                row.ColourOut,
                row.Note,
                row.Addition_info
            );
            labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
            if (row.Status == "COMPLETE")
            {
                dataGridViewOrders.Rows[0].Cells[0].Style.BackColor = Color.Lime;
            }
            else if (row.Status == "IN PROGRESS")
            {
                dataGridViewOrders.Rows[0].Cells[0].Style.BackColor = Color.Gold;
            }
            if (row.Addition_info != "")
            {
                DataGridViewButtonCell c = (DataGridViewButtonCell)dataGridViewOrders.Rows[dataGridViewOrders.Rows.Count - 1].Cells[dataGridViewOrders.Columns["ColumnAdditionalInformation_button"].Index];
                c.Style.BackColor = Color.Green;
                c.Style.SelectionBackColor = Color.Green;
                c.FlatStyle = FlatStyle.Popup;
            }
        }

        private void textBoxOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxOrderNumber.Text;
                if (data != "")
                {
                    scanInput(data);
                }
                else
                {
                    for (int i = 0; i < dataGridViewOrders.Rows.Count; i++)
                    {
                        dataGridViewOrders.Rows[i].Visible = true;
                    }
                }
            }
        }

        private void scanInput(string data)
        {
            for (int i = 0; i < dataGridViewOrders.Rows.Count; i++)
            {
                if (dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnOrder"].Index].Value.ToString() != data)
                {
                    dataGridViewOrders.Rows[i].Visible = false;
                }
                else
                {
                    dataGridViewOrders.Rows[i].Visible = true;
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int rowCount = 0;
            if ((rowCount = dataGridViewOrders.Rows.Count) > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                BookingDataSet data_Order = new BookingDataSet();
                string colour;
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnColourIn"].Index].Value.ToString() == "WHT"
                        && dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnColourOut"].Index].Value.ToString() == "WHT")
                    {
                        colour = "White";
                    }
                    else
                    {
                        colour = "Colour";
                    }
                    data_Order.Tables[1].Rows.Add(
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnOrder"].Index].Value,            //Order
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnCS"].Index].Value.ToString(),    //CS
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnVF"].Index].Value.ToString(),    //VF
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnSL"].Index].Value.ToString(),    //SL
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnSH"].Index].Value.ToString(),    //SH
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnBY"].Index].Value.ToString(),    //BY
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnBW"].Index].Value.ToString(),    //BW
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnDW"].Index].Value.ToString(),    //DW
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnSU"].Index].Value.ToString(),    //SU
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnSS"].Index].Value.ToString(),    //SS
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnGRL"].Index].Value.ToString(),   //GRL
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnSDL"].Index].Value.ToString(),   //SDL
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnEXT"].Index].Value.ToString(),   //EXT
                        dataGridViewOrders.Rows[i].Cells[dataGridViewOrders.Columns["ColumnCasing"].Index].Value.ToString(),//Casing
                        colour                                                  //Colour
                    );
                    rds.Value = data_Order.Tables[1];
                }
                reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
                reportParameters.Add(new ReportParameter("DateParameter", _date.Value.ToString("dd- MMMM yyyy")));
                rds.Name = "DataSet1";
                UniversalPrint bookingPrint = new UniversalPrint(rds, reportParameters, "reports\\Booking_Report.rdlc");
                bookingPrint.Show();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print_page()
        {
            m_currentPageIndex = 0;
            if (m_streams == null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                PrintDialog printDlg = new PrintDialog();
                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //printDlg.Document.PrinterSettings.DefaultPageSettings.Landscape = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }

        private void dataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnCol = dataGridViewOrders.Columns["ColumnAdditionalInformation_button"].Index;
            if (e.ColumnIndex == btnCol)
            {
                int txtCol = dataGridViewOrders.Columns["ColumnAdditionalInformation_text"].Index;
                string order = dataGridViewOrders.Rows[e.RowIndex].Cells[dataGridViewOrders.Columns["ColumnOrder"].Index].Value.ToString();
                string note_before = dataGridViewOrders.Rows[e.RowIndex].Cells[txtCol].Value.ToString();
                string note_after = new NoteDialog().InputBox(note_before);
                if (note_after != null)
                {
                    dataGridViewOrders.Rows[e.RowIndex].Cells[txtCol].Value = note_after;
                    DataGridViewButtonCell c = (DataGridViewButtonCell)dataGridViewOrders.Rows[e.RowIndex].Cells[btnCol];
                    if (note_after == "")
                    {
                        c.Style.BackColor = Color.White;
                        c.Style.SelectionBackColor = Color.White;
                        c.FlatStyle = FlatStyle.Standard;
                    }
                    else
                    {
                        c.Style.BackColor = Color.Green;
                        c.Style.SelectionBackColor = Color.Green;
                        c.FlatStyle = FlatStyle.Popup;
                    }
                    if (note_after != note_before)
                    {
                        DB.updateRow("ordersummary", "ORDER#", order, "STATUS", note_after);
                    }
                }
            }
        }

        private void dataGridViewOrders_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridViewOrders.HitTest(e.X, e.Y);
                if (hti.RowIndex >= 0)
                {
                    dataGridViewOrders.ClearSelection();
                    dataGridViewOrders.Rows[hti.RowIndex].Selected = true;

                    holdToolStripMenuItem.Visible = true;
                    toolStripMenuItem2.Visible = true;
                    toolStripMenuItem3.Visible = true;
                    removeToolStripMenuItem.Visible = true;
                    moveToToolStripMenuItem.Visible = true;
                }
                else
                {
                    holdToolStripMenuItem.Visible = false;
                    toolStripMenuItem2.Visible = false;
                    toolStripMenuItem3.Visible = false;
                    removeToolStripMenuItem.Visible = false;
                    moveToToolStripMenuItem.Visible = false;
                }
                dataGridViewOrdersContextMenu.Show((Control)sender, e.Location);
            }
        }

        private void dataGridViewOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridViewOrders.Columns["ColumnNote"].Index;
            if (e.ColumnIndex == col && CellValue != dataGridViewOrders.Rows[e.RowIndex].Cells[col].Value)
            {
                /*DB.UpdateOrderSummaryStatus(
                    dataGridViewOrders.Rows[e.RowIndex].Cells[dataGridViewOrders.Columns["ColumnOrder"].Index].Value.ToString(),
                    dataGridViewOrders.Rows[e.RowIndex].Cells[col].Value.ToString()
                );*/
                DB.updateRow(
                    "ordersummary",
                    "ORDER#",
                    dataGridViewOrders.Rows[e.RowIndex].Cells[dataGridViewOrders.Columns["ColumnOrder"].Index].Value.ToString(),
                    "NOTE",
                    dataGridViewOrders.Rows[e.RowIndex].Cells[col].Value?.ToString()
                );
            }
        }

        private void dataGridViewOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CellValue = dataGridViewOrders.Rows[e.RowIndex].Cells[dataGridViewOrders.Columns["ColumnNote"].Index].Value;
        }

        private void holdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateStatus("HOLD");
        }

        //100%
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateStatus("100%");
        }

        //1000%
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            updateStatus("1000%");
        }

        private void updateStatus(string status)
        {
            List<string> orders = new List<string>();
            string order;
            int chkCol = dataGridViewOrders.Columns["ColumnCheckBox"].Index;
            int ordCol = dataGridViewOrders.Columns["ColumnOrder"].Index;
            int statusCol = dataGridViewOrders.Columns["ColumnNote"].Index;
            for (int i = 0; i < dataGridViewOrders.Rows.Count; i++)
            {
                if ((bool)dataGridViewOrders.Rows[i].Cells[chkCol].Value)
                {
                    order = dataGridViewOrders.Rows[i].Cells[ordCol].Value.ToString();
                    orders.Add(order);
                    dataGridViewOrders.Rows[i].Cells[statusCol].Value = status;
                }
            }
            if (orders.Count > 0)
            {
                DB.UpdateOrderSummaryStatus(orders, status);
            }
            else
            {
                order = dataGridViewOrders.SelectedRows[0].Cells[ordCol].Value.ToString();
                if (DB.UpdateOrderSummaryStatus(order, status) == 0)
                {
                    dataGridViewOrders.SelectedRows[0].Cells[statusCol].Value = status;
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> orders = new List<string>();
            DataGridViewCell orderCell;
            string order;
            int chkCol = dataGridViewOrders.Columns["ColumnCheckBox"].Index;
            int ordCol = dataGridViewOrders.Columns["ColumnOrder"].Index;
            int i;
            for (i = 0; i < dataGridViewOrders.Rows.Count; i++)
            {
                if ((bool)dataGridViewOrders.Rows[i].Cells[chkCol].Value)
                {
                    orderCell = dataGridViewOrders.Rows[i].Cells[ordCol];
                    order = orderCell.Value.ToString();
                    orders.Add(order);
                }
            }
            if (orders.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to unbook selected orders?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DB.BookOrderSummaryByOrder(orders, "") == 0)
                    {
                        for (i = 0; i < orders.Count; i++)
                        {
                            order = orders[i];
                            UpdateUnBook(ordersummary.First(x => x[columns.IndexOf("ORDER#")] == order));
                        }
                    }
                }
            }
            else
            {
                orderCell = dataGridViewOrders.SelectedRows[0].Cells[ordCol];
                order = orderCell.Value.ToString();
                if (MessageBox.Show("Are you sure you want to unbook order " + order + "?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DB.BookOrderSummaryByOrder(order, "") == 0)
                    {
                        UpdateUnBook(ordersummary.First(x => x[columns.IndexOf("ORDER#")] == order));
                    }
                }
            }
        }

        public void UpdateUnBook(string[] order)
        {
            int i;
            int NBWhiteWindows = 0, NBColourWindows = 0,
                NBCasement = 0, NBSlider = 0, NBShape = 0, NBBayBow = 0, NBSU = 0, NBPDoor = 0;

            Data_order row = new Data_order();
            foreach (var name_type in Settings.Window_Casement)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.CS += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Fix)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.VF += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Slider)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SL += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Shape)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SH += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Sdwind)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SH += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_Dummy)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.DW += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_SU)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SU += Int32.Parse(c);
            }
            foreach (var name_type in Settings.Window_SUSHP)
            {
                i = columns.IndexOf(name_type[2]);
                string c = (i >= 0 && i < order.Length) ? order[i] : "";
                if (c != "") row.SS += Int32.Parse(c);
            }
            string co;
            co = order[columns.IndexOf("GRILL")];
            if (co != "") row.GRL = Int32.Parse(co);
            co = order[columns.IndexOf("GRILL")];
            if (co != "") row.GRL = Int32.Parse(co);
            co = order[columns.IndexOf("SDL")];
            if (co != "") row.SDL = Int32.Parse(co);
            row.EXT = order[columns.IndexOf("EXT")];
            row.Casing = order[columns.IndexOf("CASING")];
            co = order[columns.IndexOf("BAY")];
            if (co != "") row.BY = Int32.Parse(co);
            co = order[columns.IndexOf("PATIO DOOR")];
            if (co != "") row.PDoor = Int32.Parse(co);
            row.ColourIn = order[columns.IndexOf("COLOUR IN")];
            row.ColourOut = order[columns.IndexOf("COLOUR OUT")];

            NBCasement += row.CS;
            NBCasement += row.VF;
            NBCasement += row.DW;
            NBSlider += row.SL;
            NBShape += row.SH;
            NBBayBow += row.BY;
            co = order[columns.IndexOf("BOW")];
            if (co != "") NBBayBow += Int32.Parse(co);
            NBSU += row.SU;
            NBSU += row.SS;
            NBPDoor += row.PDoor;

            TotalNotBooked += (NBCasement + NBSlider + NBShape);
            labelTotalNotBooked.Text = TotalNotBooked.ToString();
            labelCasementNotBooked.Text = (Int32.Parse(labelCasementNotBooked.Text) + NBCasement).ToString();
            labelSliderNotBooked.Text = (Int32.Parse(labelSliderNotBooked.Text) + NBSlider).ToString();
            labelShapeNotBooked.Text = (Int32.Parse(labelShapeNotBooked.Text) + NBShape).ToString();
            labelBayBowNotBooked.Text = (Int32.Parse(labelBayBowNotBooked.Text) + NBBayBow).ToString();
            labelSUNotBooked.Text = (Int32.Parse(labelSUNotBooked.Text) + NBSU).ToString();
            labelPDoorNotBooked.Text = (Int32.Parse(labelPDoorNotBooked.Text) + NBPDoor).ToString();

            TotalBooked -= (NBCasement + NBSlider + NBShape);
            labelTotalBooked.Text = TotalBooked.ToString();
            labelCasementBooked.Text = (Int32.Parse(labelCasementBooked.Text) - NBCasement).ToString();
            labelSliderBooked.Text = (Int32.Parse(labelSliderBooked.Text) - NBSlider).ToString();
            labelShapeBooked.Text = (Int32.Parse(labelShapeBooked.Text) - NBShape).ToString();
            labelBayBowBooked.Text = (Int32.Parse(labelBayBowBooked.Text) - NBBayBow).ToString();
            labelSUBooked.Text = (Int32.Parse(labelSUBooked.Text) - NBSU).ToString();
            labelPDoorBooked.Text = (Int32.Parse(labelPDoorBooked.Text) - NBPDoor).ToString();

            if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
            {
                NBWhiteWindows += NBCasement + NBSlider + NBShape + NBBayBow;
            }
            else
            {
                NBColourWindows += NBCasement + NBSlider + NBShape + NBBayBow;
            }
            TotalNBWhiteWindows += NBWhiteWindows;
            TotalNBColourWindows += NBColourWindows;
            DrawPieChart(chartNotBooked, TotalNBWhiteWindows, TotalNBColourWindows, "Not Booked");
            TotalBWhiteWindows -= NBWhiteWindows;
            TotalBColourWindows -= NBColourWindows;
            DrawPieChart(chartBooked, TotalBWhiteWindows, TotalBColourWindows, "Booked");

            dataGridViewOrders.Rows.RemoveAt(dataGridViewOrders.SelectedRows[0].Index);
            labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
        }

        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> orders = new List<string>();
            DataGridViewCell orderCell;
            string order;
            int chkCol = dataGridViewOrders.Columns["ColumnCheckBox"].Index;
            int ordCol = dataGridViewOrders.Columns["ColumnOrder"].Index;
            int i;
            for (i = 0; i < dataGridViewOrders.Rows.Count; i++)
            {
                if ((bool)dataGridViewOrders.Rows[i].Cells[chkCol].Value)
                {
                    orderCell = dataGridViewOrders.Rows[i].Cells[ordCol];
                    order = orderCell.Value.ToString();
                    orders.Add(order);
                }
            }
            DateTime? list_date;
            if (orders.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to edit book date for selected orders?", "Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list_date = new SelectDateDialogBooking().InputBox();
                    if (list_date != null)
                    {
                        if (DB.BookOrderSummaryByOrder(orders, list_date.Value.ToString("yyyyMMdd")) == 0)
                        {
                            if (list_date != _date)
                            {
                                for (i = 0; i < dataGridViewOrders.Rows.Count; )
                                {
                                    if ((bool)dataGridViewOrders.Rows[i].Cells[chkCol].Value)
                                    {
                                        dataGridViewOrders.Rows.RemoveAt(i);
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                                labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                orderCell = dataGridViewOrders.SelectedRows[0].Cells[ordCol];
                order = orderCell.Value.ToString();
                if (MessageBox.Show("Are you sure you want to edit book date for order " + order + "?", "Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list_date = new SelectDateDialogBooking().InputBox();
                    if (list_date != null)
                    {
                        if (DB.BookOrderSummaryByOrder(order, list_date.Value.ToString("yyyyMMdd")) == 0)
                        {
                            if (list_date != _date)
                            {
                                dataGridViewOrders.Rows.RemoveAt(dataGridViewOrders.SelectedRows[0].Index);
                                labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void langstaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_location != "3350 Langstaff")
            {
                _location = "3350 Langstaff";
                labelLocation.Text = _location;
                dataGridViewOrders.Rows.Clear();

                int i;
                int BCasement = 0, BSlider = 0, BShape = 0, BBayBow = 0, BSU = 0, BPDoor = 0,
                    BWhiteWindows = 0, BColourWindows = 0;
                List<Data_order> BookingList = new List<Data_order>();
                List<string> order_numbers = new List<string>();
                ordersummary = DB.getBookedOrderSummary(_date.Value.ToString("yyyyMMdd"), _location);
                foreach (var element in ordersummary)
                {
                    Data_order row = new Data_order();
                    row.Order = element[columns.IndexOf("ORDER#")];
                    row.Company = element[columns.IndexOf("COMPANY")];
                    foreach (var name_type in Settings.Window_Casement)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.CS += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Fix)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.VF += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Slider)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SL += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Shape)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SH += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Sdwind)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SH += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Dummy)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.DW += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_SU)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SU += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_SUSHP)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SS += Int32.Parse(c);
                    }
                    string co;
                    co = element[columns.IndexOf("GRILL")];
                    if (co != "") row.GRL = Int32.Parse(co);
                    co = element[columns.IndexOf("GRILL")];
                    if (co != "") row.GRL = Int32.Parse(co);
                    co = element[columns.IndexOf("SDL")];
                    if (co != "") row.SDL = Int32.Parse(co);
                    row.EXT = element[columns.IndexOf("EXT")];
                    row.Casing = element[columns.IndexOf("CASING")];
                    co = element[columns.IndexOf("BAY")];
                    if (co != "") row.BY = Int32.Parse(co);
                    co = element[columns.IndexOf("PATIO DOOR")];
                    if (co != "") row.PDoor = Int32.Parse(co);
                    co = element[columns.IndexOf("BOW")];
                    if (co != "") row.BOW += Int32.Parse(co);
                    row.ColourIn = element[columns.IndexOf("COLOUR IN")];
                    row.ColourOut = element[columns.IndexOf("COLOUR OUT")];
                    row.Addition_info = element[columns.IndexOf("STATUS")];
                    row.Note = element[columns.IndexOf("NOTE")];
                    BCasement += row.CS;
                    BCasement += row.VF;
                    BCasement += row.DW;
                    BSlider += row.SL;
                    BShape += row.SH;
                    BBayBow += row.BY;
                    BBayBow += row.BOW;
                    BSU += row.SU;
                    BSU += row.SS;
                    BPDoor += row.PDoor;
                    if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
                    {
                        BWhiteWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                    }
                    else
                    {
                        BColourWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                    }
                    BookingList.Add(row);
                    order_numbers.Add(row.Order);
                }
                TotalBooked = BCasement + BSlider + BShape;
                labelTotalBooked.Text = TotalBooked.ToString();
                labelCasementBooked.Text = BCasement.ToString();
                labelSliderBooked.Text = BSlider.ToString();
                labelShapeBooked.Text = BShape.ToString();
                labelBayBowBooked.Text = BBayBow.ToString();
                labelSUBooked.Text = BSU.ToString();
                labelPDoorBooked.Text = BPDoor.ToString();
                TotalBWhiteWindows = BWhiteWindows;
                TotalBColourWindows = BColourWindows;
                if (BWhiteWindows != 0 || BColourWindows != 0)
                {
                    DrawPieChart(chartBooked, BWhiteWindows, BColourWindows, "Booked");
                }
                List<string[]> windowsAssembly_report = DB.importWindowsAssemblybyOrder(order_numbers);
                if (windowsAssembly_report != null)
                {
                    for (i = 0; i < windowsAssembly_report.Count; i++)
                    {
                        string order_numb = windowsAssembly_report[i][0].Substring(0, 5);
                        BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_done += 1;
                    }
                }
                List<string[]> FrameReport = DB.importFramereportbyIDs(order_numbers);
                if (FrameReport != null)
                {
                    for (i = 0; i < FrameReport.Count; i++)
                    {
                        string order_numb = FrameReport[i][0].Substring(0, 5);
                        BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_total += Int32.Parse(FrameReport[i][1]);
                    }
                }
                for (i = 0; i < BookingList.Count; i++)
                {
                    if (BookingList[i].Windows_total != 0)
                    {
                        if (BookingList[i].Windows_done == BookingList[i].Windows_total)
                        {
                            BookingList[i].Status = "COMPLETE";
                        }
                        else if (BookingList[i].Windows_done < BookingList[i].Windows_total)
                        {
                            BookingList[i].Status = "IN PROGRESS";
                        }
                    }
                    dataGridViewOrders.Rows.Add(BookingList[i].Status, false, BookingList[i].Order, BookingList[i].Company, BookingList[i].CS, BookingList[i].VF, BookingList[i].SL, BookingList[i].SH, BookingList[i].BY, BookingList[i].BW, BookingList[i].DW, BookingList[i].SU, BookingList[i].SS, BookingList[i].GRL, BookingList[i].SDL, BookingList[i].EXT, BookingList[i].Casing, BookingList[i].PDoor, BookingList[i].ColourIn, BookingList[i].ColourOut, BookingList[i].Note, BookingList[i].Addition_info);
                    if (BookingList[i].Status == "COMPLETE")
                    {
                        dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                    }
                    else if (BookingList[i].Status == "IN PROGRESS")
                    {
                        dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                    }
                }
                labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
            }
        }

        private void jacobKefferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_location != "100 Jacob Keffer")
            {
                _location = "100 Jacob Keffer";
                labelLocation.Text = _location;
                dataGridViewOrders.Rows.Clear();

                int i;
                int BCasement = 0, BSlider = 0, BShape = 0, BBayBow = 0, BSU = 0, BPDoor = 0,
                    BWhiteWindows = 0, BColourWindows = 0;
                List<Data_order> BookingList = new List<Data_order>();
                List<string> order_numbers = new List<string>();
                ordersummary = DB.getBookedOrderSummary(_date.Value.ToString("yyyyMMdd"), _location);
                foreach (var element in ordersummary)
                {
                    Data_order row = new Data_order();
                    row.Order = element[columns.IndexOf("ORDER#")];
                    row.Company = element[columns.IndexOf("COMPANY")];
                    foreach (var name_type in Settings.Window_Casement)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.CS += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Fix)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.VF += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Slider)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SL += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Shape)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SH += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Sdwind)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SH += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_Dummy)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.DW += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_SU)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SU += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Window_SUSHP)
                    {
                        i = columns.IndexOf(name_type[2]);
                        string c = (i >= 0 && i < element.Length) ? element[i] : "";
                        if (c != "") row.SS += Int32.Parse(c);
                    }
                    string co;
                    co = element[columns.IndexOf("GRILL")];
                    if (co != "") row.GRL = Int32.Parse(co);
                    co = element[columns.IndexOf("GRILL")];
                    if (co != "") row.GRL = Int32.Parse(co);
                    co = element[columns.IndexOf("SDL")];
                    if (co != "") row.SDL = Int32.Parse(co);
                    row.EXT = element[columns.IndexOf("EXT")];
                    row.Casing = element[columns.IndexOf("CASING")];
                    co = element[columns.IndexOf("BAY")];
                    if (co != "") row.BY = Int32.Parse(co);
                    co = element[columns.IndexOf("PATIO DOOR")];
                    if (co != "") row.PDoor = Int32.Parse(co);
                    co = element[columns.IndexOf("BOW")];
                    if (co != "") row.BOW += Int32.Parse(co);
                    row.ColourIn = element[columns.IndexOf("COLOUR IN")];
                    row.ColourOut = element[columns.IndexOf("COLOUR OUT")];
                    row.Addition_info = element[columns.IndexOf("STATUS")];
                    row.Note = element[columns.IndexOf("NOTE")];
                    BCasement += row.CS;
                    BCasement += row.VF;
                    BCasement += row.DW;
                    BSlider += row.SL;
                    BShape += row.SH;
                    BBayBow += row.BY;
                    BBayBow += row.BOW;
                    BSU += row.SU;
                    BSU += row.SS;
                    BPDoor += row.PDoor;
                    if (row.ColourIn == "WHT" && row.ColourOut == "WHT")
                    {
                        BWhiteWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                    }
                    else
                    {
                        BColourWindows += row.CS + row.VF + row.DW + row.SL + row.SH + row.BY + row.BOW;
                    }
                    BookingList.Add(row);
                    order_numbers.Add(row.Order);
                }
                TotalBooked = BCasement + BSlider + BShape;
                labelTotalBooked.Text = TotalBooked.ToString();
                labelCasementBooked.Text = BCasement.ToString();
                labelSliderBooked.Text = BSlider.ToString();
                labelShapeBooked.Text = BShape.ToString();
                labelBayBowBooked.Text = BBayBow.ToString();
                labelSUBooked.Text = BSU.ToString();
                labelPDoorBooked.Text = BPDoor.ToString();
                TotalBWhiteWindows = BWhiteWindows;
                TotalBColourWindows = BColourWindows;
                if (BWhiteWindows != 0 || BColourWindows != 0)
                {
                    DrawPieChart(chartBooked, BWhiteWindows, BColourWindows, "Booked");
                }
                List<string[]> windowsAssembly_report = DB.importWindowsAssemblybyOrder(order_numbers);
                if (windowsAssembly_report != null)
                {
                    for (i = 0; i < windowsAssembly_report.Count; i++)
                    {
                        string order_numb = windowsAssembly_report[i][0].Substring(0, 5);
                        BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_done += 1;
                    }
                }
                List<string[]> FrameReport = DB.importFramereportbyIDs(order_numbers);
                if (FrameReport != null)
                {
                    for (i = 0; i < FrameReport.Count; i++)
                    {
                        string order_numb = FrameReport[i][0].Substring(0, 5);
                        BookingList.Where(x => x.Order == order_numb).LastOrDefault().Windows_total += Int32.Parse(FrameReport[i][1]);
                    }
                }
                for (i = 0; i < BookingList.Count; i++)
                {
                    if (BookingList[i].Windows_total != 0)
                    {
                        if (BookingList[i].Windows_done == BookingList[i].Windows_total)
                        {
                            BookingList[i].Status = "COMPLETE";
                        }
                        else if (BookingList[i].Windows_done < BookingList[i].Windows_total)
                        {
                            BookingList[i].Status = "IN PROGRESS";
                        }
                    }
                    dataGridViewOrders.Rows.Add(BookingList[i].Status, false, BookingList[i].Order, BookingList[i].Company, BookingList[i].CS, BookingList[i].VF, BookingList[i].SL, BookingList[i].SH, BookingList[i].BY, BookingList[i].BW, BookingList[i].DW, BookingList[i].SU, BookingList[i].SS, BookingList[i].GRL, BookingList[i].SDL, BookingList[i].EXT, BookingList[i].Casing, BookingList[i].PDoor, BookingList[i].ColourIn, BookingList[i].ColourOut, BookingList[i].Note, BookingList[i].Addition_info);
                    if (BookingList[i].Status == "COMPLETE")
                    {
                        dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                    }
                    else if (BookingList[i].Status == "IN PROGRESS")
                    {
                        dataGridViewOrders.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                    }
                }
                labelRowNumber.Text = dataGridViewOrders.Rows.Count.ToString();
            }
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>8.5in</PageWidth>
                    <PageHeight>11in</PageHeight>
                    <MarginTop>0.5in</MarginTop>
                    <MarginLeft>0.5in</MarginLeft>
                    <MarginRight>0.5in</MarginRight>
                    <MarginBottom>0.5in</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
            }
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            // switch case is the easy way, a hash or map would be better, 
            // but more work to get set up.
            switch (keyData)
            {
                case Keys.F10:
                    // Hide();
                    IdleTimer.Enabled = false;
                    IdleTimer.Stop();
                    BookingSubMenuForm bookingForm = new BookingSubMenuForm(_date, this, _location);
                    bookingForm.ShowDialog();
                    IdleTimer.Enabled = true;
                    IdleTimer.Start();
                    //bHandled = true;
                    break;
            }
            return bHandled;
        }
    }
}