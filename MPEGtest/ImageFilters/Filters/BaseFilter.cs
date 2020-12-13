namespace MPEGtest.ImageFilters.Filters
{
    public class BaseFilter
    {
        protected readonly IImageHandler ImageHandler;

        public BaseFilter(IImageHandler imageHandler)
        {
            ImageHandler = imageHandler;
        }
    }
}