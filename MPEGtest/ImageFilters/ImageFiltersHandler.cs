using System.Drawing;

namespace MPEGtest.ImageFilters
{
    public static class ImageFiltersHandler
    {
        public static Bitmap ApplyMedianFilter(this Bitmap image, int square = default)
        {
            return square == default
                ? new AForge.Imaging.Filters.Median().Apply(image)
                : new AForge.Imaging.Filters.Median((int) square).Apply(image);
        }
        
        public static Bitmap ApplyGaussianFilter(this Bitmap image, int square = default)
        {
            return square == default
                ? new AForge.Imaging.Filters.GaussianBlur().Apply(image)
                : new AForge.Imaging.Filters.GaussianBlur((int) square).Apply(image);
        }
        
        public static Bitmap ApplyErosion(this Bitmap image, short[,] square = default)
        {
            return square == default
                ? new AForge.Imaging.Filters.Erosion().Apply(image)
                : new AForge.Imaging.Filters.Erosion(square).Apply(image);
        }
    }
}