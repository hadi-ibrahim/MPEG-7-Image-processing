using MPEGtest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace MPEGtest
{
    public partial class Form1 : Form
    {
        public HashSet<Mpeg> mpegs { get; set; }
        private string xmlPath =    "D:\\UA\\UA courses\\Multimedia Database and Image Processing\\test.xml";
        private string imgPath = "D:\\UA\\UA courses\\Multimedia Database and Image Processing\\utilities\\dog.JPG";

        public Form1()
        {
            var context = new mdipContext();
            InitializeComponent();

            string encodedImage = getBase64StringFromImage(imgPath);

            HashSet<Agent> agents = new HashSet<Agent> { new Agent("John"), new Agent("Alex") };
            mpegs = new HashSet<Mpeg>{new Mpeg("comradeship", "handshake", encodedImage, "Beirut", DateTime.Now, "accompany", agents)};
            Mpeg temp = new Mpeg("fighting", "shoot", encodedImage, "New York", DateTime.Now, "chase", agents);
            mpegs.Add(temp);
            serializeMpegsToXmlFile(mpegs, xmlPath);

            //foreach (Mpeg mpeg in mpegs)
            //{
            //    context.Mpegs.Add(mpeg);
            //    context.SaveChanges();
            //}

            //mpegs = deserializeMpegsFromXmlFile(xmlPath);
            mpegs = queryImages(temp, xmlPath);
            var image = getImageFromBase64(mpegs.ElementAt(0).Image);

            txtLabel.Image = image;
        }

        private HashSet<Mpeg> queryImages(Mpeg criteriaMpeg, string path )
        {
            XElement doc = XElement.Load(path);

            var matches = filterAllCrtieria(doc.Elements("ArrayOfMpeg").Elements("Mpeg"), criteriaMpeg);
            HashSet<Mpeg> result = convertXElementsToMpegs(matches);

            return result;
            
        }

        private IEnumerable<XElement> filterAllCrtieria(IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            IEnumerable<XElement> result = matches;

            result = filterByCriteria(result, "Concept", criteriaMpeg.Concept);
            //result = filterByCriteria(result, "Evt", criteriaMpeg.Evt);
            //result = filterByCriteria(result, "Place", criteriaMpeg.Place);
            //result = filterByCriteria(result, "Time", criteriaMpeg.Time.ToString());
            //result = filterByCriteria(result, "Relation", criteriaMpeg.Relation);
           
            return filterByAgents(result, criteriaMpeg);
        }

        private IEnumerable<XElement> filterByCriteria(IEnumerable<XElement> matches, string criteriaName, string criteriaValue)
        {
            return matches.Where(x => x.Descendants()
                                        //.Where(e => e.Name == criteriaName && e.Value.ToLower().Contains(criteriaValue.ToLower()))
                                        .Any());
        }

        private IEnumerable<XElement> filterByAgents (IEnumerable<XElement> matches, Mpeg criteriaMpeg)
        {
            IEnumerable<XElement> result = matches.Where(x=>x.Elements("Agents").Any()) ;
            
            foreach (Agent agent in criteriaMpeg.Agents)
                result = filterByAgent(result, agent.Name);

            return result;
        }

        private IEnumerable<XElement> filterByAgent(IEnumerable<XElement> matches, string agentName)
        {
            return matches.Where(x => x.Descendants()
                                        //.Where(e => e.Name == "Name" && e.Value.ToLower().Contains(agentName.ToLower()))
                                        .Any());
        }


        private Image getImageFromBase64(string base64Image)
        {
            var bytes = Convert.FromBase64String(base64Image);
            var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private string getBase64StringFromImage(string imgPath)
        {
            var bytes = File.ReadAllBytes(imgPath);
            return Convert.ToBase64String(bytes);
        }

        private void serializeMpegsToXmlFile(HashSet<Mpeg> mpegs, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Mpeg>));
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, mpegs);
            writer.Close();
        }

        private HashSet<Mpeg> deserializeMpegsFromXmlFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Mpeg>));
            TextReader reader = new StreamReader(path);
            HashSet<Mpeg> mpegsTemp = (HashSet<Mpeg>)serializer.Deserialize(reader);
            reader.Close();
            return mpegsTemp;
        }
        private HashSet<Mpeg> convertXElementsToMpegs(IEnumerable<XElement> elements)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Mpeg));
            HashSet<Mpeg> result = new HashSet<Mpeg>();

            foreach (var element in elements)
            {
                result.Add((Mpeg)serializer.Deserialize(element.CreateReader()));
            }
            return result;

        }

    }


}
