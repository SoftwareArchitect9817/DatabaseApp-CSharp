using Microsoft.Reporting.WinForms;
using Senaka.component;
using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Senaka
{
    public partial class TaskBoardAddForm : Form
    {
        int Id = 0;
        Data_TaskBoard post_data;
        public TaskBoardAddForm()
        {
            InitializeComponent();
              if(Settings.TaskBoardEmail_list!=null)
              foreach (var element in Settings.TaskBoardEmail_list)
              {
                  checkedListBoxSendTo.Items.Add(element[2]);
              }

           
            
           // CreateProgressBar(20);


        }

        private void Savebutton_Click(object sender, EventArgs e)
        {

            string ord_numb = OrderNumbtextBox.Text;
            if (ord_numb != null && ord_numb != "")
            {
                try
                {
                    string dateTime = dateTimePicker.Value.ToString();
                    string description = DescriptiontextBox.Text;
                    this.DialogResult = DialogResult.OK;


                    int frame_total = 0, frame_scanned = 0, frame = 0, color = 0, color_shipping = 0, color_receiving = 0, glass = 0, glass_total = 0, glass_scanned = 0, windows_assembly_total = 0, windows_assembly_scanned = 0, windows_assembly = 0;
                    // List<string[]> data_done_shipping = new List<string[]>(), data_done_receiving = new List<string[]>()
                    List<string> frame_ids = new List<string>();
                    List<string[]> result, data_done_shipping = new List<string[]>(), data_done_receiving = new List<string[]>(), ig_sorting = new List<string[]>(), windows_assembly_scanned_data = new List<string[]>();
                    //List<string[]> ig_sorting = new List<string[]>();
                    List<string[]> data_glass = DB.fetchRows("glassreport", "order", ord_numb, false);
                    List<string[]> data_frame_color = DB.fetchRows("framescutting", "J", ord_numb, false);
                    List<string[]> data_windows_assembly = DB.importFrameReportbyLine(ord_numb);
                    foreach (var element in data_frame_color)
                    {
                        frame_ids.Add(element[5]);

                    }
                    if (data_frame_color != null)
                        frame_total = data_frame_color.Count;

                    result = DB.importFrameClearingByIds(frame_ids);
                    if (result != null) frame_scanned = result.Count;
                   
                    if  (frame_scanned == frame_total && frame_scanned != 0) frame = 0;
                    else if (frame_scanned == 0) frame = 1;
                    else if (frame_scanned < frame_total) frame = 2;
                     
                    if (data_frame_color.Count != 0)
                        if (data_frame_color[0][16] == "WHT" && data_frame_color[0][17] == "WHT") color = 3;
                        else
                        {
                            data_done_shipping = DB.importColourShippingByIds(frame_ids);
                            data_done_receiving = DB.importColourReceivingByIds(frame_ids);
                            if (data_done_shipping != null) color_shipping = data_done_shipping.Count;
                            if (data_done_receiving != null) color_receiving = data_done_receiving.Count;
                            if (color_shipping == frame_ids.Count && color_receiving == frame_ids.Count) color = 0;
                            else if (color_shipping == frame_ids.Count || color_receiving == frame_ids.Count) color = 2;
                            else if (color_shipping != frame_ids.Count && color_receiving != frame_ids.Count) color = 1;
                        }

                    frame_ids = new List<string>();




                    foreach (var element in data_glass)
                    {
                        frame_ids.Add(element[2]);
                        glass_total += int.Parse(element[(int)GLASS.QTY]);

                    }
                    data_glass = DB.importIgSorting(frame_ids);

                    if (data_glass != null)
                        glass_scanned = data_glass.Count;
                    if (glass_scanned == glass_total && glass_scanned != 0) glass = 0;
                    else if (glass_scanned == 0) glass = 1;
                    else if (glass_scanned < glass_total) glass = 2;
                   

                    frame_ids = new List<string>();
                    foreach (var element in data_windows_assembly)
                    {
                        frame_ids.Add(element[0]);
                        windows_assembly_total += Int32.Parse(element[1]);
                    }
                  

                    windows_assembly_scanned_data = DB.importWindowsAssemblyByIds(frame_ids);
                    if (windows_assembly_scanned_data != null)
                        windows_assembly_scanned = windows_assembly_scanned_data.Count;

                    if (windows_assembly_scanned == windows_assembly_total && windows_assembly_scanned != 0) windows_assembly = 0;
                    else if (windows_assembly_scanned == 0) windows_assembly = 1;
                    else if (windows_assembly_scanned < windows_assembly_total) windows_assembly = 2;
                    
                    double pecentage = (double)(frame_scanned + glass_scanned + color_shipping + color_receiving + windows_assembly_scanned) / (double)(frame_total * 3 + glass_total + windows_assembly_total) * 100;
                    if (pecentage == Double.NaN) pecentage = 0;
                    int progressVal = Convert.ToInt32(pecentage);
                    post_data = new Data_TaskBoard(Id, ord_numb, dateTime, description, frame, color, glass, windows_assembly, 3, 3, progressVal);

                    if (Id == 0)
                    {
                        

                        sendEmails(ord_numb, dateTime, description, frame, color, glass, windows_assembly, 3, 3, pecentage);
                     
                        int id = DB.InsertTaskBoard(post_data) + 1;
                        post_data.Id = id;
                    }
                    else {
                        
                        sendEmails(ord_numb, dateTime, description, frame, color, glass, windows_assembly, 3, 3, pecentage);

                        DB.UpdateTaskBoard(Id, ord_numb, dateTime, description, frame, color, glass, windows_assembly, 3, 3, pecentage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message + " with order number: " + ord_numb, "ERROR");
                }
                }
            else MessageBox.Show("Please enter order number", "ERROR");
        }
            private void sendEmails(string order_number, string dateTime, string description , int frame , int color , int glass , int windows_assembly , int wrapping , int shipping,double overall)
        {
            try { 
            ReportDataSource rds = new ReportDataSource();
            TaskBoardDataSet taskBoardDataSet = new TaskBoardDataSet();
            string path = "";

            int rowCount = 0;
          
            
                path = Path.Combine(Environment.CurrentDirectory, @"reports\TaskBoardReport.rdlc");
               

                    taskBoardDataSet.Tables[0].Rows.Add(dateTime,order_number,description, CreateBitmap(frame), CreateBitmap(color), CreateBitmap(glass), CreateBitmap(windows_assembly), CreateBitmap(wrapping), CreateBitmap(shipping), CreateProgressBar(overall));
                    rds.Value = taskBoardDataSet.Tables[0];
              

           LocalReport report = new LocalReport();
            report.ReportPath = path;




         
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
            Attachment a = new Attachment(st, "TaskBoard.pdf");
            List<string> emails_list = new List<string>();
                foreach (string name in checkedListBoxSendTo.CheckedItems)
                {

                    string[] item= Settings.TaskBoardEmail_list.FirstOrDefault(o => o[2] == name);
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
                 
                        message.Subject = "Task Board";
                
                  

                        string body = description;
                   

                  
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
            private void TaskBoardAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
        public Byte[] CreateProgressBar(double p)
        {
            int progressVal = Convert.ToInt32(p);

            float percentage = (progressVal / 100.0f);
            ImageConverter converter = new ImageConverter();

            Bitmap bmp = new Bitmap(100, 25);

            Graphics flagGraphics = Graphics.FromImage(bmp);


              flagGraphics.FillRectangle(new SolidBrush(System.Drawing.Color.LimeGreen), 0, 0, Convert.ToInt32(percentage * 100), 25);
              flagGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            flagGraphics.DrawString(progressVal.ToString() + "%", System.Drawing.SystemFonts.DefaultFont, new SolidBrush(Color.Black), 28, 7);

          

         
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }
        public Data_TaskBoard InputBox(int id=0,string ordernumb = null, string datetime = null, string description = null)
        {
            if (ordernumb != null) {
                Id = id;
            dateTimePicker.Value= Convert.ToDateTime(datetime);
                OrderNumbtextBox.Text = ordernumb;
                DescriptiontextBox.Text = description;
            }
            var resultCode = ShowDialog();
            if (resultCode == DialogResult.OK)
            {
               

                    return post_data;
                }
            
            return null;
        }
        public Byte[] CreateBitmap(int imp)
        {
          ImageConverter converter = new ImageConverter();

              Bitmap bmp = new Bitmap(50, 50);

            Graphics flagGraphics = Graphics.FromImage(bmp);


          
            if (imp == 0)
            {
                // Draw the progress bar and the text
                flagGraphics.FillEllipse(new SolidBrush(Color.FromArgb(0, 255, 0)), new Rectangle(0, 0, 50, 50));

            }
            else if (imp == 1)
            {
                // Draw the progress bar and the text
                flagGraphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0)), new Rectangle(0, 0, 50, 50));

            }
            else if (imp == 2)
            {
                // Draw the progress bar and the text
                flagGraphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 165, 0)), new Rectangle(0, 0, 50, 50));

            }
            else if (imp == 3)
            {
                // Draw the progress bar and the text
             
                flagGraphics.DrawEllipse(new Pen(new SolidBrush(Color.Black)), new Rectangle(0, 0, 50, 50));
            }

         //padding calculator
            double colorp = Math.Round((66.2 - (Math.Round((bmp.Width * 0.75) / ((bmp.Height * 0.75) / 18), 0))) / 2, 0);
            

            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DescriptiontextBox_Click(object sender, EventArgs e)
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
    }
    

}
