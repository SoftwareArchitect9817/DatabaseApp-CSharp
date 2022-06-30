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
    public partial class OceanviewPatioFields : Form
    {
     //   DialogResult? resultCode = null;
        List<string> result = new List<string>();
        public OceanviewPatioFields(string door_number)
        {
            InitializeComponent();
            doorNumbTextBox.Text = door_number.PadLeft(5, '0');
            List<string[]> oceanviewPatioDoors_fields = DB.getOceanviewPatioDoorsFields();
            foreach (var item in oceanviewPatioDoors_fields)
            {
                if (item[1] == "Colour")
                    ColourComboBox.Items.Add(item[2]);
                else if (item[1] == "Assembled view from Exterior")
                    AssembledComboBox.Items.Add(item[2]);
                else if (item[1] == "Grills")
                    grillsComboBox.Items.Add(item[2]);
                else if (item[1] == "Internal Blinds")
                    internalBlindsComboBox.Items.Add(item[2]);
                else if (item[1] == "Elite Lock")
                    eliteLockComboBox.Items.Add(item[2]);
                else if (item[1] == "Euro Locks")
                    euroLockComboBox.Items.Add(item[2]);
                else if (item[1] == "New Euro Lock")
                    newEuroLockComboBox.Items.Add(item[2]);
                else if (item[1] == "Security options")
                    securityOptionsComboBox.Items.Add(item[2]);
                else if (item[1] == "Door Size")
                    SizeComboBox.Items.Add(item[2]);

            }
            ColourComboBox.Items.Add("N/A");
            AssembledComboBox.Items.Add("N/A");
            grillsComboBox.Items.Add("N/A");
            internalBlindsComboBox.Items.Add("N/A");
            eliteLockComboBox.Items.Add("N/A");
            euroLockComboBox.Items.Add("N/A");
            newEuroLockComboBox.Items.Add("N/A");
            securityOptionsComboBox.Items.Add("N/A");
            SizeComboBox.Items.Add("N/A");
            if (Settings.NAAutoSelectOceanView == "True") {
                ColourComboBox.SelectedIndex = ColourComboBox.FindStringExact("N/A");
                AssembledComboBox.SelectedIndex = AssembledComboBox.FindStringExact("N/A");
                grillsComboBox.SelectedIndex = grillsComboBox.FindStringExact("N/A");
                internalBlindsComboBox.SelectedIndex = internalBlindsComboBox.FindStringExact("N/A");
                eliteLockComboBox.SelectedIndex = eliteLockComboBox.FindStringExact("N/A");
                euroLockComboBox.SelectedIndex = euroLockComboBox.FindStringExact("N/A");
                newEuroLockComboBox.SelectedIndex = newEuroLockComboBox.FindStringExact("N/A");
                securityOptionsComboBox.SelectedIndex = securityOptionsComboBox.FindStringExact("N/A");
                SizeComboBox.SelectedIndex = SizeComboBox.FindStringExact("N/A");
            }

        }
      

       
        private void OceanviewPatioDoorsFields_Load(object sender, EventArgs e)
        {

        }

        private void qtyTextBox_Click(object sender, EventArgs e)
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
            if (qtyTextBox.Text != "" && SizeComboBox.Text != "" && ColourComboBox.Text != "" && AssembledComboBox.Text != "" && grillsComboBox.Text != "" && internalBlindsComboBox.Text != "" && eliteLockComboBox.Text != "" && euroLockComboBox.Text != "" && newEuroLockComboBox.Text != "" && securityOptionsComboBox.Text != "")
            {
                result.Add(doorNumbTextBox.Text);
                result.Add(qtyTextBox.Text);
                result.Add(SizeComboBox.Text);
                result.Add(ColourComboBox.Text);
                result.Add(AssembledComboBox.Text);
                result.Add(grillsComboBox.Text);
                result.Add(internalBlindsComboBox.Text);
                result.Add(eliteLockComboBox.Text);
                result.Add(euroLockComboBox.Text);
                result.Add(newEuroLockComboBox.Text);
                result.Add(securityOptionsComboBox.Text);
               
                AddBtn.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                //  resultCode = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please complete all the fields", "ERROR");
               

            }

        }
    }
}
