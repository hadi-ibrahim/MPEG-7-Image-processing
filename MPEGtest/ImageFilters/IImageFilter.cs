namespace MPEGtest.ImageFilters
{
    public partial interface IImageFilter<T>
    {
        public void ApplyFilter(T param = default);
        public void PreviewFilter(T param = default);
    }
}