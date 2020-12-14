using System;
using System.Windows.Forms;

namespace MPEGtest.Views.SingleFiltersView
{
    public partial class SliderForm : Form,ISliderForm
    {
        public int OutputValue { get; set; }

        public SliderForm()
        {
            InitializeComponent();
            AcceptButton = applyButton;
            CancelButton = cancelButton;
            applyButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            OutputValue = trackBar1.Value;
            outputValueLabel.Text = OutputValue.ToString();
        }

    }
}