using System;
using System.Collections.Generic;
using GreenMaster.Models.Plants;

namespace GreenMaster.Models
{
    public class Container
    {
        public string Type { get; set; } = null!;
        public string SizeFk { get; set; } = null!;
        public virtual Size SizeFkNavigation { get; set; } = null!;
    }
}
