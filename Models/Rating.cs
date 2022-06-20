using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Rating
    {
        public Rating()
        {
            Species = new HashSet<Specie>();
        }

        public int Score { get; set; }

        public virtual ICollection<Specie> Species { get; set; }
    }
}
