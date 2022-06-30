using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
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
    public partial class CustomLabelForm : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public CustomLabelForm()
        {
            InitializeComponent();
        }

        private void CustomLabelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            if (BarcodetextBox.Text != null & BarcodetextBox.Text != "")
            {
                Font arialFont = new Font("Arial", 10);
                ImageConverter converter = new ImageConverter();
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, BarcodetextBox.Text, 337, (75 - TextRenderer.MeasureText(DescriptiontextBox.Text, arialFont).Height));
                Bitmap bitmap = new Bitmap(337, 75);//load the image file

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {

                    graphics.DrawString(DescriptiontextBox.Text, arialFont, Brushes.Black, (337 - graphics.MeasureString(DescriptiontextBox.Text, SystemFonts.DefaultFont).Width) / 2, 0);
                    graphics.DrawImage(img, 0, graphics.MeasureString(DescriptiontextBox.Text, arialFont).Height);

                }

                string path = Path.Combine(Environment.CurrentDirectory, @"reports\BarcodeReport.rdlc");
                LocalReport report = new LocalReport();
                report.ReportPath = path;



                BarcodeDataSet barcodeDataSet = new BarcodeDataSet();


                barcodeDataSet.Tables[0].Rows.Add((byte[])converter.ConvertTo(bitmap, typeof(byte[])));



                ReportDataSource rds = new ReportDataSource();

                rds.Name = "DataSet1";
                rds.Value = barcodeDataSet.Tables[0];



                report.DataSources.Add(rds);
                Export(report);
                Print_page();
                m_streams = null;
                m_currentPageIndex = 0;
            }
            else MessageBox.Show("Please enter data", "ERROR");
        }

        private Stream CreateStream(string name,
        string fileNameExtension, Encoding encoding,
        string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
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
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false;
        //    printDoc.PrinterSettings.DefaultPageSettings.Landscape = true;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

                PrintDialog printDlg = new PrintDialog();
               // printDlg.PrinterSettings.DefaultPageSettings.Landscape = true;
                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }
    }
}



