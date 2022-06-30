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
    public partial class HourThermalGlassFields : Form
    {
        string t;
     //   DialogResult? resultCode = null;
        List<string> result = new List<string>();
        public HourThermalGlassFields(string door_number,string type)
        {
            InitializeComponent();
            t = type;
            textBoxId.Text = door_number.PadLeft(5, '0');
            if (type == "unit")
            {
                List<string[]> hour_fields = DB.get24HourThermalGlassUnitFields();
                foreach (var item in hour_fields)
                {
                    if (item[1] == "OT")
                        comboBoxOT.Items.Add(item[2]);
                    else if (item[1] == "Spacer")
                        comboBoxSpacer.Items.Add(item[2]);
                    else if (item[1] == "MIL")
                        comboBoxMil.Items.Add(item[2]);
                    else if (item[1] == "GRILL")
                        comboBoxGrill.Items.Add(item[2]);
                    else if (item[1] == "Argo gas")
                        comboBoxArgonGas.Items.Add(item[2]);
                    else if (item[1] == "Glass type")
                        comboBoxGlassType.Items.Add(item[2]);

                }

            }
            else if (type == "sheets")
            {
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.RowStyles[5].Height = 0;
                tableLayoutPanel1.RowStyles[6].Height = 0;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;

             
                List<string[]> glass_sheets_fields = DB.get24HourThermalGlassSheetsFields();
                foreach (var item in glass_sheets_fields)
                {

                    if (item[1] == "MIL")
                        comboBoxMil.Items.Add(item[2]);

                    else if (item[1] == "Glass type")
                        comboBoxGlassType.Items.Add(item[2]);


                }


            }
            else if (type == "CutToSize")
            {
                tableLayoutPanel1.RowStyles[5].Height = 0;
                tableLayoutPanel1.RowStyles[6].Height = 0;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                List<string[]> glass_cut_fields = DB.get24HourThermalGlassCutToSizeFields();
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
            if (t == "unit" && textBoxId.Text != "" && textBoxLineNumber.Text != "" && textBoxWidth.Text != "" && textBoxHeight.Text != "" && textBoxQty.Text != ""
                && comboBoxOT.Text != "" && comboBoxSpacer.Text != "" && comboBoxMil.Text != "" && comboBoxGrill.Text != ""
                  && comboBoxArgonGas.Text != "" && comboBoxGlassType.Text != "")

            {
                result.Add(textBoxId.Text);
                result.Add(textBoxLineNumber.Text);
                result.Add(textBoxWidth.Text);
                result.Add(textBoxHeight.Text);
                result.Add(textBoxQty.Text);
                result.Add(comboBoxOT.Text);
                result.Add(comboBoxSpacer.Text);
                result.Add(comboBoxMil.Text);
                result.Add(comboBoxGrill.Text);
                result.Add(comboBoxArgonGas.Text);
                result.Add(comboBoxGlassType.Text);


                AddBtn.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                //  resultCode = DialogResult.OK;
            }
            else if ((t == "sheets"||t== "CutToSize") && textBoxId.Text != null && textBoxLineNumber.Text != null && textBoxWidth.Text != null && textBoxHeight.Text != null && textBoxQty.Text != null
               && comboBoxMil.SelectedItem != null  && comboBoxGlassType.SelectedItem != null )
            {
                result.Add(textBoxId.Text);
                result.Add(textBoxLineNumber.Text);
                result.Add(textBoxWidth.Text);
                result.Add(textBoxHeight.Text);
                result.Add(textBoxQty.Text);
                result.Add("");
                result.Add("");
                result.Add(comboBoxMil.SelectedItem.ToString());
                result.Add("");
                result.Add("");
                result.Add(comboBoxGlassType.SelectedItem.ToString());

             
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

        private void textBoxWidth_Click(object sender, EventArgs e)
        {

        }

        private void textBoxHeight_Click(object sender, EventArgs e)
        {

        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void textBoxLineNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
