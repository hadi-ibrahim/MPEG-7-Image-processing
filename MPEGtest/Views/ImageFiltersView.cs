using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

        private string _sourcePixelFormatExceptionMessage =
            "Type not Supported, try to upload the image again and run this filter first or try applying some other filters first";

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

        private void ShowErrorMessage(string message = "Something went bad :( Please contact you IT person")
        {
            MessageBox.Show(message, "Internal Server Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void medianButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<ISliderForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            var config = inputView.OutputValue;
            new Thread(() => { _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyMedianFilter(config)); })
                .Start();
            inputView.Dispose();
        }


        private void gaussianButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<ISliderForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            var config = inputView.OutputValue;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyGaussianFilter(config));
                    }
                    catch (Exception exception)
                    {
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void erosionButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyErosionFilter());
                    }
                    catch (Exception exception)
                    {
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void dilatationButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyDilatationFilter());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void yCBCRButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyYCBCRFilter());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void hSLButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyHSLLinearFilter());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void grayScaleButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<ICrCgCbForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            var cr = inputView.Cr;
            var cb = inputView.Cb;
            var cg = inputView.Cg;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyGrayScaleFilter(cr, cg, cb));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }


        private void sobelEdgeDetectionButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplySobelEdgeDetectionFilter());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }

        private void laplacianEdgeDetectionButton_Click(object sender, EventArgs e)
        {
            var inputView = RoutingHelper.OpenDialogView<IConfirmationForm>();
            if (inputView.DialogResult != DialogResult.OK) return;
            new Thread(() =>
                {
                    try
                    {
                        _imageHandler.UpdateImage(_imageHandler.GetBitmapImage().ApplyLaplacienEdgeDetectionFilter());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ShowErrorMessage(_sourcePixelFormatExceptionMessage);
                    }
                })
                .Start();
            inputView.Dispose();
        }
    }
}