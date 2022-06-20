using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Color
    {
        public Color()
        {
            Flowers = new HashSet<Flower>();
            Leaves = new HashSet<Leaf>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; }
        public virtual ICollection<Leaf> Leaves { get; set; }
    }
}
