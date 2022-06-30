using Senaka.component;
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
using static Senaka.MainForm;

namespace Senaka
{
    public partial class ProductionForm : Form
    {
        List<string[]> productionReport_data, windowsassembly_data, glassreport_data;
        ProgressDialog progress = new ProgressDialog();
        Timer thread = new Timer();
        Timer timer;
        string CloseReason;
        public ProductionForm()
        {
            InitializeComponent();
            toolTipCalendar.SetToolTip(CalendarBtn, "Change date");
            toolTipBack.SetToolTip(BackDateBtn, "Back");
            toolTipForward.SetToolTip(ForwardDateBtn, "Forward");
        }
        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iShippingDate.Text = today.ToString("yyyy-MM-dd");
            iShippingTime.Text = today.ToString("HH:mm:ss");
        }
        private void ExecuteProductionForm(object sender, EventArgs e)
        {
            thread.Stop();
            thread.Tick -= ExecuteProductionForm;

            List<string> line_numbers = new List<string>();
            string[] sliders = Settings.Slider.Select(x => x[2]).ToArray();

            string[] casements = Settings.Casement.Select(x => x[2]).ToArray();

            string[] sus = Settings.SU.Select(x => x[2]).ToArray();

            string[] shapes = Settings.Shape.Select(x => x[2]).ToArray();
            string error_text = null;
            string line_number;
            int casement_total = 0, slider_total = 0, shape_total = 0, su_total = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iShippingDate.Text = date;
            iShippingTime.Text = today.ToString("HH:mm:ss");

            productionReport_data = DB.getProductioReportLeftOrderSummary(MainForm.Variables.start_date.ToString("dd MMMMMMMM yyyy"), MainForm.Variables.end_date.ToString("dd MMMMMMMM yyyy"));
            if (productionReport_data.Count != 0)
            {
                List<string> order_numbers = productionReport_data.Select(x => x[3]).ToList();
                List<string[]> IDS_total = DB.importFramereportbyIDs(order_numbers);
                List<string[]> glass_report_total = DB.importGlassReportByOrders(order_numbers, sus);
                List<string> casement_ids_total = new List<string>(), slider_ids_total = new List<string>(), glass_ids_total = new List<string>(), shape_ids_total = new List<string>();
                foreach (string[] report in productionReport_data)
                {
                    string productionOrder = report[0];
                    if (productionOrder != null)
                    {
                        string order_number = report[3].Substring(0, 5);
                        string casement = report[4];
                        string slider = report[5];
                        string shape = report[6];
                        string su = report[7];
                        if (casement != "0")
                        {
                            List<string> list = new List<string>(casements);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();


                            foreach (var entry in IDS)
                            {
                                casement_ids_total.Add(entry[0]);
                            }
                        }
                        if (slider != "0")
                        {
                            List<string> list = new List<string>(sliders);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                            foreach (var entry in IDS)
                            {
                                slider_ids_total.Add(entry[0]);
                            }


                        }
                        if (su != "0")
                        {
                            glassreport_data = glass_report_total.Where(x => x[1] == order_number).ToList();

                            foreach (var entry in glassreport_data)
                            {
                                glass_ids_total.Add(entry[0]);
                            }
                        }
                        if (shape != "0")
                        {
                            List<string> list = new List<string>(shapes);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                            foreach (var entry in IDS)
                            {
                                shape_ids_total.Add(entry[0]);
                            }
                        }
                    }

                }
                List<string[]> windows_assembly_casement_total = DB.importWindowsAssemblyByIds(casement_ids_total);
                List<string[]> windows_assembly_shape_total = DB.importWindowsAssemblyByIds(shape_ids_total);
                List<string[]> windows_assembly_slider_total = DB.importWindowsAssemblyByIds(slider_ids_total);

                List<string[]> igsorting_total = DB.importIgSorting(glass_ids_total);
                foreach (string[] report in productionReport_data)
                {
                    string productionOrder = report[0];
                    string order = report[report.Length - 1];
                    if (productionOrder != null)
                    {
                    productionReport_data = new List<string[]>();
                    windowsassembly_data = new List<string[]>();
                    glassreport_data = new List<string[]>();

                    string status = "";
                    string casement = report[4];
                    string slider = report[5];
                    string shape = report[6];
                    string su = report[7];
                    double information;


                    string casement_info = null;
                    string slider_info = null;
                    string shape_info = null;
                    string su_info = null;
                    string description = null;

                    bool casement_complete = false;
                    bool slider_complete = false;
                    bool su_complete = false;
                    bool shape_complete = false;

                    int casementqty = 0;
                    int sliderqty = 0;
                    int suty = 0;
                    int shapeqty = 0;


                    string order_number = report[3].Substring(0, 5);


                    //qty for casements
                    if (casement != "0")
                    {
                        List<string> list = new List<string>(casements);
                        //  List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                        List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                        List<string> casement_ids = new List<string>();
                        foreach (var entry in IDS)
                        {
                            casement_ids.Add(entry[0]);
                        }

                        if (windows_assembly_casement_total != null)
                            casementqty = windows_assembly_casement_total.Where(x => casement_ids.Any(a => a == x[0])).ToList().Count;
                        casement_info = casementqty + "/" + casement;

                    }

                    if (casementqty == Int32.Parse(casement)) casement_complete = true;
                    //qty for slider
                    if (slider != "0")
                    {
                        List<string> list = new List<string>(sliders);
                        //   List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                        List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();
                        List<string> slider_ids = new List<string>();
                        foreach (var entry in IDS)
                        {
                            slider_ids.Add(entry[0]);
                        }
                        //  List<string[]> windows_assembly_table = DB.importWindowsAssemblyByIds(slider_ids);
                        if (windows_assembly_slider_total != null)
                            sliderqty = windows_assembly_slider_total.Where(x => slider_ids.Any(a => a == x[0])).ToList().Count;
                        slider_info = sliderqty + "/" + slider;

                    }

                    if (sliderqty == Int32.Parse(slider))
                        slider_complete = true;
                    //qty for su
                    if (su != "0")
                    {
                        if (report[3] == "87165")
                        {
                            MessageBox.Show("test");
                        }
                        glassreport_data = glass_report_total.Where(x => x[1] == order_number).ToList();
                        List<string> glass_ids = new List<string>();
                        foreach (var entry in glassreport_data)
                        {
                            glass_ids.Add(entry[0]);
                        }
                        if (glassreport_data.Count != 0)
                            windowsassembly_data = igsorting_total.Where(x => glass_ids.Any(a => a == x[0])).ToList();
                        if (windowsassembly_data != null)
                            suty = windowsassembly_data.Count;
                        su_info = suty + "/" + su;

                    }
                    if (suty == Int32.Parse(su))
                        su_complete = true;
                    //qty for shape
                    if (shape != "0")
                    {
                        List<string> list = new List<string>(shapes);
                        //     List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                        List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();
                        List<string> shape_ids = new List<string>();
                        foreach (var entry in IDS)
                        {
                            shape_ids.Add(entry[0]);
                        }
                        List<string[]> windows_assembly_table = windows_assembly_shape_total.Where(x => shape_ids.Any(a => a == x[0])).ToList();
                        if (windows_assembly_table != null)
                            shapeqty = windows_assembly_table.Count;
                        shape_info = shapeqty + "/" + shape;
                        // line_numbers = new List<string>();
                    }


                    if (shapeqty == Int32.Parse(shape)) shape_complete = true;

                    if (casement_complete && slider_complete && su_complete && shape_complete) status = "COMPLETE";
                    else if (casementqty != 0 || sliderqty != 0 || shapeqty != 0 || suty != 0) status = "IN PROGRESS";
                    else status = "NOT READY";

                    information = ((double)(casementqty + sliderqty + shapeqty + suty) / (Int32.Parse(casement) + Int32.Parse(slider) + Int32.Parse(shape) + Int32.Parse(su))) * 100;
                    if ((Int32.Parse(casement) + Int32.Parse(slider) + Int32.Parse(shape) + Int32.Parse(su)) == 0) information = 0;
                    ProductionReportData.Rows.Insert(0, status, report[3], casement_info, slider_info, shape_info, su_info, report[10], information, report[11]);
                    if (report[11] == "RUSH") ProductionReportData.Rows[0].Visible = false;
                    if (status == "COMPLETE") ProductionReportData.Rows[0].Cells[0].Style.BackColor = Color.Lime;
                    else if (status == "IN PROGRESS") ProductionReportData.Rows[0].Cells[0].Style.BackColor = Color.Gold;
                    else ProductionReportData.Rows[0].Cells[0].Style.BackColor = Color.OrangeRed;


                    if (report[7] == "RUSH") ProductionReportData.Rows[0].Visible = false;

                    casement_total += Int32.Parse(casement);
                    slider_total += Int32.Parse(slider);
                    shape_total += Int32.Parse(shape);
                    su_total += Int32.Parse(su);

                }
                    else ProductionReportData.Rows.Insert(0, "NOT CUT", order, null, null, null, null, null, null, null);
                }
                totacasementlLbl.Text = casement_total.ToString();
                TotalSLiderLblData.Text = slider_total.ToString();
                TotalShapeLblData.Text = shape_total.ToString();
                TotalSuLblData.Text = su_total.ToString();
                if (MainForm.Variables.end_date == null) ListDate.Text = MainForm.Variables.start_date.ToString("dd MMMMMMMM yyyy");
                else ListDate.Text = MainForm.Variables.start_date.ToString("dd MMMMMMMM yyyy") + " - " + MainForm.Variables.end_date.ToString("dd MMMMMMMM yyyy");
                label1.Text = productionReport_data.Count.ToString();
               
            }
            else
            {
              
                CloseReason = "ReqFromCode";
                Close();
               MessageBox.Show("No orders!");
                SelectDateorDateRangeDialog select_daterange = new SelectDateorDateRangeDialog();
                DateTime[] list_date = select_daterange.InputBox();
                if (list_date != null)
                {

                    Variables.start_date = list_date[0];
                    Variables.end_date = list_date[1];

                    ProductionForm productionForm = new ProductionForm();
                    productionForm.Show();
                    //  if (start_date != end_date) //setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
                }
              
            }
            progress.Close();


        }
            private   void ProductionForm_Load(object sender, EventArgs e)
        {

            thread.Interval = 1;
            thread.Tick += ExecuteProductionForm;
            thread.Start();
            progress.Show();
            
        
        }

       

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBox1.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }
        private void scanInput(string data)
        {
            for (int j = 0; j < ProductionReportData.RowCount; j++)
            {
                if (ProductionReportData.Rows[j].Cells[1].Value.ToString() == data || ProductionReportData.Rows[j].Cells[6].Value.ToString() == data) ProductionReportData.Rows[j].Visible = true;
                else ProductionReportData.Rows[j].Visible = false;
            }


        }

        private void productReportMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductionReportData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProductionReportData.Rows[e.RowIndex].Cells[0].Value.ToString() != "NOT CUT")
            {
                if (e.ColumnIndex == ProductionReportData.Columns["ColumnA"].Index && e.RowIndex >= 0)
                {
                    string order_number = ProductionReportData.Rows[e.RowIndex].Cells[ProductionReportData.Columns["Order_numb"].Index].Value.ToString();
                    if (order_number != null)
                    {
                        List<string[]> data = DB.importFrameReportbyLine(order_number);
                        if (data.Count == 0)
                        {
                            MessageBox.Show("Invalid Order Number!", "Error");
                            return;
                        }
                        Hide();
                        InquireForm inquireForm = new InquireForm(data, "windowsAssembly", false);
                        inquireForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                        inquireForm.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == ProductionReportData.Columns["ColumnG"].Index && e.RowIndex >= 0)
                {
                    string order_number = ProductionReportData.Rows[e.RowIndex].Cells[ProductionReportData.Columns["Order_numb"].Index].Value.ToString();

                    if (order_number != null)
                    {
                        List<string[]> data = DB.fetchRows("glassreport", "order", order_number, false);
                        if (data.Count == 0)
                        {
                            MessageBox.Show("Invalid Order Number!", "Error");
                            return;
                        }
                        Hide();
                        IGInquireSubForm subform = new IGInquireSubForm(data, null, true);
                        subform.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                        subform.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == ProductionReportData.Columns["ColumnC"].Index && e.RowIndex >= 0)
                {
                    string order_number = ProductionReportData.Rows[e.RowIndex].Cells[ProductionReportData.Columns["Order_numb"].Index].Value.ToString();

                    if (order_number != null)
                    {
                        List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                        if (data.Count == 0)
                        {
                            MessageBox.Show("Invalid Order Number!", "Error");
                            return;
                        }
                        foreach (var element in Settings.Casing)
                            data.RemoveAll(x => x[7] == element[2]);
                        Hide();
                        InquireForm inquireForm = new InquireForm(data, "Colour", false);
                        inquireForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                        inquireForm.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == ProductionReportData.Columns["ColumnF"].Index && e.RowIndex >= 0)
                {
                    string order_number = ProductionReportData.Rows[e.RowIndex].Cells[ProductionReportData.Columns["Order_numb"].Index].Value.ToString();

                    if (order_number != null)
                    {
                        List<string[]> data = DB.fetchRows("framescutting", "J", order_number, false);
                        if (data.Count == 0)
                        {
                            MessageBox.Show("Invalid Order Number!", "Error");
                            return;
                        }

                        foreach (var element in Settings.Casing)
                            data.RemoveAll(x => x[7] == element[2]);
                        Hide();
                        InquireForm inquireForm = new InquireForm(data, "frameClearing", false);
                        inquireForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                        inquireForm.ShowDialog();

                    }
                }
            }
            else MessageBox.Show("Glass is not cut!", "Error");
        }
        void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void radioButtonShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowAll.Checked == true)
            
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                
                    ProductionReportData.Rows[j].Visible = true;
                
            
        }

        private void radioButtonShowNotComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowNotComplete.Checked == true)
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                
                    
                        if (ProductionReportData.Rows[j].Cells[ProductionReportData.Columns["Status"].Index].Value.ToString() != "COMPLETE") ProductionReportData.Rows[j].Visible = true;
            else ProductionReportData.Rows[j].Visible = false;



        }

        private void radioButtonOnlyComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOnlyComplete.Checked == true)
                for (int j = 0; j < ProductionReportData.RowCount; j++)


                    if (ProductionReportData.Rows[j].Cells[ProductionReportData.Columns["Status"].Index].Value.ToString() == "COMPLETE") ProductionReportData.Rows[j].Visible = true;
                    else ProductionReportData.Rows[j].Visible = false;

        }

        private void radioButtonRushOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRushOrders.Checked == true)
                for (int j = 0; j < ProductionReportData.RowCount; j++)
            
                if (ProductionReportData.Rows[j].Cells[8].Value.ToString() == "RUSH") ProductionReportData.Rows[j].Visible = true;
                    else ProductionReportData.Rows[j].Visible = false;
        }

        private void ProductionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseReason != "ReqFromCode")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }

        private void ForwardDateBtn_Click(object sender, EventArgs e)
        {
            CloseReason = "ReqFromCode";
            Close();
            Variables.start_date = Variables.start_date.AddDays(1);
            Variables.end_date = Variables.end_date.AddDays(1);
            ProductionForm productionForm = new ProductionForm();
            productionForm.Show();
        }

        private void CalendarBtn_Click(object sender, EventArgs e)
        {
            CloseReason = "ReqFromCode";
            Close();
            SelectDateorDateRangeDialog select_daterange = new SelectDateorDateRangeDialog();
            DateTime[] list_date = select_daterange.InputBox();
            if (list_date != null)
            {

                Variables.start_date = list_date[0];
                Variables.end_date = list_date[1];
              
                ProductionForm productionForm = new ProductionForm();
                productionForm.Show();
                //  if (start_date != end_date) //setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
            }
        }

        private void BackDateBtn_Click(object sender, EventArgs e)
        {
            CloseReason = "ReqFromCode";
            Close();
            Variables.start_date = Variables.start_date.AddDays(-1);
            Variables.end_date = Variables.end_date.AddDays(-1);
            ProductionForm productionForm = new ProductionForm();
                productionForm.Show();
                //  if (start_date != end_date) //setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
            }
        }

       

    }

