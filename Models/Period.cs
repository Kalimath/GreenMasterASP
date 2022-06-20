using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Period
    {
        public Period()
        {
            Flowers = new HashSet<Flower>();
            Species = new HashSet<Specie>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; }
        public virtual ICollection<Specie> Species { get; set; }
    }
}
