using DGVPrinterHelper;
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
    public partial class WindowsAssemblyReport : Form
    {
        DateTime s, en;
        string t;
        public WindowsAssemblyReport(DateTime start, DateTime end,string type)
        {
            InitializeComponent();
            s = start;
            en = end;
            List<string[]> prefixes = DB.getWindowsAssemblyPrefix();
            t = type;
            if (type == "range")
            {

                if (MonthDifference(start, end) >= 1 || MonthDifference(end, start) >= 1)
                {
                    dataWindowsReport.Columns.Add("total", "Total");
                    for (int i = 0; i < prefixes.Count(); i++)
                    {
                        int total = DB.getWindowsAssemblybyNameDate(start, prefixes[i][3],type, end).Count;
                        dataWindowsReport.Rows.Add(prefixes[i][3], total);
                    }

                }
                else
                {

                    List<DateTime> dates = GetDatesBetween(start, end);
                    for (int j = 0; j < dates.Count(); j++)

                        dataWindowsReport.Columns.Add("date" + j, dates[j].ToString("yyyy-MM-dd"));
                    dataWindowsReport.Columns.Add("total", "Total");
                    for (int i = 0; i < prefixes.Count(); i++)
                    {
                        int total = 0;
                        List<string[]> windowsassembly = DB.getWindowsAssemblybyNameDate(start, prefixes[i][3], type, end);

                        dataWindowsReport.Rows.Add(prefixes[i][3]);
                        for (int j = 0; j < dates.Count(); j++)
                        {
                            int date_numb = 0;
                            for (int k = 0; k < windowsassembly.Count(); k++)
                                if (windowsassembly[k][1] == dates[j].ToString("yyyy-MM-dd"))
                                    date_numb += 1;
                            total += date_numb;

                            dataWindowsReport.Rows[i].Cells[j + 1].Value = date_numb;
                        }
                        dataWindowsReport.Rows[i].Cells[dates.Count() + 1].Value = total;
                    }
                }

            }
            if (type == "date")
            {
                dataWindowsReport.Columns.Add("date", start.ToString("yyyy-MM-dd"));

                for (int i = 0; i < prefixes.Count(); i++)
                {
                    int total = 0;
                    List<string[]> windowsassembly = DB.getWindowsAssemblybyNameDate(start, prefixes[i][3],type);

                    dataWindowsReport.Rows.Add(prefixes[i][3]);

                    int date_numb = 0;
                    for (int k = 0; k < windowsassembly.Count(); k++)
                        if (windowsassembly[k][1] == start.ToString("yyyy-MM-dd"))
                            date_numb += 1;
            

                    dataWindowsReport.Rows[i].Cells[1].Value = date_numb;



                }
            }
             updateWidth();

        }
        private void updateWidth()
        {
            foreach (DataGridViewColumn item in dataWindowsReport.Columns)
            {
                if (item.Index == 0) item.Width = 80;
                else
                {
                    item.Width = 30;
                }
            }
        }
        private List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);
            return allDates;

        }
        private void WindowsAssemblyReport_Load(object sender, EventArgs e)
        {

        }
        public int MonthDifference(DateTime lValue, DateTime rValue)
        {

            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;




            StringBuilder sb = new StringBuilder();



            ////
        //    sb.AppendLine("_________________________________________________________________________________________________________________________________________");
            sb.AppendFormat("{0,-65} ", "Windows Assembly Report").AppendLine();
            if(t=="range")
            sb.AppendFormat("{0,-65}", "Date "+s.ToString("yyyy-MM-dd") +" to "+ en.ToString("yyyy-MM-dd")).AppendLine();
            else sb.AppendFormat("{0,-65}", "Date " + s.ToString("yyyy-MM-dd")).AppendLine();
            /*  sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalCaseRack.Text, optiReportLblTotalBG118Rack.Text).AppendLine();
              sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalCaseRack.Text, optiReportLblTotalMD1316Rack.Text).AppendLine();
              sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalSliderRack.Text, optiReportLblTotalMD118Rack.Text).AppendLine();
              sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalRack.Text, optiReportLblTotalShapeRack.Text).AppendLine();
              sb.AppendFormat("{0,-65}  {1,-65}", " ", optiReportLblTotalSURack.Text).AppendLine();
           */
            DGVPrinter_report printer = new DGVPrinter_report();
            
         //  printer.HeaderCellFormatFlags = StringFormatFlags.DirectionVertical;
               DGVPrinter_report.ImbeddedImage img1 = new DGVPrinter_report.ImbeddedImage();
            string path = Path.Combine(Environment.CurrentDirectory, @"images\vp-logo.png");
            Bitmap bitmap1 = new Bitmap(path);
               // This code is to crop the image size
               //    System.Drawing.Bitmap(bitmap, 60, 50 img1.Width, img1.Height);
               img1.theImage = bitmap1; img1.ImageX = 300; img1.ImageY = 150;
               img1.ImageAlignment = DGVPrinter_report.Alignment.Center;
             // img1.ImageLocation = DGVPrinter_report.Location.Header;
               printer.ImbeddedImageList.Add(img1);
            printer.PrintColumnHeaders = true;
          
            printer.SubTitle = sb.ToString();
            printer.SubTitleFont = new Font("Courier New", 12);
            printer.imageHeight = bitmap1.Height;
           // printer.ColumnHeaderStyles.Add("Name", printer.RowHeaderCellStyle.Forma);
            printer.SubTitleAlignment = StringAlignment.Near;
            printer.SubTitlePrint = DGVPrinter_report.PrintLocation.FirstOnly;
          //  printer.Title = "Windows Assembly Report";
        //    printer.PageSettings.Landscape = true;
            printer.PageNumbers = true;
            printer.FooterFont = new Font("Tahoma", 7);
          
            // printer.PaperSize= new PaperSize();
            printer.Footer = "Printed by "+Settings.user.Username+" "+ DateTime.Now.ToString() ;
            printer.FooterAlignment = StringAlignment.Far;
            printer.PageNumbers = false;
  
            printer.PrintDataGridView(dataWindowsReport);
        }

        private void dataWindowsReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Vertical text from column 0, or adjust below, if first column(s) to be skipped
            if (e.RowIndex == -1 && e.ColumnIndex >= 1)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }

        private void WindowsAssemblyReport_FormClosing(object sender, FormClosingEventArgs e)
        {

            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void dataWindowsReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
