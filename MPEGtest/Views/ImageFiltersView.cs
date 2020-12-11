using System;
using System.Drawing;
using System.Windows.Forms;
using MPEGtest.Common;
using MPEGtest.ImageFilters;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class ImageFiltersView : Form, IImageFilter, IImageObserver, IImageFilterView
    {
        private Image _image;
        private IImageHandler _imageHandler;
        public ImageFiltersView(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
            SubscribeToImageChanges();
            InitializeComponent();
        }

        private void GaussianFilterButtonOnClick(object sender, EventArgs e)
        {
            // RoutingHelper.OpenAdditionalView();
        }

        public void ProcessImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void PublishImageUpdate(Image image)
        {
            _imageHandler.UpdateImage(image);
        }

        public void ReceiveImageUpdates(Image image)
        {
            _image = image;
        }

        public bool SubscribeToImageChanges()
        {
            return _imageHandler.SubscribeObserver(this);
        }

        public bool UnSubscribeToImageChanges()
        {
            return _imageHandler.UnSubscribeObserver(this);
        }
    }
}