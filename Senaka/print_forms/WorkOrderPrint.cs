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
    public partial class WorkOrderPrint : Form
    {
        public WorkOrderPrint(List<string[]> data)
        {
            InitializeComponent();
            
            foreach (var row in data)
            {
                string type = row[6].Split(new char[] { '#' })[0];
                dataWorkOrderPrint.Rows.Add(
                    false,
                    row[9], //LINE #1
                    row[3], //DEALER
                    row[1], //PO
                    type    //WINDOW TYPE
                );
            }
        }

        private void WorkOrderPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            WorkOrderDataSet workOrderDataSet = new WorkOrderDataSet();
            var checkedRows = from DataGridViewRow r in dataWorkOrderPrint.Rows
                              where Convert.ToBoolean(r.Cells[0].Value) == true
                              select r;
            foreach (var row in checkedRows)
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, row.Cells[1].Value.ToString(), 360, 80);
                byte[] barcode = ImageToByteArray(img);
                workOrderDataSet.Tables[0].Rows.Add(
                    barcode,
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString()
                );
            }
            if (workOrderDataSet.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = workOrderDataSet.Tables[0];
                new UniversalPrint(rds, null, @"reports\WorkOrderLabelReport.rdlc").Show();
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
    }
}
