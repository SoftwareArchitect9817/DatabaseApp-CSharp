using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Senaka
{
    public partial class TaskBoardForm : Form
    {
        System.Timers.Timer TimerRefresh = new System.Timers.Timer();
        public TaskBoardForm()
        {
            InitializeComponent();

            List<Data_TaskBoard> data_TaskBoards = DB.getTaskBoard();
            foreach (var data in data_TaskBoards)
                dataGridViewTaskBoard.Rows.Add(data.Id,false, data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P);
          
        
            TimerRefresh.Elapsed += RefreshTaskBar;
          
            TimerRefresh.Interval = 10000;
           
            TimerRefresh.Enabled = true;

            TimerRefresh.Start();

        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
              
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add(column.DataPropertyName);
                
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
       
        private void RefreshTaskBar(object source, ElapsedEventArgs e) {
           
            /*    DataTable data = GetDataTableFromDGV(dataGridViewTaskBoard);
                BeginInvoke(new MethodInvoker(delegate {
                    dataGridViewTaskBoard.DataSource = data;
                }));
                data.PrimaryKey = new[] { data.Columns[1] };
                List<Data_TaskBoard> data_TaskBoards = DB.getTaskBoard();
             //   DataTable test = ToDataTableClass.ToDataTable(data_TaskBoards);
                foreach (var dr in ToDataTableClass.ToDataTable(data_TaskBoards).AsEnumerable())
                
                    data.LoadDataRow(dr.ItemArray, LoadOption.OverwriteChanges);
              */
             List<int> ids = new List<int>();
              for (int i = 0; i < dataGridViewTaskBoard.Rows.Count; i++)
              {
                  if (dataGridViewTaskBoard.Rows[i].Cells[1].Value.ToString() == "True")
                  {
                      ids.Add(Int32.Parse(dataGridViewTaskBoard.Rows[i].Cells[0].Value.ToString()));

                  }
              }
            

              List<Data_TaskBoard> data_TaskBoards = DB.getTaskBoard();
            BeginInvoke(new MethodInvoker(delegate {
                dataGridViewTaskBoard.Rows.Clear();
            }));
            foreach (var data in data_TaskBoards)
                  BeginInvoke(new MethodInvoker(delegate {
                      if(ids.Contains(data.Id))
                      dataGridViewTaskBoard.Rows.Add(data.Id, true, data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P);
          else dataGridViewTaskBoard.Rows.Add(data.Id, false, data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P);

          }));
              BeginInvoke(new MethodInvoker(delegate {
                  dataGridViewTaskBoard.Refresh();
              }));
            
        }

       

        private void TaskBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            TimerRefresh.Enabled = false;
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            TimerRefresh.Stop();
            TaskBoardAddForm taskBoardAdd = new TaskBoardAddForm();
           Data_TaskBoard data = taskBoardAdd.InputBox();
            //  Settings.TaskBoardData.Add(new Data_TaskBoard(data.Id,data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P));
           
            if(data!=null)
                dataGridViewTaskBoard.Rows.Add(data.Id, false, data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P);
            TimerRefresh.Start();
            // taskBoardAdd.Show();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            TimerRefresh.Stop();
            for (int i = dataGridViewTaskBoard.Rows.Count-1; i >=0; i--)
            {
                if (dataGridViewTaskBoard.Rows[i].Cells[1].Value.ToString() == "True")
                {
                    DB.DeleteTaskBoard(Int32.Parse(dataGridViewTaskBoard.Rows[i].Cells[0].Value.ToString()));
                    dataGridViewTaskBoard.Rows.RemoveAt(i);
                  
                }
            }
            TimerRefresh.Start();
        }

        private void dataGridViewTaskBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTaskBoard.Columns["Edit"].Index)
            {
                TimerRefresh.Stop();
                int id = Int32.Parse(dataGridViewTaskBoard.Rows[e.RowIndex].Cells[dataGridViewTaskBoard.Columns["Id"].Index].Value.ToString());
                string ord_numb = dataGridViewTaskBoard.Rows[e.RowIndex].Cells[dataGridViewTaskBoard.Columns["OrderNumbColumn"].Index].Value.ToString();
                string date_time= dataGridViewTaskBoard.Rows[e.RowIndex].Cells[dataGridViewTaskBoard.Columns["ColumnDateTime"].Index].Value.ToString();
                string description = dataGridViewTaskBoard.Rows[e.RowIndex].Cells[dataGridViewTaskBoard.Columns["DescriptionColumn"].Index].Value.ToString();
                TaskBoardAddForm taskBoardAdd = new TaskBoardAddForm();

                Data_TaskBoard data = taskBoardAdd.InputBox(id, ord_numb, date_time,description);
                //  Settings.TaskBoardData.Add(new Data_TaskBoard(data.Id,data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P));

                if (data != null)
                    for (int i = 0; i < dataGridViewTaskBoard.Rows.Count; i++)
                    {
                        if (dataGridViewTaskBoard.Rows[i].Cells[0].Value.ToString() == data.Id.ToString())
                        {
                            dataGridViewTaskBoard.Rows.RemoveAt(i);
                            dataGridViewTaskBoard.Rows.Add(data.Id, false, data.DateTime, data.Ord_numb, data.Description, data.Frame, data.Color, data.Glass, data.Windows_assembly, 3, 3, data.P);

                        }
                    }
                dataGridViewTaskBoard.Refresh();
                TimerRefresh.Start();
            }
        }
    }
}
