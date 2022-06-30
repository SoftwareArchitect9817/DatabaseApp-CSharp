using DGVPrinterHelper;
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
    public partial class OptimizeReportForm : Form
    {
        OptimizeForm optiForm;

        public OptimizeReportForm(OptimizeForm optiForm)
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);
            this.optiForm = optiForm;
            
            DateTime today = DateTime.Now;
            optiReportLblCurrentDate.Text = today.ToString("yyyy-MM-dd");

            int rack_size = Math.Max(Settings.Rack_Size_16, Settings.Rack_Size_8);
            for (int i = 0; i < rack_size; i++)
            {
                optiReportDgRackReport.Rows.Add(i + 1, i);
            }

            getReport();
        }

        private void OptimizeReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            optiForm.optimizeReportClosed();
        }

        private void getReport()
        {
            if (optiForm.list_date != null)
            {
                DateTime list_date = (DateTime) optiForm.list_date;
                optiReportLblCategory.Text = "List Date: ";
                optiReportLblCategory.Text += list_date.ToString("yyyy-MM-dd");
            }
            else if (optiForm.order_number != null)
            {
                optiReportLblCategory.Text = "Orders: ";
                foreach (string order in optiForm.order_number)
                {
                    optiReportLblCategory.Text += order + ", ";
                }
            }

            optiReportLblTotalIG.Text += Rack.getRackUnit();

            optiReportLblTotalBGRack.Text += Rack.getRackCount((int)Rack.SIZE.LARGE);
            optiReportLblTotalMDRack.Text += Rack.getRackCount((int)Rack.SIZE.MEDIUM);
            optiReportLblTotalCaseRack.Text += Rack.getRackCount((int)Rack.TYPE.CASE);
            optiReportLblTotalSliderRack.Text += Rack.getRackCount((int)Rack.TYPE.SLIDER);
            optiReportLblTotalRack.Text += Rack.getRackCount((int)Rack.SIZE.SMALL);

            optiReportLblTotalBG1316Rack.Text += Rack.getRackUnit((int)Rack.SIZE.LARGE + (int)Rack.OT.THICK16);
            optiReportLblTotalBG118Rack.Text += Rack.getRackUnit((int)Rack.SIZE.LARGE + (int)Rack.OT.THICK8);
            optiReportLblTotalMD1316Rack.Text += Rack.getRackUnit((int)Rack.SIZE.MEDIUM + (int)Rack.OT.THICK16);
            optiReportLblTotalMD118Rack.Text += Rack.getRackUnit((int)Rack.SIZE.MEDIUM + (int)Rack.OT.THICK8);
            optiReportLblTotalShapeRack.Text += Rack.getRackUnit((int)Rack.TYPE.SHAPE);
            optiReportLblTotalSURack.Text += Rack.getRackUnit((int)Rack.TYPE.SU);

            List<KeyValuePair<string, int>> rack_list = new List<KeyValuePair<string, int>>();

            int i, j, k, qty, index, rack_index;
            for (i = 0; i < Rack.optimized.Count; i++)
            {
                string[] rackId = Rack.rack[i].Split('-');
                if (rackId.Length == 2)
                {
                    string columnName = "RACK" + rackId[0], orderNumber = Rack.optimized[i][(int)GLASS.ORDER];

                    for (j = 0; j < rack_list.Count; j++) if (rack_list[j].Key == orderNumber) break;
                    if (j == rack_list.Count) rack_list.Add(new KeyValuePair<string, int>(orderNumber, 0));
                    rack_index = rack_list[j].Value + 1;

                    if (!optiReportDgRackReport.Columns.Contains(columnName))
                    {
                        optiReportDgRackReport.Columns.Add(columnName, "RACK " + rackId[0]);
                    }
                    qty = int.Parse(Rack.optimized[i][(int)GLASS.QTY]);
                    index = int.Parse(rackId[1]) - 1;
                    for (k = 0; k < qty; k++)
                    {
                        optiReportDgRackReport.Rows[index + k].Cells[columnName].Value =  orderNumber + "-" + rack_index.ToString();
                    }
                    rack_list[j] = new KeyValuePair<string, int>(orderNumber, rack_index);
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {

            DateTime today = DateTime.Now;




            StringBuilder sb = new StringBuilder();

            sb.AppendLine(today.ToString("yyyy-MM-dd"));
            sb.AppendLine(optiReportLblCategory.Text);

            sb.AppendLine(optiReportLblTotalIG.Text);
            sb.AppendLine();

            ////
            sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalBGRack.Text, optiReportLblTotalBG1316Rack.Text).AppendLine();
            sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalCaseRack.Text, optiReportLblTotalBG118Rack.Text).AppendLine();
            sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalCaseRack.Text, optiReportLblTotalMD1316Rack.Text).AppendLine();
            sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalSliderRack.Text, optiReportLblTotalMD118Rack.Text).AppendLine();
            sb.AppendFormat("{0,-65}  {1,-65}", optiReportLblTotalRack.Text, optiReportLblTotalShapeRack.Text).AppendLine();
            sb.AppendFormat("{0,-65}  {1,-65}", " ", optiReportLblTotalSURack.Text).AppendLine();

            DGVPrinter printer = new DGVPrinter();
            printer.PrintColumnHeaders = true;
            printer.SubTitle = sb.ToString();
            printer.SubTitleFont = new Font("Courier New", 12);
            
            printer.SubTitleAlignment = StringAlignment.Near;
            printer.SubTitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            printer.Title = "Optimize Report";
            printer.PageSettings.Landscape = true;
            printer.PageNumbers = true;
            printer.PrintDataGridView(optiReportDgRackReport);


        }
    }
}
