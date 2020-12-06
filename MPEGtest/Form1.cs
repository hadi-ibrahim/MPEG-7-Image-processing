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
        private string xmlPath = "C:\\Users\\Lenovo\\Desktop\\projet mult\\test.xml";
        private string imgPath = "C:\\Users\\Lenovo\\Desktop\\projet mult\\dog.JPG";
        
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
               // txtLabel.Text = m.Time;
            }
            mpeg = new Mpeg("punch", "fight", encodedImage, "Japan", "noon", "fighting", agents);
            //manager.AddMpegToXml(mpeg);
            manager.MigrateXmlToDb();
            Mpeg queryTestMpeg = new Mpeg("", "fight", "", "", "", "", agents);
            manager.QueryImages(queryTestMpeg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)| All Files(*.*)|*.*|";
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    ImageTxt.Text = imageLocation;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            this.Close();
            
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MpegManager manager = new MpegManager(xmlPath);
         
            String Concept = ConceptTxt.Text;
            String Event = EventTxt.Text;
            String Place = PlaceTxt.Text;
            String Time = TimeTxt.Text;
            String ImagePath = ImageTxt.Text;
            String agent = AgentTxt.Text;
            String Relation = RelationTxt.Text;

            HashSet<Agent> agents = new HashSet<Agent> { new Agent(agent)};
            string encodedImage = manager.GetBase64StringFromImage(ImagePath);
            Mpeg mpeg = new Mpeg( Event,Concept,encodedImage,Place,Time,Relation,agents);
            manager.AddMpegToXml(mpeg);
           
            manager.MigrateXmlToDb();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 frame = new Form2();
            frame.Show();
            
        }
    } 
}