using System;
using System.Collections.Generic;
using System.Drawing;
using MPEGtest.Common;

namespace MPEGtest.ImageFilters
{
    public class ImageHandler : IImageHandler
    {
        private const string CurrentImageFileName = "Current";
        private const string TempImageFileName = "Temp";
        private const string ImagePath = "../../../wwwroot/";
        private List<IImageObserver> _imageFilters = new List<IImageObserver>();


        private void SaveImage(string imagePath)
        {
            // load an image
            Bitmap image = (Bitmap) Bitmap.FromFile(imagePath);
            //save Image to temp path
            image.Save(ImagePath + CurrentImageFileName);
        }

        private void SaveTempImage()
        {
            // load an image
            Bitmap image = (Bitmap) Bitmap.FromFile(ImagePath + CurrentImageFileName);
            //save Image to temp path
            image.Save(ImagePath + TempImageFileName);
        }

        public bool SubscribeObserver(IImageObserver imageObserver)
        {
            try
            {
                _imageFilters.Add(imageObserver);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool UnSubscribeObserver(IImageObserver imageObserver)
        {
            try
            {
                _imageFilters.Remove(imageObserver);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private void NotifyObservers()
        {
            foreach (var filter in _imageFilters)
            {
                filter.ReceiveImageUpdates(ImagePath + CurrentImageFileName);
            }
        }

        public void UpdateImage(string imagePath, bool temporary = false)
        {
            if (temporary)
            {
                SaveTempImage();
            }
            else
            {
                SaveImage(imagePath);
            }

            NotifyObservers();
        }
    }
}