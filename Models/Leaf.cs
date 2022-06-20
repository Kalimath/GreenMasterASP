using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Leaf
    {
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Id { get; set; }

        public virtual Color? ColorNavigation { get; set; }
        public virtual Size? SizeNavigation { get; set; }
    }
}
