using System;

namespace MPEGtest.Views.ViewInterfaces
{
    public interface IForm
    {
        public void Show();
        public void Hide();
        // public abstract void SetName();
    }
    public interface IWelcomeView: IForm {}
    public interface IUploadImageView:IForm {}
    public interface ISearchImageView:IForm {}
    public interface IImageFilterView:IForm {}
    // public interface ISingleFilterView:IForm {}
}