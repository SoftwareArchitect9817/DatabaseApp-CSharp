using Microsoft.Reporting.WinForms;

using Senaka.data_sets;
using Senaka.lib;
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
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Senaka
{
    public partial class GlassReportForm : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        List<string[]> _data;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        public class List_order_type
        {
            public List_order_type(string order_number, List<string> cs_f_numbers, List<string> cs_s_numbers, List<string> sm_f_numbers, List<string> l_f_numbers, List<string> sl_f_numbers, List<string> sl_s_numbers, List<string> bmd_numbers)
            {
                Order_numb = order_number;
                Cs_F_Numbers = cs_f_numbers;
                Cs_S_Numbers = cs_s_numbers;

                Sl_F_Numbers = sl_f_numbers;
                Sl_S_Numbers = sl_s_numbers;
                Bmd_Numbers = bmd_numbers;
                Sm_F_Numbers = sm_f_numbers;
                L_F_Numbers = l_f_numbers;
            }

            public string Order_numb { get; set; }
            public List<string> Cs_F_Numbers { get; set; }
            public List<string> Cs_S_Numbers { get; set; }

            public List<string> Sl_F_Numbers { get; set; }
            public List<string> Sl_S_Numbers { get; set; }
            public List<string> Bmd_Numbers { get; set; }
            public List<string> Sm_F_Numbers { get; set; }
            public List<string> L_F_Numbers { get; set; }

        }

        public GlassReportForm(List<string[]> data)
        {
            InitializeComponent();
            _data = data;
            initForm(data);
        }
        private void initForm(List<string[]> data)
        {
            List<string> orders = new List<string>();

            int rush_count = 0, su_count = 0, grills_count = 0, shape_count = 0, total_complete = 0;

            foreach (var element in data)
            {
                string order = element[(int)GLASS.ORDER];
                string summaryOrder = element[element.Length - 1];
                if (order != null)
                {
                    if (!orders.Contains(order))
                    {
                        string status;
                        var t_orders = data.Where(x => x[(int)GLASS.ORDER] == order).ToList();
                        int total = t_orders.Count();
                        int t_complete = 0;
                        if (t_orders != null)
                            t_complete = t_orders.Where(x => x[(int)GLASS.COMPLETE] == "1").Count();

                        if (element[(int)GLASS.DESCRIPTION].Contains("RUSH")) rush_count += 1;
                        if (element[(int)GLASS.WINDOW_TYPE].Contains("Window_Type_SU")) su_count += 1;
                        if (element[(int)GLASS.GRILLS] != "" && !element[(int)GLASS.GRILLS].Contains("SDL")) grills_count += 1;
                        if (element[(int)GLASS.WINDOW_TYPE].Contains("Window_Type_SHAPE")) shape_count += 1;

                        if (t_complete == total) status = "COMPLETE";
                        else if (t_complete == 0) status = "NOT START";
                        else status = "IN PROGRESS";
                        GlassReportData.Rows.Add(status, order, t_complete + "/" + t_orders.Count, (double)t_complete / (double)total * 100);
                        GlassReportData.Rows[GlassReportData.Rows.Count - 1].Cells[0].Style.BackColor
                          = status == "COMPLETE" ? Color.Lime : (status == "NOT START" ? Color.OrangeRed : Color.Gold);
                        orders.Add(order);
                        total_complete += t_complete;
                    }
                }
                else
                {
                    GlassReportData.Rows.Add("NOT CUT", summaryOrder, 0 + "/" + 0, 0);
                    GlassReportData.Rows[GlassReportData.Rows.Count - 1].Cells[0].Style.BackColor = Color.OrangeRed;
                }

            }

            TotalRushLblData.Text = rush_count.ToString();
            TotalShapeLblData.Text = shape_count.ToString();
            totalSULbl.Text = su_count.ToString();
            TotalGrillslblData.Text = grills_count.ToString();
            TotalGlasslblData.Text = data.Count.ToString();
            TotalCompletelblData.Text = total_complete.ToString();

        }
     
            private void ProductionReportData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < GlassReportData.RowCount; i++)
            {
                if (GlassReportData.Rows[i].Cells[0].Value.ToString() == "COMPLETE") GlassReportData.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                else if (GlassReportData.Rows[i].Cells[0].Value.ToString() == "IN PROGRESS") GlassReportData.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                else if (GlassReportData.Rows[i].Cells[0].Value.ToString() == "NOT READY") GlassReportData.Rows[i].Cells[0].Style.BackColor = Color.OrangeRed;

            }
        }

        private void FrameClearingReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void radioComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioComplete.Checked)
            {
                for (int j = 0; j < GlassReportData.RowCount; j++)
                {
                    if (GlassReportData.Rows[j].Cells[0].Value.ToString() == "COMPLETE")
                    {

                        GlassReportData.Rows[j].Visible = true;

                    }
                    else
                    {

                        GlassReportData.Rows[j].Visible = false;

                    }
                }
            }
            else if (!radioComplete.Checked)
            {
                for (int j = 0; j < GlassReportData.RowCount; j++)
                {
                    if (GlassReportData.Rows[j].Cells[0].Value.ToString() == "COMPLETE")
                    {
                        GlassReportData.Rows[j].Visible = false;
                    }
                    else
                    {
                        GlassReportData.Rows[j].Visible = true;
                    }
                }
            }
        }

        private void radioIncomplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIncomplete.Checked)
            {
                for (int j = 0; j < GlassReportData.RowCount; j++)
                {
                    if (GlassReportData.Rows[j].Cells[0].Value.ToString() != "COMPLETE")
                    {
                        GlassReportData.Rows[j].Visible = true;
                    }
                    else
                    {
                        GlassReportData.Rows[j].Visible = false;
                    }
                }
            }
            else if (!radioIncomplete.Checked)
            {
                for (int j = 0; j < GlassReportData.RowCount; j++)
                {
                    if (GlassReportData.Rows[j].Cells[0].Value.ToString() != "COMPLETE")
                    {
                        GlassReportData.Rows[j].Visible = false;
                    }
                    else
                    {
                        GlassReportData.Rows[j].Visible = true;
                    }
                }
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                for (int j = 0; j < GlassReportData.RowCount; j++)
                {
                    GlassReportData.Rows[j].Visible = true;
                }
            }

        }

        public Byte[] CreateProgressBar(double p)
        {
            ImageConverter converter = new ImageConverter();
            Bitmap bmp = new Bitmap(200, 50);
            Graphics flagGraphics = Graphics.FromImage(bmp);
            int progressVal = Convert.ToInt32(p);
            float percentage = (progressVal / 100.0f);

            string s = progressVal.ToString() + "%";

            flagGraphics.FillRectangle(new SolidBrush(System.Drawing.Color.LimeGreen), 0, 0, Convert.ToInt32(percentage * 100) * 2, 50);
            flagGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            flagGraphics.DrawString(s, System.Drawing.SystemFonts.DefaultFont, new SolidBrush(Color.Black), (bmp.Width - flagGraphics.MeasureString(s, System.Drawing.SystemFonts.DefaultFont).Width) / 2, (bmp.Height - flagGraphics.MeasureString(s, System.Drawing.SystemFonts.DefaultFont).Height) / 2);

            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            GlassDataSet data_Order = new GlassDataSet();
            string path = "";

            int rowCount = 0;
            rowCount = GlassReportData.Rows.Count;

            path = Path.Combine(Environment.CurrentDirectory, @"reports\Glass_Report.rdlc");
            for (int i = 0; i < rowCount; i++)
            {
                data_Order.Tables[0].Rows.Add(GlassReportData.Rows[i].Cells[0].Value.ToString(), GlassReportData.Rows[i].Cells[1].Value.ToString(), CreateProgressBar(Double.Parse(GlassReportData.Rows[i].Cells[3].Value.ToString())));
            }
            rds.Value = data_Order.Tables[0];
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));

            LocalReport report = new LocalReport();
            report.ReportPath = path;

            report.SetParameters(reportParameters);
            report.DataSources.Add(rds);
            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";

            report.DataSources.Add(rds);
            Export(report);
            Print_page();
        }
        private Stream CreateStream(string name,
            string fileNameExtension, Encoding encoding,
             string mimeType, bool willSeek)
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
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private void ExportNotComplete(LocalReport report)
        {

            string deviceInfo =
        @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>11.69in</PageWidth>
                <PageHeight>8.27in</PageHeight>
                <MarginTop>0.5in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.5in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);


            foreach (Stream stream in m_streams)
                stream.Position = 0;


        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

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
                throw new Exception("Error: no stream to print.");
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
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }

        private void buttonPrintNotComplete_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            GlassNotCompleteDataSet glassNotCompleteDataSet = new GlassNotCompleteDataSet();
            string path = "";

         
            path = Path.Combine(Environment.CurrentDirectory, @"reports\GlassNotComplete_Report.rdlc");
            List<string[]> suIdsCount = DB.getIgSortingCount(_data.Where(x => x[(int)GLASS.COMPLETE] != "1").Select(x => x[(int)GLASS.SEALED_UNIT_ID]).ToList());
          foreach (var element in _data.Where(x => x[(int)GLASS.COMPLETE] != "1"))
            {
                string[] SuIdCount = suIdsCount.FirstOrDefault(x => x[0] == element[(int)GLASS.SEALED_UNIT_ID]);
                glassNotCompleteDataSet.Tables[0].Rows.Add(element[(int)GLASS.SEALED_UNIT_ID], element[(int)GLASS.ORDER], element[(int)GLASS.WINDOW_TYPE], element[(int)GLASS.LINE_1], element[(int)GLASS.OT], element[(int)GLASS.GLASS_TYPE],
                    element[(int)GLASS.SPACER], element[(int)GLASS.GRILLS], element[(int)GLASS.WIDTH], element[(int)GLASS.HEIGHT], element[(int)GLASS.QTY],
                  SuIdCount != null ? SuIdCount[1] : "", element[(int)GLASS.RACK_ID]);
            }
            rds.Value = glassNotCompleteDataSet.Tables[0];
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
            if (e.ColumnIndex == GlassReportData.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                if (GlassReportData.Rows[e.RowIndex].Cells[0].Value.ToString() != "NOT CUT")
                {
                    string order_number = GlassReportData.Rows[e.RowIndex].Cells[1].Value.ToString();

                    if (order_number != null)
                    {
                        List<string[]> data = DB.fetchRows("glassreport", "order", order_number, false);
                        if (data.Count == 0)
                        {
                            MessageBox.Show("Invalid Order Number!", "Error");
                            return;
                        }
                        Hide();
                        IGInquireSubForm subform = new IGInquireSubForm(data, null, true);
                        subform.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                        subform.ShowDialog();
                    }
                }
                else MessageBox.Show("Glass is not cut!", "Error");
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
                    for (int i = 0; i < GlassReportData.Rows.Count; i++)
                        if (GlassReportData.Rows[i].Cells[1].Value.ToString() != data) GlassReportData.Rows[i].Visible = false;
                }
                else for (int i = 0; i < GlassReportData.Rows.Count; i++)
                        GlassReportData.Rows[i].Visible = true;
            }
        }


    }
}





