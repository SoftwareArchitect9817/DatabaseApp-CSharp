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
    public partial class GlassEditRecordForm : Form
    {
        List<string> order_numbers;

        public GlassEditRecordForm()
        {
            InitializeComponent();

            order_numbers = new List<string>();
        }

        private void GlassEditRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void textBoxOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonAdd_Click(sender, e);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string order = textBoxOrderNumber.Text;
            if (order != "")
            {
                if (order_numbers.Contains(order))
                {
                    MessageBox.Show("Already added this order!");
                    return;
                }
                List<string[]> glasses = DB.importGlassReportByOrder(new string[] { order });
                if (glasses.Count == 0)
                {
                    MessageBox.Show("Invalid order number!");
                    return;
                }
                foreach (var row in glasses)
                {
                    dataGridViewGlassReport.Rows.Add(
                        false,
                        row[7],     //G - line2
                        row[24],    //X - description
                        row[19],    //S - glass_type
                        row[4],     //D - ot
                        row[3],     //C - sealed_unit_id
                        row[21],    //U - width
                        row[22],    //V - height
                        row[9],     //I - grills
                        row[11],    //K - dealer
                        row[25],    //Note(Y) - note1
                        row[0]      //ID
                    );
                }
                order_numbers.Add(order);
                textBoxOrderNumber.Text = "";
            }
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGlassReport.Rows.Count; i++)
            {
                dataGridViewGlassReport.Rows[i].Cells[0].Value = true;
            }
        }

        private void buttonUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGlassReport.Rows.Count; i++)
            {
                dataGridViewGlassReport.Rows[i].Cells[0].Value = false;
            }
        }

        private void buttoUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGlassReport.Rows.Count; i++)
            {
                DB.updateRow(
                    "glassreport",
                    "id", dataGridViewGlassReport.Rows[i].Cells[11].FormattedValue.ToString(),
                    "note1", dataGridViewGlassReport.Rows[i].Cells[10].FormattedValue.ToString()
                );
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int i;
            List<string> ids = new List<string>();
            for (i = 0; i < dataGridViewGlassReport.Rows.Count; i++)
            {
                if ((bool)dataGridViewGlassReport.Rows[i].Cells[0].Value)
                {
                    ids.Add(dataGridViewGlassReport.Rows[i].Cells[11].Value.ToString());
                }
            }
            if (ids.Count > 0)
            {
                DB.deleteRows("glassreport", "id", ids);
                for (i = dataGridViewGlassReport.Rows.Count - 1; i >= 0; i--)
                {
                    if (ids.Contains(dataGridViewGlassReport.Rows[i].Cells[11].Value))
                    {
                        dataGridViewGlassReport.Rows.RemoveAt(i);
                    }
                }
            }
        }
    }
}
