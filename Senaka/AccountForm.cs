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

namespace Senaka
{
    public partial class AccountForm : Form
    {
        List<Data_user> data_user = new List<Data_user>();
       
        public AccountForm()
        {
            InitializeComponent();
            List<string[]> users = DB.importAccounts();
           
            foreach (var user in users)
            {
                data_user.Add(new Data_user(Int32.Parse(user[0]),user[1], user[2],user[3], user[4], user[5], user[6], user[7], user[8], user[9], user[10], user[11]));

            }
            UserTable.AutoGenerateColumns = false;
            UserTable.DataSource = data_user;
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            Hide();
           AddUserForm userForm = new AddUserForm("add");
            userForm.Show();
        }

        private void setFrameClearingPrefixTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == UserTable.Columns["Edit"].Index)
            {
                Hide();
                AddUserForm userForm = new AddUserForm("edit", data_user[e.RowIndex]);
                userForm.Show();
            }
            else if (e.ColumnIndex == UserTable.Columns["delete"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete this user?", "", MessageBoxButtons.YesNo))
                {
                    if(DB.DeleteAccount(data_user[e.RowIndex].Username)==0)  
                        MessageBox.Show("USER DELETED!", "SUCCESS");
                    else MessageBox.Show("ERROR WHEN DELETING!", "FAIL");
                    List<string[]> users = DB.importAccounts();
                    data_user = new List<Data_user>();
                    foreach (var user in users)
                    {
                        data_user.Add(new Data_user(Int32.Parse(user[0]), user[1], user[2], user[3], user[4], user[5], user[6], user[7], user[8], user[9], user[10], user[11]));




                    }
                    UserTable.DataSource = null;
                    UserTable.AutoGenerateColumns = false;
                    UserTable.DataSource = data_user;
                }
            }
        }
      
        

        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
