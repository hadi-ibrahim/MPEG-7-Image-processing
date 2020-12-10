using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;
using MPEGtest.Models;

namespace MPEGtest.Views
{
    public partial class UploadImageView : Form
    {
        public HashSet<Mpeg> mpegs { get; set; }
        private const string XmlPath = "../../../../test.xml";
        private const string ImgPath = "../../dog.JPG";

        public UploadImageView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        

        private void UploadButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)| All Files(*.*)|*.*|";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    ImageTxt.Text = imageLocation;
                }
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

        private void InsertButtonOnClick(object sender, EventArgs e)
        {
            MpegManager manager = new MpegManager(XmlPath);

            String Concept = ConceptTxt.Text;
            String Event = EventTxt.Text;
            String Place = PlaceTxt.Text;
            String Time = TimeTxt.Text;
            String ImagePath = ImageTxt.Text;
            String agent = AgentTxt.Text;
            String Relation = RelationTxt.Text;

            HashSet<Agent> agents = new HashSet<Agent> {new Agent(agent)};
            string encodedImage = manager.GetBase64StringFromImage(ImagePath);
            Mpeg mpeg = new Mpeg(Event, Concept, encodedImage, Place, Time, Relation, agents);
            manager.AddMpegToXml(mpeg);

            // manager.MigrateXmlToDb();
        }
        
        private void SearchHereButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new SearchImageView());

        }
    }
}