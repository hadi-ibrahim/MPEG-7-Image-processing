using System;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;

namespace MPEGtest.Views
{
    public partial class WelcomeView : Form
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new UploadImageView());
        }

        private void SearchForImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new SearchImageView());
        }
    }
}