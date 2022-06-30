using DGVPrinterHelper_report;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class FrameClearingReport : Form
    {
        private int m = 0;
        StringBuilder sb = new StringBuilder();
        private PrintPreviewDialog previewDlg = null;
        public FrameClearingReport(DateTime start, DateTime end)
        {
            InitializeComponent();
            this.HorizontalScroll.Enabled = false;
            printBtn.Visible =false;
           
            List<DateTime> dates = GetDatesBetween(start, end);
            List<string> names = new List<string>();

            List<string[]> frames = new List<string[]>();
            // var result=new List<string,int>();
            //    List<string[2]> frames2 = new List<string[2]>();
            if ((end - start).TotalDays <= 1)
            {
                printBtn.Visible = true;
            }


                
                List<string[]> frameClearing = DB.getFrameClearingByDates(start, end);
                List<string> numbs_period = new List<string>();

                for (int j = 0; j < frameClearing.Count(); j++)
                {



                    numbs_period.Add(frameClearing[j][0]);

                    
                }
                List<string[]> FrameCutting = DB.getFrameCuttingByNumbs(numbs_period);

                sb.AppendFormat("{0,-65}", "Frame Clearing Report ").AppendLine();
                sb.AppendLine();
                foreach (DateTime date in dates)
                {
                    sb.AppendFormat("{0,-65}","Date " + date.ToString("yyyy-MM-dd")).AppendLine();
                    sb.AppendLine();
                    List<string[]> frames_day = new List<string[]>();
                    for (int j = 0; j < frameClearing.Count(); j++) if (frameClearing[j][1] == date.ToString("yyyy-MM-dd")) frames_day.Add(frameClearing[j]);
                    TimeSpan max = TimeSpan.Zero , min = TimeSpan.Zero ;
                    if (frames_day.Count != 0)
                    {
                        List<TimeSpan> time = frames_day
                           .Select(x => TimeSpan.ParseExact(x[2], @"hh\:mm\:ss", null))
                           .ToList();
                        max = time.Max();
                         min = time.Min();
                    }
                    List<string[]> numbs = new List<string[]>();

                    var result = frames_day.AsEnumerable()
                   .GroupBy(r => r[3])
                   .Select(r => new
                   {
                       Str = r.Key,
                       Count = r.Count()
                   });

                    foreach (var item in result)
                    {
                        List<string> numbs_name = new List<string>();
                    List<TimeSpan> time = new List<TimeSpan>();
                    for (int j = 0; j < frames_day.Count(); j++)
                        {

                            if (frames_day[j][3] == item.Str)
                            {
                            
                            time.Add(TimeSpan.ParseExact(frames_day[j][2], @"hh\:mm\:ss", null));
                                numbs_name.Add(frames_day[j][0]);

                            }
                        }
                  
                    max = time.Max();
                    min = time.Min();
                    // List<string[]> FrameCutting = DB.getFrameCuttingByNumbs(numbs_name);
                    List<string[]> FrameCutting_period = new List<string[]>();
                        for (int j = 0; j < FrameCutting.Count(); j++)
                        {
                            if (numbs_name.Contains(FrameCutting[j][6])) FrameCutting_period.Add(FrameCutting[j]);
                        }
                  var FrameCutting_period_distinct = FrameCutting_period.AsEnumerable().GroupBy(r => r[6]).Select(y => y.First());
                    result = FrameCutting_period_distinct.AsEnumerable()
                .GroupBy(r => r[8])
                .Select(r => new
                {
                    Str = r.Key,
                    Count = r.Count()
                });
                        int total = 0;
                        foreach (var item_type in result) total += item_type.Count;
                          
                        sb.AppendFormat("{0,-65}", item.Str+"   "+ min.ToString(@"hh\:mm") + " to "+max.ToString(@"hh\:mm") + "   Hours "+(max-min).ToString("%h") + "   Total frames " + total).AppendLine();
                        sb.AppendLine();
                            foreach (var item_type in result)

                        
                                sb.AppendFormat("{0,-65}", item_type.Str + " " + item_type.Count).AppendLine();
                     
                    }
                  
                   
                

            }
          
            label1.Text = sb.ToString();
        }
      

        private void Print(string thetext)
        {

          
            try
            {

                System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();

                var font = new Font("Times New Roman", 12);
                var brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

                // what still needs to be printed
               
                var remainingText = thetext;
                p.PrintPage += delegate (object sender1, System.Drawing.Printing.PrintPageEventArgs e1)
                {
                   Margins PrintMargins = new Margins(60, 60, 40, 40);
                    p.DefaultPageSettings.Margins = PrintMargins;
                    string path = Path.Combine(Environment.CurrentDirectory, @"images\vp-logo.jpg");
                    Bitmap bitmap1 = new Bitmap(path);
                    // This code is to crop the image size
                    //    System.Drawing.Bitmap(bitmap, 60, 50 img1.Width, img1.Height);

                    //   e1.Graphics.DrawImage(bitmap1, new Point((p.DefaultPageSettings.PaperSize.Width- bitmap1.Width) /2, 80));
                    /*e1.Graphics.DrawImage(bitmap1,
                      new Point((int)(p.DefaultPageSettings.Bounds.Width / 2 - bitmap1.Width / 2) + p.DefaultPageSettings.Margins.Left, p.DefaultPageSettings.Margins.Top),
                      new Size(bitmap1.Width, bitmap1.Height);*/
                    e1.Graphics.DrawImage(bitmap1,
                     new Rectangle(new Point((int)((p.DefaultPageSettings.Bounds.Width- PrintMargins.Left*2) / 2 - bitmap1.Width / 2) + PrintMargins.Left, PrintMargins.Top),
                      new Size(bitmap1.Width, bitmap1.Height)));
                  
                    int charsFitted, linesFilled;
                    RectangleF printarea = new RectangleF((float)p.DefaultPageSettings.Margins.Left, 160, (float)p.DefaultPageSettings.PaperSize.Width,
            p.DefaultPageSettings.PaperSize.Height);
                    // measure how many characters will fit of the remaining text
                    e1.Graphics.DrawLine(new Pen(brush), p.DefaultPageSettings.Margins.Left, 150, p.DefaultPageSettings.Bounds.Width - p.DefaultPageSettings.Margins.Left, 150);
                   var realsize = e1.Graphics.MeasureString(
                            remainingText,
                            font,
                            e1.MarginBounds.Size,
                            System.Drawing.StringFormat.GenericDefault,
                            out charsFitted,  // this will return what we need
                            out linesFilled);

                    // take from the remainingText what we're going to print on this page
                    var fitsOnPage = remainingText.Substring(0, charsFitted);
                    // keep what is not printed on this page 
                    remainingText = remainingText.Substring(charsFitted).Trim();
                 
                    // print what fits on the page
                    e1.Graphics.DrawString(
                            fitsOnPage,
                            font,
                            brush,
                           printarea);

                    // if there is still text left, tell the PrintDocument it needs to call 
                    // PrintPage again.
                    e1.HasMorePages = remainingText.Length > 0;
                };

                System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
                
                pd.Document = p;
                DialogResult result = pd.ShowDialog();
               

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    IEnumerable<PaperSize> paperSizes = pd.PrinterSettings.PaperSizes.Cast<PaperSize>();
                    PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
                    p.PrinterSettings.DefaultPageSettings.PaperSize = sizeA4;
                    p.DefaultPageSettings = pd.PrinterSettings.DefaultPageSettings;
                    p.Print();
                }


            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Unable to print", MessageBoxButtons.OK);
            }

        }
       
            private List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
            {
                List<DateTime> allDates = new List<DateTime>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                    allDates.Add(date);
                return allDates;

            }

        private void FrameClearingReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
          

            string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
            string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string linesb = null;
            Font font = new Font("Arial", 20, FontStyle.Regular);
            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height /
               font.GetHeight(e.Graphics);

            string path = Path.Combine(Environment.CurrentDirectory, @"images\vp-logo.jpg");
            Bitmap bitmap1 = new Bitmap(path);
            // This code is to crop the image size
            //    System.Drawing.Bitmap(bitmap, 60, 50 img1.Width, img1.Height);
          
            e.Graphics.DrawImage(bitmap1, new Point(150, 130));
            int offsetY = 80;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            for(m=0;m<lines.Length;m++)
            {
                yPos = topMargin + (count *
                 font.GetHeight(e.Graphics));
                e.Graphics.DrawString(lines[m], font, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
                linesb = lines[m];
                offsetY += (int)font.GetHeight(e.Graphics);

                if (offsetY >= pageHeight)
                {

                    e.HasMorePages = true;
                    offsetY = 0;
                    return;
                }
                else
                {
                    e.HasMorePages = false;

                }
            }
          
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(sb.ToString());


        }

        private void FrameClearingReport_Load(object sender, EventArgs e)
        {

        }
    }
}
