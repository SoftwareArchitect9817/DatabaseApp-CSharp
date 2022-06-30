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
    public partial class IGInquireSubForm : Form
    {
        CurrentProductionForm currentProductionForm;
        IGInquireForm inquireForm;
        bool IWindow=false;
        public IGInquireSubForm(List<string[]> data, CurrentProductionForm currentProductionForm = null,bool r=false)
        {
            InitializeComponent();
            MinimumSize = new Size(1024, 768);
            if (currentProductionForm != null)
                this.currentProductionForm = currentProductionForm;
            this.inquireForm = null;
            IWindow = r;
            showData(data);
            this.ActiveControl = textBoxOrderNumber;
        }

        public IGInquireSubForm(IGInquireForm inquireForm, List<string[]> data)
        {
            InitializeComponent();

            this.inquireForm = inquireForm;
            if (currentProductionForm != null)
                this.currentProductionForm = null;
            showData(data);
        }

        private void showData(List<string[]> data)
        {
            IGInquireSubProductTable.Rows.Clear();
            int i = 0, qty, scanned_qty;
            List<string[]> ig_sorting;
            string date, time, name;
            foreach (string[] row in data)
            {
                ig_sorting = DB.fetchRows("ig_sorting", "sealed_unit_id", row[(int)GLASS.SEALED_UNIT_ID]);
                scanned_qty = ig_sorting.Count;
                date = time = name = "";
                if (scanned_qty > 0)
                {
                    date = Convert.ToDateTime(ig_sorting[scanned_qty - 1][(int)IG_SORTING.DATE]).ToString("yyyy-MM-dd");
                    time = ig_sorting[scanned_qty - 1][(int)IG_SORTING.TIME];
                    name = ig_sorting[scanned_qty - 1][(int)IG_SORTING.NAME];
                }
                qty = int.Parse(row[(int)GLASS.QTY]);
                IGInquireSubProductTable.Rows.Add(
                    row[(int)GLASS.SEALED_UNIT_ID], row[(int)GLASS.ORDER], row[(int)GLASS.WINDOW_TYPE], row[(int)GLASS.LINE_1], row[(int)GLASS.OT], row[(int)GLASS.GLASS_TYPE],
                    row[(int)GLASS.SPACER], row[(int)GLASS.GRILLS], row[(int)GLASS.WIDTH], row[(int)GLASS.HEIGHT], qty,
                    scanned_qty.ToString(), date, time, name, row[(int)GLASS.RACK_ID],
                    qty == scanned_qty ? "COMPLETE" : (scanned_qty == 0 ? "NOT READY" : "PROGRESSING")
                );
                IGInquireSubProductTable.Rows[i].Cells["IGInquireSubProductStatus"].Style.BackColor
                    = qty == scanned_qty ? Color.Lime : (scanned_qty == 0 ? Color.OrangeRed : Color.Gold);

                IGInquireSubLblProductDateValue.Text = row[(int)GLASS.ORDER_DATE];
                IGInquireSubLblListDateValue.Text = row[(int)GLASS.LIST_DATE];
                IGInquireSubLblCustomerNameValue.Text = row[(int)GLASS.DEALER];
                IGInquireSubLblDescriptionValue.Text = row[(int)GLASS.DESCRIPTION];
                i++;
            }
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
                    List<string[]> data = DB.fetchRows("glassreport", "order", orderNumber, false);
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
