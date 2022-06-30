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
    public partial class MessageBoxDialog : Form
    {
        public MessageBoxDialog()
        {
            InitializeComponent();

            btnOK.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
        }

        public DialogResult Show(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            lblMessage.Text = message;
            Text = title;
            if (buttons == MessageBoxButtons.OK)
            {
                btnOK.Visible = true;
            }
            else
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            return (ShowDialog());
        }
    }
}
