using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.print_forms
{
    public partial class UniversalPrint : Form
    {
        ReportDataSource rdsLocal;
        ReportParameterCollection reportParametersLocal;
        string reportAddress;

        public UniversalPrint(ReportDataSource rds, ReportParameterCollection reportParameters, string address)
        {
            InitializeComponent();

            rdsLocal = rds;
            reportParametersLocal = reportParameters;
            reportAddress = address;
        }
      
        private void PrintForm_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = reportAddress;
            reportViewer1.LocalReport.DataSources.Add(rdsLocal);
            if (reportParametersLocal != null)
            {
                reportViewer1.LocalReport.SetParameters(reportParametersLocal);
            }
            reportViewer1.RefreshReport();
        }
    }
}
