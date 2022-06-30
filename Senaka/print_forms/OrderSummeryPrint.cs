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
    public partial class OrderSummeryPrint : Form
    {
        SummaryDataSet summaryDataSet_global;
        string order_date_global;
        ReportParameterCollection reportParameters = new ReportParameterCollection();

        public OrderSummeryPrint(SummaryDataSet summaryDataSet, string order_date)
        {
            InitializeComponent();

            summaryDataSet_global = summaryDataSet;
            order_date_global = order_date;
        }

        private void OrderSummeryPrint_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet";
            rds.Value = summaryDataSet_global.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
            reportParameters.Add(new ReportParameter("DateParameter", order_date_global));
            reportViewer1.LocalReport.SetParameters(reportParameters);
            reportViewer1.RefreshReport();
            reportViewer1.RefreshReport();
        }

        private void OrderSummeryPrint_FormClosing(object sender, FormClosingEventArgs e)
        {  
        }
    }
}
