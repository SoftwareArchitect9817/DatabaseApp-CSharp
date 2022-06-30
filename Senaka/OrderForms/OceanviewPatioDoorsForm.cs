using Microsoft.Reporting.WinForms;

using Senaka.component;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace Senaka.OrderForms
{
    public partial class OceanviewPatioDoorsForm : Form
    {
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public DateTime? list_date = null;
      
        int door = 000001;
        string[] last_oceanview, last_vista;
     
        bool pacific_series = true;
        int last_door_numb;
        int orders;
        List<string[]> orders_list = new List<string[]>();
        public OceanviewPatioDoorsForm()
        {
            InitializeComponent();
            last_oceanview = DB.getLastOceanviewPatioDoors();
            last_vista = DB.getLastVistaPatioDoors();

            if (last_oceanview != null && last_vista != null)
            {
                if (Int32.Parse(last_oceanview[2]) > Int32.Parse(last_vista[2]))
                    last_door_numb = Int32.Parse(last_oceanview[2]) + 1;
                else last_door_numb = Int32.Parse(last_vista[2]) + 1;
            }
            else if (last_oceanview != null) last_door_numb = Int32.Parse(last_oceanview[2]) + 1;
            else if (last_vista != null) last_door_numb = Int32.Parse(last_vista[2]) + 1;
            else
            {

                last_door_numb = door;
            }



            dateRequiredTimePicker.Value = dateTimePicker.Value.AddDays(Settings.OceanviewPatioDoors_days).Date;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataOceanView.CurrentCell.ColumnIndex == 0 || dataOceanView.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dataOceanView.CurrentCell.ColumnIndex == 3 || dataOceanView.CurrentCell.ColumnIndex == 4 || dataOceanView.CurrentCell.ColumnIndex == 5 || dataOceanView.CurrentCell.ColumnIndex == 6 || dataOceanView.CurrentCell.ColumnIndex == 7 || dataOceanView.CurrentCell.ColumnIndex == 8 || dataOceanView.CurrentCell.ColumnIndex == 9 || dataOceanView.CurrentCell.ColumnIndex == 10)

            {
                ComboBox c = e.Control as ComboBox;
                if (c != null) c.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataOceanView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataOceanView.Rows.Count > 1)
            {

                dataOceanView.Rows[dataOceanView.Rows.Count - 1].Cells[0].Value = (Int32.Parse(dataOceanView.Rows[dataOceanView.Rows.Count - 2].Cells[0].Value.ToString()) + 1).ToString();

            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool validate = true;

            // validate order number

            if (string.IsNullOrEmpty(orderReferencenumbText.Text.Trim()))
            {
                validate = false;
                errorProviderOrderNumb.SetError(orderReferencenumbText, "Order number is required.");


            }
            else
            {

                errorProviderOrderNumb.SetError(orderReferencenumbText, string.Empty);
            }
            if (validate)
            {
                List<string[]> data = new List<string[]>();
                
                int current_door = 0;
                int rowCount = 0;
              rowCount = dataOceanView.Rows.Count;
                validate = true;
                for (int i = 0; i < rowCount; i++)

                    for (int m = 0; m < dataOceanView.Columns.Count; m++)
                        if (dataOceanView.Rows[i].Cells[m].Value == null) validate = false;
                if (validate)
                    for (int i = 0; i < rowCount; i++)
                    {
                       
                     
                        if (current_door == 0) current_door = Int32.Parse(dataOceanView.Rows[i].Cells[0].Value.ToString());
                            else current_door += 1;
                        string reference_numb = "", order_numb = "", type = "";
                        if (radioButtonCustom.Checked == true) type = "Custom";
                        else type = "Stock";

                        if (radioButtonStock.Checked == true)

                            reference_numb = orderReferencenumbText.Text;


                        else order_numb = orderReferencenumbText.Text;
                        // current_door = (Int32.Parse(dataOceanView.Rows[i].Cells[0].Value.ToString()) + last_door);
                        string[] row = new string[] { dateTimePicker.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), dataOceanView.Rows[i].Cells[2].Value.ToString(),"1", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd"), order_numb, dataOceanView.Rows[i].Cells[0].Value.ToString(), dataOceanView.Rows[i].Cells[3].Value.ToString(), dataOceanView.Rows[i].Cells[4].Value.ToString(), dataOceanView.Rows[i].Cells[5].Value.ToString(), dataOceanView.Rows[i].Cells[6].Value.ToString(), dataOceanView.Rows[i].Cells[7].Value.ToString(), dataOceanView.Rows[i].Cells[8].Value.ToString(), dataOceanView.Rows[i].Cells[9].Value.ToString(), dataOceanView.Rows[i].Cells[10].Value.ToString(),pacific_series.ToString(),textBoxNote.Text,TagText.Text,type,reference_numb,textBoxCompany.Text };
                            data.Add(row);
                        


                        //  last_door = current_door;
                    }
                else MessageBox.Show("Not all fields are filled!", "ERROR");

                if (DB.saveOceanviewPatioDoors(data) == 0)
                {
                    MessageBox.Show("Order is saved");
                    saveBtn.Enabled = false;
                    saveXlxBtn.Enabled = true;
                    emailBtn.Enabled = true;
                    printBtn.Enabled = true;
                    dataOceanView.Enabled = false;
                    checkBoxPacificSeries.Enabled = false;
                    dateTimePicker.Enabled = false;
                    dateRequiredTimePicker.Enabled = false;
                    orderReferencenumbText.Enabled = false;
                    TagText.Enabled = false;
                    textBoxNote.Enabled = false;
                    textBoxCompany.Enabled = false;
                    if (Settings.EmailSubjectOceanview_boolean == "True" && Settings.EmailMessageOceanview_boolean == "True")
                        tableLayoutPanelEmail.Visible = false;
                    else
                    {
                        tableLayoutPanelEmail.Visible = true;
                        if (Settings.EmailSubjectOceanview_boolean == "True") tableLayoutPanelEmail.RowStyles[0].Height = 0;
                        if (Settings.EmailMessageOceanview_boolean == "True") tableLayoutPanelEmail.RowStyles[1].Height = 0;

                    }

                }

            }
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            string path = "";
            LocalReport report = new LocalReport();
            OceanviewPatioDoorsDataSet oceanviewPatioDoorsDataSet = new OceanviewPatioDoorsDataSet();
            DataSetDoorNumbers dataSetDoorNumbers = new DataSetDoorNumbers();
            int rowCount = 0;
            if (radioButtonStock.Checked == true)
            {
                path = Path.Combine(Environment.CurrentDirectory, @"reports\OceanviewPatioDoorsReportStock.rdlc");

                report.ReportPath = path;





                rowCount = dataOceanView.Rows.Count;
                foreach(var order in orders_list)
                oceanviewPatioDoorsDataSet.Tables[0].Rows.Add(0 + 1, order[2], order[3], order[1], order[4], order[5], order[6], order[7], order[8], order[9], order[10], order[0]);
                for (int i = 0; i < rowCount; i++)
                {

                    // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                    dataSetDoorNumbers.Tables[0].Rows.Add(dataOceanView.Rows[i].Cells[0].Value.ToString());
                }



                ReportDataSource rds = new ReportDataSource();
                reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));

                if (pacific_series == true) reportParameters.Add(new ReportParameter("ReportParameterPacificSeries", "Pacific Series"));
                else reportParameters.Add(new ReportParameter("ReportParameterPacificSeries", ""));
                reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));

                report.SetParameters(reportParameters);
                rds.Name = "DataSet1";
                rds.Value = oceanviewPatioDoorsDataSet.Tables[0];
                report.DataSources.Add(rds);

                ReportDataSource rds2 = new ReportDataSource();
                rds2.Name = "DataSet2";
                rds2.Value = dataSetDoorNumbers.Tables[0];
                report.DataSources.Add(rds2);
            }
            else if (radioButtonCustom.Checked == true)
            {
                path = Path.Combine(Environment.CurrentDirectory, @"reports\OceanviewPatioDoorsReportCustom.rdlc");

                report.ReportPath = path;





                rowCount = dataOceanView.Rows.Count;

                for (int i = 0; i < rowCount; i++)
                {

                    oceanviewPatioDoorsDataSet.Tables[0].Rows.Add(i + 1, dataOceanView.Rows[0].Cells[2].Value.ToString(), dataOceanView.Rows[0].Cells[3].Value.ToString(), dataOceanView.Rows[i].Cells[1].Value.ToString(),  dataOceanView.Rows[0].Cells[4].Value.ToString(), dataOceanView.Rows[0].Cells[5].Value.ToString(), dataOceanView.Rows[0].Cells[6].Value.ToString(), dataOceanView.Rows[0].Cells[7].Value.ToString(), dataOceanView.Rows[0].Cells[8].Value.ToString(), dataOceanView.Rows[0].Cells[9].Value.ToString(), dataOceanView.Rows[0].Cells[10].Value.ToString(), dataOceanView.Rows[i].Cells[0].Value.ToString());

                }
                // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");


                ReportDataSource rds = new ReportDataSource();
                reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));

                report.SetParameters(reportParameters);
                rds.Name = "DataSet1";
                rds.Value = oceanviewPatioDoorsDataSet.Tables[0];
                report.DataSources.Add(rds);

            }
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
            printDoc.DefaultPageSettings.Landscape = true;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
               printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
               /* m_currentPageIndex = 0;
                printDoc.Print();
              */
                PrintDialog printDlg = new PrintDialog();
              
                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }
        private void dataOceanView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                LocalReport report = new LocalReport();
                OceanviewPatioDoorsDataSet oceanviewPatioDoorsDataSet = new OceanviewPatioDoorsDataSet();
                DataSetDoorNumbers dataSetDoorNumbers = new DataSetDoorNumbers();
                int rowCount = 0;
                if (radioButtonStock.Checked == true)
                {
                    path = Path.Combine(Environment.CurrentDirectory, @"reports\OceanviewPatioDoorsReportStock.rdlc");

                    report.ReportPath = path;




                   
                    rowCount = dataOceanView.Rows.Count;
                    foreach (var order in orders_list)
                        oceanviewPatioDoorsDataSet.Tables[0].Rows.Add(0 + 1, order[2], order[3], order[1], order[4], order[5], order[6], order[7], order[8], order[9], order[10], order[0]);
                    for (int i = 0; i < rowCount; i++)
                    {

                        // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                        dataSetDoorNumbers.Tables[0].Rows.Add(dataOceanView.Rows[i].Cells[0].Value.ToString());
                    }



                    ReportDataSource rds = new ReportDataSource();
                    reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
                    reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));

                    if (pacific_series == true) reportParameters.Add(new ReportParameter("ReportParameterPacificSeries", "Pacific Series"));
                    else reportParameters.Add(new ReportParameter("ReportParameterPacificSeries", ""));
                    reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
                    reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
                    reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));

                    report.SetParameters(reportParameters);
                    rds.Name = "DataSet1";
                    rds.Value = oceanviewPatioDoorsDataSet.Tables[0];
                    report.DataSources.Add(rds);

                    ReportDataSource rds2 = new ReportDataSource();
                    rds2.Name = "DataSet2";
                    rds2.Value = dataSetDoorNumbers.Tables[0];
                    report.DataSources.Add(rds2);
                }
                else if (radioButtonCustom.Checked == true)
                {
                    path = Path.Combine(Environment.CurrentDirectory, @"reports\OceanviewPatioDoorsReportCustom.rdlc");

                    report.ReportPath = path;



                   

                    rowCount = dataOceanView.Rows.Count;

                    for (int i = 0; i < rowCount; i++)
                    {

                        oceanviewPatioDoorsDataSet.Tables[0].Rows.Add(i + 1, dataOceanView.Rows[0].Cells[2].Value.ToString(), dataOceanView.Rows[0].Cells[3].Value.ToString(), dataOceanView.Rows[i].Cells[1].Value.ToString(), dataOceanView.Rows[0].Cells[4].Value.ToString(), dataOceanView.Rows[0].Cells[5].Value.ToString(), dataOceanView.Rows[0].Cells[6].Value.ToString(), dataOceanView.Rows[0].Cells[7].Value.ToString(), dataOceanView.Rows[0].Cells[8].Value.ToString(), dataOceanView.Rows[0].Cells[9].Value.ToString(), dataOceanView.Rows[0].Cells[10].Value.ToString(), dataOceanView.Rows[i].Cells[0].Value.ToString());

                    }
                    // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");


                    ReportDataSource rds = new ReportDataSource();
                    reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
                    reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));
                    reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
                    reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
                    reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));

                    report.SetParameters(reportParameters);
                    rds.Name = "DataSet1";
                    rds.Value = oceanviewPatioDoorsDataSet.Tables[0];
                    report.DataSources.Add(rds);

                }

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
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = report.Render("PDF", deviceInfo, out mimeType,
                        out encoding, out extension, out streamids, out warnings);
                MemoryStream st = new MemoryStream(bytes);
                st.Seek(0, SeekOrigin.Begin);
                Attachment a = new Attachment(st, "OceanviewPatioDoorsReport.pdf");
                List<string> emails_list = new List<string>();
                foreach (string[] item in Settings.Receiving_Emails_Table)


                    if (item[2].Contains("Oceanview Patio Doors"))
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
                        if (Settings.EmailSubjectOceanview_boolean == "False")
                            message.Subject = textBoxEmailSubject.Text;
                        else message.Subject = Settings.EmailSubjectOceanview;
                        string body = "";

                        if (Settings.EmailMessageOceanview_boolean == "False")
                            body = textBoxEmailMessage.Text;
                        else body = Settings.EmailMessageOceanview;

                        if (Settings.EmailSignatureOceanview_boolean != "False")
                            body += System.Environment.NewLine + System.Environment.NewLine + Settings.EmailSignatureOceanview;

                        //  message.IsBodyHtml = true; //to make message body as html  
                        message.Body = body;
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



        

        private void button2_Click(object sender, EventArgs e)
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
                int columnCount = dataOceanView.ColumnCount;
                int rowCount = dataOceanView.RowCount - 1;
                string columnNames = "";
                string[] output = new string[dataOceanView.ColumnCount + 1];
                columnNames += " ,";
                for (int i = 0; i < rowCount; i++)
                {
                    columnNames += "Door " + (i + 1) + ",";
                }
                output[0] += columnNames;
                for (int i = 0; i < columnCount; i++)
                {
                    output[i + 1] += dataOceanView.Columns[i].HeaderText + ",";
                    for (int j = 0; j < rowCount; j++)
                    {
                        output[i + 1] += dataOceanView.Rows[j].Cells[i].Value.ToString() + ",";
                    }
                }


                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Your file was generated and its ready for use.");
            }
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void OceanviewPatioDoorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void ordernumbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataOceanView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataOceanView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                object eFV = e.FormattedValue;
                if (!colour.Items.Contains(eFV))
                {
                    colour.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                object eFV = e.FormattedValue;
                if (!assmebled.Items.Contains(eFV))
                {
                    assmebled.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                object eFV = e.FormattedValue;
                if (!grills.Items.Contains(eFV))
                {
                    grills.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                object eFV = e.FormattedValue;
                if (!internal_blinds.Items.Contains(eFV))
                {
                    internal_blinds.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 7)
            {
                object eFV = e.FormattedValue;
                if (!elite_lock.Items.Contains(eFV))
                {
                    elite_lock.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 8)
            {
                object eFV = e.FormattedValue;
                if (!euro_lock.Items.Contains(eFV))
                {
                    euro_lock.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 9)
            {
                object eFV = e.FormattedValue;
                if (!new_euro_lock.Items.Contains(eFV))
                {
                    new_euro_lock.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 10)
            {
                object eFV = e.FormattedValue;
                if (!security_options.Items.Contains(eFV))
                {
                    security_options.Items.Add(eFV);
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
        }

        private void dataOceanView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void dataOceanView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            dataOceanView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateRequiredTimePicker.Value = dateTimePicker.Value.AddDays(Settings.OceanviewPatioDoors_days).Date;
        }

        private void dataOceanView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11 || e.ColumnIndex == 2)
            {
                string note = "";
                NoteDialog noteDialog = new NoteDialog();
                if (dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "")

                    note = noteDialog.InputBox();
                else note = noteDialog.InputBox(dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (note != null)
                    dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = note;

            }
        }

        private void TabText_Click(object sender, EventArgs e)
        {
            string note = "";
            NoteDialog noteDialog = new NoteDialog();
            if (TagText.Text == null || TagText.Text == "")

                note = noteDialog.InputBox();
            else note = noteDialog.InputBox(TagText.Text);
            if (note != null)
                TagText.Text = note;
        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataOceanView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
          //  if(dataOceanView.Rows.Count!=0) last_door_numb=

            OceanviewPatioFields oceanviewPatioDoorsFields = new OceanviewPatioFields(last_door_numb.ToString());

                List<string> result = oceanviewPatioDoorsFields.InputBox();
                if (result != null)
                {
                for (int i = 0; i < Int32.Parse(result[1]); i++)
                {
                    last_door_numb = Int32.Parse(result[0]) + i;
                    dataOceanView.Rows.Add(last_door_numb.ToString().PadLeft(5, '0'), "1", result[2], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10]);

                    
                }
                orders_list.Add(new string[] { last_door_numb.ToString().PadLeft(5, '0'), result[1], result[2], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10] });

                last_door_numb++;
                }
               
            
         /*   orders++;
            if (orders >= Settings.OceanviewPatioDoors_Custom_Limit && radioButtonCustom.Checked == true)
                addButton.Enabled = false;*/
        }

        private void dataOceanView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message != "")
            {
                object value = dataOceanView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataOceanView.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataOceanView.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

       
        private void TextDialog_Click(object sender, EventArgs e)
        {

            string note = "";
            NoteDialog noteDialog = new NoteDialog();
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == null || textBox.Text == "")

                note = noteDialog.InputBox();
            else note = noteDialog.InputBox(textBox.Text);
            if (note != null)
                textBox.Text = note;
        }

        private void radioButtonStock_CheckedChanged(object sender, EventArgs e)
        {
            string[] last_stockOceanview = DB.getLastOceanviewDoorsStock();
            labelOrderReference.Text = "Reference number";
            if (last_stockOceanview != null)
            {
                orderReferencenumbText.Text = (Int32.Parse(last_stockOceanview[2]) + 1).ToString().PadLeft(5, '0');

            }
            else
            {
                orderReferencenumbText.Text = "1".PadLeft(5, '0');
            }
            orderReferencenumbText.Enabled = false;
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            labelOrderReference.Text = "Order number";
            orderReferencenumbText.Enabled = true;
            orderReferencenumbText.Text = "";
        }

        private void checkBoxPacificSeries_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPacificSeries.Checked == true) pacific_series = true;
            else pacific_series = false;
        }
    }
}
    
