
using Senaka.component;
using Senaka.lib;
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

namespace Senaka
{
    public partial class OptimizeForm : Form
    {
        string[] field_names;
        public DateTime? list_date = null;
        public string[] order_number = null;
        public string batch_number = null;
        bool open_file;
        bool is_saved = true;

        Timer thread = new Timer();
        ProgressDialog progress = new ProgressDialog();

        OptimizeReportForm optiReport = null;
        ProductionReportForm productReport = null;

        public OptimizeForm()
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            optInit();
        }

        private void optInit()
        {
            optBtnOptimize.Enabled = false;
            optBtnSaveOptimize.Enabled = false;
            optBtnExportCsv.Enabled = false;
            optBtnProReport.Enabled = false;
            optBtnOptimizeReport.Enabled = false;
            optDgGlass.Rows.Clear();

            field_names = new string[26] { "ORDER DATE", "LIST DATE", "SEALED UNIT ID", "OT", "WINDOW TYPE", "LINE# 1", "LINE# 2", "LINE# 3", "GRILLS", "SPACER", "DEALER", "GLASS COMMENT", "TAG", "ZONES", "U VALUE", "SOLAR HEAT GAIN", "VISUAL TRASMITTANCE", "ENERGY RATING", "GLASS TYPE", "ORDER #", "WIDTH", "HEIGHT", "QTY", "DESCRIPTION", "NOTE 1", "NOTE 2" };
            open_file = false;

            Rack.initRack();
        }

        private bool confirmSaved()
        {
            DialogResult confirm = MessageBox.Show("Data is not saved yet.\n Will you save data to database?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (confirm.Equals(DialogResult.Yes))
            {
                saveOptimize();
            }
            else if (confirm.Equals(DialogResult.Cancel))
            {
                return false;
            }
            return true;
        }

        private void OptimizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!is_saved && !confirmSaved())
            {
                e.Cancel = true;
                return;
            }

            if (optiReport != null)
            {
                optiReport.Close();
            }

