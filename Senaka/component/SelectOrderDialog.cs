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
    public partial class SelectOrderDialog : Form
    {
        private int text_number;
        TextBox[] orderNumber;

        public SelectOrderDialog(int number = 10, string button = "OK")
        {
            InitializeComponent();

            int x_pos = 12, y_pos = 12, x_margin = 6, y_margin = 6;
            int width = 110, height = 26;

            int row = number / 5 - 2;
            if (row > 0)
            {
                row = (height + y_margin) * row;
                Height += row;
                btnOK.Top += row;
                btnCancel.Top += row;
            }

            int x = x_pos, y = y_pos, i = 0;
            orderNumber = new TextBox[number];
            for (i = 0; i < number; i++)
            {
                orderNumber[i] = new TextBox();
                orderNumber[i].Location = new Point(x, y);
                orderNumber[i].Width = width; orderNumber[i].Height = height;
                orderNumber[i].Font = new Font(orderNumber[i].Font.FontFamily, 12);
                orderNumber[i].KeyPress += new KeyPressEventHandler(orderNumber_KeyPress);
                Controls.Add(orderNumber[i]);
                if (i > 0 && (i + 1) % 5 == 0)
                {
                    x = x_pos; y += height + y_margin;
                }
                else
                {
                    x += width + x_margin;
                }
            }

            text_number = number;
            btnOK.Text = button;
        }

        private void orderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (int)Keys.Back && e.KeyChar != (int)Keys.Enter
                && !(e.KeyChar == (int)Keys.V && ModifierKeys == Keys.Control))
            {
                e.Handled = true;
                return;
            }
        }

        public string[] InputBox()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return getOrders();
            }
            return new string[] { };
        }

        private string[] getOrders()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < text_number; i++)
            {
                if (orderNumber[i].Text != "") list.Add(orderNumber[i].Text);
            }
            return list.ToArray();
        }
    }
}
