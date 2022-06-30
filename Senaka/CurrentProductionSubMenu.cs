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
    public partial class CurrentProductionSubMenu : Form
    {
        CurrentProductionForm currentProductionForm;

        public CurrentProductionSubMenu(CurrentProductionForm currentProductionForm, List<string[]> data)
        {
            InitializeComponent();
            MinimumSize = new Size(1024, 768);

            this.currentProductionForm = currentProductionForm;

            showData(data);
        }

        private void showData(List<string[]> data)
        {
            int i = 0, qty, scanned_qty;
            List<string[]> ig_sorting;
            foreach (string[] row in data)
            {
                ig_sorting = DB.fetchRows("ig_sorting", "sealed_unit_id", row[(int)GLASS.SEALED_UNIT_ID]);
                scanned_qty = ig_sorting.Count;
                qty = int.Parse(row[(int)GLASS.QTY]);
                CurSubProductTable.Rows.Add(
                    row[(int)GLASS.LIST_DATE], row[(int)GLASS.SEALED_UNIT_ID], row[(int)GLASS.ORDER], row[(int)GLASS.WINDOW_TYPE], row[(int)GLASS.LINE_1], row[(int)GLASS.OT],
                    row[(int)GLASS.GLASS_TYPE], row[(int)GLASS.SPACER], row[(int)GLASS.GRILLS], row[(int)GLASS.WIDTH], row[(int)GLASS.HEIGHT], qty,
                    scanned_qty.ToString(), qty == scanned_qty ? "COMPLETE" : (scanned_qty == 0 ? "NOT READY" : "PROGRESSING")
                );
                CurSubProductTable.Rows[i].Cells["CurSubProductStatus"].Style.BackColor
                    = qty == scanned_qty ? Color.Lime : (scanned_qty == 0 ? Color.OrangeRed : Color.Gold);
                i++;
            }
        }

        private void CurrentProductionSubMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentProductionForm.Show();
        }
    }
}
