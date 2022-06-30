using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Senaka
{
    public partial class ShippingSummaryForm : Form
    {
        public ShippingSummaryForm(List<string[]> shippingsummary, DateTime[] dates)
        {
            InitializeComponent();
            if (dates[0] != dates[1])
            {
                labelDateRange.Text = dates[0].ToString("yyyy-MM-dd") + " / " + dates[1].ToString("yyyy-MM-dd");
            }
            else
            {
                labelDateRange.Text = dates[0].ToString("yyyy-MM-dd");
            }
            int total = 0;
            foreach (var row in shippingsummary)
            {
                dataGridViewShippingSummary.Rows.Add(
                    row[0],
                    row[1],
                    row[2] + "/" + row[3],
                    row[4]
                );
                total += int.Parse(row[3]);
            }
            labelTotalWindows.Text = total.ToString();

            DateTime today = DateTime.Now, start = today.AddDays(-30);
            List<string[]> chart_data = DB.getWindowsAssemblyByDate(new DateTime[] { start, today });
            
            chartShippingSummary.Titles.Add("History");
            Series series = chartShippingSummary.Series.FindByName("Shipping");
            chartShippingSummary.ChartAreas[0].AxisX.Interval = 1;

            string[] data;
            for (DateTime day = start; day.CompareTo(today) < 0; day = day.AddDays(1))
            {
                data = chart_data.Find(x => (DateTime.Parse(x[0])).ToString("yyyy-MM-dd") == day.ToString("yyyy-MM-dd"));
                if (data != null)
                {
                    total = int.Parse(data[1]);
                }
                else
                {
                    total = 0;
                }
                series.Points.AddXY(day.ToString("MM/dd"), total);
            }
        }

        private void ShippingSummaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }
    }
}
