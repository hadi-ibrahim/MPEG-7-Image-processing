using System.Drawing;

namespace MPEGtest.Common
{
    public interface IImageFilter
    {
        public void DiscardChanges();
        public void PreviewFilter();
        public void ApplyFilter();
    }    
}