using MPEGtest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MPEGtest
{
    public partial class Form2 : Form
    {
        public HashSet<Mpeg> mpegs { get; set; }
        private string xmlPath = "C:\\Users\\Lenovo\\Desktop\\projet mult\\test.xml";
        private string imgPath = "C:\\Users\\Lenovo\\Desktop\\projet mult\\dog.JPG";

        public Form2()
        {
            InitializeComponent();
            MpegManager manager = new MpegManager(xmlPath);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MpegManager manager = new MpegManager(xmlPath);

            String Concept = ConceptTxt.Text;
            String Event = EventTxt.Text;
            String Place = PlaceTxt.Text;
            String Time = TimeTxt.Text;
            String agent = AgentTxt.Text;
            String Relation = RelationTxt.Text;
            if(Concept==null)
            {
                Concept = " ";
            }
            if (Event == null)
            {
                Event = " ";
            }
            if (Place == null)
            {
                Place = " ";
            }
            if (Time == null)
            {
                Time = " ";
            }
            if (agent== null)
            {
                agent = " ";
            }
            if (Relation == null)
            {
                Relation = " ";
            }

            HashSet<Agent> agents = new HashSet<Agent> { new Agent(agent) };
            Mpeg queryTestMpeg = new Mpeg(Event, Concept," ", Place, Time, Relation, agents);
           
            HashSet<Mpeg> result = manager.QueryImages(queryTestMpeg);

            foreach (var r in result)
            {
             Image image = manager.GetImageFromBase64(r.Image);
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form1 frame = new Form1();
            //frame.Show();
            this.Close();
        }
    }
}
