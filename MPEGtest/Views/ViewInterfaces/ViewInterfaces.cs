
using System.Windows.Forms;

namespace MPEGtest.Views.ViewInterfaces
{
    public interface IForm
    {
        public void Show();

        public void Dispose();
        public DialogResult DialogResult { get; set; }
        public DialogResult ShowDialog();

        public void Hide();
        // public abstract void SetName();
    }

    public interface IWelcomeView : IForm
    {
    }

    public interface IUploadImageView : IForm
    {
    }

    public interface ISearchImageView : IForm
    {
    }

    public interface IImageFilterView : IForm
    {
    }

}