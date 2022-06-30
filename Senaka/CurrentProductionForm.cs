using Senaka.component;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Senaka
{
    public partial class CurrentProductionForm : Form
    {
        IGInquireForm inquireForm;
        Timer blink_timer;
        List<string[]> original_data;
        List<string[]> today_data;

        public CurrentProductionForm(List<string[]> data, IGInquireForm inquireForm = null)
        {
            InitializeComponent();
            MinimumSize = new Size(1024, 768);

            blink_timer = new Timer();
            blink_timer.Interval = 500;
            blink_timer.Tick += Blink_Timer_Tick;

            this.inquireForm = inquireForm;

            initForm(data);
        }

        private void Blink_Timer_Tick(object sender, EventArgs e)
        {
            if (Settings.IG_Sorting_Last_Scanned_Order != "")
            {
                int r, c = -1;
                for (r = 0; r < CurProductDgOrderNumber.Rows.Count; r++)
                {
                    if ((string)CurProductDgOrderNumber.Rows[r].Cells[1].Value == Settings.IG_Sorting_Last_Scanned_Order)
                    {
                        c = 0; break;
                    }
                    else if ((string)CurProductDgOrderNumber.Rows[r].Cells[8].Value == Settings.IG_Sorting_Last_Scanned_Order)
                    {
                        c = 7; break;
                    }
                    else if ((string)CurProductDgOrderNumber.Rows[r].Cells[15].Value == Settings.IG_Sorting_Last_Scanned_Order)
                    {
                        c = 14; break;
                    }
                }
                if (c > -1)
                {
                    string dot_value = CurProductDgOrderNumber.Rows[r].Cells[c].Value.ToString();
                    if (dot_value == "1") dot_value = "0";
                    else dot_value = "1";
                    CurProductDgOrderNumber.Rows[r].Cells[c].Value = int.Parse(dot_value);
                }
            }
        }

        private void CurrentProductionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            blink_timer.Stop();

            if (inquireForm != null)
            {
                inquireForm.Show();
            }
            else
            {
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }

        private void initForm(List<string[]> data)
        {
            initialControl();

            original_data = data;
            today_data = data;

            foreach (KeyValuePair<string, int> row in Settings.IG_Sorting_Scanned)
            {
                CurProductHistoryData.Rows.Add(row.Key, row.Value);
            }

            if (inquireForm != null)
            {
                CurProductDgOrderNumber.Columns["CurProductOrderDot"].Visible = false;
            }
            else
            {
                original_data = null;
                if (Settings.Selected_Date != null)
                {
                    original_data = DB.importGlassByListDate(Settings.Selected_Date);
                }
            }

            List<string> orders = new List<string>();
            List<string> ig = new List<string>();
            foreach (string[] row in original_data)
            {
                if (!ig.Contains(row[(int)GLASS.SEALED_UNIT_ID])) ig.Add(row[(int)GLASS.SEALED_UNIT_ID]);
                if (!orders.Contains(row[(int)GLASS.ORDER])) orders.Add(row[(int)GLASS.ORDER]);
            }

            string start_date = Settings.Selected_Date[0].ToString("yyyy/MM/dd");
            string end_date = Settings.Selected_Date[1].ToString("yyyy/MM/dd");
            if (start_date != end_date) CurProductLblListDateValue.Text = start_date + " - " + end_date;
            else CurProductLblListDateValue.Text = start_date;

            CurProductLblTotalIGValue.Text = ig.Count.ToString();
            CurProductLblTotalOrdersValue.Text = orders.Count.ToString();

            showByOrder(original_data);
            showByGlassType(original_data);
        }

        private void initialControl()
        {
            CurProductDgOrderNumber.Visible = true;
            CurProductDgGlassType.Visible = false;
        }

        private List<string[]> showSelectedDate(List<string[]> today_data)
        {
            List<string[]> data = DB.importGlassByListDate(Settings.Selected_Date);
            int i;
            foreach (string[] row in today_data)
            {
                for (i = 0; i < data.Count; i++)
                {
                    if (data[i][(int)GLASS.SEALED_UNIT_ID] == row[(int)GLASS.SEALED_UNIT_ID]) break;
                }
                if (i == data.Count) data.Add(row);
            }
            return data;
        }

        private void showByOrder(List<string[]> data)
        {
            int i, complete, total;
            string status;
            List<string[]> orders = new List<string[]>();
            foreach (string[] row in data)
            {
                for (i = 0; i < orders.Count; i++)
                {
                    if (row[(int)GLASS.ORDER] == orders[i][0]) break;
                }
                if (i == orders.Count) orders.Add(new string[] { row[(int)GLASS.ORDER], "0", "0" });
                total = int.Parse(orders[i][2]) + 1;
                orders[i][2] = total.ToString();
                if (row[(int)GLASS.COMPLETE] == "1")
                {
                    complete = int.Parse(orders[i][1]) + 1;
                    orders[i][1] = complete.ToString();
                }
            }

            CurProductDgOrderNumber.Rows.Clear();
            int r;
            for (i = 0; i < orders.Count; i += 3)
            {
                r = i / 3;
                complete = int.Parse(orders[i][1]);
                total = int.Parse(orders[i][2]);
                if (complete == total) status = "Complete";
                else if (complete == 0) status = "Not Start";
                else status = "In Progress";
                CurProductDgOrderNumber.Rows.Add(
                    0, orders[i][0], (float)complete / total * 100, orders[i][1] + "/" + orders[i][2], status, "INFO", "",
                    0, "", -1, "", "", "", "",
                    0, "", -1, "", "", "");
                CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderStatus"].Style.BackColor
                    = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                if (i + 1 < orders.Count)
                {
                    complete = int.Parse(orders[i + 1][1]);
                    total = int.Parse(orders[i + 1][2]);
                    if (complete == total) status = "Complete";
                    else if (complete == 0) status = "Not Start";
                    else status = "In Progress";
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderNumber1"].Value = orders[i + 1][0];
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderProgress1"].Value = (float)complete / total * 100;
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderProgressNumber1"].Value = orders[i + 1][1] + "/" + orders[i + 1][2];
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderStatus1"].Value = status;
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderStatus1"].Style.BackColor
                        = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderInfo1"].Value = "INFO";
                }
                if (i + 2 < orders.Count)
                {
                    complete = int.Parse(orders[i + 2][1]);
                    total = int.Parse(orders[i + 2][2]);
                    if (complete == total) status = "Complete";
                    else if (complete == 0) status = "Not Start";
                    else status = "In Progress";
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderNumber2"].Value = orders[i + 2][0];
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderProgress2"].Value = (float)complete / total * 100;
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderProgressNumber2"].Value = orders[i + 2][1] + "/" + orders[i + 2][2];
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderStatus2"].Value = status;
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderStatus2"].Style.BackColor
                        = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                    CurProductDgOrderNumber.Rows[r].Cells["CurProductOrderInfo2"].Value = "INFO";
                }
                if (i + 1 == orders.Count || i + 2 == orders.Count) break;
            }
            blink_timer.Start();
        }

        private void showByGlassType(List<string[]> data)
        {
            int i, complete, total;
            string status;
            List<string[]> glasses = new List<string[]>();
            foreach (string[] row in data)
            {
                for (i = 0; i < glasses.Count; i++)
                {
                    if (row[(int)GLASS.GLASS_TYPE] == glasses[i][0]) break;
                }
                if (i == glasses.Count) glasses.Add(new string[] { row[(int)GLASS.GLASS_TYPE], "0", "0" });
                total = int.Parse(glasses[i][2]) + 1;
                glasses[i][2] = total.ToString();
                if (row[(int)GLASS.COMPLETE] == "1")
                {
                    complete = int.Parse(glasses[i][1]) + 1;
                    glasses[i][1] = complete.ToString();
                }
            }

            CurProductDgGlassType.Rows.Clear();
            int r;
            for (i = 0; i < glasses.Count; i += 3)
            {
                r = i / 3;
                complete = int.Parse(glasses[i][1]);
                total = int.Parse(glasses[i][2]);
                if (complete == total) status = "Complete";
                else if (complete == 0) status = "Not Start";
                else status = "In Progress";
                CurProductDgGlassType.Rows.Add(glasses[i][0], (float)complete / total * 100, glasses[i][1] + "/" + glasses[i][2], status, "",
                    "", -1, "", "", "",
                    "", -1, "", "");
                CurProductDgGlassType.Rows[r].Cells["CurProductGlassStatus"].Style.BackColor
                    = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                if (i + 1 < glasses.Count)
                {
                    complete = int.Parse(glasses[i + 1][1]);
                    total = int.Parse(glasses[i + 1][2]);
                    if (complete == total) status = "Complete";
                    else if (complete == 0) status = "Not Start";
                    else status = "In Progress";
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassType1"].Value = glasses[i + 1][0];
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassProgress1"].Value = (float)complete / total * 100;
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassProgressNumber1"].Value = glasses[i + 1][1] + "/" + glasses[i + 1][2];
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassStatus1"].Value = status;
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassStatus1"].Style.BackColor
                        = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                }
                if (i + 2 < glasses.Count)
                {
                    complete = int.Parse(glasses[i + 2][1]);
                    total = int.Parse(glasses[i + 2][2]);
                    if (complete == total) status = "Complete";
                    else if (complete == 0) status = "Not Start";
                    else status = "In Progress";
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassType2"].Value = glasses[i + 2][0];
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassProgress2"].Value = (float)complete / total * 100;
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassProgressNumber2"].Value = glasses[i + 2][1] + "/" + glasses[i + 2][2];
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassStatus2"].Value = status;
                    CurProductDgGlassType.Rows[r].Cells["CurProductGlassStatus2"].Style.BackColor
                        = status == "Complete" ? Color.Lime : (status == "Not Start" ? Color.OrangeRed : Color.Gold);
                }
                if (i + 1 == glasses.Count || i + 2 == glasses.Count) break;
            }
        }

        private void CurProductBtnOrderNumber_Click(object sender, EventArgs e)
        {
            initialControl();

            showByOrder(original_data);
        }

        private void CurProductBtnGlassType_Click(object sender, EventArgs e)
        {
            CurProductDgOrderNumber.Visible = false;
            CurProductDgGlassType.Visible = true;
        }

        private void CurProductBtnRushOrder_Click(object sender, EventArgs e)
        {
            initialControl();

            List<string[]> data = new List<string[]>();
            foreach (string[] row in today_data)
            {
                if (row[(int)GLASS.DESCRIPTION].Contains("RUSH")) data.Add(row);
            }

            showByOrder(data);
        }

        private void CurProductBtnSealedUnit_Click(object sender, EventArgs e)
        {
            initialControl();

            List<string[]> data = new List<string[]>();
            foreach (string[] row in original_data)
            {
                if (row[(int)GLASS.WINDOW_TYPE].Contains("Window_Type_SU")) data.Add(row);
            }

            showByOrder(data);
        }

        private void CurProductBtnGrills_Click(object sender, EventArgs e)
        {
            initialControl();

            List<string[]> data = new List<string[]>();
            foreach (string[] row in original_data)
            {
                if (row[(int)GLASS.GRILLS] != "" && !row[(int)GLASS.GRILLS].Contains("SDL")) data.Add(row);
            }

            showByOrder(data);
        }

        private void CurProductBtnShape_Click(object sender, EventArgs e)
        {
            initialControl();

            List<string[]> data = new List<string[]>();
            foreach (string[] row in original_data)
            {
                if (row[(int)GLASS.WINDOW_TYPE].Contains("Window_Type_SHAPE")) data.Add(row);
            }

            showByOrder(data);
        }

        private void CurProductBtnSearch_Click(object sender, EventArgs e)
        {
            string order = CurProductTxtSearch.Text;
            if (order != "")
            {
                initialControl();

                List<string[]> data = new List<string[]>();
                foreach (string[] row in original_data)
                {
                    if (row[(int)GLASS.ORDER] == order) data.Add(row);
                }

                showByOrder(data);
            }
        }

        private void CurProductDgOrderNumber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string[]> data = null;
            int r = e.RowIndex;
            if (e.ColumnIndex == 5)
            {
                data = DB.fetchRows("glassreport", "order", CurProductDgOrderNumber.Rows[r].Cells[1].Value.ToString(), false);
            }
            else if (e.ColumnIndex == 12)
            {
                data = DB.fetchRows("glassreport", "order", CurProductDgOrderNumber.Rows[r].Cells[8].Value.ToString(), false);
            }
            else if (e.ColumnIndex == 19)
            {
                data = DB.fetchRows("glassreport", "order", CurProductDgOrderNumber.Rows[r].Cells[15].Value.ToString(), false);
            }
            if (data != null)
            {
                Hide();
                if (inquireForm != null)
                {
                    IGInquireSubForm subform = new IGInquireSubForm(data, this);
                    subform.Show();
                }
                else
                {
                    CurrentProductionSubMenu subform = new CurrentProductionSubMenu(this, data);
                    subform.Show();
                }
            }
        }
    }
}
