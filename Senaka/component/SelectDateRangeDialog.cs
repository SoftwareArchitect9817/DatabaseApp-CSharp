using System;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class SelectDateRangeDialog : Form
    {
        public SelectDateRangeDialog()
        {
            InitializeComponent();
        }

        public DateTime[] InputBox(string title = null)
        {
            if (title != null) Text = title;
            if (ShowDialog() == DialogResult.OK)
            {
                return new DateTime[] { StartDate.SelectionRange.Start, EndDate.SelectionRange.Start };
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
    }
}
