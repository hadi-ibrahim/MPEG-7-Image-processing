using System.Windows.Forms;

namespace MPEGtest.Views.SingleFiltersView
{
    public partial class ConfirmationForm : Form, IConfirmationForm
    {
        public ConfirmationForm()
        {
            InitializeComponent();
            AcceptButton = applyButton;
            CancelButton = cancelButton;
            applyButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }
    }
}