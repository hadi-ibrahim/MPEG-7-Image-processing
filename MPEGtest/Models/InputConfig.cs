using System;
using System.Collections.Generic;

namespace MPEGtest.Models
{
    public class InputConfig
    {
        public List<decimal> Values { get; set; }
        public decimal IncrementBy { get; set; }
        public decimal DefaultValue { get; set; }
        public bool Show = false;
    }
}