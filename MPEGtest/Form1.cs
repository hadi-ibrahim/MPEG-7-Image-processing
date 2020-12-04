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
        private string xmlPath = "D:\\UA\\UA courses\\Multimedia Database and Image Processing\\test.xml";
        private string imgPath = "D:\\UA\\UA courses\\Multimedia Database and Image Processing\\utilities\\dog.JPG";

        public Form1()
        {
            InitializeComponent();
            MpegManager manager = new MpegManager(xmlPath);

            string encodedImage = manager.GetBase64StringFromImage(imgPath);
            HashSet<Agent> agents = new HashSet<Agent> { new Agent("Alex"), new Agent("John") };
            HashSet<Mpeg> mpegs;
            mpegs = manager.DeserializeMpegsFromXmlFile();

            Mpeg mpeg = new Mpeg("handshake", "comradeship", encodedImage, "New York", "9th November", "accompany", agents);
            mpegs.Add(mpeg);
            //manager.AddMpegToXml(mpeg);
            mpeg = new Mpeg("kick", "fight", encodedImage, "Beirut", "winter", "fighting", agents);
            mpegs.Add(mpeg);
            //manager.AddMpegToXml(mpeg);
            foreach(Mpeg m in mpegs )
            {
                txtLabel.Text = m.Time;
            }
            mpeg = new Mpeg("punch", "fight", encodedImage, "Japan", "noon", "fighting", agents);
            //manager.AddMpegToXml(mpeg);
            manager.MigrateXmlToDb();
            Mpeg queryTestMpeg = new Mpeg("", "fight", "", "", "", "", agents);
            manager.QueryImages(queryTestMpeg);
        }

    } 
}