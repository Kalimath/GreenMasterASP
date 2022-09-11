namespace GreenMaster.Models.Plants.Properties
{
    public class Color
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; } = new HashSet<Flower>();
        public virtual ICollection<Leaf> Leaves { get; set; } = new HashSet<Leaf>();
    }
}
