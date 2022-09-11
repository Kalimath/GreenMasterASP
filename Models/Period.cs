using System;
using System.Collections.Generic;
using GreenMaster.Models.Plants;

namespace GreenMaster.Models
{
    public class Period
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; } = new HashSet<Flower>();
        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
