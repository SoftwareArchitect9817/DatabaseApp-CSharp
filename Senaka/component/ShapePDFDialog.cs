using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class ShapePDFDialog : Form
    {
        public ShapePDFDialog()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string order_number = txtOrderNumber.Text;
            if (!string.IsNullOrEmpty(order_number))
            {
                dataGridViewFiles.Rows.Clear();

                string[] files = Directory.GetFiles(Settings.ShapePDF_Path, "*.pdf");
                string filename;
                List<string> filenames = new List<string>();
                foreach (string file in files)
                {
                    filename = Path.GetFileName(file);
                    if (filename.StartsWith(order_number + ".pdf") || filename.StartsWith(order_number + "-"))
                    {
                        filenames.Add(file);
                        dataGridViewFiles.Rows.Add(filename, Path.GetDirectoryName(file));
                    }
                }
                if (filenames.Count == 0)
                {
                    MessageBox.Show("File not found", "Error");
                }
                else
                {
                    txtOrderNumber.Text = "";
                }
            }
        }

        private void dataGridViewFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            string filename = dataGridViewFiles.Rows[r].Cells[1].Value.ToString() + "\\" + dataGridViewFiles.Rows[r].Cells[0].Value.ToString();
            Process.Start(filename);
        }

        private void txtOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
