using System.Drawing;

namespace MPEGtest.Common
{ 
    // this should be the views that have an image shown
    public interface IImageObserver
    {
        public void PublishImageUpdate(Image image);
        public void ReceiveImageUpdates(Image image);
        public bool SubscribeToImageChanges();
        public bool UnSubscribeToImageChanges();
    }
}