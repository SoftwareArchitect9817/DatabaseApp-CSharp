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
    public partial class BookingListMessageBox : Form
    {
        public BookingListMessageBox(String text)
        {
            InitializeComponent();
            label1.Text = text;
            button1.Focus();
        }
    }
}
