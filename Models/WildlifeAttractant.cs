﻿using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class WildlifeAttractant
    {
        public WildlifeAttractant()
        {
            Species = new HashSet<Specie>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; }
    }
}
