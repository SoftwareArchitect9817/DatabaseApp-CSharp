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

namespace Senaka
{
    public partial class PaintScheduleForm : Form
    {
        public PaintScheduleForm(List<string[]> orders, DateTime[] list_date)
        {
            InitializeComponent();

            if (list_date[0] == list_date[1])
            {
                labelListDate.Text = "List Date: " + list_date[0].ToString("yyyy-MM-dd");
            }
            else
            {
                labelListDate.Text = "List Date: " + list_date[0].ToString("yyyy-MM-dd") + " / " + list_date[1].ToString("yyyy-MM-dd");
            }

            comboBoxCommonCompany.Items.Add("");
            ((DataGridViewComboBoxColumn)dataGridView3350Langstaff.Columns[4]).Items.Add("");
            ((DataGridViewComboBoxColumn)dataGridView100Jacob.Columns[4]).Items.Add("");
            foreach (var company in Settings.Paint_Companies1_Table)
            {
                comboBoxCommonCompany.Items.Add(company[1]);
                ((DataGridViewComboBoxColumn)dataGridView3350Langstaff.Columns[4]).Items.Add(company[1]);
                ((DataGridViewComboBoxColumn)dataGridView100Jacob.Columns[4]).Items.Add(company[1]);
            }
            
            foreach (var order in orders)
            {
                if (order[1] == "WHT" && order[1] == order[2]) continue;
                if (order[3] == "3350 Langstaff")
                {
                    dataGridView3350Langstaff.Rows.Add(new string[] { order[0], order[5], order[1], order[2], order[4] });
                }
                else if (order[3] == "100 Jacob Keffer")
                {
                    dataGridView100Jacob.Rows.Add(new string[] { order[0], order[5], order[1], order[2], order[4] });
                }
            }
        }

        private void PaintScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void dataGridView3350Langstaff_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void dataGridView3350Langstaff_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dataGridView100Jacob_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void dataGridView100Jacob_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void comboBoxCommonCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            string company = ((ComboBox)sender).Text;
            int i;
            for (i = 0; i < dataGridView3350Langstaff.Rows.Count; i++)
            {
                if (dataGridView3350Langstaff.Rows[i].IsNewRow) continue;
                dataGridView3350Langstaff.Rows[i].Cells[4].Value = company;
            }
            for (i = 0; i < dataGridView100Jacob.Rows.Count; i++)
            {
                if (dataGridView3350Langstaff.Rows[i].IsNewRow) continue;
                dataGridView100Jacob.Rows[i].Cells[4].Value = company;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string[]> data = new List<string[]>();
            int i;
            string order, company;
            for (i = 0; i < dataGridView3350Langstaff.Rows.Count; i++)
            {
                if (dataGridView3350Langstaff.Rows[i].IsNewRow) continue;
                order = dataGridView3350Langstaff.Rows[i].Cells[0].FormattedValue.ToString();
                company = dataGridView3350Langstaff.Rows[i].Cells[4].FormattedValue.ToString();
                data.Add(new string[] { order, company });
            }
            for (i = 0; i < dataGridView100Jacob.Rows.Count; i++)
            {
                if (dataGridView3350Langstaff.Rows[i].IsNewRow) continue;
                order = dataGridView100Jacob.Rows[i].Cells[0].FormattedValue.ToString();
                company = dataGridView100Jacob.Rows[i].Cells[4].FormattedValue.ToString();
                data.Add(new string[] { order, company });
            }
            DB.savePaintSchedule(data);
            Close();
        }
    }
}
