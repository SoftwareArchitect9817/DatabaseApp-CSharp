using System;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class SelectDateTimeDialog : Form
    {
        public SelectDateTimeDialog()
        {
            InitializeComponent();
        }

        public DateTime? InputBox(string datetime, string title = null)
        {
            if (title != null) Text = title;
            if (!string.IsNullOrEmpty(datetime))
            {
                datePicker.SelectionStart = Convert.ToDateTime(datetime);
                timePicker.Value = Convert.ToDateTime(datetime);
            }
            if (ShowDialog() == DialogResult.OK)
            {
                return datePicker.SelectionStart.Date + timePicker.Value.TimeOfDay;
            }
            if (datetime != "") return Convert.ToDateTime(datetime);
            return null;
        }
    }
}
