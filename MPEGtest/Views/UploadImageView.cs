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

            var Concept = ConceptTxt.Text ?? "";
            var Event = EventTxt.Text ?? "";
            var SpatialRelation = SpatialRelationTxt.Text ?? "";
            var SpatialRelationSource = SpatialRelationSourceTxt.Text ?? "";
            var SpatialRelationTarget = SpatialRelationTargetTxt.Text ?? "";

            var TemporalRelation = TemporalRelationTxt.Text ?? "";
            var TemporalRelationSource = TemporalRelationSourceTxt.Text ?? "";
            var TemporalRelationTarget = TemporalRelationTargetTxt.Text ?? "";
            var agent = AgentTxt.Text ?? "";
            var Relation = RelationTxt.Text ?? "";

            HashSet<Agent> agents = new HashSet<Agent> {new Agent(agent)};
            string encodedImage = manager.GetBase64StringFromImage(_imageHandler.GetImageUrl());
            Mpeg mpeg = new Mpeg(Event, Concept, encodedImage, SpatialRelation, SpatialRelationSource, SpatialRelationTarget,
                TemporalRelation, TemporalRelationSource, TemporalRelationTarget, Relation, agents);
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
           // Console.WriteLine("Image Updated");
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