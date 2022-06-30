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
    public partial class SelectDateorDateRangeDialog : Form
    {
        public SelectDateorDateRangeDialog()
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
    }
}
