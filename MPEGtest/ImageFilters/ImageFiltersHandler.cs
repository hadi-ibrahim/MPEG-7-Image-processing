using System.Drawing;

namespace MPEGtest.ImageFilters
{
    public static class ImageFiltersHandler
    {
        public static Bitmap ApplyMedianFilter(this Bitmap image, int square = default) // 3-99
        {
            return square == default
                ? new AForge.Imaging.Filters.Median().Apply(image)
                : new AForge.Imaging.Filters.Median((int) square).Apply(image);
        }

        public static Bitmap ApplyGaussianFilter(this Bitmap image, int square = default) // 3-99
        {
            return square == default
                ? new AForge.Imaging.Filters.GaussianBlur().Apply(image)
                : new AForge.Imaging.Filters.GaussianBlur((int) square).Apply(image);
        }

        public static Bitmap ApplyErosionFilter(this Bitmap image) 
        {
            return new AForge.Imaging.Filters.BinaryErosion3x3().Apply(image);
        }

        public static Bitmap ApplyDilationFilter(this Bitmap image)
        {
            return new AForge.Imaging.Filters.BinaryDilatation3x3().Apply(image);
        }

        public static Bitmap ApplyYCBCRFilter(this Bitmap image)
        {
            return new AForge.Imaging.Filters.YCbCrFiltering().Apply(image);
        }

        public static Bitmap ApplyHSLLinearFilter(this Bitmap image)
        {
            return new AForge.Imaging.Filters.HSLLinear().Apply(image);
        }


        public static Bitmap ApplyGrayScaleFilter(this Bitmap image, float cr, float cg, float cb)
        {
            return new AForge.Imaging.Filters.Grayscale(cr, cg, cb).Apply(image);
        }
        
        public static Bitmap ApplySobelEdgeDetectionFilter(this Bitmap image)
        {
            return new AForge.Imaging.Filters.SobelEdgeDetector().Apply(image);
        }

        public static Bitmap ApplyLaplacienEdgeDetectionFilter(this Bitmap image)
        {
            return new AForge.Imaging.Filters.Edges().Apply(image);
        }
    }
}