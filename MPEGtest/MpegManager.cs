using MPEGtest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MPEGtest
{
    public class MpegManager
    {
        private readonly string xmlPath;
        
        public MpegManager(string path)
        {
            this.xmlPath = path;
        }

        public HashSet<Mpeg> QueryImages(Mpeg criteriaMpeg)
        {
            XElement doc = XElement.Load(xmlPath);
            var matches = FilterAllCrtieria(doc.Elements("Mpeg"), criteriaMpeg);
            HashSet<Mpeg> result = DeserializeXmlElementsToMpegs(matches);

            return result;

        }
        private IEnumerable<XElement> FilterAllCrtieria(IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            IEnumerable<XElement> result = matches;

            result = FilterByCriteria(result, "Concept", criteriaMpeg.Concept);
            result = FilterByCriteria(result, "Evt", criteriaMpeg.Evt);

            result = FilterByCriteria(result, "SpatialRelation", criteriaMpeg.SpatialRelation);
            result = FilterByRelationAttribute(result, "SpatialRelation", "Source", criteriaMpeg.SpatialRelationSource);
            result = FilterByRelationAttribute(result, "SpatialRelation", "Target", criteriaMpeg.SpatialRelationTarget);

            result = FilterByCriteria(result, "TemporalRelation", criteriaMpeg.TemporalRelation);
            result = FilterByRelationAttribute(result, "TemporalRelation", "Source", criteriaMpeg.TemporalRelationSource);
            result = FilterByRelationAttribute(result, "TemporalRelation", "Target", criteriaMpeg.TemporalRelationTarget);

            result = FilterByCriteria(result, "Relation", criteriaMpeg.Relation);
            result = FilterByAgents(result, criteriaMpeg);
            return result;
        }
        private IEnumerable<XElement> FilterByCriteria(IEnumerable<XElement> matches, string criteriaName, string criteriaValue)
        {
            return matches.Where(x => x.Elements(criteriaName)
                                        .Where(e => e.Value.ToLower().Contains(criteriaValue.ToLower()))
                                        .Any());
        }

        private IEnumerable<XElement> FilterByRelationAttribute(IEnumerable<XElement> matches, string criteriaName,string attributeName, string attributeValue)
        {
            return matches.Where(x => x.Elements(criteriaName).Attributes(attributeName)
                                        .Where(e => e.Value.ToLower().Contains(attributeValue.ToLower()))
                                        .Any()); ;
        }

        private IEnumerable<XElement> FilterByAgents(IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            foreach (Agent agent in criteriaMpeg.Agents)
                matches = FilterByCriteria(matches,"Agent", agent.Name);

            return matches;
        }

        public void AddMpegToXml(Mpeg mpeg)
        {
            var mpegs = DeserializeMpegsFromXmlFile();
            mpegs.Add(mpeg);
            SerializeMpegsToXmlFile(mpegs);
        }

        public void MigrateXmlToDb()
        {
            var context = new mdipContext();
            var mpegsInXml = DeserializeMpegsFromXmlFile();
            var mpegsInDb = context.Mpegs.ToList();
            foreach(var mpeg in mpegsInXml)
            {
                if (!MpegInList(mpegsInDb,mpeg))
                SaveMpegToDb(mpeg);
            }
        }

        private bool MpegInList(IEnumerable<Mpeg>mpegs, Mpeg mpeg)
        {
            return mpegs.Any(m => m.Equals(mpeg));
        }

        private void SaveMpegToDb(Mpeg mpeg)
        {
            var context = new mdipContext();
            {
                context.Mpegs.Add(mpeg);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e) { }
            }
        }



        public void SerializeMpegsToXmlFile(HashSet<Mpeg> mpegs)
        {
            var mpegsInXml = new HashSet<XElement>();
            foreach(var mpeg in mpegs)
            {
                mpegsInXml.Add(SerializeMpeg7(mpeg));
            }
            var root = new XElement("Mpegs", mpegsInXml);
            root.Save(xmlPath);
        }

        private XElement SerializeMpeg7(Mpeg mpeg)
        {
            return new XElement("Mpeg7",
                                   new XElement("Event", mpeg.Evt),
                                   new XElement("Concept", mpeg.Concept),
                                   new XElement("Image", mpeg.Image),
                                   new XElement("SpatialRelation", mpeg.SpatialRelation,
                                       new XAttribute("Source", mpeg.SpatialRelationSource),
                                       new XAttribute("Target", mpeg.SpatialRelationTarget)),
                                   new XElement("TemporalRelation", mpeg.TemporalRelation,
                                       new XAttribute("Source", mpeg.TemporalRelationSource),
                                       new XAttribute("Target", mpeg.TemporalRelationTarget)),
                                   new XElement("Relation", mpeg.Relation),
                                   SerializeAgents(mpeg)
                                   );
        }
        private XElement SerializeAgents(Mpeg mpeg)
        {
            var agents = new XElement("Agents");
            foreach (var agent in mpeg.Agents)
            {
                agents.Add(SerializeAgent(agent));
            }
            return agents;
        }
        private XElement SerializeAgent(Agent agent)
        {
            return new XElement("Agent", agent.Name);
        }

        public HashSet<Mpeg> DeserializeMpegsFromXmlFile()
        {
            var elements = XElement.Parse(File.ReadAllText(xmlPath)).Elements("Mpeg7");
            return DeserializeXmlElementsToMpegs(elements);
        }

        public HashSet<Mpeg> DeserializeXmlElementsToMpegs(IEnumerable<XElement> elements)
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

        public Image GetImageFromBase64(string base64Image)
        {
            var bytes = Convert.FromBase64String(base64Image);
            var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        public string GetBase64StringFromImage(string imgPath)
        {
            var bytes = File.ReadAllBytes(imgPath);
            return Convert.ToBase64String(bytes);
        }
    }
}
