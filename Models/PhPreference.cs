using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public class PhPreference
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public double PhMin { get; set; }
        public double PhMax { get; set; }
    }
}
