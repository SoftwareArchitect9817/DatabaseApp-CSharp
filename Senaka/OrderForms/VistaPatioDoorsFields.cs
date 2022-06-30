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
    public partial class VistaPatioFields : Form
    {
     //   DialogResult? resultCode = null;
        List<string> result = new List<string>();
        public VistaPatioFields(string door_number)
        {
            InitializeComponent();
            doorNumbTextBox.Text = door_number.PadLeft(5, '0');
            List<string[]> vistaPatioDoors_fields = DB.getVistaPatioDoorsFields();
            foreach (var item in vistaPatioDoors_fields)
            {
                if (item[1] == "FINISHES")
                    finishesComboBox.Items.Add(item[2]);
                else if (item[1] == "GLAZING OPTIONS")
                    glazingOptionsComboBox.Items.Add(item[2]);
                else if (item[1] == "MINI BLINDS")
                    miniBlindsComboBox.Items.Add(item[2]);
                else if (item[1] == "GRILLS")
                    grillsComboBox.Items.Add(item[2]);
                else if (item[1] == "SILL EXTENTION")
                    sillExtensionComboBox.Items.Add(item[2]);
                else if (item[1] == "NAILING FIN")
                    nailingFinComboBox.Items.Add(item[2]);
                else if (item[1] == "DRYWALL RETURN")
                    drywallReturnComboBox.Items.Add(item[2]);
                else if (item[1] == "LOCKING HARDWARE")
                    lockingHardwareComboBox.Items.Add(item[2]);
                else if (item[1] == "SERIES")
                    seriesComboBox.Items.Add(item[2]);
                else if (item[1] == "SECONDARY HARDWARE")
                    secondaryHardwareComboBox.Items.Add(item[2]);
                else if (item[1] == "Transom Size")
                    transomSizeComboBox.Items.Add(item[2]);
                else if (item[1] == "Sidelite Size")
                    sideliteSizeComboBox.Items.Add(item[2]);
                else if (item[1] == "LUXURY PACKAGES")
                    luxuryPackagesComboBox.Items.Add(item[2]);
                else if (item[1] == "Door Size")
                    DoorSizeComboBox.Items.Add(item[2]);
                else if (item[1] == "KNOCKED DOWN")
                    KnockedDownComboBox.Items.Add(item[2]);
                else if (item[1] == "ASSEMBLED")
                    AssembledComboBox.Items.Add(item[2]);
                else if (item[1] == "INTERIOR EXTENTIONS")
                    InteriorExtensiosComboBox.Items.Add(item[2]);
                else if (item[1] == "BRICKMOULD")
                    BrickmouldComboBox.Items.Add(item[2]);
                else if (item[1] == "VINYL PACKAGE")
                    VinylPackageComboBox.Items.Add(item[2]);

            }
            finishesComboBox.Items.Add("N/A");
            glazingOptionsComboBox.Items.Add("N/A");
            miniBlindsComboBox.Items.Add("N/A");
            grillsComboBox.Items.Add("N/A");
            sillExtensionComboBox.Items.Add("N/A");
            nailingFinComboBox.Items.Add("N/A");
            drywallReturnComboBox.Items.Add("N/A");
            lockingHardwareComboBox.Items.Add("N/A");
            seriesComboBox.Items.Add("N/A");
            secondaryHardwareComboBox.Items.Add("N/A");
            transomSizeComboBox.Items.Add("N/A");
            sideliteSizeComboBox.Items.Add("N/A");
            luxuryPackagesComboBox.Items.Add("N/A");
            DoorSizeComboBox.Items.Add("N/A");
            KnockedDownComboBox.Items.Add("N/A");
            AssembledComboBox.Items.Add("N/A");
            InteriorExtensiosComboBox.Items.Add("N/A");
            BrickmouldComboBox.Items.Add("N/A");
            VinylPackageComboBox.Items.Add("N/A");
            if (Settings.NAAutoSelectVista == "True")
            {
                finishesComboBox.SelectedIndex = finishesComboBox.FindStringExact("N/A");
                glazingOptionsComboBox.SelectedIndex = glazingOptionsComboBox.FindStringExact("N/A");
                miniBlindsComboBox.SelectedIndex = miniBlindsComboBox.FindStringExact("N/A");
                grillsComboBox.SelectedIndex = grillsComboBox.FindStringExact("N/A");
                sillExtensionComboBox.SelectedIndex = sillExtensionComboBox.FindStringExact("N/A");
                nailingFinComboBox.SelectedIndex = nailingFinComboBox.FindStringExact("N/A");
                drywallReturnComboBox.SelectedIndex = drywallReturnComboBox.FindStringExact("N/A");
                lockingHardwareComboBox.SelectedIndex = lockingHardwareComboBox.FindStringExact("N/A");
                seriesComboBox.SelectedIndex = seriesComboBox.FindStringExact("N/A");
                secondaryHardwareComboBox.SelectedIndex = secondaryHardwareComboBox.FindStringExact("N/A");
                transomSizeComboBox.SelectedIndex = transomSizeComboBox.FindStringExact("N/A");
                sideliteSizeComboBox.SelectedIndex = sideliteSizeComboBox.FindStringExact("N/A");
                luxuryPackagesComboBox.SelectedIndex = luxuryPackagesComboBox.FindStringExact("N/A");
                DoorSizeComboBox.SelectedIndex = DoorSizeComboBox.FindStringExact("N/A");
                KnockedDownComboBox.SelectedIndex = KnockedDownComboBox.FindStringExact("N/A");
                AssembledComboBox.SelectedIndex = AssembledComboBox.FindStringExact("N/A");
                InteriorExtensiosComboBox.SelectedIndex = InteriorExtensiosComboBox.FindStringExact("N/A");
                BrickmouldComboBox.SelectedIndex = BrickmouldComboBox.FindStringExact("N/A");
                VinylPackageComboBox.SelectedIndex = VinylPackageComboBox.FindStringExact("N/A");
            }
            luxuryPackagesComboBox.DropDownWidth = DropDownWidth(luxuryPackagesComboBox);
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }


        private void VistaPatioDoorsFields_Load(object sender, EventArgs e)
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
                 
                    return null;
                }
                
            
            //return null;
        }
        private void sizeTextBox_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (qtyTextBox.Text != "" && DoorSizeComboBox.Text != "" && KnockedDownComboBox.Text != "" && AssembledComboBox.Text != "" && finishesComboBox.Text != "" && glazingOptionsComboBox.Text != "" && miniBlindsComboBox.Text != ""
                 && grillsComboBox.Text != "" && InteriorExtensiosComboBox.Text != "" && BrickmouldComboBox.Text != "" && VinylPackageComboBox.Text != ""
                 && sillExtensionComboBox.Text != "" && nailingFinComboBox.Text != "" && drywallReturnComboBox.Text != "" && lockingHardwareComboBox.Text != "" && seriesComboBox.Text != ""
                 && secondaryHardwareComboBox.Text != "" && transomSizeComboBox.Text != "" && sideliteSizeComboBox.Text != "" && luxuryPackagesComboBox.Text != "")
            {
                result.Add(doorNumbTextBox.Text);
                result.Add(qtyTextBox.Text);
                result.Add(DoorSizeComboBox.Text.ToString());
                result.Add(KnockedDownComboBox.Text.ToString());
                result.Add(AssembledComboBox.Text.ToString());
                result.Add(finishesComboBox.Text.ToString());
                result.Add(glazingOptionsComboBox.Text.ToString());
                result.Add(miniBlindsComboBox.Text.ToString());
                result.Add(grillsComboBox.Text.ToString());
                result.Add(InteriorExtensiosComboBox.Text.ToString());
                result.Add(BrickmouldComboBox.Text.ToString());
                result.Add(VinylPackageComboBox.Text.ToString());
                result.Add(sillExtensionComboBox.Text.ToString());
                result.Add(nailingFinComboBox.Text.ToString());
                result.Add(drywallReturnComboBox.Text.ToString());
                result.Add(lockingHardwareComboBox.Text.ToString());
                result.Add(seriesComboBox.Text.ToString());
                result.Add(secondaryHardwareComboBox.Text.ToString());
                result.Add(transomSizeComboBox.Text.ToString());
                result.Add(sideliteSizeComboBox.Text.ToString());
                result.Add(luxuryPackagesComboBox.Text.ToString());

                AddBtn.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                //  resultCode = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please complete all the fields", "ERROR");
               

            }

        }

        private void qtyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void knockedDownTextBox_Click(object sender, EventArgs e)
        {

        }
    }
}
