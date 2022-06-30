using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
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

namespace Senaka.print_forms
{
    public partial class FrameReportPrint : Form
    {
        ReportDataSource rdsLocal = new ReportDataSource();
        ReportParameterCollection reportParameters = new ReportParameterCollection();

        public FrameReportPrint(List<string> orderNumbers)
        {
            InitializeComponent();

            List<string[]> data = DB.getFramesCuttingByOrdersWID(orderNumbers);
            List<string[]> ListDates = DB.getOrderListDate(orderNumbers);
            if (data != null)
            {
                List<string> frame_ids = new List<string>();
                foreach (var element in data)
                {
                    frame_ids.Add(element[5]);
                }
                List<string[]> FrameClearing_prefix_date = new List<string[]>();
                List<string> names = new List<string>();
                FrameReportDataSet data_Order = new FrameReportDataSet();
                List<string[]> data_done = DB.importFrameClearingByIds(frame_ids);
                if (data_done != null)
                {
                    List<string[]> ShippingReceivingDates = DB.getVinylShippingReceivingDate(orderNumbers);
                    foreach (var element in data)
                    {
                        string status = "NOT READY";
                        DateTime listDate = new DateTime();
                        bool result = false;
                        var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        string[] dates = ShippingReceivingDates.FirstOrDefault(x => x[0] == element[9]);
                        string[] OrdSummary = ListDates.FirstOrDefault(x => x[0] == element[9]);
                        if (OrdSummary != null)
                        {
                            result = DateTime.TryParseExact(OrdSummary[1], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out listDate);
                        }
                        string shipingDate = "", receivingDate = "";
                        if (dates != null)
                        {
                            shipingDate = dates[1] != null ? DateTime.ParseExact(dates[1].Substring(0,9), "M/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MM-yyyy") : "";
                            receivingDate = dates[2] != null ? DateTime.ParseExact(dates[2].Substring(0, 9), "M/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MM-yyyy") : "";
                        }

                        if (match != null)
                        {
                            status = "COMPLETE";
                        }
                        data_Order.Tables[0].Rows.Add(
                            element[9],
                            element[18],
                            element[11],
                            element[12],
                            element[7],
                            element[5],
                            element[16],
                            element[17],
                            element[19],
                            result == true ? listDate.ToString("dd-MM-yyyy") : "",
                            shipingDate,receivingDate, status
                        );
                    }
                    rdsLocal.Value = data_Order.Tables[0];
                    rdsLocal.Name = "DataSet2";
                }
            }                     
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
        }

        private void FrameReportPrint_Load(object sender, EventArgs e)
        {
            FrameReportViewer.LocalReport.DataSources.Add(rdsLocal);
            FrameReportViewer.LocalReport.SetParameters(reportParameters);
            FrameReportViewer.RefreshReport();
        }

        private void FrameReportPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }
    }
}
