using MPEGtest.ImageFilters.Filters.Interfaces;

namespace MPEGtest.ImageFilters.Filters
{
    public class MedianFilter : BaseFilter, IMedianFilter
    {
        public MedianFilter(IImageHandler imageHandler) : base(imageHandler)
        {}

        public void ApplyFilter(int param = default)
        {
            ImageHandler.GetBitmapImage().ApplyMedianFilter(param);
        }

        public void PreviewFilter(int param = default)
        {
            ImageHandler.GetTempBitmapImage().ApplyMedianFilter(param);
        }
    }
}