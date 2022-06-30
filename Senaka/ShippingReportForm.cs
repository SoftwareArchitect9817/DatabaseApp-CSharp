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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class ShippingReportForm : Form
    {
        private string _batch;
        private IList<Stream> m_streams;
        private int m_currentPageIndex;

        public ShippingReportForm(DateTime[] dates, string batch, List<string[]> report_data)
        {
            InitializeComponent();

            _batch = batch;

            List<string[]> dealers = DB.getWorkOrderDealers();
            foreach (var dealer in dealers)
            {
                textBoxCompanyName.AutoCompleteCustomSource.Add(dealer[0]);
            }
            textBoxCompanyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            int total_wqty = 0, total_pdoor = 0, total_casing = 0;
            string su;
            List<string> sus = new List<string>();
            foreach (var row in report_data)
            {
                su = row[4].Split('#')[0];
                dataGridViewShippingReport.Rows.Add(
                    row[0],
                    row[1],
                    row[2],
                    row[3],
                    su
                );
                total_wqty += int.Parse(row[1]);
                total_pdoor += int.Parse(row[2]);
                total_casing += int.Parse(row[3]);
                if (!sus.Contains(su)) sus.Add(su);
            }
            labelTotalWindows.Text = total_wqty.ToString();
            labelTotalPatioDoors.Text = total_pdoor.ToString();
            labelTotalCasing.Text = total_casing.ToString();
            labelTotalSU.Text = sus.Count.ToString();
        }

        private void ShippingReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void buttonAddtional_Click(object sender, EventArgs e)
        {
            string company = textBoxCompanyName.Text;
            new ShippingReportAddtionalForm(company, _batch).ShowDialog();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            LocalReport report = getReport();
            Export(report);
            Print_page();
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            string company = textBoxCompanyName.Text;
            if (company == "") return;
            List<string> emails_list = new List<string>();
            foreach (string[] item in Settings.Shipping_Report_Dealers)
            {
                if (item[0] == company)
                {
                    emails_list.Add(item[1]);
                }
            }
            if (emails_list.Count == 0)
            {
                MessageBox.Show("Cannot find email.", "Error");
                return;
            }
            try
            {
                LocalReport report = getReport();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                byte[] bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                MemoryStream st = new MemoryStream(bytes);
                st.Seek(0, SeekOrigin.Begin);
                Attachment a = new Attachment(st, "WindowsShippingReport.pdf");
                
                foreach (var email in emails_list)
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress(Settings.sender_email);

                    message.To.Add(new MailAddress(email));
                    message.Attachments.Add(a);
                    message.Subject = "Windows Shipping Report";
                    //message.IsBodyHtml = true; //to make message body as html  
                    //message.Body = htmlString;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;


                    smtp.Credentials = new NetworkCredential(Settings.sender_email, Settings.sender_pass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                if (emails_list.Count > 1) MessageBox.Show("Emails were sent successfully!");
                else if (emails_list.Count == 1) MessageBox.Show("Email was sent successfully!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF File|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.ShowDialog();
            string filename = saveFileDialog.FileName;
            if (string.IsNullOrEmpty(filename)) return;

            LocalReport report = getReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            byte[] bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            MemoryStream st = new MemoryStream(bytes);
            st.Seek(0, SeekOrigin.Begin);
            using (FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            st.CopyTo(file);

            MessageBox.Show("File saved!", "Info");
        }

        private LocalReport getReport()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"reports\WindowsShippingReport.rdlc");
            LocalReport report = new LocalReport();
            report.ReportPath = path;

            WindowsShippingDataSet windowsShippingDataSet = new WindowsShippingDataSet();
            for (int i = 0; i < dataGridViewShippingReport.Rows.Count; i++)
            {
                windowsShippingDataSet.Tables[0].Rows.Add(
                    dataGridViewShippingReport.Rows[i].Cells[0].FormattedValue.ToString(),
                    dataGridViewShippingReport.Rows[i].Cells[1].FormattedValue.ToString(),
                    dataGridViewShippingReport.Rows[i].Cells[2].FormattedValue.ToString(),
                    dataGridViewShippingReport.Rows[i].Cells[3].FormattedValue.ToString(),
                    dataGridViewShippingReport.Rows[i].Cells[4].FormattedValue.ToString()
                );
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = windowsShippingDataSet.Tables[0];
            report.DataSources.Add(rds);
            return report;
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

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
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
    }
}
