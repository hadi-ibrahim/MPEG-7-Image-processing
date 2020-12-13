using System;
using System.Windows.Forms;
using MPEGtest.Common;
using MPEGtest.ImageFilters;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class ImageFiltersView : Form, IImageObserver, IImageFilterView
    {
        public string ImagePath { get; set; }
        private readonly IImageHandler _imageHandler;

        public ImageFiltersView(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
            SubscribeToImageChanges();
            InitializeComponent();
        }
        
        

        public void PublishImageUpdate(string imagePath)
        {
            _imageHandler.UpdateImage(imagePath);
        }

        public void ReceiveImageUpdates(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void SubscribeToImageChanges()
        {
            if (!_imageHandler.SubscribeObserver(this))
            {
                MessageBox.Show("Something went bad :( Please contact you IT person", "Internal Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UnSubscribeToImageChanges()
        {
            if (!_imageHandler.UnSubscribeObserver(this))
            {
                MessageBox.Show("Something went bad :( Please contact you IT person", "Internal Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void medianButton_Click(object sender, EventArgs e)
        {
            // RoutingHelper.OpenAdditionalView<>()
        }
    }
}