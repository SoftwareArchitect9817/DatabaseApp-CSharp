
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using static Senaka.ProductionReportForm;

namespace Senaka
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.SetParameters(Variables.reportParameters);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = Variables.datat;

            ReportDataSource rds_comm = new ReportDataSource();
            rds_comm.Name = "DataSet2";
            rds_comm.Value = Variables.datat_comm;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds_comm);
            reportViewer1.RefreshReport();
        }

        private void frmPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }
    }
}
