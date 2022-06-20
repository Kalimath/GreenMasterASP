using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Container
    {
        public string Type { get; set; } = null!;
        public string SizeFk { get; set; } = null!;

        public virtual Size SizeFkNavigation { get; set; } = null!;
    }
}
