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
    public partial class BookingPrint : Form
    {
        ReportDataSource rdsLocal;
        ReportParameterCollection reportParametersLocal;
        public BookingPrint(ReportDataSource rds, ReportParameterCollection reportParameters)
        {
            InitializeComponent();
            rdsLocal = rds;
            reportParametersLocal = reportParameters;
        }
      
        private void BarcodePrint_Load(object sender, EventArgs e)
        {
          
            this.reportViewer1.LocalReport.DataSources.Add(rdsLocal);
            this.reportViewer1.LocalReport.SetParameters(reportParametersLocal);
            this.reportViewer1.RefreshReport();
           
        }

        private void BarcodePrint_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
