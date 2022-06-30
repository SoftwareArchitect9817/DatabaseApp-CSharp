using Senaka.component;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Senaka
{
    public partial class IGShippingForm : Form
    {
        MessageBoxDialog error_message;
        Timer timer, error_timer;

        public IGShippingForm()
        {
            InitializeComponent();
            MinimumSize = new Size(800, 600);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += showingCurrentTime;
            timer.Start();

            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            iShippingDate.Text = date;
            iShippingTime.Text = today.ToString("HH:mm:ss");

            List<string[]> data = DB.fetchRows("ig_shipping", "date", date, new string[] { "time", "DESC" });
            string[] glass;
            foreach (string[] row in data)
            {
                glass = DB.fetchRow("glassreport", "sealed_unit_id", row[(int)IG_SHIPPING.SEALED_UNIT_ID], false);
                iShippingScanedData.Rows.Add(
                    row[(int)IG_SHIPPING.SEALED_UNIT_ID], Convert.ToDateTime(row[(int)IG_SHIPPING.DATE]).ToString("yyyy-MM-dd"),
                    row[(int)IG_SHIPPING.TIME], row[(int)IG_SHIPPING.NAME], glass[(int)GLASS.RACK_ID]);
            }

            error_timer = new Timer();
            error_timer.Interval = Settings.IG_Shipping_Error_Time * 1000;
            error_timer.Tick += Error_timer_Tick;

            error_message = new MessageBoxDialog();
        }

        private void IGShippingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            error_timer.Stop();

            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void showingCurrentTime(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            iShippingDate.Text = today.ToString("yyyy-MM-dd");
            iShippingTime.Text = today.ToString("HH:mm:ss");
        }

        private void Error_timer_Tick(object sender, EventArgs e)
        {
            error_timer.Stop();
            FormCollection forms = Application.OpenForms;
            foreach (Form f in forms)
            {
                if (f.Name == "ErrorMessageBox")
                {
                    error_message.Close();
                }
            }
        }

        private void iShippingTxtDataInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = iShippingTxtDataInput.Text;
                if (data != "")
                {
                    scanInput(data);
                }
            }
        }

        private void scanInput(string data)
        {
            bool exist_prefix = false;
            string[] prefix_data = null, optimize_data;

            string prefix = data.Substring(0, 1);
            string sealed_unit_id = data.Substring(1);
            string error_text;

            foreach (string[] r in Settings.IG_Shipping_Prefix_Table)
            {
                if (r[(int)PREFIX.PREFIX] == prefix)
                {
                    exist_prefix = true;
                    prefix_data = r;
                    break;
                }
            }

            if (exist_prefix)
            {
                optimize_data = DB.fetchRow("glassreport", "sealed_unit_id", sealed_unit_id, false);
                if (optimize_data == null)
                {
                    error_text = "Invalid SEALED UNIT ID!";
                }
                else
                {
                    int qty = Convert.ToInt32(optimize_data[(int)GLASS.QTY]);
                    int scanned_qty = DB.fetchRows("ig_shipping", "sealed_unit_id", sealed_unit_id).Count;
                    if (scanned_qty < qty)
                    {

                        DateTime now = DateTime.Now;
                        string date = now.ToString("yyyy-MM-dd"), time = now.ToString("HH:mm:ss");
                        string name = prefix_data[(int)PREFIX.NAME], rack_id = optimize_data[(int)GLASS.RACK_ID];
                        if (DB.saveIGShippingData(sealed_unit_id, date, time, name) == 0)
                        {
                            if (scanned_qty + 1 == qty)
                            {
                                DB.shippingCompleteGlassBySealedUnit(sealed_unit_id);
                                if (rack_id.Contains("SU-"))
                                {
                                    int category = (int)Rack.TYPE.SU + Rack.getThick(optimize_data);
                                    DB.addSUShipping(rack_id, category, qty);
                                }


                            }
                            string order_numb = optimize_data[19];
                            bool exist = false;
                            List<string[]> grid_view_data = new List<string[]>();
                            for (int i = 0; i < OrderScanedData.Rows.Count; i++)
                            {
                                if (OrderScanedData.Rows[i].Cells[0].Value.ToString() == order_numb && OrderScanedData.Rows[i].Cells[1].Value.ToString() == name)
                                {
                                    exist = true;
                                    OrderScanedData.Rows[i].Cells[2].Value = (Int32.Parse(OrderScanedData.Rows[i].Cells[2].Value.ToString()) + 1).ToString();
                                    break;
                                }
                            }
                            if (!exist)
                            {
                                List<string[]> glass_report = DB.fetchRows("glassreport", "order", order_numb, false);
                                List<string> su_ids = new List<string>();
                                foreach (var entry in glass_report)
                                {
                                    su_ids.Add(entry[2]);
                                }
                                List<string[]> ig_shipping_table = DB.importigshippingByIds(su_ids);
                                var result = ig_shipping_table.AsEnumerable()
              .GroupBy(r => r[4])
              .Select(r => new
              {
                  Str = r.Key,
                  Count = r.Count()
              });
                                foreach (var data_result in result)
                                {
                                    OrderScanedData.Rows.Add(order_numb, data_result.Str, data_result.Count);
                                }
                            }
                                iShippingScanedData.Rows.Insert(0, sealed_unit_id, date, time, name, rack_id);
                         

                            iShippingTxtDataInput.Text = "";
                            return;
                        }
                        else
                        {
                            error_text = "Cannot Save data. Please try again!";
                        }
                    }
                    else
                    {
                        error_text = "Already scanned all quantities!";
                    }
                }
            }
            else
            {
                error_text = "Invalid prefix letter!";
            }
            error_timer.Start();
            ColourlblMessage.Text=error_text;
        }

        private void iShippingTxtDataInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderScanedData_SelectionChanged(object sender, EventArgs e)
        {
            this.OrderScanedData.ClearSelection();
        }

        private void iShippingTxtDataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string data = iShippingTxtDataInput.Text;
            UInt64 number;
            if (
                e.KeyChar != (int)(Keys.Back) &&
                (
                    (data == "" && !char.IsLetter(e.KeyChar)) ||
                    (
                        data.Length > 0 &&
                        (
                            (
                                iShippingTxtDataInput.SelectionStart == 0 &&
                                (
                                    !UInt64.TryParse(data, out number) ||
                                    (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
                                )
                            ) ||
                            (iShippingTxtDataInput.SelectionStart > 0 && !char.IsDigit(e.KeyChar))
                        )
                    )
                )
            )
            {
                e.Handled = true;
                return;
            }
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
