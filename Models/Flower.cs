using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Flower
    {
        public int Id { get; set; }
        public string Size { get; set; } = null!;
        public string? Color { get; set; }
        public string BloomingPeriod { get; set; } = null!;
        public string Type { get; set; } = null!;

        public virtual Period BloomingPeriodNavigation { get; set; } = null!;
        public virtual Color? ColorNavigation { get; set; }
        public virtual Size SizeNavigation { get; set; } = null!;
    }
}
