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
    public partial class FrameRecutReport : Form
    {
        public class Data_order
        {
            public string Order_numb { get; set; }
            public string Frame_id { get; set; }
            public string Window_type { get; set; }
            public string Profile_type { get; set; }
            public string ColorIn { get; set; }
            public string ColorOut { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Status { get; set; }

        }
        public FrameRecutReport()
        {
            InitializeComponent();

            List<string[]> framerecut = DB.getFrameRecut();
            List<string> frame_ids = new List<string>();
            foreach (var element in framerecut)
            {
                frame_ids.Add(element[0]);
            }
            List<string[]> framescutting = DB.getFrameCuttingByNumbs(frame_ids);
            foreach (var element in framerecut)
            {
                Data_order line = new Data_order();
                line.Order_numb = element[3];
                line.Frame_id = element[0];

                line.Date = element[1];
                line.Time = element[2];
                line.Status = element[6];
                string[] framescutting_element = framescutting.Where(x => x[6] == element[0]).FirstOrDefault();
                if (framescutting_element.Length > 0)
                    line.Window_type = framescutting_element[12];
                    line.Profile_type = framescutting_element[8];
                line.ColorIn = framescutting_element[17];
                line.ColorOut = framescutting_element[18];
                dataGridViewFrameRecut.Rows.Add(line.Order_numb, line.Frame_id, line.Window_type, line.Profile_type, line.Date, line.Time,line.ColorIn, line.ColorOut, line.Status);
                dataGridViewFrameRecut.Rows[dataGridViewFrameRecut.Rows.Count - 1].Cells[8].Style.BackColor
                         = line.Status == "Complete" ? Color.Lime : Color.OrangeRed;
            }
            
                if (Settings.user.Username != "admin" && Settings.user.FrameDelete == "False") dataGridViewFrameRecut.Columns["RemoveColumn"].Visible = false;
        }

        private void dataGridViewGlassRecut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewFrameRecut.Columns["RemoveColumn"].Index)
            {
              if(DB.RemoveFromFrameRecut(dataGridViewFrameRecut.Rows[e.RowIndex].Cells[dataGridViewFrameRecut.Columns["frame_id"].Index].Value.ToString())==0)
                dataGridViewFrameRecut.Rows.RemoveAt(e.RowIndex);
            }
            }

       
        private void FrameRecutReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
