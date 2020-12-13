using System.Drawing;

namespace MPEGtest.Common
{ 
    // this should be the views that have an image shown
    public interface IImageObserver
    {
        public void PublishImageUpdate(string imagePath);
        public void ReceiveImageUpdates(string imagePath);
        public void SubscribeToImageChanges();
        public void UnSubscribeToImageChanges();
    }
}