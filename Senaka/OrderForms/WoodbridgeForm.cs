﻿using Microsoft.Reporting.WinForms;
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
using System.Windows.Forms;

namespace Senaka.OrderForms
{
    public partial class WoodbridgeForm : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        string type = "sheets";
        string[] last;
        int batch,id = 000001;
        int last_id_numb = 0;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        public WoodbridgeForm()
        {
            InitializeComponent();
           /* List<string[]>woodbridge_sheets_fields = DB.getWoodbridgeSheetsfields();
            foreach (var item in woodbridge_sheets_fields)
            {
             
                 if (item[1] == "MIL")
                    mil.Items.Add(item[2]);
              
                else if (item[1] == "Glass type")
                    glass_type.Items.Add(item[2]);
               

            }*/
            last = DB.getLastHourWoodbridger();
            /*if (last != null)
            {
                if (last[1] != DateTime.Today.ToString("yyyy-MM-dd"))
                    batch = Int32.Parse(last[2]) + 1;
                else batch = Int32.Parse(last[2]);
            }
            batchnumbText.Text = batch.ToString();*/
            if (last != null)
            {
                // data24ThermalGlass.Rows[data24ThermalGlass.Rows.Count - 1].Cells[0].Value = Int32.Parse(last[3]) + 1;
                last_id_numb = Int32.Parse(last[2]) + 1;
            }
            else
            {
                // data24ThermalGlass.Rows[data24ThermalGlass.Rows.Count - 1].Cells[0].Value = door;
                last_id_numb = id;
            }

            string[] last_sheetsWoodbrdige = DB.getLastWoodbirdgeSheets();
            labelOrderReference.Text = "Reference number";
            if (last_sheetsWoodbrdige != null && last_sheetsWoodbrdige[2] != "")
            {
                orderReferencenumbText.Text = (Int32.Parse(last_sheetsWoodbrdige[2]) + 1).ToString().PadLeft(5, '0');

            }
            else
            {
                orderReferencenumbText.Text = "1".PadLeft(5, '0');
            }
            orderReferencenumbText.Enabled = false;
            dateRequiredTimePicker.Value = dateTimePicker.Value.AddDays(Settings.HourThermalGlass_Unit_days).Date;
        }

       
        private void radioButtonSheets_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStockSheets.Checked == true)
            {
                type = "sheets";
             
                List<string[]> glass_sheets_fields = DB.get24HourThermalGlassSheetsFields();
                foreach (var item in glass_sheets_fields)
                {
                   
                     if (item[1] == "MIL")
                        mil.Items.Add(item[2]);
                  
                    else if (item[1] == "Glass type")
                        glass_type.Items.Add(item[2]);


                }
                string[] last_sheetsWoodbrdige = DB.getLastWoodbirdgeSheets();
                labelOrderReference.Text = "Reference number";
                if (last_sheetsWoodbrdige != null && last_sheetsWoodbrdige[2]!="")
                {
                    orderReferencenumbText.Text = (Int32.Parse(last_sheetsWoodbrdige[2]) + 1).ToString().PadLeft(5, '0');

                }
                else
                {
                    orderReferencenumbText.Text = "1".PadLeft(5, '0');
                }
                orderReferencenumbText.Enabled = false;
            }
        }

        private void radioButtonCutToSize_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCutToSize.Checked == true)
            {
                type = "CutToSize";
               
               
                List<string[]> glass_cut_fields = DB.get24HourThermalGlassCutToSizeFields();
                foreach (var item in glass_cut_fields)
                {

                    if (item[1] == "MIL")
                        mil.Items.Add(item[2]);

                    else if (item[1] == "Glass type")
                        glass_type.Items.Add(item[2]);


                }
                labelOrderReference.Text = "Order number";
                orderReferencenumbText.Enabled = true;
                orderReferencenumbText.Text = "";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
           
                WoodbridgeFields woodbridgeFields = new WoodbridgeFields(last_id_numb.ToString(),type);

                List<string> result = woodbridgeFields.InputBox();
                if (result != null)
                {
                 //   for (int i = 0; i < Int32.Parse(result[3]); i++)
                        dataWoodbridge.Rows.Add(result[0].ToString().PadLeft(5, '0'),result[3], result[1], result[2], result[4], result[5]);
                    last_id_numb += 1;
                 
                }
               
            
           
        }

        private void emailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource();
                WoodbridgeDataSet woodbridgeDataSet = new WoodbridgeDataSet();
                string path = "";

                int rowCount = 0;
                rowCount = dataWoodbridge.Rows.Count;
               
                if (type == "CutToSize" || type == "sheets")
                {
                    path = Path.Combine(Environment.CurrentDirectory, @"reports\Woodbridge_Sheet_CutToSize_Report.rdlc");
                    for (int i = 0; i < rowCount; i++)
                    {

                        woodbridgeDataSet.Tables[0].Rows.Add(dataWoodbridge.Rows[i].Cells[0].Value.ToString(), dataWoodbridge.Rows[i].Cells[2].Value.ToString(), dataWoodbridge.Rows[i].Cells[3].Value.ToString(), dataWoodbridge.Rows[i].Cells[1].Value.ToString(), dataWoodbridge.Rows[i].Cells[4].Value.ToString(), dataWoodbridge.Rows[i].Cells[5].Value.ToString(), i + 1);
                        // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                        rds.Value = woodbridgeDataSet.Tables[0];
                    }
                }
                LocalReport report = new LocalReport();
                report.ReportPath = path;




                // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");



                reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));
                reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
                reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));
                report.SetParameters(reportParameters);
                rds.Name = "DataSet1";




                report.DataSources.Add(rds);
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
                Attachment a = new Attachment(st, "WoodbridgeReport.pdf");
                List<string> emails_list = new List<string>();
                foreach (string[] item in Settings.Receiving_Emails_Table)


                    if (item[2].Contains("Woodbridge"))
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
                        if (Settings.EmailSubjectWoodbridge_boolean == "False")
                            message.Subject = textBoxEmailSubject.Text;
                        else message.Subject = Settings.EmailSubjectWoodbridge;
                        string body = "";

                        if (Settings.EmailMessageWoodbridge_boolean == "False")
                            body = textBoxEmailMessage.Text;
                        else body = Settings.EmailMessageWoodbridge;

                        if (Settings.EmailSignatureWoodbridge_boolean != "False")
                            body += System.Environment.NewLine + System.Environment.NewLine + Settings.EmailSignatureWoodbridge;
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
                int first_batch = Int32.Parse(dataWoodbridge.Rows[0].Cells[0].Value.ToString());
                int last_door = 0;
                int current_door = 0;
                int rowCount = 0;
               rowCount = dataWoodbridge.Rows.Count;
                validate = true;
                for (int i = 0; i < rowCount; i++)

                    for (int m = 0; m < dataWoodbridge.Columns.Count; m++)
                        if (dataWoodbridge.Rows[i].Cells[m].Value == null) validate = false;
                if (validate)
                    for (int i = 0; i < rowCount; i++)
                    {
                        string reference_numb = "", order_numb = "";
                        if (radioButtonStockSheets.Checked == true)

                            reference_numb = orderReferencenumbText.Text;


                        else order_numb = orderReferencenumbText.Text;

                        if (current_door == 0) current_door = Int32.Parse(dataWoodbridge.Rows[i].Cells[0].Value.ToString());
                            else current_door += 1;
                            // current_door = (Int32.Parse(data24ThermalGlass.Rows[i].Cells[0].Value.ToString()) + last_door);
                            string[] row = new string[] { dateTimePicker.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), type,
                                dateRequiredTimePicker.Value.ToString("yyyy-MM-dd"),order_numb, current_door.ToString().PadLeft(5, '0'), 
                                dataWoodbridge.Rows[i].Cells[2].Value.ToString(), dataWoodbridge.Rows[i].Cells[3].Value.ToString(), dataWoodbridge.Rows[i].Cells[1].Value.ToString(),
                               dataWoodbridge.Rows[i].Cells[4].Value.ToString(), 
                                dataWoodbridge.Rows[i].Cells[5].Value.ToString(), 
                               textBoxNote.Text,TagText.Text,reference_numb};
                            data.Add(row);
                        


                        //  last_door = current_door;
                    }
                else MessageBox.Show("Not all fields are filled!", "ERROR");

                if (DB.saveWoodbridge(data) == 0)
                {
                    MessageBox.Show("Order is saved");
                    saveBtn.Enabled = false;
                    saveXlxBtn.Enabled = true;
                    emailBtn.Enabled = true;
                    printBtn.Enabled = true;
                    dataWoodbridge.Enabled = false;
                    groupBoxType.Enabled = false;
                    dateTimePicker.Enabled = false;
                    dateRequiredTimePicker.Enabled = false;
                    orderReferencenumbText.Enabled = false;
                    TagText.Enabled = false;
                    textBoxNote.Enabled = false;
                    if (Settings.EmailSubjectWoodbridge_boolean == "True" && Settings.EmailMessageWoodbridge_boolean == "True")
                        tableLayoutPanelEmail.Visible = false;
                    else
                    {
                        tableLayoutPanelEmail.Visible = true;
                        if (Settings.EmailSubjectWoodbridge_boolean == "True") tableLayoutPanelEmail.RowStyles[0].Height = 0;
                        if (Settings.EmailMessageWoodbridge_boolean == "True") tableLayoutPanelEmail.RowStyles[1].Height = 0;

                    }


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
        private void printBtn_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            WoodbridgeDataSet woodbridgeDataSet = new WoodbridgeDataSet();
            string path = "";

            int rowCount = 0;
             rowCount = dataWoodbridge.Rows.Count;
            
             if (type == "CutToSize" || type == "sheets")
            {
                path = Path.Combine(Environment.CurrentDirectory, @"reports\Woodbridge_Sheet_CutToSize_Report.rdlc");
                for (int i = 0; i < rowCount; i++)
                {

                    woodbridgeDataSet.Tables[0].Rows.Add(dataWoodbridge.Rows[i].Cells[0].Value.ToString(), dataWoodbridge.Rows[i].Cells[2].Value.ToString(), dataWoodbridge.Rows[i].Cells[3].Value.ToString(), dataWoodbridge.Rows[i].Cells[1].Value.ToString(), dataWoodbridge.Rows[i].Cells[4].Value.ToString(), dataWoodbridge.Rows[i].Cells[5].Value.ToString(), i + 1);
                    // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                    rds.Value = woodbridgeDataSet.Tables[0];
                }
            }
            LocalReport report = new LocalReport();
            report.ReportPath = path;




            // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");



            reportParameters.Add(new ReportParameter("ReportParameterDate", dateTimePicker.Value.ToString("yyyy-MM-dd")));
            reportParameters.Add(new ReportParameter("ReportParameterDateRequired", dateRequiredTimePicker.Value.ToString("yyyy-MM-dd")));
            reportParameters.Add(new ReportParameter("ReportParameterPO", orderReferencenumbText.Text));
            reportParameters.Add(new ReportParameter("ReportParameterTag", TagText.Text));
            reportParameters.Add(new ReportParameter("ReportParameterNotes", textBoxNote.Text));

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

        private void saveXlxBtn_Click(object sender, EventArgs e)
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
                int columnCount = dataWoodbridge.ColumnCount;
                int rowCount;
             rowCount = dataWoodbridge.Rows.Count;
               
                string columnNames = "";
                string[] output = new string[dataWoodbridge.ColumnCount + 1];
                columnNames += " ,";
                for (int i = 0; i < rowCount; i++)
                {
                    columnNames += "Door " + (i + 1) + ",";
                }
                output[0] += columnNames;
                for (int i = 0; i < columnCount; i++)
                {
                    output[i + 1] += dataWoodbridge.Columns[i].HeaderText + ",";
                    for (int j = 0; j < rowCount; j++)
                    {
                        output[i + 1] += dataWoodbridge.Rows[j].Cells[i].Value.ToString() + ",";
                    }
                }


                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Your file was generated and its ready for use.");
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

        private void ordernumbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataWoodbridge_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message != "")
            {
                object value = dataWoodbridge.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataWoodbridge.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataWoodbridge.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void groupBoxType_Enter(object sender, EventArgs e)
        {

        }

        private void HourThermalGlassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
