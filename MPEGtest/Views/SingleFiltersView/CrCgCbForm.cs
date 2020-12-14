using System;
using System.Windows.Forms;

namespace MPEGtest.Views.SingleFiltersView
{
    public partial class CrCgCbForm : Form, ICrCgCbForm
    {
        public float Cr { get; set; }
        public float Cg { get; set; }
        public float Cb { get; set; }

        public CrCgCbForm()
        {
            InitializeComponent();
            AcceptButton = applyButton;
            CancelButton = cancelButton;
            applyButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
            numericUpDownCR.Value = numericUpDownCG.Value = numericUpDownCB.Value = 30;
        }

        private void numericUpDownCR_ValueChanged(object sender, EventArgs e)
        {
            Cr = (float) (numericUpDownCR.Value / 100);
        }

        private void numericUpDownCG_ValueChanged(object sender, EventArgs e)
        {
            Cg = (float) (numericUpDownCG.Value / 100);
        }

        private void numericUpDownCB_ValueChanged(object sender, EventArgs e)
        {
            Cb = (float) (numericUpDownCB.Value / 100);
        }
    }
}