using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPEGtest.Common;
using MPEGtest.ImageFilters;
using MPEGtest.Models;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views.SingleFiltersView
{
    public partial class SingleFilterView : Form, ISingleFilterView
    {
        private IImageHandler _imageHandler;
        public SingleFilterView(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
            InitializeComponent();
            discardButton.Enabled = false;
        }

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }

        public void PreviewFilter()
        {
            // _imageHandler.UpdateImageByPath(_imageHandler.GetTempBitmapImage().ApplyMedianFilter()));
        }

        public void ApplyFilter()
        {
            throw new NotImplementedException();
        }

        public void SetupInputComponents(SingleFilterConfiguration config)
        {
            if (!config.SliderConfig.Show)
            {
                ValueSlider.Hide();
                SetupNumericUpDowns(config.NumberInputsConfig);
            }
            else
            {
                numericUpDownCR.Hide();
                numericUpDownCG.Hide();
                numericUpDownCB.Hide();
                labelCR.Hide();
                labelCG.Hide();
                labelCB.Hide();
                SetupSlider(config.SliderConfig);
            }
        }

        private void SetupNumericUpDowns(InputConfig config)
        {
            numericUpDownCR.Minimum = numericUpDownCG.Minimum = numericUpDownCB.Minimum = config.Values[0];
            numericUpDownCR.Maximum = numericUpDownCG.Maximum = numericUpDownCB.Maximum = config.Values[1];
            numericUpDownCR.Value = numericUpDownCG.Value = numericUpDownCB.Value = config.DefaultValue;
        }

        public void SetupSlider(InputConfig config)
        {
            ValueSlider.Minimum = (int) config.Values[0];
            ValueSlider.Maximum = (int) config.Values[1];
            ValueSlider.Maximum = (int) config.DefaultValue;
        }
    }
}