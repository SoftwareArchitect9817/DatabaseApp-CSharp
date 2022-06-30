using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
using Senaka.lib;
using Senaka.print_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class WorkScheduleReport : Form
    {
        DateTime? _date;
        List<string> columns;
        List<string[]> ordersummary;
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        object CellValue;

        public class Data_order
        {
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
            public int Corner_dr { get; set; }
            public int Sdl { get; set; }
            public int Slider_Frame { get; set; }
            public int Slider_Sash { get; set; }
            public string EXT { get; set; }
            public string Casing { get; set; }
            public int PDoor { get; set; }
            public string ColourIn { get; set; }
            public string ColourOut { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
        }

        public WorkScheduleReport(DateTime? date)
        {
            InitializeComponent();

            _date = date;
            labelDate.Text = _date.Value.ToString("dd- MMMM yyyy");

            DataTable schema = DB.GetTableSchema("ordersummary");
            columns = new List<string>();
            foreach (DataRow col in schema.Rows)
            {
                columns.Add(col.Field<String>("ColumnName"));
            }

            ordersummary = DB.getBookedOrderSummary(_date.Value.ToString("yyyyMMdd"));
            foreach (var element in ordersummary)
            {
                Data_order row = new Data_order();
                row.Order = element[columns.IndexOf("ORDER#")];
                row.Company = element[columns.IndexOf("COMPANY")];
                foreach (var name_type in Settings.Window_Casement)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.CS += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Fix)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.VF += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Slider)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SL += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Shape)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Sdwind)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Dummy)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.DW += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SU)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SU += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SUSHP)
                {
                    string c = element[columns.IndexOf(name_type[2])];
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
                row.Status = element[columns.IndexOf("STATUS")];
                row.Note = element[columns.IndexOf("NOTE")];
                dataGridViewOrders.Rows.Add(row.Order, row.Company, row.CS, row.VF, row.SL, row.SH, row.BY, row.BW, row.DW, row.SU, row.SS, row.GRL, row.SDL, row.EXT, row.Casing, row.PDoor, row.ColourIn, row.ColourOut, row.Status, row.Note);
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
                if (dataGridViewOrders.Rows[i].Cells[0].Value.ToString() != data)
                {
                    dataGridViewOrders.Rows[i].Visible = false;
                }
                else
                {
                    dataGridViewOrders.Rows[i].Visible = true;
                }
            }
        }

        private void WorkScheduleReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int rowCount = 0;
            rowCount = dataGridViewOrders.Rows.Count;
            if (rowCount > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                BookingDataSet data_Order = new BookingDataSet();
                string path = "";
                rowCount = dataGridViewOrders.Rows.Count;
                path = Path.Combine(Environment.CurrentDirectory, @"reports\WorkSchedule_Report.rdlc");
                for (int i = 0; i < rowCount; i++)
                {
                    //string order = dataGridViewOrders.Rows[i].Cells[0].Value;
                    data_Order.Tables[1].Rows.Add(dataGridViewOrders.Rows[i].Cells[0].Value, dataGridViewOrders.Rows[i].Cells[2].Value.ToString(), dataGridViewOrders.Rows[i].Cells[3].Value.ToString(), dataGridViewOrders.Rows[i].Cells[4].Value.ToString(), dataGridViewOrders.Rows[i].Cells[5].Value.ToString(), dataGridViewOrders.Rows[i].Cells[6].Value.ToString(), dataGridViewOrders.Rows[i].Cells[7].Value.ToString(), dataGridViewOrders.Rows[i].Cells[8].Value.ToString(), dataGridViewOrders.Rows[i].Cells[9].Value.ToString(), dataGridViewOrders.Rows[i].Cells[10].Value.ToString(), dataGridViewOrders.Rows[i].Cells[11].Value.ToString(), dataGridViewOrders.Rows[i].Cells[12].Value.ToString(), dataGridViewOrders.Rows[i].Cells[13].Value.ToString(), dataGridViewOrders.Rows[i].Cells[14].Value.ToString(), dataGridViewOrders.Rows[i].Cells[15].Value.ToString(), dataGridViewOrders.Rows[i].Cells[16].Value.ToString(), dataGridViewOrders.Rows[i].Cells[17].Value.ToString(), dataGridViewOrders.Rows[i].Cells[18].Value.ToString(), dataGridViewOrders.Rows[i].Cells[19].Value.ToString());
                    rds.Value = data_Order.Tables[1];
                }
                reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
                reportParameters.Add(new ReportParameter("DateParameter", _date.Value.ToString("dd- MMMM yyyy")));

                LocalReport report = new LocalReport();
                report.ReportPath = path;
                report.SetParameters(reportParameters);
                report.DataSources.Add(rds);
                // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                report.SetParameters(reportParameters);
                rds.Name = "DataSet1";
                report.DataSources.Add(rds);
                Export(report);
                Print_page();
            }
        }
        
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>13in</PageWidth>
                    <PageHeight>8.5in</PageHeight>
                    <MarginTop>0in</MarginTop>
                    <MarginLeft>0in</MarginLeft>
                    <MarginRight>0in</MarginRight>
                    <MarginBottom>0in</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
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
            printDoc.DefaultPageSettings.Landscape = true;

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

        private void buttonSummary_Click(object sender, EventArgs e)
        {
            int DW = 0, Shape = 0, Shape_SU = 0, BayBow = 0, Corner_dr = 0, Sdl = 0, Grill = 0;
            SummaryDataSet data_Order = new SummaryDataSet();
            int Total_CS = 0, Total_SliderFrame = 0, Total_SliderSash = 0, Total_SU = 0, Total_PDoor = 0, Total_Corner_dr = 0,
                Total_Shape = 0, Total_SS = 0, Total_GRL = 0, Total_SDL = 0, Total_BayBow = 0, Total_DW = 0;
            List<Data_order> rows = new List<Data_order>();
            foreach (var element in ordersummary)
            {
                //string Corner_dr = "", Sdl = "";
                Data_order row = new Data_order();
                row.Order = element[columns.IndexOf("ORDER#")];
                foreach (var name_type in Settings.Window_Casement)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.CS += Int32.Parse(c);
                }
                /* foreach (var name_type in Settings.Window_Fix)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.VF += Int32.Parse(c);
                }*/
                /*foreach (var name_type in Settings.Window_Slider)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SL += Int32.Parse(c);
                }*/
                foreach (var name_type in Settings.Window_Shape)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Sdwind)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SH += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Dummy)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.DW += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_SU)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SU += Int32.Parse(c);
                }
                foreach (var name_type in Settings.Book_Slider_Frame)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.Slider_Frame += Int32.Parse(c) * Int32.Parse(name_type[3]);
                }
                foreach (var name_type in Settings.Book_Slider_Sash)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.Slider_Sash += Int32.Parse(c) * Int32.Parse(name_type[3]);
                }
                foreach (var name_type in Settings.Window_SUSHP)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "") row.SS += Int32.Parse(c);
                }
                string co;
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
                /*row.ColourIn = element[columns.IndexOf("COLOUR IN")];
                row.ColourOut = element[columns.IndexOf("COLOUR OUT")];*/
                if (element[columns.IndexOf("CORNER_DR")] != "" && element[columns.IndexOf("CORNER_DR")] != null)
                {
                    row.Corner_dr = Int32.Parse(element[columns.IndexOf("CORNER_DR")]);
                }
                if (element[columns.IndexOf("SDL")] != "" && element[columns.IndexOf("SDL")] != null)
                {
                    row.Sdl = Int32.Parse(element[columns.IndexOf("SDL")]);
                }
                Total_CS += row.CS;
                Total_SliderFrame += row.Slider_Frame;
                Total_SliderSash += row.Slider_Sash;
                /*Shape += row.SH;
                BayBow += row.BY;
                BayBow += row.BOW;
                Total_SU += row.SU;*/
                Total_PDoor += row.PDoor;
                Total_Corner_dr += row.Corner_dr;
                Total_Shape += row.SH;
                Total_SS += row.SS;
                Total_GRL += row.GRL;
                Total_SDL += row.SDL;
                Total_BayBow += row.BY;
                Total_BayBow += row.BOW;
                Total_DW += row.DW;
                rows.Add(row);
            }
            if (Total_CS != 0)
            {
                data_Order.Tables[0].Rows.Add("Casement", "Total Casement", Total_CS, 0, 0);
            }
            if (Total_SliderFrame != 0)
            {
                data_Order.Tables[0].Rows.Add("SLIDER FRAME", "Total Slider Frame", Total_SliderFrame, 0, 1);
            }
            if (Total_SliderSash != 0)
            {
                data_Order.Tables[0].Rows.Add("SLIDER SASH", "Total Slider Sash", Total_SliderSash, 0, 2);
            }
            if (Total_SU != 0)
            {
                data_Order.Tables[0].Rows.Add("SEALED UNIT", "Total Sealed Unit", Total_SU, 0, 4);
            }
            if (Total_PDoor != 0)
            {
                data_Order.Tables[0].Rows.Add("PATIO DOOR", "Total Patio Door", Total_PDoor, 0, 3);
            }
            if (Total_Corner_dr != 0)
            { 
                data_Order.Tables[0].Rows.Add("CONER DRIVE HARDWEAR", "Total Corner Drive Hardware", Total_Corner_dr,0,5);
                Corner_dr+=3;
            }
            if (Total_Shape != 0)
            { 
                data_Order.Tables[0].Rows.Add("Shape", "Total Shape", Total_Shape, 0,6);
                Shape += 3;
            }
            if (Total_BayBow != 0)
            {
                data_Order.Tables[0].Rows.Add("BAY/BOW", "Total BAY/BOW", Total_BayBow, 0, 7);
                BayBow += 3;
            }
            if (Total_SS != 0)
            {
                data_Order.Tables[0].Rows.Add("SHAPE SEALD UNIT", "Total Shape Sealed Unit", Total_SS, 0,8);
                Shape_SU += 3;
            }
            if (Total_GRL != 0)
            {
                data_Order.Tables[0].Rows.Add("GRILL", "Total GRILL", Total_GRL, 0,9);
                Grill+=3;
            }
            if (Total_SDL != 0)
            {
                data_Order.Tables[0].Rows.Add("SDL", "Total SDL", Total_SDL, 0,10);
                Sdl+=3;
            }
            if (Total_DW != 0)
            {
                data_Order.Tables[0].Rows.Add("DUMMI WINDOW", "Total Dummy Window", Total_DW, 0,11);
                DW+=3;
            }
            int row_index_Corner_dr = 0, row_index_Shape = 0, row_index_BayBow = 0, row_index_SS = 0,
                row_index_GRL = 0, row_index_SDL = 0, row_index_DW = 0;
            foreach (var row in rows)
            {
                if (row.Corner_dr != 0)
                {
                    //if (Corner_dr % 3 == 2) row_index_Corner_dr += 1;
                    data_Order.Tables[0].Rows.Add("CONER DRIVE HARDWEAR", row.Order+"-", row.Corner_dr, Corner_dr % 3,5);
                    Corner_dr++;
                }
                if (row.SH != 0)
                {
                    if (Shape % 3 ==2) row_index_Shape += 1;
                    data_Order.Tables[0].Rows.Add("Shape", row.Order + "-", row.SH , Shape % 3,6);
                    Shape++;
                }
                if (row.BOW + row.BY != 0)
                {
                    if (BayBow % 3 == 2) row_index_BayBow += 1;
                    data_Order.Tables[0].Rows.Add("BAY/BOW", row.Order + "-", row.BOW + row.BY , BayBow % 3,7);
                    BayBow++;
                }
                if (row.SS != 0)
                {
                    if (Shape_SU % 3 == 2) row_index_SS += 1;
                    data_Order.Tables[0].Rows.Add("SHAPE SEALD UNIT", row.Order + "-", row.SS, Shape_SU % 3,8);
                    Shape_SU++;
                }
                if (row.GRL != 0)
                {
                    if (Grill % 3 == 2) row_index_GRL += 1;
                    data_Order.Tables[0].Rows.Add("GRILL", row.Order + "-", row.GRL, Grill % 3,9);
                    Grill++;
                }
                if (row.SDL != 0)
                {
                    if (Sdl % 3 ==2) row_index_SDL += 1;
                    data_Order.Tables[0].Rows.Add("SDL", row.Order + "-", row.SDL, Sdl % 3,10);
                    Sdl++;
                }
                if (row.DW != 0)
                {
                    if (DW % 3 == 2) row_index_DW += 1;
                    data_Order.Tables[0].Rows.Add("DUMMI WINDOW", row.Order + "-", row.DW , DW % 3,11);
                    DW++;
                }
            }
            DataTable dtSorted = new DataTable();
            DataView dv = data_Order.Tables[0].DefaultView;
            dv.Sort = "Type ASC";
            dtSorted = dv.ToTable();
            data_Order.Tables[0].Clear();
            data_Order.Tables[0].Merge(dtSorted);
            for(int i = 0; i < data_Order.Tables[0].Rows.Count-1; i++)
            {
                if (data_Order.Tables[0].Rows[i]["Col_index"].ToString() == "2"
                    || data_Order.Tables[0].Rows[i]["Type"].ToString() != data_Order.Tables[0].Rows[i + 1]["Type"].ToString()
                    || data_Order.Tables[0].Rows[i]["Order"].ToString().Contains("Total"))
                {
                    data_Order.Tables[0].Rows[i + 1]["Index"] = Int32.Parse(data_Order.Tables[0].Rows[i]["Index"].ToString()) + 1;
                }
                else
                {
                    data_Order.Tables[0].Rows[i + 1]["Index"] = Int32.Parse(data_Order.Tables[0].Rows[i]["Index"].ToString());
                }
            }
            new OrderSummeryPrint(data_Order, _date.Value.ToString("dd- MMMM yyyy")).ShowDialog();
        }
    }
}
