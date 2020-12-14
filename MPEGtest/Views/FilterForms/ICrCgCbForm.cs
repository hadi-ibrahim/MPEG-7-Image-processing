using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views.SingleFiltersView
{
    public interface ICrCgCbForm: IForm
    {
        public float Cr { get; set; }
        public float Cg { get; set; }
        public float Cb { get; set; }

    }
}