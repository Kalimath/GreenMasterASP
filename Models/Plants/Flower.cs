using GreenMaster.Models.Plants.Properties;

namespace GreenMaster.Models.Plants
{
    public class Flower
    {
        public int Id { get; set; }
        public string Size { get; set; } = null!;
        public string? Color { get; set; }
        public string BloomingPeriod { get; set; } = null!;
        public string Type { get; set; } = null!;
        public virtual Period BloomingPeriodNavigation { get; set; }
        public virtual Color ColorNavigation { get; set; }
        public virtual Size SizeNavigation { get; set; } = null!;
    }
}
