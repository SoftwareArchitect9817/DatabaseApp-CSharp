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
    public partial class NoteDialog : Form
    {
        public NoteDialog(string special_req = "")
        {
            InitializeComponent();

            if(special_req == "number") NoteTextBox.KeyPress += ordernumbText_KeyPress;
        }

        private void NoteDialog_Load(object sender, EventArgs e)
        {
            ActiveControl = NoteTextBox;
        }

        private void ordernumbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public string InputBox(string text = null)
        {
            if (text != null) NoteTextBox.Text = text;
            if (ShowDialog() == DialogResult.OK)
            {
                return NoteTextBox.Text;
            }
            return text;
        }
    }
}
