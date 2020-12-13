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
            HashSet<Mpeg> result = ConvertXElementsToMpegs(matches);

            return result;

        }
        private IEnumerable<XElement> FilterAllCrtieria(IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            IEnumerable<XElement> result = matches;

            result = FilterByCriteria(result, "Concept", criteriaMpeg.Concept);
            result = FilterByCriteria(result, "Evt", criteriaMpeg.Evt);
            result = FilterByCriteria(result, "Place", criteriaMpeg.Place);
            result = FilterByCriteria(result, "Time", criteriaMpeg.Time);
            result = FilterByCriteria(result, "Relation", criteriaMpeg.Relation);
            result = FilterByAgents(result, criteriaMpeg);
            return result;
        }
        private IEnumerable<XElement> FilterByCriteria(IEnumerable<XElement> matches, string criteriaName, string criteriaValue)
        {
            return matches.Where(x => x.Descendants()
                                        .Where(e => e.Name == criteriaName && e.Value.ToLower().Contains(criteriaValue.ToLower()))
                                        .Any());
        }

        private IEnumerable<XElement> FilterByAgents(IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            foreach (Agent agent in criteriaMpeg.Agents)
                matches = FilterByAgent(matches, agent.Name);

            return matches;
        }

        private IEnumerable<XElement> FilterByAgent(IEnumerable<XElement> matches, string agentName)
        {
            return matches.Where(x => x.Descendants()
                                        .Where(e => e.Name == "Name" && e.Value.ToLower().Contains(agentName.ToLower()))
                                        .Any());
        }

        public void AddMpegToXml(Mpeg mpeg)
        {
            var mpegs = DeserializeMpegsFromXmlFile();
            Console.WriteLine("mpeg");
            Console.WriteLine(mpeg);
            
            mpegs.Add(mpeg);
            Console.WriteLine("mpegs");
            Console.WriteLine(mpegs);
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

        public HashSet<Mpeg> DeserializeMpegsFromXmlFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Mpeg>));
            TextReader reader = new StreamReader(xmlPath);
            HashSet<Mpeg> mpegsTemp = new HashSet<Mpeg>();
            if (reader.Peek() != -1)
                mpegsTemp = (HashSet<Mpeg>)serializer.Deserialize(reader);
            reader.Close();
            return mpegsTemp;
        }

        public void SerializeMpegsToXmlFile(HashSet<Mpeg> mpegs)
        {
            DeleteFileIfExists();
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Mpeg>));
            TextWriter writer = new StreamWriter(xmlPath);

            serializer.Serialize(writer, mpegs);
            writer.Close();
        }

        private void DeleteFileIfExists()
        {
            if (File.Exists(xmlPath))         
                File.Delete(xmlPath);
        }

        public HashSet<Mpeg> ConvertXElementsToMpegs(IEnumerable<XElement> elements)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Mpeg));
            HashSet<Mpeg> result = new HashSet<Mpeg>();

            foreach (var element in elements)
            {
                StringReader reader = new StringReader(element.ToString());
                result.Add((Mpeg)serializer.Deserialize(reader));
            }
            return result;

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
