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
    public partial class ProductionByOrdersPrint : Form
    {
        public ProductionByOrdersPrint(List<string[]> data)
        {
            InitializeComponent();

            foreach (var row in data)
            {
                //H,K,E,S,J,I,C
                dataProductionByOrders.Rows.Add(
                    false,
                    row[7],     //H line3
                    row[10],    //K dealer
                    row[4],     //E window type
                    row[18],    //S glass type
                    row[9],     //J spacer
                    row[8],     //I grills
                    row[2],     //C sealed unit id

                    row[19],    //T
                    row[2],     //C
                    row[3],     //D
                    row[9],     //J
                    row[5],     //F
                    row[4],     //E
                    row[8],     //I
                    row[20],    //U
                    row[21],    //V
                    row[18],    //S
                    row[7],     //H
                    row[14],    //O
                    row[15],    //P
                    row[16],    //Q
                    row[17]     //R
                );
            }
        }

        private void ProductionByOrdersPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            new MainForm().Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ProductionByOrdersDataSet dataSet = new ProductionByOrdersDataSet();
            var checkedRows = from DataGridViewRow r in dataProductionByOrders.Rows
                              where Convert.ToBoolean(r.Cells[0].Value) == true
                              select r;
            foreach (var row in checkedRows)
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.IncludeLabel = true;
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, row.Cells[9].Value.ToString(), 360, 80);
                byte[] C_barcode = ImageToByteArray(img);
                b.IncludeLabel = false;
                img = b.Encode(BarcodeLib.TYPE.CODE128, row.Cells[18].Value.ToString(), 360, 80);
                byte[] H_barcode = ImageToByteArray(img);
                dataSet.Tables[0].Rows.Add(
                    row.Cells[8].Value.ToString(),
                    C_barcode,
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString(),
                    row.Cells[13].Value.ToString(),
                    row.Cells[14].Value.ToString(),
                    row.Cells[15].Value.ToString(),
                    row.Cells[16].Value.ToString(),
                    row.Cells[17].Value.ToString(),
                    H_barcode,
                    row.Cells[19].Value.ToString(),
                    row.Cells[20].Value.ToString(),
                    row.Cells[21].Value.ToString(),
                    row.Cells[22].Value.ToString()
                );
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dataSet.Tables[0];
                new UniversalPrint(rds, null, @"reports\ProductionByOrdersLabel.rdlc").Show();
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
