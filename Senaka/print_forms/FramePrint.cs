using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
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
    public partial class FramePrint : Form
    {
        List<string[]> data = new List<string[]>();
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public FramePrint(List<string[]> data_get)
        {
            InitializeComponent();

            data = data_get;
        }

        private void FramePrint_Load(object sender, EventArgs e)
        {
            foreach (var element in data)
            {
                dataFramePrint.Rows.Add(
                    false,
                    element[5],     //F
                    element[12],    //M
                    element[18],    //S
                    element[11],    //N
                    element[7],     //H
                    element[9],     //J
                    element[15],    //P
                    element[3]      //D
                );
            }
        }

        private void FramePrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void printBarcode_Click(object sender, EventArgs e)
        {
            FrameCutDataSet frameCutDataSet = new FrameCutDataSet();
            var checkedRows = from DataGridViewRow r in dataFramePrint.Rows
                              where Convert.ToBoolean(r.Cells[0].Value) == true
                              select r;
            foreach (var row in checkedRows)
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, row.Cells[1].Value.ToString(), 360, 80);
                byte[] barcode = ImageToByteArray(img);
                frameCutDataSet.Tables[0].Rows.Add(
                    barcode,
                    row.Cells[6].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString()
                );
            }
            if (frameCutDataSet.Tables[0].Rows.Count != 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = frameCutDataSet.Tables[0];
                new UniversalPrint(rds, null, @"reports\FrameCutLabelReport.rdlc").Show();
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
                    <PageHeight>1in</PageHeight>
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
    }
}