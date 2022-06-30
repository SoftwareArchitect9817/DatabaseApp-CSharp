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

namespace Senaka.OrderForms
{
    public partial class WoodbridgeFields : Form
    {
        string t;
     //   DialogResult? resultCode = null;
        List<string> result = new List<string>();
        public WoodbridgeFields(string door_number,string type)
        {
            InitializeComponent();
            t = type;
            textBoxId.Text = door_number.PadLeft(5, '0') ;
            
            if (type == "sheets")
            {
               

             
                List<string[]> woodbrdidge_sheets_fields = DB.getWoodbridgeSheetsfields();
                foreach (var item in woodbrdidge_sheets_fields)
                {

                    if (item[1] == "MIL")
                        comboBoxMil.Items.Add(item[2]);

                    else if (item[1] == "Glass type")
                        comboBoxGlassType.Items.Add(item[2]);


                }


            }
            else if (type == "CutToSize")
            {
              
                List<string[]> glass_cut_fields = DB.getWoodbridgeCutToSizefields();
                foreach (var item in glass_cut_fields)
                {

                    if (item[1] == "MIL")
                        comboBoxMil.Items.Add(item[2]);

                    else if (item[1] == "Glass type")
                        comboBoxGlassType.Items.Add(item[2]);


                }


            }
        }
      

       
        private void OceanviewPatioDoorsFields_Load(object sender, EventArgs e)
        {

        }

      
       
        public List<string> InputBox(string title = null)
        {
            if (title != null) Text = title;
           var  resultCode  = ShowDialog();
           
            if (resultCode == DialogResult.OK)
            
               
                    return result;
                
                else {
                  //  MessageBox.Show("Please complete all the fields", "ERROR");
                    return null;
                }
                
            
            //return null;
        }
      
        private void AddBtn_Click(object sender, EventArgs e)
        {

            if ((t == "sheets" || t == "CutToSize") && textBoxId.Text != "" && textBoxWidth.Text != "" && textBoxHeight.Text != "" && textBoxQty.Text != ""
              && comboBoxMil.Text != "" && comboBoxGlassType.Text != "")
            {
                result.Add(textBoxId.Text);
              
                result.Add(textBoxWidth.Text);
                result.Add(textBoxHeight.Text);
                result.Add(textBoxQty.Text);
              
                result.Add(comboBoxMil.Text);
              
                result.Add(comboBoxGlassType.Text);

             //   result.Add(textBoxNote.Text);
                AddBtn.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                //  resultCode = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please complete all the fields", "ERROR");
               

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
