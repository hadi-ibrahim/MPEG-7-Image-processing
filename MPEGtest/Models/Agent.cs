using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace MPEGtest.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Mpegs = new HashSet<Mpeg>();
        }

        public Agent(string name)
        {
            this.Name = name;
        }
        [XmlIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual HashSet<Mpeg> Mpegs { get; set; }

        public override bool Equals(Object obj)
        {
            Agent agent = obj as Agent;
            if (agent == null)
                return false;
            else
            {
                return Name.Equals(agent.Name);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
