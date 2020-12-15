using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using MPEGtest.Common.Helpers;
using MPEGtest.Models;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Views
{
    public partial class WelcomeView : Form, IWelcomeView
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private HashSet<Mpeg> DeserializeMpegsFromXElements(IEnumerable<XElement> elements)
        {
            HashSet<Mpeg> mpegs = new HashSet<Mpeg>();
            foreach (var mpegInXml in elements)
            {
                Mpeg mpeg = new Mpeg
                {
                    Agents = DeserializeAgentsFromXmlAgentsElement(mpegInXml.Element("Agents")),
                    TemporalRelation = mpegInXml.Element("TemporalRelation").Value,
                    TemporalRelationSource = mpegInXml.Element("TemporalRelation").Attribute("Source").Value,
                    TemporalRelationTarget = mpegInXml.Element("TemporalRelation").Attribute("Target").Value,
                    SpatialRelation = mpegInXml.Element("SpatialRelation").Value,
                    SpatialRelationSource = mpegInXml.Element("SpatialRelation").Attribute("Source").Value,
                    SpatialRelationTarget = mpegInXml.Element("SpatialRelation").Attribute("Target").Value,
                    Image = mpegInXml.Element("Image").Value,
                    Evt = mpegInXml.Element("Event").Value,
                    Concept = mpegInXml.Element("Concept").Value,
                    Relation = mpegInXml.Element("Relation").Value
                };

                mpegs.Add(mpeg);

            }
            return mpegs;
        }

        private HashSet<Agent> DeserializeAgentsFromXmlAgentsElement(XElement element)
        {
            var agents = new HashSet<Agent>();
            foreach (var agnt in element.Elements("Agent"))
            {
                agents.Add(new Agent(agnt.Value));
            }
            return agents;
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