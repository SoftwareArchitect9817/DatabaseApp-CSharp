using Senaka.lib;
using System;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class SelectPaintCompanyDialog : Form
    {
        public SelectPaintCompanyDialog()
        {
            InitializeComponent();

            comboBoxCompany.DataSource = Settings.CompaniesList;
        }

        public string InputBox(string title = null)
        {
            if (title != null) Text = title;
            var resultCode = ShowDialog();
            if (ShowDialog() == DialogResult.OK)
            {
                return comboBoxCompany.SelectedItem.ToString();
            }
            return null;
        }
    }
}
