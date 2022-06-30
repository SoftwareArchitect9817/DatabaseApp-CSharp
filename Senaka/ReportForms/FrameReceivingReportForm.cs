using Microsoft.Reporting.WinForms;

using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Senaka
{
    public partial class FrameReceivingReportForm : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        Timer blink_timer;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        List<string[]> ColorReceivingDB = new List<string[]>();
        List<string[]> VinylProReceivingDB = new List<string[]>();
        public class dataOrder
        {
            public string Order_numb { get; set; }
            public string Status { get; set; }
            public int Bmd_done { get; set; }
            public int Cs_F_done { get; set; }
            public int Cs_S_done { get; set; }
            public int Sm_F_done { get; set; }
            public int Lg_F_done { get; set; }
            public int Sl_F_done { get; set; }
            public int Sl_S_done { get; set; }
            public int Bmd_total { get; set; }
            public int Cs_F_total { get; set; }
            public int Cs_S_total { get; set; }
            public int Sm_F_total { get; set; }
            public int Lg_F_total { get; set; }
            public int Sl_F_total { get; set; }
            public int Sl_S_total { get; set; }
            public string Bmd_info { get; set; }
            public string Cs_F_info { get; set; }
            public string Cs_S_info { get; set; }
            public string Sm_F_info { get; set; }
            public string Lg_F_info { get; set; }
            public string Sl_F_info { get; set; }
            public string Sl_S_info { get; set; }
            public double Info { get; set; }
            public Boolean isWhite { get; set; }
            public string Location { get; set; }
        }
        List<dataOrder> ReceivingFrames = new List<dataOrder>();

        public FrameReceivingReportForm(List<string[]> ordersummaryData, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            
            initForm(ordersummaryData);
            if (startDate == endDate)
            {
                ListDateLbl.Text = "List Date: " + startDate.ToString("dd-MM-yyyy");
            }
            else
            {
                ListDateLbl.Text = "List Date: " + startDate.ToString("dd-MM-yyyy") + " to " + endDate.ToString("dd-MM-yyyy");
            }
        }

        private void insertData(List<string[]> FramesDB, Boolean isWhite, int idIndex, List<string[]> ordersummaryData)
        {
            for (int i = 0; i < FramesDB.Count; i++)
            {
                bool exist = false;
                string currOrdNumber = FramesDB[i][2];
                string location = ordersummaryData.First(x => x[0] == currOrdNumber)[3];
                int index = ReceivingFrames.FindIndex(x => x.Order_numb == currOrdNumber && x.isWhite == isWhite);
                Boolean done = FramesDB[i][idIndex] == null ? false : true;
            
                if (index > -1)
                {
                    if (Settings.Brickmould.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Bmd_done += 1;
                        ReceivingFrames[index].Bmd_total += 1;
                    }
                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Cs_F_done += 1;
                        ReceivingFrames[index].Cs_F_total += 1;
                    }
                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Cs_S_done += 1;
                        ReceivingFrames[index].Cs_S_total += 1;
                    }
                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Sl_F_done += 1;
                        ReceivingFrames[index].Sl_F_total += 1;
                    }
                    else if (Settings.Slider_sash.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Sl_S_done += 1;
                        ReceivingFrames[index].Sl_S_total += 1;
                    }
                    else if (Settings.Small_Fix.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Sm_F_done += 1;
                        ReceivingFrames[index].Sm_F_total += 1;
                    }
                    else if (Settings.Large_Fix.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (done) ReceivingFrames[index].Lg_F_done += 1;
                        ReceivingFrames[index].Lg_F_total += 1;
                    }
                    exist = true;
                }
                if (!exist)
                {
                    if (Settings.Brickmould.Any(type => type[2] == FramesDB[i][1]))
                    {
                        dataOrder element = new dataOrder();
                        element.Order_numb = currOrdNumber;
                        if (done) element.Bmd_done = 1;
                        element.Bmd_total = 1;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Cs_F_done = 1;
                        element.Cs_F_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Cs_S_done = 1;
                        element.Cs_S_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Sl_F_done = 1;
                        element.Sl_F_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Slider_sash.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Sl_S_done = 1;
                        element.Sl_S_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Small_Fix.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Sm_F_done = 1;
                        element.Sm_F_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                    else if (Settings.Large_Fix.Any(type => type[2].Equals(FramesDB[i][1], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        dataOrder element = new dataOrder();
                        if (done) element.Lg_F_done = 1;
                        element.Lg_F_total = 1;
                        element.Order_numb = currOrdNumber;
                        element.isWhite = isWhite;
                        element.Location = location;
                        ReceivingFrames.Add(element);
                    }
                }
            }
        }

        private void initForm(List<string[]> ordersummaryData)
        {
            ProductionReportData.AutoGenerateColumns = false;

            int cs_f_TotalDone = 0, cs_s_TotalDone = 0, sm_f_TotalDone = 0, sl_f_TotalDone = 0, sl_s_TotalDone = 0, bmd_TotalDone = 0, lg_f_TotalDone = 0;
            int totalFrames = 0, doneFrames = 0;
            List<string> ordNumbers = ordersummaryData.FindAll(x => x[1] == "WHT" && x[2] == "WHT").Select(x => x[0]).ToList();
            VinylProReceivingDB = DB.getVinylProReceiving(ordNumbers);
            insertData(VinylProReceivingDB, true, 5, ordersummaryData);

            ordNumbers = ordersummaryData.FindAll(x => x[1] != "WHT" || x[2] != "WHT").Select(x => x[0]).ToList();
            ColorReceivingDB = DB.getColorFrameReceiving(ordNumbers); 
            insertData(ColorReceivingDB, false, 5, ordersummaryData);
          
            for (int i = 0; i < ReceivingFrames.Count; i++)
            {
                bool cs_f = false, cs_s = false, sm_f = false, sl_f = false, sl_s = false, bmd = false, lg_f = false;
                string status;
                int currentDone = 0, currentTotal = 0;
                ReceivingFrames[i].Bmd_info = ReceivingFrames[i].Bmd_done + "/" + ReceivingFrames[i].Bmd_total;
                ReceivingFrames[i].Cs_F_info = ReceivingFrames[i].Cs_F_done + "/" + ReceivingFrames[i].Cs_F_total;
                ReceivingFrames[i].Cs_S_info = ReceivingFrames[i].Cs_S_done + "/" + ReceivingFrames[i].Cs_S_total;
                ReceivingFrames[i].Lg_F_info = ReceivingFrames[i].Lg_F_done + "/" + ReceivingFrames[i].Lg_F_total;
                ReceivingFrames[i].Sl_F_info = ReceivingFrames[i].Sl_F_done + "/" + ReceivingFrames[i].Sl_F_total;
                ReceivingFrames[i].Sl_S_info = ReceivingFrames[i].Sl_S_done + "/" + ReceivingFrames[i].Sl_S_total;
                ReceivingFrames[i].Sm_F_info = ReceivingFrames[i].Sm_F_done + "/" + ReceivingFrames[i].Sm_F_total;

                bmd_TotalDone += ReceivingFrames[i].Bmd_done;
                cs_f_TotalDone += ReceivingFrames[i].Cs_F_done;
                cs_s_TotalDone += ReceivingFrames[i].Cs_S_done;
                lg_f_TotalDone += ReceivingFrames[i].Lg_F_done;
                sl_f_TotalDone += ReceivingFrames[i].Sl_F_done;
                sl_s_TotalDone += ReceivingFrames[i].Sl_S_done;
                sm_f_TotalDone += ReceivingFrames[i].Sm_F_done;

                currentDone += ReceivingFrames[i].Bmd_done
                    + ReceivingFrames[i].Cs_F_done + ReceivingFrames[i].Cs_S_done + ReceivingFrames[i].Sl_F_done
                    + ReceivingFrames[i].Lg_F_done + ReceivingFrames[i].Sl_S_done + ReceivingFrames[i].Sm_F_done;

                currentTotal += ReceivingFrames[i].Bmd_total
                    + ReceivingFrames[i].Cs_F_total + ReceivingFrames[i].Cs_S_total + ReceivingFrames[i].Sl_F_total
                    + ReceivingFrames[i].Lg_F_total + ReceivingFrames[i].Sl_S_total + ReceivingFrames[i].Sm_F_total;

                totalFrames += currentTotal;
                doneFrames += currentDone;
               
                if (ReceivingFrames[i].Bmd_done == ReceivingFrames[i].Bmd_total) bmd = true;
                if (ReceivingFrames[i].Cs_F_done == ReceivingFrames[i].Cs_F_total) cs_f = true;
                if (ReceivingFrames[i].Cs_S_done == ReceivingFrames[i].Cs_S_total) cs_s = true;
                if (ReceivingFrames[i].Lg_F_done == ReceivingFrames[i].Lg_F_total) lg_f = true;
                if (ReceivingFrames[i].Sl_F_done == ReceivingFrames[i].Sl_F_total) sl_f = true;
                if (ReceivingFrames[i].Sl_S_done == ReceivingFrames[i].Sl_S_total) sl_s = true;
                if (ReceivingFrames[i].Sm_F_done == ReceivingFrames[i].Sm_F_total) sm_f = true;

                if (cs_f && cs_s && sm_f && sl_f && sl_s && bmd && lg_f) status = "COMPLETE";
                else if (currentDone != 0) status = "IN PROGRESS";
                else status = "NOT READY";

                ReceivingFrames[i].Status = status;
                ReceivingFrames[i].Info = (double)currentDone / (double)currentTotal * 100;
            }
            List<string[]> NotFoundOrders = ordersummaryData.Where(p => !ReceivingFrames.Any(p2 => p2.Order_numb == p[0]))
                .Select(x => new string[] { x[0], x[3] })
                .ToList();
            for (int i = 0; i < NotFoundOrders.Count; i++)
            {
                dataOrder row = new dataOrder();
                row.Order_numb = NotFoundOrders[i][0];
                row.Cs_F_info = "";
                row.Cs_S_info = "";
                row.Lg_F_info = "";
                row.Sl_F_info = "";
                row.Sl_S_info = "";
                row.Sm_F_info = "";
                row.Bmd_info = "";
                row.Status = "NOT CUT";
                row.Location = NotFoundOrders[i][1];
                ReceivingFrames.Add(row);
            }

            totacasementlfrmLbl.Text = cs_f_TotalDone.ToString();
            TotalCasementSashblData.Text = cs_s_TotalDone.ToString();
            TotalSliderFrameblData.Text = sl_f_TotalDone.ToString();
            TotalSliderSashLblData.Text = sl_s_TotalDone.ToString();
            TotalBrickmouldLblData.Text = bmd_TotalDone.ToString();
            TotalLgFLblData.Text = lg_f_TotalDone.ToString();
            TotalSmFLblData.Text = sm_f_TotalDone.ToString();
            TotalCompletelblData.Text = doneFrames.ToString();
            TotalFramelblData.Text = totalFrames.ToString();
            ProductionReportData.DataSource = ReceivingFrames;
        }

        private void ProductionReportData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < ProductionReportData.RowCount; i++)
            {
                if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "COMPLETE")
                {
                    ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                }
                else if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "IN PROGRESS")
                {
                    ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                }
                else if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "NOT READY")
                {
                    ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.OrangeRed;
                }
            }
        }

        private void FrameClearingReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            Boolean langstaff = false, jacob = false, bothlocation = false;
            Boolean white = false, colour = false, colourWhtAll = false;
            Boolean complete = false, incomplete = false, complIncomplAll = false;

            langstaff = radio3350Langstaff.Checked;
            jacob = radio100JacobKeffer.Checked;
            bothlocation = radioBothLocation.Checked;

            //Colour White Condition
            white = radioWhite.Checked;
            colour = radioColour.Checked;
            colourWhtAll = radioWhtColourAll.Checked;

            complete = radioComplete.Checked;
            incomplete = radioIncomplete.Checked;
            complIncomplAll = radioAll.Checked;

            for (int j = 0; j < ProductionReportData.RowCount; j++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                currencyManager1.SuspendBinding();
                ProductionReportData.Rows[j].Visible = true;
                if ((langstaff && ProductionReportData.Rows[j].Cells[12].Value.ToString() != "3350 Langstaff")
                    || (jacob && ProductionReportData.Rows[j].Cells[12].Value.ToString() != "100 Jacob Keffer")
                    || (white && ProductionReportData.Rows[j].Cells[11].Value.ToString() != "True")
                    || (colour && ProductionReportData.Rows[j].Cells[11].Value.ToString() != "False")
                    || (complete && ProductionReportData.Rows[j].Cells[0].Value.ToString() != "COMPLETE")
                    || (incomplete && ProductionReportData.Rows[j].Cells[0].Value.ToString() == "COMPLETE"))
                {
                    ProductionReportData.Rows[j].Visible = false;
                }
                currencyManager1.ResumeBinding();
            }
        }

        public Byte[] CreateProgressBar(double p)
        {
            int pbComplete = Convert.ToInt32(p);
            ImageConverter converter = new ImageConverter();
            int pbWIDTH, pbHEIGHT;
            double pbUnit;

            pbWIDTH = 1000;
            pbHEIGHT = 250;

            pbUnit = pbWIDTH / 100.0;
            Bitmap bmp = new Bitmap(pbWIDTH, pbHEIGHT);
            Graphics g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.White);

            //draw progressbar
            g.FillRectangle(Brushes.LimeGreen, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));

            //draw % complete
            g.DrawString(pbComplete + "%", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));


            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            OrderDataSet data_Order = new OrderDataSet();
            string path = Path.Combine(Environment.CurrentDirectory, @"reports\FrameClearingReport.rdlc");
            int rowCount = ProductionReportData.Rows.Count;
            
            for (int i = 0; i < rowCount; i++)
            {
                data_Order.Tables[0].Rows.Add(
                    ProductionReportData.Rows[i].Cells[0].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[1].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[2].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[3].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[4].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[5].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[6].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[7].Value.ToString(),
                    ProductionReportData.Rows[i].Cells[8].Value.ToString(),
                    CreateProgressBar(Double.Parse(ProductionReportData.Rows[i].Cells[9].Value.ToString()))
                );
                rds.Value = data_Order.Tables[0];
            }
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";
            report.DataSources.Add(rds);
            Export(report);
            Print_page();
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
                    <PageWidth>11.69in</PageWidth>
                    <PageHeight>8.27in</PageHeight>
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

        private void ExportNotComplete(LocalReport report)
        {

            string deviceInfo =
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>8.27in</PageWidth>
                    <PageHeight>11.69in</PageHeight>
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

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height
            );

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
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }

        private void buttonPrintNotComplete_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            OrderNotCompleteDataSet data_Order = new OrderNotCompleteDataSet();
            string path = Path.Combine(Environment.CurrentDirectory, @"reports\FrameShipping_Report.rdlc");
            int rowCount = ProductionReportData.Rows.Count;
            IEnumerable<string> LineNumbersVinyl = from order in VinylProReceivingDB
                                                   where order[5] == null
                                                  select order[0];
            List<string[]> VinylData = DB.getFrameCuttingByNumbs(LineNumbersVinyl.ToList());
            foreach (var element in Settings.Casing)
            {
                VinylData.RemoveAll(x => x[8] == element[2]);
            }
            foreach (var element in VinylData)
            {
                string name = "", date = "", machine_id = "", time = "", status = "Vinyl pro receiving";
                data_Order.Tables[0].Rows.Add(
                    element[10],
                    element[12],
                    element[13],
                    element[8],
                    element[6],
                    element[17],
                    element[18],
                    element[20],
                    date,
                    time,
                    name,
                    machine_id,
                    status
                );
            }
            IEnumerable<string> LineNumbersColor = from order in ColorReceivingDB
                                                   where order[5] == null
                                                   select order[0];
            List<string[]> ColourData = DB.getFrameCuttingByNumbs(LineNumbersColor.ToList());
            foreach (var element in Settings.Casing)
            {
                ColourData.RemoveAll(x => x[8] == element[2]);
            }
            foreach (var element in ColourData)
            {
                string name = "", date = "", machine_id = "", time = "", status = "Color receiving";
                data_Order.Tables[0].Rows.Add(
                    element[10],
                    element[12],
                    element[13],
                    element[8],
                    element[6],
                    element[17],
                    element[18],
                    element[20],
                    date,
                    time,
                    name,
                    machine_id,
                    status
                );
            }
            rds.Value = data_Order.Tables[0];
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
            report.SetParameters(reportParameters);
            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";
            report.DataSources.Add(rds);
            ExportNotComplete(report);
            Print_page();
        }

        private void ProductionReportData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ProductionReportData.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                string order_number = ProductionReportData.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                if (ProductionReportData.Rows[e.RowIndex].Cells[11].Value.ToString() == "True")
                {
                    InquireForm inquireForm = new InquireForm(data, "VinylFrameReceiving", false);
                    inquireForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                    inquireForm.ShowDialog();
                }
                else if (ProductionReportData.Rows[e.RowIndex].Cells[11].Value.ToString() == "False")
                {
                    InquireForm inquireForm = new InquireForm(data, "ColourReceiving", false);
                    inquireForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                    inquireForm.ShowDialog();
                }
            }
        }

        void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxSearch.Text;
                if (data != "")
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                    currencyManager1.SuspendBinding();
                    for (int i = 0; i < ProductionReportData.Rows.Count; i++)
                    {
                        if (ProductionReportData.Rows[i].Cells[1].Value.ToString() != data)
                        {
                            ProductionReportData.Rows[i].Visible = false;
                        }
                    }
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    for (int i = 0; i < ProductionReportData.Rows.Count; i++)
                    {
                        ProductionReportData.Rows[i].Visible = true;
                    }
                }
            }
        }
    }
}

