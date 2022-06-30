using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.ReportForms
{
    public partial class ProductionCountReport : Form
    {
        public ProductionCountReport()
        {
            InitializeComponent();
        }
        public class dataOrder
        {
            public string ordNumber { get; set; }
            public int Casement { get; set; }
            public int Slider { get; set; }
            public int Shape { get; set; }
            public int SU { get; set; }


        }
        private void ProductionCountReport_Load(object sender, EventArgs e)
        {
            int casement = 0, slider = 0, shape = 0, su = 0;
            List<string[]> FrameReportDB = DB.getFrameReportCount(MainForm.Variables.start_date.ToString("yyyy-MM-dd"), MainForm.Variables.end_date.ToString("yyyy-MM-dd"));
          
            foreach (var element in FrameReportDB)
            {

                if (Settings.Casement.Any(type => type[2].Equals(element[1], StringComparison.InvariantCultureIgnoreCase)))
                    casement += 1;
                else if (Settings.Slider.Any(type => type[2].Equals(element[1], StringComparison.InvariantCultureIgnoreCase)))
                    slider += 1;
                else if (Settings.Shape.Any(type => type[2].Equals(element[1], StringComparison.InvariantCultureIgnoreCase)))
                    shape += 1;
             
            }
            List<string[]> IGSortingDB = DB.getIgSortingByDate(MainForm.Variables.start_date.ToString("yyyy-MM-dd"), MainForm.Variables.end_date.ToString("yyyy-MM-dd"));
            List<string> SuIds = IGSortingDB.Select(x => x[0]).ToList();
            List<string[]> GlassReportDB = DB.getSUGlassReport(SuIds);

            su = GlassReportDB.Count;

             CasementValueLbl.Text = casement.ToString();
            SliderValueLbl.Text = slider.ToString();
            ShapeValueLbl.Text = shape.ToString();
            SuValueLbl.Text = su.ToString();
       
        }
        public static string GetUntilOrEmpty(string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
        private void ProductionCountReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
