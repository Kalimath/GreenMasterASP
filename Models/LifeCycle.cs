using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class LifeCycle
    {
        public LifeCycle()
        {
            Species = new HashSet<Specie>();
        }

        public string Type { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; }
    }
}
