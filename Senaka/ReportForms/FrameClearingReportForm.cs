using Microsoft.Reporting.WinForms;

using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Senaka
{
    public partial class FrameClearingReportForm : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        Timer blink_timer;
        ReportParameterCollection reportParameters = new ReportParameterCollection();
        public class List_order_type
        {
            public List_order_type(string order_number, List<string> cs_f_numbers, List<string> cs_s_numbers, List<string> sm_f_numbers, List<string> l_f_numbers, List<string> sl_f_numbers, List<string> sl_s_numbers, List<string> bmd_numbers)
            {
                Order_numb = order_number;
                Cs_F_Numbers = cs_f_numbers;
                Cs_S_Numbers = cs_s_numbers;

                Sl_F_Numbers = sl_f_numbers;
                Sl_S_Numbers = sl_s_numbers;
                Bmd_Numbers = bmd_numbers;
                Sm_F_Numbers = sm_f_numbers;
                L_F_Numbers = l_f_numbers;
            }

            public string Order_numb { get; set; }
            public List<string> Cs_F_Numbers { get; set; }
            public List<string> Cs_S_Numbers { get; set; }

            public List<string> Sl_F_Numbers { get; set; }
            public List<string> Sl_S_Numbers { get; set; }
            public List<string> Bmd_Numbers { get; set; }
            public List<string> Sm_F_Numbers { get; set; }
            public List<string> L_F_Numbers { get; set; }

        }


        public FrameClearingReportForm(List<string[]> data, List<string> orderNumbers)
        {
            InitializeComponent();

            MinimumSize = new Size(1024, 768);

            initForm(data, orderNumbers);
        }
        private void initForm(List<string[]> data, List<string> orderNumbers)
        {
            ProductionReportData.AutoGenerateColumns = false;
            var list = new List<Data_order>();
            var list_type = new List<List_order_type>();
            var ord_numbs = new List<string>();
            var listorder = new List<KeyValuePair<string, string[]>>();
            for (int i = 0; i < data.Count; i++)
            {
                int cs_f = 0, cs_s = 0, s_f = 0, sl_f = 0, sl_s = 0, bmd = 0, l_f = 0;
                bool exist = false;
                string category = "";

                for (int j = 0; j < list.Count; j++)
                {

                    if (list[j].Order_numb == data[i][10])
                    {



                        if (Settings.Brickmould.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].Bmd += 1;

                            category = "Brickmould";
                            list_type[j].Bmd_Numbers.Add(data[i][6]);

                        }
                        else if (Settings.Casement_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].Cs_F += 1;
                            category = "Casement_Frame";
                            list_type[j].Cs_F_Numbers.Add(data[i][6]);
                        }
                        else if (Settings.Casement_Sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].Cs_S += 1;
                            category = "Casement_Sash";
                            list_type[j].Cs_S_Numbers.Add(data[i][6]);
                        }
                        else if (Settings.Slider_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].Sl_F += 1;

                            category = "Slider_Frame";
                            list_type[j].Sl_F_Numbers.Add(data[i][6]);
                        }
                        else if (Settings.Slider_sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].Sl_S += 1;
                            category = "Slider_sash";
                            list_type[j].Sl_S_Numbers.Add(data[i][6]);
                        }
                        else if (Settings.Small_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].S_F += 1;
                            category = "Small Fix";
                            list_type[j].Sm_F_Numbers.Add(data[i][6]);
                        }
                        else if (Settings.Large_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            list[j].L_F += 1;
                            category = "Large Fix";
                            list_type[j].L_F_Numbers.Add(data[i][6]);
                        }


                        exist = true;
                        break;
                    }



                }
                ord_numbs.Add(data[i][6]);
                if (!exist)
                {


                    if (Settings.Brickmould.Any(type => type[2] == data[i][8]))
                    {
                        bmd = 1;
                        category = "Brickmould";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), numb));
                        list.Add(new Data_order("", data[i][10], 0, 0, 0, 0, 0, bmd, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }
                    else if (Settings.Casement_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cs_f = 1;
                        category = "Casement_Frame";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], numb, new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>()));
                        list.Add(new Data_order("", data[i][10], cs_f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }
                    else if (Settings.Casement_Sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cs_s = 1;
                        category = "Casement_Sash";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), numb, new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>()));
                        list.Add(new Data_order("", data[i][10], 0, cs_s, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }

                    else if (Settings.Slider_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        sl_f = 1;

                        category = "Slider_Frame";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), new List<string>(), new List<string>(), new List<string>(), numb, new List<string>(), new List<string>()));
                        list.Add(new Data_order("", data[i][10], 0, 0, 0, sl_f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }
                    else if (Settings.Slider_sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        sl_s = 1;
                        category = "Slider_sash";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), numb, new List<string>()));
                        list.Add(new Data_order("", data[i][10], 0, 0, 0, 0, sl_s, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }
                    else if (Settings.Small_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        s_f = 1;
                        category = "Small_Fix";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), new List<string>(), new List<string>(), numb, new List<string>(), new List<string>(), new List<string>()));
                        list.Add(new Data_order("", data[i][10], 0, 0, s_f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }
                    else if (Settings.Large_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        l_f = 1;
                        category = "Large_Fix";
                        List<string> numb = new List<string> { data[i][6] };
                        list_type.Add(new List_order_type(data[i][10], new List<string>(), new List<string>(), new List<string>(), numb, new List<string>(), new List<string>(), new List<string>()));
                        list.Add(new Data_order("", data[i][10], 0, 0, 0, l_f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0));
                    }


                }



            }
            List<string[]> ListDone = DB.getFrameClearing(ord_numbs);
            int cs_f_total = 0, cs_s_total = 0, s_f_total = 0, sl_f_total = 0, sl_s_total = 0, bmd_total = 0, l_f_total = 0, total_complete = 0;
            for (int i = 0; i < list_type.Count; i++)
            {
                bool cs_f = false, cs_s = false, s_f = false, sl_f = false, sl_s = false, bmd = false, l_f = false;
                int done = 0, all = 0;
                string status = "";
                if (list_type[i].Cs_F_Numbers != null)
                {
                    cs_f_total += list_type[i].Cs_F_Numbers.Count;
                    for (int j = 0; j < list_type[i].Cs_F_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Cs_F_Numbers[j]))
                            list[i].Cs_F_done += 1;


                    }

                    //  list[i].Cs_F_done = DB.getFrameClearing(list_type[i].Cs_F_Numbers).Count;
                    all += list_type[i].Cs_F_Numbers.Count;
                    done += list[i].Cs_F_done;
                    if (list[i].Cs_F_done == list_type[i].Cs_F_Numbers.Count) cs_f = true;
                }

                list[i].Cs_F_info = list[i].Cs_F_done + "/" + list_type[i].Cs_F_Numbers.Count;

                if (list_type[i].Cs_S_Numbers != null)
                {
                    cs_s_total += list_type[i].Cs_S_Numbers.Count;
                    for (int j = 0; j < list_type[i].Cs_S_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Cs_S_Numbers[j])) list[i].Cs_S_done += 1;


                    }

                    // list[i].Cs_S_done = DB.getFrameClearing(list_type[i].Cs_S_Numbers).Count;
                    all += list_type[i].Cs_S_Numbers.Count;
                    done += list[i].Cs_S_done;
                    if (list[i].Cs_S_done == list_type[i].Cs_S_Numbers.Count) cs_s = true;

                }
                list[i].Cs_S_info = list[i].Cs_S_done + "/" + list_type[i].Cs_S_Numbers.Count;

                if (list_type[i].Sm_F_Numbers != null)
                {
                    s_f_total += list_type[i].Sm_F_Numbers.Count;
                    for (int j = 0; j < list_type[i].Sm_F_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Sm_F_Numbers[j])) list[i].Sm_F_done += 1;


                    }

                    all += list_type[i].Sm_F_Numbers.Count;
                    done += list[i].Sm_F_done;
                    if (list[i].Sm_F_done == list_type[i].Sm_F_Numbers.Count) s_f = true;
                }
                list[i].Sm_F_info = list[i].Sm_F_done + "/" + list_type[i].Sm_F_Numbers.Count;

                if (list_type[i].L_F_Numbers != null)
                {
                    l_f_total += list_type[i].L_F_Numbers.Count;
                    for (int j = 0; j < list_type[i].L_F_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].L_F_Numbers[j])) list[i].L_F_done += 1;


                    }

                    all += list_type[i].L_F_Numbers.Count;
                    done += list[i].L_F_done;
                    if (list[i].L_F_done == list_type[i].L_F_Numbers.Count) l_f = true;
                }
                list[i].L_F_info = list[i].L_F_done + "/" + list_type[i].L_F_Numbers.Count;

                if (list_type[i].Sl_F_Numbers != null)
                {
                    sl_f_total += list_type[i].Sl_F_Numbers.Count;
                    for (int j = 0; j < list_type[i].Sl_F_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Sl_F_Numbers[j]))
                            list[i].Sl_F_done += 1;


                    }
                    // list[i].Sl_F_done = DB.getFrameClearing(list_type[i].Sl_F_Numbers).Count;
                    all += list_type[i].Sl_F_Numbers.Count;
                    done += list[i].Sl_F_done;
                    if (list[i].Sl_F_done == list_type[i].Sl_F_Numbers.Count) sl_f = true;
                }
                list[i].Sl_F_info = list[i].Sl_F_done + "/" + list_type[i].Sl_F_Numbers.Count;

                if (list_type[i].Sl_S_Numbers != null)
                {
                    sl_s_total += list_type[i].Sl_S_Numbers.Count;
                    for (int j = 0; j < list_type[i].Sl_S_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Sl_S_Numbers[j])) list[i].Sl_S_done += 1;


                    }
                    //   list[i].Sl_S_done = DB.getFrameClearing(list_type[i].Sl_S_Numbers).Count;
                    all += list_type[i].Sl_S_Numbers.Count;
                    done += list[i].Sl_S_done;
                    if (list[i].Sl_S_done == list_type[i].Sl_S_Numbers.Count) sl_s = true;
                }
                list[i].Sl_S_info = list[i].Sl_S_done + "/" + list_type[i].Sl_S_Numbers.Count;

                if (list_type[i].Bmd_Numbers != null)
                {
                    bmd_total += list_type[i].Bmd_Numbers.Count;
                    for (int j = 0; j < list_type[i].Bmd_Numbers.Count; j++)
                    {
                        if (ListDone.Any(type => type[0] == list_type[i].Bmd_Numbers[j])) list[i].Bmd_done += 1;


                    }
                    //   list[i].Bmd_done = DB.getFrameClearing(list_type[i].Bmd_Numbers).Count;
                    all += list_type[i].Bmd_Numbers.Count;
                    done += list[i].Bmd_done;
                    if (list[i].Bmd_done == list_type[i].Bmd_Numbers.Count) bmd = true;
                }
                if (cs_f && cs_s && s_f && sl_f && sl_s && bmd && l_f) status = "COMPLETE";
                else if (done != 0) status = "IN PROGRESS";
                else status = "NOT READY";
                list[i].Status = status;
                list[i].Bmd_info = list[i].Bmd_done + "/" + list_type[i].Bmd_Numbers.Count;
                // double test;
                //  test =;
                list[i].Info = (double)done / (double)all * 100;
                //  list[i].Info = 70;
                total_complete += done;
            }
            List<string> NotFoundOrders = orderNumbers.Where(p => !data.Any(p2 => p2[10] == p)).Distinct().ToList();
            for (int i = 0; i < NotFoundOrders.Count; i++)
            {
                Data_order row = new Data_order("", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, 0);
                row.Order_numb = NotFoundOrders[i];
                row.Cs_F_info = "";
                row.Cs_S_info = "";
                row.Lg_F_info = "";
                row.Sl_F_info = "";
                row.Sl_S_info = "";
                row.Sm_F_info = "";
                row.Bmd_info = "";
                row.Status = "NOT CUT";
                list.Add(row);
            }


            totacasementlfrmLbl.Text = cs_f_total.ToString();
            TotalCasementSashblData.Text = cs_s_total.ToString();
            TotalSliderFrameblData.Text = sl_f_total.ToString();
            TotalSliderSashLblData.Text = sl_s_total.ToString();
            TotalBrickmouldLblData.Text = bmd_total.ToString();
            TotalLgFLblData.Text = l_f_total.ToString();
            TotalSmFLblData.Text = s_f_total.ToString();
            TotalCompletelblData.Text = total_complete.ToString();
            TotalFramelblData.Text = (cs_f_total + cs_s_total + sl_f_total + sl_s_total + bmd_total + s_f_total + l_f_total).ToString();
            ProductionReportData.DataSource = list;

        }
        private void FrameClearingReportForm_Load(object sender, EventArgs e)
        {

        }

        private void ProductionReportData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < ProductionReportData.RowCount; i++)
            {
                if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "COMPLETE") ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                else if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "IN PROGRESS") ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                else if (ProductionReportData.Rows[i].Cells[0].Value.ToString() == "NOT READY") ProductionReportData.Rows[i].Cells[0].Style.BackColor = Color.OrangeRed;

            }
        }


        private void FrameClearingReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }



        private void radioComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioComplete.Checked)
            {
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                {
                    if (ProductionReportData.Rows[j].Cells[0].Value.ToString() == "COMPLETE")
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
            else if (!radioComplete.Checked)
            {
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                {
                    if (ProductionReportData.Rows[j].Cells[0].Value.ToString() == "COMPLETE")
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
        }

        private void radioIncomplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIncomplete.Checked)
            {
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                {
                    if (ProductionReportData.Rows[j].Cells[0].Value.ToString() != "COMPLETE")
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
            else if (!radioIncomplete.Checked)
            {
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                {
                    if (ProductionReportData.Rows[j].Cells[0].Value.ToString() != "COMPLETE")
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                        currencyManager1.SuspendBinding();
                        ProductionReportData.Rows[j].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                for (int j = 0; j < ProductionReportData.RowCount; j++)
                {

                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                    currencyManager1.SuspendBinding();
                    ProductionReportData.Rows[j].Visible = true;
                    currencyManager1.ResumeBinding();

                }
            }

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalSliderFrameblData_Click(object sender, EventArgs e)
        {

        }
        public Byte[] CreateProgressBar(double p)
        {
            int progressVal = Convert.ToInt32(p);

            float percentage = (progressVal / 100.0f);
            ImageConverter converter = new ImageConverter();

            Bitmap bmp = new Bitmap(100, 25);

            Graphics flagGraphics = Graphics.FromImage(bmp);


            flagGraphics.FillRectangle(new SolidBrush(System.Drawing.Color.LimeGreen), 0, 0, Convert.ToInt32(percentage * 100), 25);
            flagGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            flagGraphics.DrawString(progressVal.ToString() + "%", System.Drawing.SystemFonts.DefaultFont, new SolidBrush(Color.Black), 28, 7);




            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();

            OrderDataSet data_Order = new OrderDataSet();
            string path = "";

            int rowCount = 0;
            rowCount = ProductionReportData.Rows.Count;

            path = Path.Combine(Environment.CurrentDirectory, @"reports\FrameClearing_Report.rdlc");
            for (int i = 0; i < rowCount; i++)
            {

                data_Order.Tables[0].Rows.Add(ProductionReportData.Rows[i].Cells[0].Value, ProductionReportData.Rows[i].Cells[1].Value, ProductionReportData.Rows[i].Cells[2].Value, ProductionReportData.Rows[i].Cells[3].Value, ProductionReportData.Rows[i].Cells[4].Value, ProductionReportData.Rows[i].Cells[5].Value, ProductionReportData.Rows[i].Cells[6].Value, ProductionReportData.Rows[i].Cells[7].Value, ProductionReportData.Rows[i].Cells[8].Value, CreateProgressBar(Double.Parse(ProductionReportData.Rows[i].Cells[9].Value.ToString())));
                // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
                rds.Value = data_Order.Tables[0];
            }
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));




            LocalReport report = new LocalReport();
            report.ReportPath = path;


            report.SetParameters(reportParameters);
            report.DataSources.Add(rds);




            // oceanviewPatioDoorsDataSet.Tables[0].Rows.Add("test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");





            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";




            report.DataSources.Add(rds);
            Export(report);
            Print_page();
        }
        private Stream CreateStream(string name,
   string fileNameExtension, Encoding encoding,
   string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {

            string deviceInfo =
        @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>11.69in</PageWidth>
                <PageHeight>8.27in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);


            foreach (Stream stream in m_streams)
                stream.Position = 0;


        }
        private void ExportNotComplete(LocalReport report)
        {

            string deviceInfo =
        @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);


            foreach (Stream stream in m_streams)
                stream.Position = 0;


        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print_page()
        {
            m_currentPageIndex = 0;
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

                PrintDialog printDlg = new PrintDialog();

                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }

        private void buttonPrintNotComplete_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();

            OrderNotCompleteDataSet data_Order = new OrderNotCompleteDataSet();
            string path = "";

            int rowCount = 0;
            rowCount = ProductionReportData.Rows.Count;

            path = Path.Combine(Environment.CurrentDirectory, @"reports\FrameClearingNotComplete_Report.rdlc");
            for (int i = 0; i < rowCount; i++)
            {
                if (ProductionReportData.Rows[i].Cells[0].Value.ToString() != "COMPLETE")
                {
                    List<string[]> data = DB.fetchRows("framescutting", "J", ProductionReportData.Rows[i].Cells[1].Value.ToString(), false);
                    List<string[]> data_done = new List<string[]>();
                    List<string> frame_ids = new List<string>();


                    foreach (var element in data)

                        frame_ids.Add(element[5]);



                    data_done = DB.importFrameClearingByIds(frame_ids);


                    foreach (var element in data)
                    {

                        string name = "", date = "", machine_id = "", time = "", status = "NOT READY";
                        var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        if (match == null)

                            data_Order.Tables[0].Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], date, time, name, machine_id, status);

                    }
                }
            }
            rds.Value = data_Order.Tables[0];
            LocalReport report = new LocalReport();
            report.ReportPath = path;
            reportParameters.Add(new ReportParameter("FootParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));




            report.SetParameters(reportParameters);

            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";




            report.DataSources.Add(rds);
            ExportNotComplete(report);
            Print_page();
        }

        private void ProductionReportData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ProductionReportData.Columns["Detail"].Index && e.RowIndex >= 0)
            {

                string order_number = ProductionReportData.Rows[e.RowIndex].Cells[1].Value.ToString();
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
        void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Show();
        }
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxSearch.Text;
                if (data != "")
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ProductionReportData.DataSource];
                    currencyManager1.SuspendBinding();
                    for (int i = 0; i < ProductionReportData.Rows.Count; i++)

                        if (ProductionReportData.Rows[i].Cells[1].Value.ToString() != data) ProductionReportData.Rows[i].Visible = false;
                    currencyManager1.ResumeBinding();
                }
                else for (int i = 0; i < ProductionReportData.Rows.Count; i++)

                        ProductionReportData.Rows[i].Visible = true;
            }
        }
    }
}

