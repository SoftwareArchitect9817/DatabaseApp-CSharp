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

namespace Senaka
{
    public partial class FrameReport : Form
    {
        string _Type;
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        Timer blink_timer;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        public FrameReport(List<string> order_number)
        {
            InitializeComponent();
            List<string[]> data = DB.getFramesCuttingByOrdersWID(order_number);
            List<string[]> ListDates = DB.getOrderListDate(order_number);
            Set(data, ListDates);
        }
        public void Set(List<string[]> data, List<string[]> ListDates)
        {
            if (data != null)
            {
                List<string[]> data_done = new List<string[]>();
                List<string> frame_ids = new List<string>();
                List<string> names = new List<string>();
               
                    foreach (var element in data)

                        frame_ids.Add(element[5]);

               
                    List<string[]> FrameClearing_prefix_date = new List<string[]>();

                    data_done = DB.importFrameClearingByIds(frame_ids);
                if (data_done != null)
                {
                    foreach (var element in data_done)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        FrameClearing_prefix_date = DB.importFrameClearingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string status = "NOT READY", listDate="";
                        var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        string[] OrdSummary = ListDates.FirstOrDefault(x => x[0] == element[9]);
                        if (OrdSummary != null)
                            listDate = OrdSummary[1];
                        if (match != null)
                        {
                            status = "COMPLETE";
                          
                        }

                        dataClearing.Rows.Add(element[9], element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], listDate, status);

                    }
                    for (int i = 0; i < dataClearing.Rows.Count - 1; i++)
                    {
                        if (dataClearing.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataClearing.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else dataClearing.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }

                }
                
            }
        }
        
        private void InquireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        
        private void FrameReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();

            FrameReportDataSet data_Order = new FrameReportDataSet();
            string path = "";

            int rowCount = 0;
            rowCount = dataClearing.Rows.Count;

            path = Path.Combine(Environment.CurrentDirectory, @"reports\FrameReport.rdlc");
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow row = dataClearing.Rows[i];
                 data_Order.Tables[0].Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value);
            }
            rds.Value = data_Order.Tables[0];
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));




            report.SetParameters(reportParameters);

            report.SetParameters(reportParameters);
            rds.Name = "DataSet2";




            report.DataSources.Add(rds);
            ExportNotComplete(report);
            Print_page();
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
        private Stream CreateStream(string name,
  string fileNameExtension, Encoding encoding,
  string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
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
    }
}
