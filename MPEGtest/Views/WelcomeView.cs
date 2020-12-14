using System;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class WelcomeView : Form, IWelcomeView
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AddNewImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView<IUploadImageView>();
        }

        private void SearchForImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView<ISearchImageView>();
        }
    }
}