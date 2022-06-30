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

namespace Senaka
{
    public partial class GlassRecutReport : Form
    {
        public class Data_order
        {
            public string Order_numb { get; set; }
            public string Sealed_unit_id { get; set; }
            public string Glass_type { get; set; }
            public string Thickness { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Status { get; set; }

        }
        public GlassRecutReport()
        {
            InitializeComponent();

            List<string[]> glassrecut = DB.getGlassRecut();
            List<string> su_ids = new List<string>();
            foreach (var element in glassrecut)
            {
                su_ids.Add(element[0]);
            }

            List<string[]> glassreport = DB.importGlassBySU(su_ids.ToArray());
            foreach (var element in glassrecut)
            {
                Data_order line = new Data_order();
                line.Sealed_unit_id = element[0];
                line.Date = element[1];
                line.Time = element[2];
                line.Status = element[6];
                string[] glassreport_element = glassreport.Where(x => x[2] == element[0]).FirstOrDefault();
                line.Order_numb = glassreport_element[19];
                line.Glass_type = glassreport_element[18];
                line.Thickness = glassreport_element[3];
                dataGridViewGlassRecut.Rows.Add(line.Order_numb, line.Sealed_unit_id, line.Glass_type, line.Thickness, line.Date, line.Time, line.Status);
                dataGridViewGlassRecut.Rows[dataGridViewGlassRecut.Rows.Count - 1].Cells[6].Style.BackColor
                         = line.Status == "Complete" ? Color.Lime : Color.OrangeRed;
            }
            if (Settings.user.Username != "admin" && Settings.user.GlassDelete == "False") dataGridViewGlassRecut.Columns["RemoveColumn"].Visible = false;
        }

        private void dataGridViewGlassRecut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewGlassRecut.Columns["RemoveColumn"].Index)
            {
                if (DB.RemoveFromGlassRecut(dataGridViewGlassRecut.Rows[e.RowIndex].Cells[dataGridViewGlassRecut.Columns["sealed_unit_id"].Index].Value.ToString()) == 0)
                    dataGridViewGlassRecut.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void GlassRecutReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
