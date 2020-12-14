using System;

namespace MPEGtest.Models
{
    public class SingleFilterConfiguration
    {
        public string FrameName { get; set; }
        public Object Filter { get; set; }
        
        public InputConfig SliderConfig { get; set; }
        public InputConfig NumberInputsConfig { get; set; }
    }
}