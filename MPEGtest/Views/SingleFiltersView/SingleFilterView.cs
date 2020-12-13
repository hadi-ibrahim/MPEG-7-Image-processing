using System;
using System.Windows.Forms;
using MPEGtest.Common;

namespace MPEGtest.Views.SingleFiltersView
{
    public partial class SingleFilterView : Form, IImageFilter
    {
        public SingleFilterView()
        {
            InitializeComponent();
            discardButton.Enabled = false;
        }
        

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }

        public void PreviewFilter()
        {
            throw new NotImplementedException();
        }

        public void ApplyFilter()
        {
            throw new NotImplementedException();
        }


        private void thresholdSlider_Scroll(object sender, EventArgs e)
        {
            discardButton.Enabled = true;
        }
    }
}