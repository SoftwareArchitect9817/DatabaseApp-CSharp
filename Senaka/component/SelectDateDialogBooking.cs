using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class SelectDateDialogBooking : Form
    {
        public SelectDateDialogBooking(string default_date = null)
        {
            InitializeComponent();

            if (default_date != null && default_date != "")
            {
                Calender.SetDate(DateTime.Parse(default_date));
            }
        }

        public DateTime? InputBox(string title = null)
        {
            if (title != null) Text = title;
            if (ShowDialog() == DialogResult.OK)
            {
                return Calender.SelectionRange.Start;
            }
            return null;
        }
    }
}
