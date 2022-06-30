using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class SelectDateRangeAndNumberDialog : Form
    {
        public SelectDateRangeAndNumberDialog(List<string[]> batch_numbers = null)
        {
            InitializeComponent();

            if (batch_numbers != null && batch_numbers.Count > 0)
            {
                foreach (var row in batch_numbers)
                {
                    batchText.AutoCompleteCustomSource.Add(row[0]);
                }
                batchText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                batchText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        public Tuple<DateTime[], string,string> InputBox(string title = null)
        {
            if (title != null) Text = title;
            if (ShowDialog() == DialogResult.OK)
            {
                return new Tuple<DateTime[], string,string>(new DateTime[] { StartDate.SelectionRange.Start, EndDate.SelectionRange.Start }, batchText.Text, checkBoxBatch.Checked.ToString());
            }
            return null;
        }

        private void StartDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndDate.MinDate = StartDate.SelectionRange.Start;
        }

        private void EndDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartDate.MaxDate = EndDate.SelectionRange.Start;
        }

        private void checkBoxBatch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBatch.Checked == true)
            {
                StartDate.Enabled = false;
                EndDate.Enabled = false;
            }
            else {
                StartDate.Enabled = true;
                EndDate.Enabled = true;
            }
        }
    }
}
