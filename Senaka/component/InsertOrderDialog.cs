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
    public partial class InsertOrderDialog : Form
    {
        public InsertOrderDialog(string type)
        {
            InitializeComponent();

            typeLbl.Text = type.ToUpper();
            ActiveControl = ordNumber;
        }

        public string InputBox()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return ordNumber.Text;
            }
            return null;
        }

        private void ordNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ordNumber.Text != "")
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
