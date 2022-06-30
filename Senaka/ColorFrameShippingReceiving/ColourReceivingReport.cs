using DGVPrinterHelper;
using DGVPrinterHelper_report;
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
    public partial class ColourReceivingReport : Form
    {
        DateTime s, en;
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        List<Data_order> list_data = new List<Data_order>();
        string paint_company,oBatch;
        //  string t;
       
        public class Data_order
        {
            public Data_order(string order_number, string cs_f, string cs_s, string s_f, string l_f, string sl_f, string sl_s, string bmd,  int total,int delivered,string shipped_date,string status)
            {

                Order_numb = order_number;
                Cs_F = cs_f;
                Cs_S = cs_s;
                S_F = s_f;
                L_F = l_f;
                Sl_F = sl_f;
                Sl_S = sl_s;
                Bmd = bmd;
              
               
                Total = total;
                Delivered = delivered;
                Shipped_date = shipped_date;
                Status = status;

            }
          
            public string Order_numb { get; set; }
            public string Cs_F { get; set; }
            public string Cs_S { get; set; }
            public string S_F { get; set; }
            public string L_F { get; set; }
            public string Sl_F { get; set; }
            public string Sl_S { get; set; }
            public string Bmd { get; set; }
                    
            public int Total { get; set; }
            public int Delivered { get; set; }
            public string Shipped_date { get; set; }
            public string Status { get; set; }
        }
        public ColourReceivingReport(DateTime start, DateTime end, string batch_number,string onlyBatch)
        {
            InitializeComponent();
            if (onlyBatch == "False")
            {
                s = start;
                en = end;
            }
            oBatch = onlyBatch;
            string prefix_name="";
            string[] prefix;
            List<string[]> data, framecutting = new List<string[]>();
            List<string> numbs = new List<string>();

            if (batch_number != "" && batch_number != null)
            {
                prefix = DB.fetchRow("ColourReceiving_prefix", "batch_number", batch_number);
                if (prefix != null)
                {
                    prefix_name = prefix[2];
                  
                }
            }
            if (onlyBatch == "True")
                 data = DB.getColourReceivingbyBatch(batch_number);
            else data = DB.getColourReceivingbyBatchDate(start, end, batch_number);
            List<string> scanned_prefix = new List<string>();
            foreach (var item in data)
            {
                numbs.Add(item[0]);
                if (paint_company == null)
                {
                    if (!scanned_prefix.Contains(item[3]))
                    {
                        prefix = DB.fetchRow("ColourReceiving_prefix", "name", item[3]);
                        scanned_prefix.Add(item[3]);
                        if (prefix != null)

                            paint_company = prefix[2];
                    }

                }
            }
            framecutting = DB.getFrameCuttingByNumbs(numbs);
          
            var groupedFrames = framecutting.GroupBy(p => p[10]);
            List<string> order_numbers = new List<string>();
            foreach (var item in groupedFrames)

                order_numbers.Add(item.Key);
            List<string[]> framecutting_order = DB.getFrameCuttingByOrder(order_numbers);
            List<string[]> colour_shipping = DB.importColourShippingByIds(numbs);

            List<string> line_numbers_all = new List<string>();
            foreach (var item in framecutting_order)
                line_numbers_all.Add(item[6]);

            List<string> colorReceiving_all = DB.importColourReceivingByIds(line_numbers_all).Select(x => x[0]).ToList();
            foreach (var item in groupedFrames)
            {
                
                var groupedFrames_total = framecutting_order.GroupBy(p => p[10]).Where(p => p.Key == item.Key).First();
                string ordnumb = item.Key;
                int bmd_scnd_all = 0, cs_f_scnd_all = 0, cs_s_scnd_all = 0, sl_f_scnd_all = 0, sl_s_scnd_all = 0, s_f_scnd_all = 0, l_f_scnd_all = 0,
                    bmd = 0, cs_f = 0, cs_s = 0, sl_f = 0, sl_s = 0, s_f = 0, l_f = 0, total=0,delivered=0, bmd_total = 0, cs_f_total = 0, cs_s_total = 0,
                    sl_f_total = 0, sl_s_total = 0, s_f_total = 0, l_f_total = 0;
                string colour_in = "", colour_out = "",shipped_date="";
                List<string> numbers = new List<string>();
                //iterating through values
                foreach (var line_total in groupedFrames_total)
                {
                    if (Settings.Brickmould.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        bmd_total += 1;

                        if (colorReceiving_all.Contains(line_total[6])) bmd_scnd_all += 1;
                    }
                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        cs_f_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) cs_f_scnd_all += 1;
                    }
                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        cs_s_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) cs_s_scnd_all += 1;
                    }
                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        sl_f_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) sl_f_scnd_all += 1;
                    }
                    else if (Settings.Slider_sash.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        sl_s_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) sl_s_scnd_all += 1;

                    }
                    else if (Settings.Small_Fix.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        s_f_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) s_f_scnd_all += 1;
                    }

                    else if (Settings.Large_Fix.Any(type => type[2].Equals(line_total[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        l_f_total += 1;
                        if (colorReceiving_all.Contains(line_total[6])) l_f_scnd_all += 1;
                    }
                  //  else MessageBox.Show(line_total[6]);
                }
                    foreach (var line in item)
                    {


                        numbers.Add(line[6]);
                        colour_in = line[17];
                        colour_out = line[18];


                    if (Settings.Brickmould.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        //   list[j].Bmd += 1;
                        //  list[j].Bmd_done += count;
                        //    category = "Brickmould";
                        bmd += 1;

                        //   list_type.Add(new List_order_type(list[j].Order_numb, cs_f, cs_s, fx_f, sl_f, sl_s, bmd, count));
                    }
                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        cs_f += 1;

                    }
                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        cs_s += 1;

                    }
                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        sl_f += 1;

                    }
                    else if (Settings.Slider_sash.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {

                        sl_s += 1;

                    }
                    else if (Settings.Small_Fix.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        s_f += 1;

                    }
                    else if (Settings.Large_Fix.Any(type => type[2].Equals(line[8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        l_f += 1;

                    }
                   // else MessageBox.Show(line[4]);
                    }
                
                var colour_shipping_order = colour_shipping.Join(numbers, o => o[0], id => id, (o, id) => o);

                delivered = colour_shipping_order.ToList().Count;
                if (delivered != 0)
                    shipped_date = colour_shipping_order.ToList()[0][1];
                total = cs_f_scnd_all + cs_s_scnd_all + s_f_scnd_all + l_f_scnd_all + sl_f_scnd_all + sl_s_scnd_all + bmd_scnd_all;
                string status = "";
                if (total == cs_f_total + cs_s_total + s_f_total + l_f_total + sl_f_total + sl_s_total + bmd_total)
                    status = "COMPLETE";
                else status = "NOT COMPLETE";
                list_data.Add(new Data_order(ordnumb,cs_f+"/"+ cs_f_total, cs_s + "/" + cs_s_total, s_f + "/" + s_f_total, l_f + "/" + l_f_total, sl_f + "/" + sl_f_total, sl_s + "/" + sl_s_total, bmd + "/" + bmd_total, total, delivered, shipped_date,status));
                }
            dataColourReceivingReport.DataSource = list_data;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;


            string path = Path.Combine(Environment.CurrentDirectory, @"reports\ColourReceivingReport.rdlc");
            LocalReport report = new LocalReport();
            report.ReportPath = path;



            ColourReceivingDataSet colourReceivingDataSet = new ColourReceivingDataSet();
            foreach (var line in list_data)
            {

                colourReceivingDataSet.Tables[0].Rows.Add(line.Order_numb, line.Cs_F, line.Cs_S, line.S_F, line.L_F, line.Sl_F, line.Sl_S, line.Bmd, line.Total, line.Delivered, line.Shipped_date, line.Status);
            }
            if (oBatch == "False")
                reportParameters.Add(new ReportParameter("DataParameter", s.ToString("yyyy-MM-dd") + " to " + en.ToString("yyyy-MM-dd")));
            reportParameters.Add(new ReportParameter("ReportParameter", "Colour Receiving Report"));
            reportParameters.Add(new ReportParameter("FooterParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
            reportParameters.Add(new ReportParameter("CompanyParameter", "Paint Company " + paint_company));
            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";
            rds.Value = colourReceivingDataSet.Tables[0];


            report.SetParameters(reportParameters);
            report.DataSources.Add(rds);

            Export(report);
            Print_page();
        }

        private void Print_page()
        {
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
        private void emailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"reports\ColourReceivingReport.rdlc");
                LocalReport report = new LocalReport();
                report.ReportPath = path;



                ColourReceivingDataSet colourReceivingDataSet = new ColourReceivingDataSet();
                foreach (var line in list_data)
                {

                    colourReceivingDataSet.Tables[0].Rows.Add(line.Order_numb, line.Cs_F, line.Cs_S, line.S_F, line.L_F, line.Sl_F, line.Sl_S, line.Bmd, line.Total, line.Delivered, line.Shipped_date,line.Status);
                }
                if (oBatch == "False")
                    reportParameters.Add(new ReportParameter("DataParameter", s.ToString("yyyy-MM-dd") + " to " + en.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameter", "Colour Receiving Report"));
                reportParameters.Add(new ReportParameter("FooterParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
                reportParameters.Add(new ReportParameter("CompanyParameter", "Paint Company " + paint_company));
                ReportDataSource rds = new ReportDataSource();

                rds.Name = "DataSet1";
                rds.Value = colourReceivingDataSet.Tables[0];


                report.SetParameters(reportParameters);
                report.DataSources.Add(rds);
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = report.Render("PDF", null, out mimeType,
                        out encoding, out extension, out streamids, out warnings);
                MemoryStream st = new MemoryStream(bytes);
                st.Seek(0, SeekOrigin.Begin);
                Attachment a = new Attachment(st, "ColourReceivingReport.pdf");
                List<string> emails_list = new List<string>();
                foreach (string[] item in Settings.Receiving_Emails_Table)
                    if (item[2].Contains("Colour Receiving Report"))
                {
                    emails_list.Add(item[1]);
                }

                if (emails_list.Count != 0)
                    foreach (var email in emails_list)
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress(Settings.sender_email);

                          message.To.Add(new MailAddress(email));
                        message.Attachments.Add(a);
                        message.Subject = "Colour Receiving Report";
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com"; //for gmail host  
                        smtp.EnableSsl = true;


                        smtp.Credentials = new NetworkCredential(Settings.sender_email, Settings.sender_pass);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                    }
                if (emails_list.Count > 1) MessageBox.Show("Emails were sent successfully!");
                else if (emails_list.Count == 1)
                    MessageBox.Show("Email was sent successfully!");
                else if (emails_list.Count == 0) MessageBox.Show("No email was sent!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
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
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private Stream CreateStream(string name,
    string fileNameExtension, Encoding encoding,
    string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
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

        private void ColourReceivingReport_FormClosing(object sender, FormClosingEventArgs e)
        {

            MainForm mainform = new MainForm();
            mainform.Show();
        }

       

        private void dataColourReceivingReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var columnList = dataColourReceivingReport.Columns.Cast<DataGridViewColumn>().ToList();
            int index = columnList.FindIndex(c => c.HeaderText == "Status");

            for (int i = 0; i < dataColourReceivingReport.RowCount; i++)
                if (dataColourReceivingReport.Rows[i].Cells[index].Value.ToString() == "COMPLETE") dataColourReceivingReport.Rows[i].Cells[index].Style.BackColor = Color.Lime;
                else dataColourReceivingReport.Rows[i].Cells[index].Style.BackColor = Color.OrangeRed;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
           
                string filename = "";
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                  //  MessageBox.Show("Data will be exported and you will be notified when it is ready.");
                    if (File.Exists(filename))
                    {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    int columnCount = dataColourReceivingReport.ColumnCount;
                    string columnNames = "";
                    string[] output = new string[dataColourReceivingReport.RowCount + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dataColourReceivingReport.Columns[i].HeaderText.ToString() + ",";
                    }
                    output[0] += columnNames;
                    for (int i = 1; (i - 1) < dataColourReceivingReport.RowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            output[i] += dataColourReceivingReport.Rows[i - 1].Cells[j].Value.ToString() + ",";
                        }
                    }
                    System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                    MessageBox.Show("Your file was generated and its ready for use.");
                }
            
        }
    }
}
