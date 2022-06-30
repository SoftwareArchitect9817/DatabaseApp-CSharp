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
    public partial class VistaPatioDoorsForm : Form
    {
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public DateTime? list_date = null;
        int batch = 000001;
        int door = 000001;
        string[] last_oceanview, last_vista;
        List<string[]> orders_list = new List<string[]>();
        int last_door_numb;
        int orders;
        public VistaPatioDoorsForm()
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

           
            dateRequiredTimePicker.Value = dateTimePicker.Value.AddDays(Settings.VistaPatioDoors_days).Date;

        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataVista.CurrentCell.ColumnIndex == 0 || dataVista.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dataVista.CurrentCell.ColumnIndex == 5 || dataVista.CurrentCell.ColumnIndex == 6 || dataVista.CurrentCell.ColumnIndex == 7 || dataVista.CurrentCell.ColumnIndex == 8 || dataVista.CurrentCell.ColumnIndex == 12 || dataVista.CurrentCell.ColumnIndex == 13 || dataVista.CurrentCell.ColumnIndex == 14 || dataVista.CurrentCell.ColumnIndex == 15 || dataVista.CurrentCell.ColumnIndex == 16 || dataVista.CurrentCell.ColumnIndex == 17 || dataVista.CurrentCell.ColumnIndex == 18 || dataVista.CurrentCell.ColumnIndex == 19 || dataVista.CurrentCell.ColumnIndex == 20)

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
            if (dataVista.Rows.Count > 1)
            {

                dataVista.Rows[dataVista.Rows.Count - 1].Cells[0].Value = (Int32.Parse(dataVista.Rows[dataVista.Rows.Count - 2].Cells[0].Value.ToString()) + 1).ToString();

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
                int first_batch = Int32.Parse(dataVista.Rows[0].Cells[0].Value.ToString());
               
                int current_door = 0;
                int rowCount = 0;
                 rowCount = dataVista.Rows.Count;
                validate = true;
                for (int i = 0; i < rowCount; i++)

                    for (int m = 0; m < dataVista.Columns.Count; m++)
                        if (dataVista.Rows[i].Cells[m].Value == null) validate = false;
                if (validate)
                    for (int i = 0; i < rowCount; i++)
                    {
                        string type = "";
                        if (radioButtonCustom.Checked == true) type = "Custom";
                         else type = "Stock";



                        if (current_door == 0) current_door = Int32.Parse(dataVista.Rows[i].Cells[0].Value.ToString());
                            else current_door += 1;
                        string reference_numb = "", order_numb = "";
                        if (radioButtonStock.Checked == true)
                        
                            reference_numb = orderReferencenumbText.Text;
                            
                        
                        else order_numb = orderReferencenumbText.Text;
                        // current_door = (Int32.Parse(dataOceanView.Rows[i].Cells[0].Value.ToString()) + last_door);
                        string[] row = new string[] { dateTimePicker.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), dataVista.Rows[i].Cells[2].Value.ToString(),"1", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd"), order_numb, dataVista.Rows[i].Cells[0].Value.ToString(), dataVista.Rows[i].Cells[3].Value.ToString(), dataVista.Rows[i].Cells[4].Value.ToString(), dataVista.Rows[i].Cells[5].Value.ToString(), dataVista.Rows[i].Cells[6].Value.ToString(), dataVista.Rows[i].Cells[7].Value.ToString(), dataVista.Rows[i].Cells[8].Value.ToString(), dataVista.Rows[i].Cells[9].Value.ToString(), dataVista.Rows[i].Cells[10].Value.ToString(), dataVista.Rows[i].Cells[11].Value.ToString(), dataVista.Rows[i].Cells[12].Value.ToString(), dataVista.Rows[i].Cells[13].Value.ToString(), dataVista.Rows[i].Cells[14].Value.ToString(), dataVista.Rows[i].Cells[15].Value.ToString(), dataVista.Rows[i].Cells[16].Value.ToString(), dataVista.Rows[i].Cells[17].Value.ToString(), dataVista.Rows[i].Cells[18].Value.ToString(), dataVista.Rows[i].Cells[19].Value.ToString(), dataVista.Rows[i].Cells[20].Value.ToString(), textBoxNote.Text,TagText.Text, type,reference_numb,textBoxCompany.Text };
                         
                        data.Add(row);
                        


                        //  last_door = current_door;
                    }
                else MessageBox.Show("Not all fields are filled!", "ERROR");

                if (DB.saveVistaPatioDoors(data) == 0)
                {
                    MessageBox.Show("Order is saved");
                    saveBtn.Enabled = false;
                    saveXlxBtn.Enabled = true;
                    emailBtn.Enabled = true;
                    printBtn.Enabled = true;
                    dataVista.Enabled = false;
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
            VistaPatioDoorsDataSet vistaPatioDoorsDataSet = new VistaPatioDoorsDataSet();
            DataSetDoorNumbers dataSetDoorNumbers = new DataSetDoorNumbers();
            int rowCount = 0;
            if (radioButtonStock.Checked == true)
            {
                path = Path.Combine(Environment.CurrentDirectory, @"reports\VistaPatioDoorsReportStock.rdlc");

                report.ReportPath = path;



                rowCount = dataVista.Rows.Count;
                /*  for (int i = 0; i < orders_list.Count; i++)
                  {

                      vistaPatioDoorsDataSet.Tables[0].Rows.Add(1, orders_list[i][2], ordernumbText.Text, orders_list[i][3], orders_list[i][4], orders_list[i][5], orders_list[i][6], orders_list[i][7], orders_list[i][8], orders_list[i][9], orders_list[i][10], orders_list[i][11], orders_list[i][12], orders_list[i][13], orders_list[i][14], orders_list[i][15], orders_list[i][16], orders_list[i][17], orders_list[i][18], orders_list[i][19], orders_list[i][20], orders_list[i][21], orders_list[i][0]);
                      // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");

                  }*/
                rowCount = dataVista.Rows.Count;
                foreach (var order in orders_list)
                    vistaPatioDoorsDataSet.Tables[0].Rows.Add(1, order[2], orderReferencenumbText.Text, order[3], order[1], order[4], order[5], order[6], order[7], order[8], order[9], order[10], order[11], order[12], order[13], order[14], order[15], order[16], order[17], order[18], order[19], order[20], order[0]);

                for (int i = 0; i < rowCount; i++)
                {

                    // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                    dataSetDoorNumbers.Tables[0].Rows.Add(dataVista.Rows[i].Cells[0].Value.ToString());
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
                rds.Value = vistaPatioDoorsDataSet.Tables[0];
                report.DataSources.Add(rds);

                ReportDataSource rds2 = new ReportDataSource();
                rds2.Name = "DataSet2";
                rds2.Value = dataSetDoorNumbers.Tables[0];
                report.DataSources.Add(rds2);
            }
            else if (radioButtonCustom.Checked == true)
            {
                path = Path.Combine(Environment.CurrentDirectory, @"reports\VistaPatioDoorsReportCustom.rdlc");

                report.ReportPath = path;



                rowCount = dataVista.Rows.Count;

                rowCount = dataVista.Rows.Count;

                for (int i = 0; i < rowCount; i++)
                {

                    vistaPatioDoorsDataSet.Tables[0].Rows.Add(i + 1, dataVista.Rows[i].Cells[2].Value.ToString(), orderReferencenumbText.Text, dataVista.Rows[i].Cells[1].Value.ToString(), dataVista.Rows[i].Cells[3].Value.ToString(), dataVista.Rows[i].Cells[4].Value.ToString(), dataVista.Rows[i].Cells[5].Value.ToString(), dataVista.Rows[i].Cells[6].Value.ToString(), dataVista.Rows[i].Cells[7].Value.ToString(), dataVista.Rows[i].Cells[8].Value.ToString(), dataVista.Rows[i].Cells[9].Value.ToString(), dataVista.Rows[i].Cells[10].Value.ToString(), dataVista.Rows[i].Cells[11].Value.ToString(), dataVista.Rows[i].Cells[12].Value.ToString(), dataVista.Rows[i].Cells[13].Value.ToString(), dataVista.Rows[i].Cells[14].Value.ToString(), dataVista.Rows[i].Cells[15].Value.ToString(), dataVista.Rows[i].Cells[16].Value.ToString(), dataVista.Rows[i].Cells[17].Value.ToString(), dataVista.Rows[i].Cells[18].Value.ToString(), dataVista.Rows[i].Cells[19].Value.ToString(), dataVista.Rows[i].Cells[20].Value.ToString(), dataVista.Rows[i].Cells[0].Value.ToString());

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
                rds.Value = vistaPatioDoorsDataSet.Tables[0];
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
                VistaPatioDoorsDataSet vistaPatioDoorsDataSet = new VistaPatioDoorsDataSet();
                DataSetDoorNumbers dataSetDoorNumbers = new DataSetDoorNumbers();
                int rowCount = 0;
                if (radioButtonStock.Checked == true)
                {
                    path = Path.Combine(Environment.CurrentDirectory, @"reports\VistaPatioDoorsReportStock.rdlc");

                    report.ReportPath = path;



                    rowCount = dataVista.Rows.Count;
                    /*  for (int i = 0; i < orders_list.Count; i++)
                      {

                          vistaPatioDoorsDataSet.Tables[0].Rows.Add(1, orders_list[i][2], ordernumbText.Text, orders_list[i][3], orders_list[i][4], orders_list[i][5], orders_list[i][6], orders_list[i][7], orders_list[i][8], orders_list[i][9], orders_list[i][10], orders_list[i][11], orders_list[i][12], orders_list[i][13], orders_list[i][14], orders_list[i][15], orders_list[i][16], orders_list[i][17], orders_list[i][18], orders_list[i][19], orders_list[i][20], orders_list[i][21], orders_list[i][0]);
                          // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");

                      }*/
                    rowCount = dataVista.Rows.Count;
                    foreach(var order in orders_list)
                    vistaPatioDoorsDataSet.Tables[0].Rows.Add(1, order[2], orderReferencenumbText.Text, order[3], order[1], order[4], order[5], order[6], order[7], order[8], order[9], order[10], order[11], order[12], order[13], order[14], order[15], order[16], order[17], order[18], order[19], order[20], order[0]);

                    for (int i = 0; i < rowCount; i++)
                    {

                              // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                        dataSetDoorNumbers.Tables[0].Rows.Add(dataVista.Rows[i].Cells[0].Value.ToString());
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
                    rds.Value = vistaPatioDoorsDataSet.Tables[0];
                    report.DataSources.Add(rds);

                    ReportDataSource rds2 = new ReportDataSource();
                    rds2.Name = "DataSet2";
                    rds2.Value = dataSetDoorNumbers.Tables[0];
                    report.DataSources.Add(rds2);
                }
                else if (radioButtonCustom.Checked == true)
                {
                    path = Path.Combine(Environment.CurrentDirectory, @"reports\VistaPatioDoorsReportCustom.rdlc");

                    report.ReportPath = path;



                  
                  
                    rowCount = dataVista.Rows.Count;
                   
                    for (int i = 0; i < rowCount; i++)
                    {

                        vistaPatioDoorsDataSet.Tables[0].Rows.Add(i + 1, dataVista.Rows[i].Cells[2].Value.ToString(), orderReferencenumbText.Text, dataVista.Rows[i].Cells[1].Value.ToString(), dataVista.Rows[i].Cells[3].Value.ToString(), dataVista.Rows[i].Cells[4].Value.ToString(), dataVista.Rows[i].Cells[5].Value.ToString(), dataVista.Rows[i].Cells[6].Value.ToString(), dataVista.Rows[i].Cells[7].Value.ToString(), dataVista.Rows[i].Cells[8].Value.ToString(), dataVista.Rows[i].Cells[9].Value.ToString(), dataVista.Rows[i].Cells[10].Value.ToString(), dataVista.Rows[i].Cells[11].Value.ToString(), dataVista.Rows[i].Cells[12].Value.ToString(), dataVista.Rows[i].Cells[13].Value.ToString(), dataVista.Rows[i].Cells[14].Value.ToString(), dataVista.Rows[i].Cells[15].Value.ToString(), dataVista.Rows[i].Cells[16].Value.ToString(), dataVista.Rows[i].Cells[17].Value.ToString(), dataVista.Rows[i].Cells[18].Value.ToString(), dataVista.Rows[i].Cells[19].Value.ToString(), dataVista.Rows[i].Cells[20].Value.ToString(), dataVista.Rows[i].Cells[0].Value.ToString());

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
                    rds.Value = vistaPatioDoorsDataSet.Tables[0];
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
                Attachment a = new Attachment(st, "VistaPatioDoorsReport.pdf");
                List<string> emails_list = new List<string>();
                foreach (string[] item in Settings.Receiving_Emails_Table)
                
                
                    if (item[2].Contains("Vista Patio Doors"))
                    {
                        emails_list.Add(item[1]);
                    }
                
                if(emails_list.Count!=0)
                    foreach(var email in emails_list)
                    {
                       
                        MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress(Settings.sender_email);

                        message.To.Add(new MailAddress(email));
                        message.Attachments.Add(a);
                        if (Settings.EmailSubjectVista_boolean == "False") 
                            message.Subject = textBoxEmailSubject.Text;
                        else message.Subject = Settings.EmailSubjectVista;
                        string body = "";

                        if (Settings.EmailMessageVista_boolean == "False")
                            body= textBoxEmailMessage.Text;
                        else body = Settings.EmailMessageVista;

                        if (Settings.EmailSignatureVista_boolean != "False")
                            body += System.Environment.NewLine + System.Environment.NewLine + Settings.EmailSignatureVista;
                       
                        //  message.IsBodyHtml = true; //to make message body as html  
                        message.Body = body;
                        
                      //  message.
                        smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;


                    smtp.Credentials = new NetworkCredential(Settings.sender_email, Settings.sender_pass);
                        
                   // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
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



      /*  private void dataOceanView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataVista.Rows.Count > 1)
            {
                if (!checkBoxMultipleDoors.Checked) dataVista.AllowUserToAddRows = false;
                // else
                // dataOceanView.Rows[dataOceanView.Rows.Count - 1].Cells[0].Value = (Int32.Parse(dataOceanView.Rows[dataOceanView.Rows.Count - 2].Cells[0].Value.ToString()) + 1).ToString();

            }
        }*/

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
                int columnCount = dataVista.ColumnCount;
                int rowCount = 0;
                rowCount = dataVista.Rows.Count;
                string columnNames = "";
                string[] output = new string[dataVista.ColumnCount + 1];
                columnNames += " ,";
                for (int i = 0; i < rowCount; i++)
                {
                    columnNames += "Door " + (i + 1) + ",";
                }
                output[0] += columnNames;
                for (int i = 0; i < columnCount; i++)
                {
                    output[i + 1] += dataVista.Columns[i].HeaderText + ",";
                    for (int j = 0; j < rowCount; j++)
                    {
                        output[i + 1] += dataVista.Rows[j].Cells[i].Value.ToString() + ",";
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
           
                if (e.ColumnIndex == 5)
            {
                object eFV = e.FormattedValue;
                if (!finishes.Items.Contains(eFV))
                {
                    finishes.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                object eFV = e.FormattedValue;
                if (!GLAZING_OPTIONS.Items.Contains(eFV))
                {
                    GLAZING_OPTIONS.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex ==7)
            {
                object eFV = e.FormattedValue;
                if (!MINI_BLINDS.Items.Contains(eFV))
                {
                    MINI_BLINDS.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 8)
            {
                object eFV = e.FormattedValue;
                if (!GRILLS.Items.Contains(eFV))
                {
                    GRILLS.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            
            else if (e.ColumnIndex == 12)
            {
                object eFV = e.FormattedValue;
                if (!SILL_EXTENTION.Items.Contains(eFV))
                {
                    SILL_EXTENTION.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 13)
            {
                object eFV = e.FormattedValue;
                if (!NAILING_FIN.Items.Contains(eFV))
                {
                    NAILING_FIN.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
            else if (e.ColumnIndex == 14)
            {
                object eFV = e.FormattedValue;
                if (!DRYWALL_RETURN.Items.Contains(eFV))
                {
                    DRYWALL_RETURN.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                }
            }
                else if (e.ColumnIndex == 15)
                {
                    object eFV = e.FormattedValue;
                    if (!LOCKING_HARDWARE.Items.Contains(eFV))
                    {
                    LOCKING_HARDWARE.Items.Add(eFV);
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                    }
                }
                else if (e.ColumnIndex == 16)
                {
                    object eFV = e.FormattedValue;
                    if (!SERIES.Items.Contains(eFV))
                    {
                    SERIES.Items.Add(eFV);
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                    }
                }
                else if (e.ColumnIndex == 17)
                {
                    object eFV = e.FormattedValue;
                    if (!SECONDARY_HARDWARE.Items.Contains(eFV))
                    {
                    SECONDARY_HARDWARE.Items.Add(eFV);
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                    }
                }
                else if (e.ColumnIndex == 18)
                {
                    object eFV = e.FormattedValue;
                    if (!Transom_Size.Items.Contains(eFV))
                    {
                    Transom_Size.Items.Add(eFV);
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                    }
                }
                else if (e.ColumnIndex == 19)
                {
                    object eFV = e.FormattedValue;
                    if (!Sidelite_Size.Items.Contains(eFV))
                    {
                    Sidelite_Size.Items.Add(eFV);
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
                    }
                }
            else if (e.ColumnIndex == 20)
            {
                object eFV = e.FormattedValue;
                if (!LUXURY_PACKAGES.Items.Contains(eFV))
                {
                    LUXURY_PACKAGES.Items.Add(eFV);
                    dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
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

            dataVista.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            if (dataVista.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewTextBoxColumn))
            {
                string note = "";
                NoteDialog noteDialog = new NoteDialog();
                if (dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "")
                                   
                     note = noteDialog.InputBox();
                else note = noteDialog.InputBox(dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (note != null)
                        dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = note;
                
            }
        }

        private void TagText_Click(object sender, EventArgs e)
        {
            string note = "";
            NoteDialog noteDialog = new NoteDialog();
            if (TagText.Text == null || TagText.Text == "")

                note = noteDialog.InputBox();
            else note = noteDialog.InputBox(TagText.Text);
            if (note != null)
                TagText.Text = note;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
          
                VistaPatioFields vistaPatioFields = new VistaPatioFields(last_door_numb.ToString());

            List<string> result = vistaPatioFields.InputBox();
            if (result != null)
            {
                for (int i = 0; i < Int32.Parse(result[1]); i++)
                {
                    last_door_numb = Int32.Parse(result[0]) + i;
                    dataVista.Rows.Add(last_door_numb.ToString().PadLeft(5, '0'), "1", result[2], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10], result[11], result[12], result[13], result[14], result[15], result[16], result[17], result[18], result[19], result[20]);

                }
                last_door_numb++;
                orders_list.Add(new string[] { (Int32.Parse(result[0])).ToString().PadLeft(5, '0'), result[1], result[2], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10], result[11], result[12], result[13], result[14], result[15], result[16], result[17], result[18], result[19], result[20] });
                }

               
            
        /*    orders++;
            if (orders >= Settings.VistaPatioDoors_Custom_Limit && radioButtonCustom.Checked == true)
                addButton.Enabled = false;*/

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TagText_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void batchnumbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ordernumbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateRequiredTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void companyLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateLbl_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nameLbl_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNote_Click(object sender, EventArgs e)
        {

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
        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataVista_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message != "")
            {
                object value = dataVista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataVista.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataVista.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void textBoxEmailMessage_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            labelOrderReference.Text = "Order number";
            orderReferencenumbText.Enabled = true;
            orderReferencenumbText.Text = "";
        }

        private void radioButtonStock_CheckedChanged(object sender, EventArgs e)
        {
          string[]  last_stockVista = DB.getLastVistaPatioDoorsStock();
            labelOrderReference.Text = "Reference number";
            if (last_stockVista != null)
            {
                orderReferencenumbText.Text = (Int32.Parse(last_stockVista[2]) + 1).ToString().PadLeft(5, '0');

            }
            else {
                orderReferencenumbText.Text = "1".PadLeft(5, '0');
            }
            orderReferencenumbText.Enabled = false;
        }

        private void TagText_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }
    }
}
    
