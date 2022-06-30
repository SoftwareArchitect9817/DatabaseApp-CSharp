using Senaka.lib;
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
    public partial class MessageBoxDueDateOrders : Form
    {
        public MessageBoxDueDateOrders(List<string> orders)
        {
            InitializeComponent();

            labelMessage.Text = Settings.BookDueDate_Message;
            foreach (string ord in orders) dataGridViewOrders.Rows.Add(ord);
        }
    }
}
