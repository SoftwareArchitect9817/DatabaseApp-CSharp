using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class BookingSubMenuForm : Form
    {
        List<string[]> ordersummary;
        List<string> columns;
        AutoCompleteStringCollection companies = new AutoCompleteStringCollection();
        DateTime? _date;
        private BookingForm bookingForm = null;
        string _location;
        BookingDataSet bDataSet;
        DataView dv;

        public BookingSubMenuForm(DateTime? date, BookingForm form, string location)
        {
            InitializeComponent();

            _date = date;
            labelDate.Text = _date.Value.ToString("dd- MMMM yyyy");
            bookingForm = form;
            _location = location;
            init();
            textBoxSearchDealer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSearchDealer.AutoCompleteCustomSource = companies;
        }

        public void init()
        {
            DataTable schema = DB.GetTableSchema("ordersummary");
            columns = new List<string>();
            foreach (DataRow col in schema.Rows)
            {
                columns.Add(col.Field<String>("ColumnName"));
            }

            bDataSet = new BookingDataSet();
            bDataSet.DataTableSubMenu.Columns["Total_Windows"].DataType=typeof(int);
            bDataSet.DataTableSubMenu.Columns["DueDate"].DataType = typeof(DateTime);
            ordersummary = DB.getNotBookedOrderSummary(Settings.BookDateFilterType, Settings.BookDateFilter);
            foreach (var element in ordersummary)
            {
                int total = 0;
                DataRow myDataRow;
                myDataRow = bDataSet.DataTableSubMenu.NewRow();
                myDataRow["Order"] = element[columns.IndexOf("ORDER#")];
                myDataRow["Dealer"] = element[columns.IndexOf("COMPANY")];
                myDataRow["CustomerPO"] = element[columns.IndexOf("CUST PO")];
                companies.Add(myDataRow["Dealer"].ToString());
                myDataRow["OrderDate"] = element[columns.IndexOf("ORDER DATE")];
                DateTime DueDate = new DateTime();
                if (DateTime.TryParseExact(element[columns.IndexOf("DUE DATE")], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DueDate) == true)
                {
                    myDataRow["DueDate"] = DueDate;
                }
                foreach (var name_type in Settings.Window_Casement)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["CS"] = string.IsNullOrEmpty(myDataRow["CS"].ToString()) ? 0 : int.Parse(myDataRow["CS"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_Fix)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                        myDataRow["CS"] = string.IsNullOrEmpty(myDataRow["CS"].ToString()) ? 0 : int.Parse(myDataRow["CS"].ToString()) + Int32.Parse(c);
                }
                foreach (var name_type in Settings.Window_Dummy)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["CS"] = string.IsNullOrEmpty(myDataRow["CS"].ToString()) ? 0 : int.Parse(myDataRow["CS"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_Slider)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["SL"] = string.IsNullOrEmpty(myDataRow["SL"].ToString()) ? 0 : int.Parse(myDataRow["SL"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_Shape)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["SH"] = string.IsNullOrEmpty(myDataRow["SH"].ToString()) ? 0 : int.Parse(myDataRow["SH"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_Sdwind)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["SH"] = string.IsNullOrEmpty(myDataRow["SH"].ToString()) ? 0 : int.Parse(myDataRow["SH"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_SU)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["SU"] = string.IsNullOrEmpty(myDataRow["SU"].ToString()) ? 0 : int.Parse(myDataRow["SU"].ToString()) + Int32.Parse(c);
                    }
                }
                foreach (var name_type in Settings.Window_SUSHP)
                {
                    string c = element[columns.IndexOf(name_type[2])];
                    if (c != "")
                    {
                        myDataRow["SU"] = string.IsNullOrEmpty(myDataRow["SU"].ToString()) ? 0 : int.Parse(myDataRow["SU"].ToString()) + Int32.Parse(c);
                    }
                }
                if (myDataRow["CS"].ToString() == "") myDataRow["CS"] = 0;
                else total += Int32.Parse(myDataRow["CS"].ToString());
                if (myDataRow["SL"].ToString() == "") myDataRow["SL"] = 0;
                else total += Int32.Parse(myDataRow["SL"].ToString());
                if (myDataRow["SH"].ToString() == "") myDataRow["SH"] = 0;
                else total += Int32.Parse(myDataRow["SH"].ToString());
                if (myDataRow["SU"].ToString() == "") myDataRow["SU"] = 0;
                else total += Int32.Parse(myDataRow["SU"].ToString());
                myDataRow["Total_Windows"] = total;
                myDataRow["BM"] = element[columns.IndexOf("BRICKMOULD")];
                myDataRow["ET"] = element[columns.IndexOf("EXT")];
                myDataRow["ColourIN"] = element[columns.IndexOf("COLOUR IN")];
                myDataRow["ColourOUT"] = element[columns.IndexOf("COLOUR OUT")];
                myDataRow["Id"] = element[columns.IndexOf("id")];
                myDataRow["TotalC"] += (Int32.Parse(myDataRow["CS"].ToString()) + Int32.Parse(myDataRow["SH"].ToString()) + Int32.Parse(myDataRow["SU"].ToString())).ToString();
                myDataRow["TotalS"] += myDataRow["SL"].ToString();
                bDataSet.Tables[0].Rows.Add(myDataRow);
            }
            dv = new DataView(bDataSet.Tables[0]);
            dataGridViewOrder.DataSource = dv;
            dataGridViewOrder.Columns["totalWindowsDataGridViewTextBoxColumn"].ValueType = typeof(Int32);
            /*dataGridViewOrder.DataSource = bDataSet; // dataset
            dataGridViewOrder.DataMember = "DataTable1";*/
        }

        private void radioButtonWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWhite.Checked == true)
            /* for (int i = 0; i < ordersummary.Count; i++)
            {
                 if (!((ordersummary[i][columns.IndexOf("COLOUR IN")] == "WHT" && ordersummary[i][columns.IndexOf("COLOUR OUT")] == "WHT")))
                 {
                     dataGridViewOrder.CurrentCell = null;
                     dataGridViewOrder.Rows[i].Visible = false;
                 }
                 else
                 {
                     dataGridViewOrder.CurrentCell = null;
                     dataGridViewOrder.Rows[i].Visible = true;
                 }
            }*/
            {
                dv = new DataView(bDataSet.Tables[0]);
                dv.RowFilter = "ColourIN ='WHT' And ColourOUT = 'WHT'";
                dataGridViewOrder.DataSource = dv;
            }
        }

        private void radioButtonColour_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonColour.Checked == true)
            {
                dv = new DataView(bDataSet.Tables[0]);
                dv.RowFilter = "Not(ColourIN ='WHT' And ColourOUT = 'WHT')";
                dataGridViewOrder.DataSource = dv;
            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                dv = new DataView(bDataSet.Tables[0]);
                dv.RowFilter = String.Empty;
                dataGridViewOrder.DataSource = dv;
            }
        }

        private void radioButtonSortDueDateClose_CheckedChanged(object sender, EventArgs e)
        {
          dataGridViewOrder.Sort(dataGridViewOrder.Columns["totalWindowsDataGridViewTextBoxColumn"], ListSortDirection.Descending);
        }

        private void radioButtonSortDueDateFar_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewOrder.Sort(dataGridViewOrder.Columns["totalWindowsDataGridViewTextBoxColumn"], ListSortDirection.Ascending);
        }

        private void BookingSubMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*Hide();
            BookingForm bookingForm = new BookingForm(order_date);
            bookingForm.Show();*/
        }

        private void textBoxSearchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxSearchOrder.Text;
                if (data != "")
                {
                    scanOrder(data);
                }
                else
                {
                    dv.RowFilter = String.Empty;
                    dataGridViewOrder.DataSource = dv;
                }
            }
        }

        private void scanOrder(string data)
        {
            if (dv.RowFilter != String.Empty)
            {
                dv.RowFilter = dv.RowFilter + " AND (Order='" + data + "' OR CustomerPO='" + data + "')";
            }
            else
            {
                dv.RowFilter = "(Order='" + data + "' OR CustomerPO='" + data + "')";
            }
            dataGridViewOrder.DataSource = dv;
        }

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrder.Columns["BookColumn"].Index)
            {
                DataGridViewCell cell = dataGridViewOrder.Rows[e.RowIndex].Cells[dataGridViewOrder.Columns["iDDataGridViewTextBoxColumn"].Index];
                if (DB.BookOrderSummary(cell.Value.ToString(), _date.Value.ToString("yyyyMMdd"), _location) == 0)
                {
                    string order = cell.Value.ToString();
                    bookingForm.UpdateBook(ordersummary.First(x => x[columns.IndexOf("ORDER#")] == order));
                    dv.Delete(e.RowIndex);
                }
            }
        }

        private void textBoxSearchDealer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxSearchDealer.Text;
                if (data != "")
                {
                    scanDealer(data);
                }
                else
                {
                    dv.RowFilter = String.Empty;
                    dataGridViewOrder.DataSource = dv;
                }
            }
        }

        private void scanDealer(string data)
        {
            if (dv.RowFilter != String.Empty)
            {
                dv.RowFilter = dv.RowFilter + " AND (Dealer='" + data + "')";
            }
            else
            {
                dv.RowFilter = "(Dealer='" + data + "')";
            }
            dataGridViewOrder.DataSource = dv;
        }

        private void radioButtonSortDueDateClose_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridViewOrder.Sort(dataGridViewOrder.Columns["dueDateDataGridViewTextBoxColumn"], ListSortDirection.Descending);
        }

        private void radioButtonSortDueDateFar_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridViewOrder.Sort(dataGridViewOrder.Columns["dueDateDataGridViewTextBoxColumn"], ListSortDirection.Ascending);
        }

        private void radioButtonCasement_CheckedChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "(TotalC <> 0) AND (TotalS = 0) ";
            dataGridViewOrder.DataSource = dv;
        }

        private void radioButtonSlider_CheckedChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "(TotalS <> 0) AND (TotalC = 0) ";
            dataGridViewOrder.DataSource = dv;
        }
    }
}
