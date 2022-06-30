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

namespace Senaka.component
{
    public partial class AddPaintComapny : Form
    {
        List<string[]> Colors;
        string _action;

        public AddPaintComapny(string action, string company = "")
        {
            InitializeComponent();

            _action = action;
            if (action == "add")
            {
                foreach (var element in Settings.NotUsedColorsList)
                {
                    dataGridViewColors.Rows.Add(false, element[0], element[1]);
                }
            }
            else
            {
                textBoxCompany.Text = company;
                textBoxCompany.Enabled = false;
                foreach (var element in Settings.Paint_Companies_Table.Where(x => x[0] == company))
                {
                    dataGridViewColors.Rows.Add(true, element[1], element[2]);
                }
               
                foreach (var element in Settings.NotUsedColorsList)
                {
                    dataGridViewColors.Rows.Add(false, element[0], element[1]);
                }
            }
        }

        public Dictionary<string, List<string[]>> CompanyColors()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return new Dictionary<string, List<string[]>>
                {
                    [textBoxCompany.Text] = Colors
                };
            }
            return null;
        }

        private List<string[]> getDataFromDGViewUsed(DataGridView DGView)
        {
            List<string[]> data = new List<string[]>();
            foreach (DataGridViewRow row in DGView.Rows)
            {
                if (row.IsNewRow) continue;
                List<string> item = new List<string>();
                if (row.Cells[0].Value.ToString() == "True")
                {
                    item.Add((row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString());
                    item.Add((row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString());
                    data.Add(item.ToArray());
                }
            }
            return data;
        }

        private List<string[]> getDataFromDGViewNotUsed(DataGridView DGView)
        {
            List<string[]> data = new List<string[]>();
            foreach (DataGridViewRow row in DGView.Rows)
            {
                if (row.IsNewRow) continue;
                List<string> item = new List<string>();
                if (row.Cells[0].Value.ToString() == "False")
                {
                    item.Add((row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString());
                    item.Add((row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString());
                    data.Add(item.ToArray());
                }
            }
            return data;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCompany.Text != null && textBoxCompany.Text != "")
            {
                if (_action == "edit" || !Settings.CompaniesList.Any(x => x == textBoxCompany.Text))
                {
                    Colors = getDataFromDGViewUsed(dataGridViewColors);
                    if (_action == "edit")
                    {
                        Settings.NotUsedColorsList = getDataFromDGViewNotUsed(dataGridViewColors);
                        Settings.UsedColorsList = Settings.TotalColorsList.Where(p => !Settings.NotUsedColorsList.Any(l => p.SequenceEqual(l))).ToList();
                    }
                    if (Colors.Count != 0) DialogResult = DialogResult.OK;
                    else MessageBox.Show("Select at least one color in/color out!");
                }
                else
                {
                    MessageBox.Show("Company exists!");
                }
            }
            else MessageBox.Show("Enter company name!");
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridViewColors.Rows.Count; i++)
            {
                dataGridViewColors.Rows[i].Cells[0].Value = true;
            }
        }

        private void buttonUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewColors.Rows.Count; i++)
            {
                dataGridViewColors.Rows[i].Cells[0].Value = false;
            }
        }
    }
}
