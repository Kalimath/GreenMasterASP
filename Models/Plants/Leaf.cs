using GreenMaster.Models.Plants.Properties;

namespace GreenMaster.Models.Plants
{
    public class Leaf
    {
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Id { get; set; }

        public virtual Color? ColorNavigation { get; set; }
        public virtual Size? SizeNavigation { get; set; }
    }
}
