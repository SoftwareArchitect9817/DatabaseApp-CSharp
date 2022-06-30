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

namespace Senaka
{
    public partial class OrderSummaryInquireForm : Form
    {
        List<string> columns;
        public OrderSummaryInquireForm(string order)
        {
            InitializeComponent();
            search(order);
        }
        
        public void search(string ord)
        {
            string[] OrderSummary = DB.getOrderSummaryBYNumber(ord);
            if(OrderSummary != null)
            {
                DataTable schema = DB.GetTableSchema("ordersummary");
                columns = new List<string>();
                foreach (DataRow col in schema.Rows)
                {
                    columns.Add(col.Field<String>("ColumnName"));
                }

                OrderLbl.Text = ord;
                BookLbl.Text = OrderSummary[columns.IndexOf("LIST DATE")];
                CustomerNameLbl.Text = OrderSummary[columns.IndexOf("COMPANY")];
                CustomerPOLbl.Text = OrderSummary[columns.IndexOf("CUST PO")];
            }
            else
            {
                MessageBox.Show("No found data");
            }
        }

        private void OrderSummaryInquireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void OrdertextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = OrdertextBox.Text;
                if (data != "")
                {
                    search(data);
                    OrdertextBox.Text = "";
                }
            }

        }
    }
}
