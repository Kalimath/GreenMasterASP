using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Size
    {
        public Size()
        {
            Flowers = new HashSet<Flower>();
            Leaves = new HashSet<Leaf>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; }
        public virtual ICollection<Leaf> Leaves { get; set; }
    }
}
