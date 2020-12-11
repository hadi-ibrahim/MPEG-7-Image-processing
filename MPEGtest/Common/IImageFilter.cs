using System.Drawing;

namespace MPEGtest.Common
{
    public interface IImageFilter
    {
        public abstract void ProcessImage(Image image);
    }
}