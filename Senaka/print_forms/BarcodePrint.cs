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
    public partial class BarcodePrint : Form
    {
        List<byte[]> images;

        public BarcodePrint(List<byte[]> images_get)
        {
            InitializeComponent();

            images = images_get;
        }
      
        private void BarcodePrint_Load(object sender, EventArgs e)
        {
            BarcodeDataSet barcodeDataSet = new BarcodeDataSet();
            foreach (byte[] img in images)
            {
                barcodeDataSet.Tables[0].Rows.Add(img);
            }
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = barcodeDataSet.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void BarcodePrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }
    }
}
