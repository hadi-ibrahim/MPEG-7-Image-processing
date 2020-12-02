using System;
using System.Collections.Generic;

#nullable disable

namespace MPEGtest.Models
{
    public partial class MpegAgent
    {
        public int IdMpeg { get; set; }
        public int IdAgent { get; set; }

        public virtual Agent IdAgentNavigation { get; set; }
        public virtual Mpeg IdMpegNavigation { get; set; }
    }
}
