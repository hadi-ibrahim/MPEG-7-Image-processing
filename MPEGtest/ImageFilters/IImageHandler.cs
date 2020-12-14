using System.Drawing;
using MPEGtest.Common;

namespace MPEGtest.ImageFilters
{
    public interface IImageHandler
    {
        public bool SubscribeObserver(IImageObserver imageObserver);
        public bool UnSubscribeObserver(IImageObserver imageObserver);
        public void UpdateImageByPath(string imagePath, bool temporary = false);
        public void UpdateImage(Bitmap newImage, bool temporary = false);
        public Bitmap GetBitmapImage();
        public Bitmap GetTempBitmapImage();
    }
}