using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MPEGtest.Common;
using MPEGtest.Common.Helpers;
using MPEGtest.ImageFilters;
using MPEGtest.Models;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class UploadImageView : Form, IUploadImageView, IImageObserver
    {
        private const string XmlPath = "../../test.xml";
        private IImageHandler _imageHandler;
        private IUploadImageView _uploadImageViewImplementation;

        public UploadImageView(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
            SubscribeToImageChanges();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void BrowseButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)| All Files(*.*)|*.*|";
                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                PublishImageUpdate(dialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void UploadButtonOnClick(object sender, EventArgs e)
        {
            MpegManager manager = new MpegManager(XmlPath);

            String Concept = ConceptTxt.Text;
            String Event = EventTxt.Text;
            String Place = PlaceTxt.Text;
            String Time = TimeTxt.Text;
            String agent = AgentTxt.Text;
            String Relation = RelationTxt.Text;

            HashSet<Agent> agents = new HashSet<Agent> {new Agent(agent)};
            string encodedImage = manager.GetBase64StringFromImage(_imageHandler.GetImageUrl());
            Mpeg mpeg = new Mpeg(Event, Concept, encodedImage, Place, Time, Relation, agents);
            manager.AddMpegToXml(mpeg);

            // manager.MigrateXmlToDb();        
        }

        private void SearchHereButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView<ISearchImageView>();
            UnSubscribeToImageChanges();
        }

        private void OpenFiltersButtonClick(object sender, EventArgs e)
        {
            RoutingHelper.OpenAdditionalView<IImageFilterView>();
        }

        public void PublishImageUpdate(string imagePath)
        {
            _imageHandler.UpdateImageByPath(imagePath);
        }

        public void ReceiveImageUpdates(Bitmap image)
        {
            imagePanel.BackgroundImage = image;
            Console.WriteLine("Image Updated");
        }

        public void SubscribeToImageChanges()
        {
            if (!_imageHandler.SubscribeObserver(this))
            {
                MessageBox.Show("Something went bad :( Please contact you IT person", "Internal Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UnSubscribeToImageChanges()
        {
            if (!_imageHandler.UnSubscribeObserver(this))
            {
                MessageBox.Show("Something went bad :( Please contact you IT person", "Internal Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}