            new MainForm().Show();

        }

        private void optBtnImportDate_Click(object sender, EventArgs e)
        {
            if (!is_saved && !confirmSaved())
            {
                return;
            }
            
            list_date = new SelectDateDialogBooking().InputBox();
            if (list_date == null) return;

            order_number = null;
            optInit();

            thread.Interval = 1;
            thread.Tick += Import_Tick;
            thread.Start();

            progress.Show();
        }

        private void optBtnImportOrder_Click(object sender, EventArgs e)
        {
            if (!is_saved && !confirmSaved())
            {
                return;
            }
            
            order_number = new SelectOrderDialog().InputBox();
            if (order_number.Length == 0) return;

            list_date = null;
            optInit();

            thread.Interval = 1;
            thread.Tick += Import_Tick;
            thread.Start();

            progress.Show();
        }

        private void Import_Tick(object sender, EventArgs e)
        {
            thread.Stop();
            thread.Tick -= Import_Tick;

            List<string[]> data;
            if (list_date != null) data = DB.importGlassByListDate(list_date);
            else if(order_number != null) data = DB.importGlassByOrder(order_number);
            else data = DB.importGlassByBatch(batch_number);
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Rack.addGlass(i, data[i]);
                    addGlassToTable(i + 1, data[i]);
                }
                optBtnOptimize.Enabled = true;
                progress.Close();
                return;
            }

            is_saved = true;
            optInit();
            progress.Close();
            MessageBox.Show("No found data!");
        }

        private void addGlassToTable(int i, string[] temp, string rackId = null)
        {
            optDgGlass.Rows.Add(i, rackId, temp[(int)GLASS.ORDER], temp[(int)GLASS.OT], temp[(int)GLASS.SEALED_UNIT_ID],
                temp[(int)GLASS.WINDOW_TYPE], temp[(int)GLASS.GLASS_TYPE], temp[(int)GLASS.WIDTH], temp[(int)GLASS.HEIGHT], temp[(int)GLASS.QTY]);
        }

        private void optBtnOpenFile_Click(object sender, EventArgs e)
        {
            if (!is_saved && !confirmSaved())
            {
                return;
            }

            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            fdlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
                openCSVFile(fname);
            }
        }

        private void openCSVFile(string fileName)
        {
            optInit();
            try
            {
                open_file = true;

                string[] temp;
                using (var reader = new StreamReader(fileName))
                {
                    field_names = reader.ReadLine().Split(',');
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        temp = reader.ReadLine().Split(',').Select(item => item.Trim()).ToArray();
                        Rack.addGlass(i, temp);
                        addGlassToTable(++i, temp);
                    }
                }
                optBtnOptimize.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unknow File Format");
                is_saved = true;
            }
        }

        private void optBtnOptimize_Click(object sender, EventArgs e)
        {
            int i;
            string rackId;
            string[] glass;

            Rack.optimize();
            optDgGlass.Rows.Clear();
            for (i = 0; i < Rack.optimized.Count; i++)
            {
                rackId = Rack.rack[i];
                glass = Rack.optimized[i];
                addGlassToTable(i + 1, glass, rackId);
            }

            is_saved = false;
            optBtnOptimize.Enabled = false;
            optBtnSaveOptimize.Enabled = true;
            optBtnExportCsv.Enabled = true;
            optBtnProReport.Enabled = true;
            optBtnOptimizeReport.Enabled = true;
        }

        private void optBtnSaveOptimize_Click(object sender, EventArgs e)
        {
            saveOptimize();
        }

        private void saveOptimize()
        {
            thread.Interval = 1;
            thread.Tick += SaveOptimize_Tick; ;
            thread.Start();

            progress.Show();
        }

        private void SaveOptimize_Tick(object sender, EventArgs e)
        {
            thread.Stop();
            thread.Tick -= SaveOptimize_Tick;
            Settings.saveSUShipping(Rack.su_shipping);
            int fails = 0;
            for (int i = 0; i < Rack.optimized.Count; i++)
            {
                if (open_file) fails += DB.saveOptimizeGlass(Rack.optimized[i], Rack.rack[i]);
                else
                {
                    if (list_date != null) fails += DB.updateGlassByListDate(list_date, Rack.optimized[i][(int)GLASS.SEALED_UNIT_ID], Rack.rack[i]);
                    if(batch_number != null) fails += DB.updateGlassByBatch(batch_number, Rack.optimized[i][(int)GLASS.SEALED_UNIT_ID], Rack.rack[i]);
                    else fails += DB.updateGlassByOrder(i, order_number, Rack.optimized[i][(int)GLASS.SEALED_UNIT_ID], Rack.rack[i]);
                }
            }

            if (fails > 0) MessageBox.Show("Already saved or Failed! Please try again.");
            else
            {
                if (Rack.su_history.Count > 0) Settings.saveSUHistory(Rack.listToList(Rack.su_history));
                if (Rack.su_shipping.Count > 0) Settings.saveSUShipping(Rack.su_shipping);
                is_saved = true;
                optBtnSaveOptimize.Enabled = false;
            }

            progress.Close();
        }

        private void optBtnExportCsv_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    saveCSVFile(sfd.FileName);
                }
            }
        }

        private void saveCSVFile(string filename)
        {
            //before your loop
            var csv = new StringBuilder();
            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25}", field_names);
            newLine = "RACK ID," + newLine;
            csv.AppendLine(newLine);
            for (int i = 0; i < Rack.optimized.Count; i++)
            {
                newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25}", Rack.optimized[i]);
                newLine = Rack.rack[i] + "," + newLine;
                csv.AppendLine(newLine);
            }

            //after your loop
            File.WriteAllText(filename, csv.ToString());
        }

        private void optBtnProReport_Click(object sender, EventArgs e)
        {
            if (productReport == null)
            {
                productReport = new ProductionReportForm(this);
                productReport.Show();
            }
        }

        public void productReportClosed()
        {
            productReport = null;
        }

        private void optBtnOptimizeReport_Click(object sender, EventArgs e)
        {
            if (optiReport == null)
            {
                optiReport = new OptimizeReportForm(this);
                optiReport.Show();
            }
        }

        public void optimizeReportClosed()
        {
            optiReport = null;
        }

        private void optBtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void optBtnImportBatch_Click(object sender, EventArgs e)
        {
            if (!is_saved && !confirmSaved())
            {
                return;
            }
            
            batch_number = new InsertOrderDialog("Batch number").InputBox();
            if (string.IsNullOrEmpty(batch_number)) return;

            list_date = null;
            order_number = null;

            optInit();

            thread.Interval = 1;
            thread.Tick += Import_Tick;
            thread.Start();

            progress.Show();
        }
    }
}
