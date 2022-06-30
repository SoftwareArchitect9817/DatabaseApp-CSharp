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
    public partial class SelectProductionOrListDate : Form
    {
        public SelectProductionOrListDate()
        {
            InitializeComponent();
        }

        public string InputBox()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                if (radioProductionDate.Checked == true) return "production";
                else if (radioListDate.Checked == true) return "list";
                else if (radioCurrentDate.Checked == true) return "current";
            }
            return null;
        }
    }
}
