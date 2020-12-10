using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;
using MPEGtest.Models;

namespace MPEGtest.Views
{
    public partial class SearchImageView : Form
    {
        public HashSet<Mpeg> mpegs { get; set; }
        private string xmlPath = "../../../../test.xml";
        private string imgPath = "../../dog.JPG";

        public SearchImageView()
        {
            InitializeComponent();
            MpegManager manager = new MpegManager(xmlPath);
        }
        

        private void SearchButtonOnClick(object sender, EventArgs e)
        {
            MpegManager manager = new MpegManager(xmlPath);

            var Concept = ConceptTxt.Text ?? "";
            var Event = EventTxt.Text ?? "";
            var Place = PlaceTxt.Text ?? "";
            var Time = TimeTxt.Text ?? "";
            var agent = AgentTxt.Text ?? "";
            var Relation = RelationTxt.Text ?? "";


            HashSet<Agent> agents = new HashSet<Agent> { new Agent(agent) };
            Mpeg queryTestMpeg = new Mpeg(Event, Concept," ", Place, Time, Relation, agents);
           
            HashSet<Mpeg> result = manager.QueryImages(queryTestMpeg);

            foreach (var r in result)
            {
             Image image = manager.GetImageFromBase64(r.Image);
             
            }
        }

        private void BackButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new UploadImageView());
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
