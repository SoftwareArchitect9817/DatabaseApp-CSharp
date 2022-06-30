using System.Windows.Forms;

namespace Senaka.component
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }
        public new DialogResult Show()
        {
            return (ShowDialog());
        }
    }
}
