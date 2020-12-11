using System;
using System.Collections.Generic;
using System.Drawing;
using MPEGtest.Common;

namespace MPEGtest.ImageFilters
{
    public class ImageHandler : IImageHandler
    {
        private Image _image { get; set; }
        private List<IImageObserver> _imageFilters = new List<IImageObserver>();


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
                filter.ReceiveImageUpdates(_image);
            }
        }

        public void UpdateImage(Image image)
        {
            _image = image;
            NotifyObservers();
        }
    }
}