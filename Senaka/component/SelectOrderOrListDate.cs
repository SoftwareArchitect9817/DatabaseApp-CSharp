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
    public partial class SelectOrderOrListDate : Form
    {
        public SelectOrderOrListDate()
        {
            InitializeComponent();
        }

        public string InputBox()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                if (radioOrderDate.Checked == true) return "order";
                else if (radioListDate.Checked == true) return "list";
            }
            return null;
        }
    }
}
