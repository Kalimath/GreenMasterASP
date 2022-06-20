using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class HardinessZone
    {
        public HardinessZone()
        {
            Species = new HashSet<Specie>();
        }

        public string Id { get; set; } = null!;
        public double MinTemperature { get; set; }

        public virtual ICollection<Specie> Species { get; set; }
    }
}
