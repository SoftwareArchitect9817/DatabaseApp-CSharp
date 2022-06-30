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
    public partial class CasementHardwareReport : Form
    {
        private int m = 0;
        StringBuilder sb = new StringBuilder();
        public CasementHardwareReport(DateTime start, DateTime end)
        {
            InitializeComponent();
          
            this.HorizontalScroll.Enabled = false;
            printBtn.Visible = false;

            List<DateTime> dates = GetDatesBetween(start, end);
            List<string> names = new List<string>();

            List<string[]> frames = new List<string[]>();
            // var result=new List<string,int>();
            //    List<string[2]> frames2 = new List<string[2]>();
            if ((end - start).TotalDays <= 1)
            {
                printBtn.Visible = true;
            }



            List<string[]> CasementHardware = DB.getCasementHardwareByDates(start, end);
            List<string> numbs_period = new List<string>();

            for (int j = 0; j < CasementHardware.Count(); j++)
            {



                numbs_period.Add(CasementHardware[j][0]);


            }
            List<string[]> FrameCutting = DB.getFrameCuttingByNumbs(numbs_period);
            List<string[]> casement_frame_types = DB.fetchRows("types", "type", "CASEMENT");
            
                sb.AppendFormat("{0,-65}", "Casement Hardware Report ").AppendLine();
            sb.AppendLine();
            foreach (DateTime date in dates)
            {
                sb.AppendFormat("{0,-65}", "Date " + date.ToString("yyyy-MM-dd")).AppendLine();
                sb.AppendLine();
                List<string[]> frames_day = new List<string[]>();
                for (int j = 0; j < CasementHardware.Count(); j++) if (CasementHardware[j][1] == date.ToString("yyyy-MM-dd")) frames_day.Add(CasementHardware[j]);
                TimeSpan max = TimeSpan.Zero, min = TimeSpan.Zero;
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

                    for (int j = 0; j < frames_day.Count(); j++)
                    {

                        if (frames_day[j][3] == item.Str)
                        {


                            numbs_name.Add(frames_day[j][0]);

                        }
                    }

                    // List<string[]> FrameCutting = DB.getFrameCuttingByNumbs(numbs_name);
                    List<string[]> FrameCutting_period = new List<string[]>();
                    for (int j = 0; j < FrameCutting.Count(); j++)
                    {
                        if (numbs_name.Contains(FrameCutting[j][6])) FrameCutting_period.Add(FrameCutting[j]);
                    }
                    result = FrameCutting_period.AsEnumerable()
        .GroupBy(r => r[12])
        .Select(r => new
        {
            Str = r.Key,
            Count = r.Count()
        });
                    int total = 0;
                    foreach (var item_type in result)
                        if (casement_frame_types.Any(frame_type => frame_type[2].Equals(item_type.Str, StringComparison.InvariantCultureIgnoreCase)))
                        
                            total += item_type.Count;

                    sb.AppendFormat("{0,-65}", item.Str + "   " + min.ToString(@"hh\:mm") + " to " + max.ToString(@"hh\:mm") + "   Hours " + (max - min).ToString("%h") + "   Total frames " + total).AppendLine();
                    sb.AppendLine();
                    foreach (var item_type in result)

                        if (casement_frame_types.Any(frame_type => frame_type[2].Equals(item_type.Str, StringComparison.InvariantCultureIgnoreCase)))
                            sb.AppendFormat("{0,-65}", item_type.Str + " " + item_type.Count).AppendLine();

                }




            }

            label1.Text = sb.ToString();
        }
        private List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);
            return allDates;

        }
        private void CasementHardwareReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
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
                     new Rectangle(new Point((int)((p.DefaultPageSettings.Bounds.Width - PrintMargins.Left * 2) / 2 - bitmap1.Width / 2) + PrintMargins.Left, PrintMargins.Top),
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
                   
                    p.DefaultPageSettings = pd.PrinterSettings.DefaultPageSettings;
                    p.Print();
                }


            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Unable to print", MessageBoxButtons.OK);
            }

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            Print(sb.ToString());
        }
    }
}
