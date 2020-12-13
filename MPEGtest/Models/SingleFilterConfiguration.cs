using MPEGtest.ImageFilters;

namespace MPEGtest.Models
{
    public class SingleFilterConfiguration<T>
    {
        public string FrameName { get; set; }
        public IImageFilter<T> Filter { get; set; }
        
        public InputConfig SliderConfig { get; set; }
        public InputConfig NumberInputsConfig { get; set; }
    }
}