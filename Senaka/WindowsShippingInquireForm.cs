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
    public partial class WindowsShippingInquireForm : Form
    {
        CurrentProductionForm currentProductionForm;
        IGInquireForm inquireForm;
        bool IWindow=false;
        public WindowsShippingInquireForm(List<string[]> data)
        {
            InitializeComponent();
            MinimumSize = new Size(1024, 768);
        
            showData(data);
            this.ActiveControl = textBoxOrderNumber;
        }

        public WindowsShippingInquireForm(IGInquireForm inquireForm, List<string[]> data)
        {
            InitializeComponent();

            this.inquireForm = inquireForm;
            if (currentProductionForm != null)
                this.currentProductionForm = null;
            showData(data);
        }

        private void showData(List<string[]> data)
        {
            int i = 0, qty, scanned_qty;
            WindowsShippingTable.Rows.Clear();
            List<string> LineNumbers = new List<string>();
            foreach (string[] row in data)
                LineNumbers.Add(row[9]);

            List<string[]> WindowsShipping = DB.importWindowsShippingByLines(LineNumbers);
            foreach (string[] row in data)
            {
                scanned_qty = 0;
                string lineNumber = row[9];
                List<string[]> currentWindowsShipping = WindowsShipping.Where(x => x[0] == lineNumber).ToList();
                if(currentWindowsShipping.Count != 0)
                     scanned_qty = Int32.Parse(currentWindowsShipping[0][5]);
                qty = Int32.Parse(row[8]);
            
               if(scanned_qty == 0)
                WindowsShippingTable.Rows.Add(lineNumber, row[7], "","", "", qty, scanned_qty,
                    qty == scanned_qty ? "COMPLETE" : (scanned_qty == 0 ? "NOT SHIPPED" : "PROGRESSING")
                );
               else
                    WindowsShippingTable.Rows.Add(lineNumber, row[6],  currentWindowsShipping[0][1], currentWindowsShipping[0][2], currentWindowsShipping[0][3], qty, scanned_qty,
                  qty == scanned_qty ? "COMPLETE" : (scanned_qty == 0 ? "NOT SHIPPED" : "PROGRESSING")
              );
                WindowsShippingTable.Rows[WindowsShippingTable.Rows.Count - 1].Cells["Status"].Style.BackColor
                    = qty == scanned_qty ? Color.Lime : (scanned_qty == 0 ? Color.OrangeRed : Color.Gold);
            }
            OrderNumberLblValue.Text = data[0][0];
            CompanyNameLblValue.Text = data[0][3];
            CustomerPOLblValue.Text = data[0][1];

        }

        private void IGInquireSubForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inquireForm != null) inquireForm.Show();
            if (currentProductionForm != null) currentProductionForm.Show();
            if (IWindow==false) 
            
            {
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }

        private void IGInquireSubForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string orderNumber = textBoxOrderNumber.Text;
                if (orderNumber != "")
                {
                    List<string[]> data = DB.fetchRows("workorder", "ORDER #", orderNumber, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    showData(data);
                }
               
            }
        }
    }
}
