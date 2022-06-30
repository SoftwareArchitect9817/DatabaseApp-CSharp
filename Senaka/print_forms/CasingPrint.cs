using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Senaka.print_forms
{
    public partial class CasingPrint : Form
    {
        List<string[]> data = new List<string[]>();
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public CasingPrint(List<string[]> data_get) //framescutting
        {
            InitializeComponent();

            data = data_get;
        }

        private void CasingPrint_Load(object sender, EventArgs e)
        {
            List<string> lineNumbers = new List<string>();
            foreach (var element in data)
            {
                lineNumbers.Add(element[18]);
            }
            List<string[]> workOrderData = DB.importWorkOrderByLines(lineNumbers);
            foreach (var element in data)
            {
                string compnayName = "", customerPO = "";
                List<string[]> currentWorkOrder = workOrderData.Where(x => x[9] == element[18]).ToList();
                if(currentWorkOrder.Count > 0)
                {
                    compnayName = currentWorkOrder[0][3];
                    customerPO = currentWorkOrder[0][1];
                }
                dataFramePrint.Rows.Add(false, element[5], element[12], element[18], element[11], element[7], compnayName, customerPO);
            }
        }

        private void CasingPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void printBarcode_Click(object sender, EventArgs e)
        {
            CasingDataSet casingDataSet = new CasingDataSet();
            var checkedRows = from DataGridViewRow r in dataFramePrint.Rows
                              where Convert.ToBoolean(r.Cells[0].Value) == true
                              select r;
            foreach (var row in checkedRows)
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, row.Cells[1].Value.ToString(), 360, 80);
                byte[] barcode = ImageToByteArray(img);
                casingDataSet.Tables[0].Rows.Add(
                    barcode,
                    row.Cells[3].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString()
                );
            }
            if (casingDataSet.Tables[0].Rows.Count > 0)
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

        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>4in</PageWidth>
                    <PageHeight>2in</PageHeight>
                    <MarginTop>0.3in</MarginTop>
                    <MarginLeft>0.3in</MarginLeft>
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

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Print_page()
        {
            if (m_streams == null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.DefaultPageSettings.Landscape = true;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
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


