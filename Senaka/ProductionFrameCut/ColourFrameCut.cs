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

namespace Senaka.ProductionFrameCut
{
    public partial class ColourFrameCut : Form
    {
        int casement_total = 0, large_fix_total = 0, small_fix_total = 0, dh_frame_total = 0, sh_frame_total = 0, small_sash1_total = 0, small_sash2_total = 0;
        int casement_SlotSize = 0, large_fix_SlotSize = 0, small_fix_SlotSize = 0, dh_frame_SlotSize = 0, sh_frame_SlotSize = 0, small_sash1_SlotSize = 0, small_sash2_SlotSize = 0;

        List<Data_order> ListToSend = new List<Data_order>();
        List<string> columns;
        public class Data_order
        {
            public string Id { get; set; }
            public string Order { get; set; }
            public string Company { get; set; }
            public int Casement { get; set; }
            public int Large_Fix { get; set; }
            public int Small_Fix { get; set; }
            public int DH_Frame { get; set; }
            public int SH_Frame { get; set; }
            public int Small_Sash1 { get; set; }
            public int Small_Sash2 { get; set; }
            public bool Selected { get; set; }
            public string Live_Test { get; set; }


        }
        public ColourFrameCut()
        {
            InitializeComponent();
        }

        private void ColourFrameCut_Load(object sender, EventArgs e)
        {
           
            
            DataTable schema = DB.GetTableSchema("ordersummary");
            columns = new List<string>();
            foreach (DataRow col in schema.Rows)
            {
                columns.Add(col.Field<String>("ColumnName"));
            }
            List<string[]> CompanyColors = Settings.Paint_Companies_Table.Where(x => x[0] == MainForm.Variables.paint_company).Select(x => new string[] { x[1], x[2] }).ToList();
            List<string[]> OrderSummary = DB.getOrderSummaryByListDateComapny(MainForm.Variables.start_date, MainForm.Variables.end_date, CompanyColors);
            foreach (var element in OrderSummary)
            {
                if (element[element.Length - 1] == null)
                {
                    Data_order row = new Data_order();
                    row.Id = element[columns.IndexOf("id")];
                    row.Order = element[columns.IndexOf("ORDER#")];
                    row.Company = element[columns.IndexOf("COMPANY")];
                    row.Live_Test = element[columns.IndexOf("LIVE_TEST")];
                    //  dgvListToSend.Rows.Add(element[0], false, element[1]);
                    foreach (var name_type in Settings.Production_Casement)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.Casement += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_LargeFix)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.Large_Fix += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_SmallFix)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.Small_Fix += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_DHFrame)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.DH_Frame += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_SHFrame)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.SH_Frame += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_SmallSash1)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.Small_Sash1 += Int32.Parse(c);
                    }
                    foreach (var name_type in Settings.Production_SmallSash2)
                    {
                        string c = element[columns.IndexOf(name_type[2])];
                        if (c != "")
                            row.Small_Sash2 += Int32.Parse(c);
                    }
                    casement_total += row.Casement;
                    large_fix_total += row.Large_Fix;
                    small_fix_total += row.Small_Fix;
                    dh_frame_total += row.DH_Frame;
                    sh_frame_total += row.SH_Frame;
                    small_sash1_total += row.Small_Sash1;
                    small_sash2_total += row.Small_Sash2;
                    
                    ListToSend.Add(row);

                }
            }
            //    bool res;
            string[] res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "Casement frame");
            if (res != null)
            {
                casement_SlotSize = Int32.Parse(res[2]);
                lblCasementBuggy.Text = (casement_total / casement_SlotSize).ToString();
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "Large fix");
            if (res != null)
            {
                large_fix_SlotSize = Int32.Parse(res[2]);
                lblLargeFixBuggy.Text = (large_fix_total / large_fix_SlotSize).ToString();
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "Small fix");
            if (res != null)
            {
                small_fix_SlotSize = Int32.Parse(res[2]);
                lblSmallFixBuggy.Text = (small_fix_total / small_fix_SlotSize).ToString() ;
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "DH Frame");
            if (res != null)
            {
                dh_frame_SlotSize = Int32.Parse(res[2]);
                lblDHFrame.Text =(dh_frame_total / dh_frame_SlotSize).ToString();
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "SH Frame");
            if (res != null)
            {
                sh_frame_SlotSize = Int32.Parse(res[2]);
                lblSHFrame.Text =(sh_frame_total / sh_frame_SlotSize).ToString();
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "Small Sash 1");
            if (res != null)
            {
                small_sash1_SlotSize = Int32.Parse(res[2]);
                lblSmallSash1.Text = (small_sash1_total / small_sash1_SlotSize).ToString();
            }

            res = Settings.Production_Cut_SlotSize_Table.FirstOrDefault(x => x[1] == "Small Sash 2");
            if (res != null)
            {
                small_sash2_SlotSize = Int32.Parse(res[2]);
                lblSmallSash2.Text = (small_sash2_total / small_sash2_SlotSize).ToString();
            }
            /* lblHighFixBuggy.Text = (high_fix_buggy / Int32.Parse(Settings.Production_Cut_SlotSize)).ToString();
             lblSmallSashBuggy.Text = (small_sash_buggy / Int32.Parse(Settings.Production_Cut_SlotSize)).ToString();
             lblSliderFrame.Text = (slider_frame / Int32.Parse(Settings.Production_Cut_SlotSize)).ToString();
            */
            dgvListToSend.AutoGenerateColumns = false;
            (dgvListToSend.BindingContext[ListToSend] as CurrencyManager).Refresh();
            dgvListToSend.DataSource = ListToSend;
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvListToSend.Rows.Count;i++)
                dgvListToSend.Rows[i].Cells[1].Value = true;
        }

        private void buttonUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvListToSend.Rows.Count; i++)
                dgvListToSend.Rows[i].Cells[1].Value = false;
        }

        private void ColourFrameCut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void textBoxOrderNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                //allows just number keys
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }

        private void textBoxOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxOrderNumber.Text;
                if (data != "")
               
                   
                   scanInput(data);

              
            }
        }
        private void scanInput(string order_number)
        {
            WindowLblMessage.Text = "";
            string[] order_Summary = DB.getOrderSummaryLeftProductionCutList(order_number);
            if(!ListToSend.Any(x => x.Order == order_number))
            if (order_Summary != null)
            {
                if (order_Summary[order_Summary.Length-1] == null)
                {
                    Data_order row = new Data_order();
                    row.Id = order_Summary[columns.IndexOf("id")];
                    row.Order = order_Summary[columns.IndexOf("ORDER#")];
                    row.Company = order_Summary[columns.IndexOf("COMPANY")];
                    row.Live_Test = order_Summary[columns.IndexOf("LIVE_TEST")];
                        //  dgvListToSend.Rows.Add(element[0], false, element[1]);
                        foreach (var name_type in Settings.Production_Casement)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.Casement += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_LargeFix)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.Large_Fix += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_SmallFix)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.Small_Fix += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_DHFrame)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.DH_Frame += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_SHFrame)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.SH_Frame += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_SmallSash1)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.Small_Sash1 += Int32.Parse(c);
                        }
                        foreach (var name_type in Settings.Production_SmallSash2)
                        {
                            string c = order_Summary[columns.IndexOf(name_type[2])];
                            if (c != "")
                                row.Small_Sash2 += Int32.Parse(c);
                        }
                        casement_total += row.Casement;
                        large_fix_total += row.Large_Fix;
                        small_fix_total += row.Small_Fix;
                        dh_frame_total += row.DH_Frame;
                        sh_frame_total += row.SH_Frame;
                        small_sash1_total += row.Small_Sash1;
                        small_sash2_total += row.Small_Sash2;

                        ListToSend.Add(row);
                    (dgvListToSend.BindingContext[ListToSend] as CurrencyManager).Refresh();
                    dgvListToSend.DataSource = ListToSend;

                        lblCasementBuggy.Text = casement_SlotSize != 0 ? (casement_total / casement_SlotSize).ToString() : "0";
                        lblLargeFixBuggy.Text = large_fix_SlotSize != 0 ? (large_fix_total / large_fix_SlotSize).ToString() : "0";
                        lblSmallFixBuggy.Text = small_fix_SlotSize != 0 ? (small_fix_total / small_fix_SlotSize).ToString() : "0";
                        lblDHFrame.Text = dh_frame_SlotSize != 0 ? (dh_frame_total / dh_frame_SlotSize).ToString() : "0";
                        lblSHFrame.Text = sh_frame_SlotSize != 0 ? (sh_frame_total / sh_frame_SlotSize).ToString() : "0";
                        lblSmallSash1.Text = small_sash1_SlotSize != 0 ? (small_sash1_total / small_sash1_SlotSize).ToString() : "0";
                        lblSmallSash2.Text = small_sash2_SlotSize != 0 ? (small_sash2_total / small_sash2_SlotSize).ToString() : "0";

                    }
                    else WindowLblMessage.Text = "Order number already scanned!";
            }
            else WindowLblMessage.Text = "Order number doesn't exist!";
            else WindowLblMessage.Text = "This order number is already in the list!";
        
        }

        private void btnSendToCut_Click(object sender, EventArgs e)
        {
             WindowLblMessage.Text = "";
            if (Properties.Settings.Default.ProductionCutPath != "" && Properties.Settings.Default.ProductionCutPath != null)
            {
                if (textBoxFileName.Text != "")
                {
                    List<string[]> data = new List<string[]>();
                    foreach (var row in ListToSend)
                        if (row.Selected == true)
                        {
                            data.Add(new string[] { row.Order, DateTime.Now.ToString("yyyyMMdd") });
                            casement_total -= row.Casement;
                            large_fix_total -= row.Large_Fix;
                            small_fix_total -= row.Small_Fix;
                            dh_frame_total -= row.DH_Frame;
                            sh_frame_total -= row.SH_Frame;
                            small_sash1_total -= row.Small_Sash1;
                            small_sash2_total -= row.Small_Sash2;

                        }
                    if (data.Count != 0)
                    {
                        DB.insertIntoProductionCutList(data);
                        Create_File();
                        ListToSend.RemoveAll(x => x.Selected == true);

                        (dgvListToSend.BindingContext[ListToSend] as CurrencyManager).Refresh();
                        dgvListToSend.DataSource = ListToSend;

                        lblCasementBuggy.Text = casement_SlotSize != 0 ? (casement_total / casement_SlotSize).ToString() : "0";
                        lblLargeFixBuggy.Text = large_fix_SlotSize != 0 ? (large_fix_total / large_fix_SlotSize).ToString() : "0";
                        lblSmallFixBuggy.Text = small_fix_SlotSize != 0 ? (small_fix_total / small_fix_SlotSize).ToString() : "0";
                        lblDHFrame.Text = dh_frame_SlotSize != 0 ? (dh_frame_total / dh_frame_SlotSize).ToString() : "0";
                        lblSHFrame.Text = sh_frame_SlotSize != 0 ? (sh_frame_total / sh_frame_SlotSize).ToString() : "0";
                        lblSmallSash1.Text = small_sash1_SlotSize != 0 ? (small_sash1_total / small_sash1_SlotSize).ToString() : "0";
                        lblSmallSash2.Text = small_sash2_SlotSize != 0 ? (small_sash2_total / small_sash2_SlotSize).ToString() : "0";
                    }
                }
                else WindowLblMessage.Text = "Enter file name!";
            }
            else WindowLblMessage.Text = "Select file path!";
          
        }
        private int Create_File()
        {
            List<string> test = new List<string>(), live = new List<string>();
            foreach (var element in ListToSend)
            {   if(element.Selected==true)
                if (element.Live_Test == "L") live.Add(element.Order);
                else if (element.Live_Test == "T") test.Add(element.Order);
            }

            string fileName = Properties.Settings.Default.ProductionCutPath+ @"\URBAN_LIVE_"+textBoxFileName.Text+".csv";

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine();

            foreach (var element in live)
                sbOutput.AppendLine(element);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, sbOutput.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            fileName = Properties.Settings.Default.ProductionCutPath + @"\URBAN_TEST_" + textBoxFileName.Text + ".csv";

            sbOutput = new StringBuilder();
            sbOutput.AppendLine();
            foreach (var element in test)
                sbOutput.AppendLine(element);
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, sbOutput.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Create a new file     

            return 0;

        }
        private void textBoxFileName_Click(object sender, EventArgs e)
        {
          
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}
