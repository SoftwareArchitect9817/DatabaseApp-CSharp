using Microsoft.Reporting.WinForms;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{

    public partial class ProductionReportForm : Form
    {
        public class Variables
        {
            public static DataTable datat = null;
            public static DataTable datat_comm = null;
            public static ReportParameterCollection reportParameters = new ReportParameterCollection();
        }
        OptimizeForm optiForm;
        PrintDialog printDialog = new PrintDialog();
        PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
        PrintDocument pd;

        public ProductionReportForm(OptimizeForm optiForm)
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);
            this.optiForm = optiForm;

            DateTime today = DateTime.Now;
            productReportLblCurrentDate.Text = today.ToString("yyyy-MM-dd");

            getReport();
        }

        private void ProductionReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            optiForm.productReportClosed();
        }

        private void getReport()
        {
            if (optiForm.list_date != null)
            {
                DateTime list_date = (DateTime)optiForm.list_date;
                productReportLblCategory.Text = "List Date: ";
                productReportLblCategory.Text += list_date.ToString("yyyy-MM-dd");
            }
            else if (optiForm.order_number != null)
            {
                productReportLblCategory.Text = "Orders: ";
                foreach (string order in optiForm.order_number)
                {
                    productReportLblCategory.Text += order + ", ";
                }
            }

            productReportLblTotalIG.Text += Rack.getRackUnit();
            List<string[]> glassTypes = new List<string[]>();

            int i, j, white, black;
            int grill = 0, sdl = 0, casement = 0, slider = 0, shape = 0, su = 0, qty;
            int case_with_hard = 0, case_without_hard = 0;
            int slider_sash_frame = 0, slider_fixed_frame = 0, slider_sash2_fixed1 = 0, slider_sash1_fixed1 = 0;

            string spacer, glassType, value, wType;
            string[] caseWithHard = new string[] { "AW-V", "B-AW", "CS-L", "CS-R" };
            string[] caseWithoutHard = new string[] { "V-C", "V-F", "V-SF" };
            string[] sliderSash2Fixed1 = new string[] { "DES", "DESLO" };
            string[] sliderSash = new string[] { "DS", "TRS", "V-A", "V-AO", "V-B", "V-BLO", "V-LCS" };
            string[] sliderSash1Fixed1 = new string[] { "SH", "SHO", "SLO", "SS", "V-SH", "V-SHO", "V-SLO", "V-SS", "V-SSO" };

            for (i = 0; i < Rack.optimized.Count; i++)
            {
                spacer = Rack.optimized[i][(int)GLASS.SPACER];
                if (spacer != "")
                {
                    glassType = Rack.optimized[i][(int)GLASS.GLASS_TYPE];
                    white = black = 0;
                    for (j = 0; j < glassTypes.Count; j++)
                    {
                        if (glassTypes[j][0] == glassType)
                        {
                            if (spacer.Contains("WHITE")) white = 1;
                            else if (spacer.Contains("BLACK")) black = 1;
                            glassTypes[j][1] = (int.Parse(glassTypes[j][1]) + white).ToString();
                            glassTypes[j][2] = (int.Parse(glassTypes[j][2]) + black).ToString();
                            break;
                        }
                    }
                    if (j == glassTypes.Count)
                    {
                        if (spacer.Contains("WHITE")) white = 1;
                        else if (spacer.Contains("BLACK")) black = 1;
                        glassTypes.Add(new string[] { glassType, white.ToString(), black.ToString() });
                    }
                }

                qty = int.Parse(Rack.optimized[i][(int)GLASS.QTY]);
                wType = Rack.optimized[i][(int)GLASS.WINDOW_TYPE].Remove(0, 12);

                value = Rack.optimized[i][(int)GLASS.GRILLS];
                if (value != "")
                {
                    if (value.Contains("SDL")) sdl += qty;
                    else grill += qty;
                }

                switch (Rack.getType(Rack.optimized[i]))
                {
                    case (int)Rack.TYPE.CASE:
                        casement += qty;
                        if (caseWithHard.Contains(wType.ToUpper()))
                        {
                            case_with_hard += qty;
                        }
                        else if (caseWithoutHard.Contains(wType.ToUpper()))
                        {
                            case_without_hard += qty;
                        }
                        break;
                    case (int)Rack.TYPE.SLIDER:
                        slider += qty;
                        if (sliderSash2Fixed1.Contains(wType.ToUpper()))
                        {
                            slider_sash2_fixed1 += qty;
                        }
                        else if (sliderSash1Fixed1.Contains(wType.ToUpper()))
                        {
                            slider_sash1_fixed1 += qty;
                        }
                        else if (sliderSash.Contains(wType.ToUpper()))
                        {
                            slider_sash_frame += qty;
                        }
                        break;
                    case (int)Rack.TYPE.SHAPE:
                        shape += qty; break;
                    case (int)Rack.TYPE.SU:
                        su += qty; break;
                }

                if (Rack.optimized[i][(int)GLASS.GLASS_COMMENT] != "")
                {
                    productReportDgGlassComment.Rows.Add(Rack.optimized[i][(int)GLASS.ORDER], Rack.optimized[i][(int)GLASS.LINE_1], Rack.optimized[i][(int)GLASS.GLASS_COMMENT]);
                }
            }

            for (i = 0; i < glassTypes.Count; i++)
            {
                productReportDgGlassType.Rows.Add(glassTypes[i]);
            }

            qty = slider_sash2_fixed1 / 3;
            slider_sash_frame += qty * 2;
            slider_fixed_frame += slider_sash2_fixed1 - qty * 2;

            qty = slider_sash1_fixed1 / 2;
            slider_sash_frame += qty;
            slider_fixed_frame += slider_sash1_fixed1 - qty;

            productReportLblTotalGrill.Text += grill.ToString();
            productReportLblTotalSDL.Text += sdl.ToString();
            productReportLblTotalCase.Text += casement.ToString();
            productReportLblTotalSlider.Text += slider.ToString();
            productReportLblTotalShape.Text += shape.ToString();
            productReportLblTotalSealedUnit.Text += su.ToString();
            productReportLblTotalCaseWithHard.Text += case_with_hard.ToString();
            productReportLblTotalCaseWithoutHard.Text += case_without_hard.ToString();
            productReportLblTotalSliderSash.Text += slider_sash_frame.ToString();
            productReportLblTotalSliderFixed.Text += slider_fixed_frame.ToString();

            DateTime today = DateTime.Now;
            Variables.reportParameters.Add(new ReportParameter("time", today.ToString("yyyy-MM-dd")));
            Variables.reportParameters.Add(new ReportParameter("list_date", today.ToString("yyyy-MM-dd")));
            Variables.reportParameters.Add(new ReportParameter("ig_number", productReportLblTotalIG.Text));
            Variables.reportParameters.Add(new ReportParameter("grill_number", productReportLblTotalGrill.Text));
            Variables.reportParameters.Add(new ReportParameter("sdl", productReportLblTotalSDL.Text));
            Variables.reportParameters.Add(new ReportParameter("casement", productReportLblTotalCase.Text));
            Variables.reportParameters.Add(new ReportParameter("sliders", productReportLblTotalSlider.Text));
            Variables.reportParameters.Add(new ReportParameter("shape", productReportLblTotalShape.Text));
            Variables.reportParameters.Add(new ReportParameter("sealed_unit", productReportLblTotalSealedUnit.Text));
            Variables.reportParameters.Add(new ReportParameter("casementwhardware", productReportLblTotalCaseWithHard.Text));
            Variables.reportParameters.Add(new ReportParameter("casementwohardware", productReportLblTotalCaseWithoutHard.Text));
            Variables.reportParameters.Add(new ReportParameter("slider_slash_frame", productReportLblTotalSliderSash.Text));
            Variables.reportParameters.Add(new ReportParameter("slider_fixed_frame", productReportLblTotalSliderFixed.Text));
        }
        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            try
            {
                printDialog.Document = pd;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }
        private void Btprint_Click(object sender, EventArgs e)
        {

        }

        private void ProductReportTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductionReportForm_Load(object sender, EventArgs e)
        {

        }

        private void productReportMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btprint_Click_1(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            DataTable dt_comm = new DataTable();
            //Adding the Columns.
            /*   foreach (DataGridViewColumn column in productReportDgGlassType.Columns)
               {
                   dt.Columns.Add(column.HeaderText);
               }*/
            dt.Columns.Add("glasstype");
            dt.Columns.Add("spwhite");
            dt.Columns.Add("spblack");
            //Adding the Rows.
            foreach (DataGridViewRow row in productReportDgGlassType.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            Variables.datat = dt;

            dt_comm.Columns.Add("Order_number");
            dt_comm.Columns.Add("Line");
            dt_comm.Columns.Add("Glass_comment");
            //Adding the Rows.
            foreach (DataGridViewRow row in productReportDgGlassType.Rows)
            {
                dt_comm.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt_comm.Rows[dt_comm.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            Variables.datat_comm = dt_comm;
            frmPrint frm = new frmPrint();
            frm.Show();

        }
    }
}
