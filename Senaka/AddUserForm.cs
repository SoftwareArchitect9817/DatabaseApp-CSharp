using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class AddUserForm : Form
    {
        string action = "";
        Data_user user_data = null;
        List<string[]> ListControls = new List<string[]>();
        public AddUserForm(string act, Data_user user = null)
        {
           
            action = act;
            user_data = user;
            InitializeComponent();
            ListControls = DB.getControls();
            for (int i = 0; i < ListControls.Count; i++)
            {
                if(ListControls[i][3] != "")
                permisions_menu.Items.Add(ListControls[i][2] + " - " + ListControls[i][3]);
                else
                permisions_menu.Items.Add(ListControls[i][2]);
            }
            if (action == "edit" && user != null)
            {
                List<string[]> ControlsToUser = DB.getControlsToUser(user.Id.ToString());
                first_name.Text = user.First_Name;
                last_name.Text = user.Last_Name;
                username.Text = user.Username;
                password.Text = user.Password;
                email_1.Text = user.Email_1;
                email_2.Text = user.Email_2;
                phone.Text = user.Phone;
                FrameRecutDeletePermission.Checked = Convert.ToBoolean(user.FrameDelete);
                GlassRecutDeletePermission.Checked = Convert.ToBoolean(user.GlassDelete);
                for (int count = 0; count < permisions_search.Items.Count; count++)
                {
                    if (user.Permissions_Search.Contains(permisions_search.Items[count].ToString()))
                    {
                        permisions_search.SetItemChecked(count, true);
                    }
                }
                for (int i = 0; i < ControlsToUser.Count; i++)
                {
                    int IdElement = ListControls.FindIndex(x => x[0] == ControlsToUser[i][2]);
                    if(IdElement>0)
                    permisions_menu.SetItemChecked(IdElement, true);
                }


            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            bool validate = true;
            //validate password
            if (string.IsNullOrEmpty(password.Text.Trim()))
            {
                validate = false;
                errorProviderPassword.SetError(password, "Password is required.");
             

            }
            else
            {

                errorProviderPassword.SetError(password, string.Empty);
            }
            // validate username
            int count = 0;
            if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                validate = false;
                errorProviderUsername.SetError(username, "UserName is required.");
              

            }
            else
            {
                if (action == "edit")
                {
                    count = DB.importAccountByUserNameandId(username.Text, user_data.Id).Count();

                    if (count.Equals(1))
                    {
                        validate = false;
                        errorProviderUsername.SetError(username, "UserName exists.");
                      
                    }
                    else
                    {
                       
                        errorProviderUsername.SetError(username, string.Empty);
                    }
                }
                else if (action == "add")
                {
                    count = DB.importAccountByUserName(username.Text).Count();
                    if (count.Equals(1))
                    {
                        validate = false;
                        errorProviderUsername.SetError(username, "UserName exists.");
                       
                    }
                    else
                    {
                      
                        errorProviderUsername.SetError(username, string.Empty);
                    }
                }

            }

            if (validate)
            {
                if (action == "add")
                {
                    var texts = this.permisions_search.CheckedItems.Cast<object>()
                      .Select(x => this.permisions_search.GetItemText(x));

                    string permissions_search_text = (string.Join(" ", texts));
                   
                    var data = new List<string>();
                    data.Add(first_name.Text);
                    data.Add(last_name.Text);
                    data.Add(username.Text);
                    data.Add(password.Text);
                    data.Add(email_1.Text);
                    data.Add(email_2.Text);
                    data.Add(phone.Text);
                    data.Add(permissions_search_text);
                    data.Add(Convert.ToInt32(GlassRecutDeletePermission.Checked).ToString());
                    data.Add(Convert.ToInt32(FrameRecutDeletePermission.Checked).ToString());

                    if (DB.insertAccount(data.ToArray()) == 0)
                    {
                        int[] elementsID = this.permisions_menu.CheckedIndices.Cast<int>().ToArray();
                        List<int> controlsId = new List<int>();
                        foreach (int id in elementsID)
                            controlsId.Add(Int32.Parse(ListControls[id][0]));


                        string Userid = DB.getUserId(username.Text)[0];
                        if(controlsId.Count!=0)
                        DB.insertControlsToUser(Userid, controlsId);
                        this.Close();
                        MessageBox.Show("USER ADDED!", "SUCCESS");

                    }
                    else
                    {
                        this.Close();
                        MessageBox.Show("ERROR WHEN ADDING!", "FAIL");
                    }
                }
                else if (action == "edit")
                {
                    var texts = this.permisions_search.CheckedItems.Cast<object>()
                    .Select(x => this.permisions_search.GetItemText(x));

                    string permissions_search_text = (string.Join(" ", texts));
                    texts = this.permisions_menu.CheckedItems.Cast<object>()
                  .Select(x => this.permisions_search.GetItemText(x));
                    string permissions_menu_text = (string.Join(" ", texts));
                    var data = new List<string>();
                    data.Add(user_data.Id.ToString());
                    data.Add(first_name.Text);
                    data.Add(last_name.Text);
                    data.Add(username.Text);
                    data.Add(password.Text);
                    data.Add(email_1.Text);
                    data.Add(email_2.Text);
                    data.Add(phone.Text);
                    data.Add(permissions_search_text);
                    data.Add(permissions_menu_text);
                    data.Add(Convert.ToInt32(GlassRecutDeletePermission.Checked).ToString());
                    data.Add(Convert.ToInt32(FrameRecutDeletePermission.Checked).ToString());
                    if (DB.UpdateAccount(data.ToArray()) == 0)
                    {
                        int[] elementsID = this.permisions_menu.CheckedIndices.Cast<int>().ToArray();
                        List<int> controlsId = new List<int>();
                        foreach (int id in elementsID)
                            controlsId.Add(Int32.Parse(ListControls[id][0]));


                        string Userid = DB.getUserId(username.Text)[0];
                        if (controlsId.Count != 0)
                            DB.insertControlsToUser(Userid, controlsId);
                        this.Close();
                        MessageBox.Show("USER UPDATED!", "SUCCESS");

                    }
                    else
                    {
                        this.Close();
                        MessageBox.Show("ERROR WHEN UPDATING!", "FAIL");
                    }
                }
            }
        }
        private void tableLayoutPanel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void first_name_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void username_Validating(object sender, CancelEventArgs e)
        {


        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
