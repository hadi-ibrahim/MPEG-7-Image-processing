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

        public Mpeg(string evt, string concept, string image, string place, DateTime time, string relation, HashSet<Agent> agents)
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
        public DateTime? Time { get; set; }
        public string Relation { get; set; }

        public virtual HashSet<Agent> Agents { get; set; }
    }
}
