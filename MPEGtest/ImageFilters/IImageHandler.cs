using System.Drawing;
using MPEGtest.Common;

namespace MPEGtest.ImageFilters
{
    public interface IImageHandler
    {
        public bool SubscribeObserver(IImageObserver imageObserver);
        public bool UnSubscribeObserver(IImageObserver imageObserver);
        public void UpdateImage(string imagePath, bool temporary= false);
    }
}