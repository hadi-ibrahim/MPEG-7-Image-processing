using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;
using MPEGtest.Models;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class SearchImageView : Form, ISearchImageView
    {
        private string xmlPath = "../../../mpegs.xml";

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
            var SpatialRelation = SpatialRelationTxt.Text ?? "";
            var SpatialRelationSource = SpatialRelationSourceTxt.Text ?? "";
            var SpatialRelationTarget = SpatialRelationTargetTxt.Text ?? "";

            var TemporalRelation = TemporalRelationTxt.Text ?? "";
            var TemporalRelationSource = TemporalRelationSourceTxt.Text ?? "";
            var TemporalRelationTarget = TemporalRelationTargetTxt.Text ?? "";
            var agent = AgentTxt.Text ?? "";
            var Relation = RelationTxt.Text ?? "";



            HashSet<Agent> agents = new HashSet<Agent> {new Agent(agent)};
            Mpeg mpegQuery = new Mpeg(Event, Concept, "", SpatialRelation, SpatialRelationSource, SpatialRelationTarget,
                TemporalRelation, TemporalRelationSource, TemporalRelationTarget, Relation, agents); 
            HashSet<Mpeg> result = manager.QueryImages(mpegQuery);

            HashSet<Image> images = new HashSet<Image>();
            foreach (var r in result)
            { 
                images.Add(manager.GetImageFromBase64(r.Image));
            }
        }

        private void BackButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView<IUploadImageView>();
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}