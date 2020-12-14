using System.Windows.Forms;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views.SingleFiltersView
{
    public interface ISliderForm: IForm
    {
        public int OutputValue { get; set; }
    }
}