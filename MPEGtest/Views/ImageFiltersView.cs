using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MPEGtest.Common;
using MPEGtest.Common.Helpers;
using MPEGtest.ImageFilters;
using MPEGtest.Models;
using MPEGtest.Views.SingleFiltersView;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class ImageFiltersView : Form, IImageObserver, IImageFilterView
    {
        public string ImagePath { get; set; }
        private readonly IImageHandler _imageHandler;

        public readonly InputConfig DefaultConfig = new InputConfig()
        {
            Show = true,
            DefaultValue = 3,
            IncrementBy = 1,
            Values = new List<decimal> {0, 100},
        };

        public ImageFiltersView(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
            SubscribeToImageChanges();
            InitializeComponent();
        }


        public void PublishImageUpdate(string imagePath)
        {
            _imageHandler.UpdateImageByPath(imagePath);
        }

        public void ReceiveImageUpdates(Bitmap imagePath)
        {
            // ImagePath = imagePath;
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
            var median = new MedianFilterView(_imageHandler);
            median.Show();
            // GetFilterView().SetupInputComponents(new SingleFilterConfiguration()
            // {
            //     FrameName = "Median Filter",
            //     SliderConfig = DefaultConfig,
            //     Filter = RoutingHelper.OpenAdditionalView<IMedianFilter>(),
            // });
        }

        private ISingleFilterView GetFilterView()
        {
            return RoutingHelper.OpenAdditionalView<ISingleFilterView>();
        }

        private void gaussianButton_Click(object sender, EventArgs e)
        {

                var gaussian = new GaussianFilterView(_imageHandler);
                gaussian.Show();
        }
    }
}