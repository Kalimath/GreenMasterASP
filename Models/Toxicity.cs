using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Toxicity
    {
        public Toxicity()
        {
            Species = new HashSet<Specie>();
        }

        public string Description { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; }
    }
}
