﻿namespace GreenMaster.Models.Plants.Properties
{
    public class Shape
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
