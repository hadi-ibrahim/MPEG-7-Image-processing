using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace MPEGtest.Models
{
    public partial class Mpeg
    {
        public Mpeg()
        {
            Agents = new HashSet<Agent>();
        }

        public Mpeg(string evt, string concept, string image, string place, string time, string relation, HashSet<Agent> agents)
        {
            this.Evt = evt;
            this.Concept = concept;
            this.Image = image;
            this.Place = place;
            this.Time = time;
            this.Relation = relation;
            this.Agents = agents;

        }

        [XmlIgnore]
        public int Id { get; set; }
        public string Evt { get; set; }
        public string Concept { get; set; }
        public string Image { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public string Relation { get; set; }

        public virtual HashSet<Agent> Agents { get; set; }

        public override bool Equals(Object obj)
        {
            Mpeg mpeg = obj as Mpeg;
            if (mpeg == null)
                return false;
            else
            {
                bool flag = true;
                if (!Concept.Equals(mpeg.Concept)) flag = false;
                if (!Evt.Equals(mpeg.Evt)) flag = false;
                if (!Image.Equals(mpeg.Image))flag = false;
                if (!Place.Equals(mpeg.Place))flag = false;
                if (!Time.Equals(mpeg.Time))flag = false;
                if (!Relation.Equals(mpeg.Relation))flag = false;
                foreach (var agent in Agents )
                {
                    if (!mpeg.Agents.Contains(agent))
                        flag = false;
                }
                return flag;
            }
        }
    }
}
