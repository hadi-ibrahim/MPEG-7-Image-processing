using AForge.Imaging.Filters;
using MPEGtest.ImageFilters.Filters.Interfaces;

namespace MPEGtest.ImageFilters.Filters
{
    public class GaussianFilter:BaseFilter, IGaussianFilter
    {
        
        public GaussianFilter(IImageHandler imageHandler) : base(imageHandler)
        { }


        public void ApplyFilter(int param = default)
        {
            ImageHandler.GetBitmapImage().ApplyGaussianFilter(param);
        }

        public void PreviewFilter(int param = default)
        {
            ImageHandler.GetTempBitmapImage().ApplyGaussianFilter(param);
        }
    }
}