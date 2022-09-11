namespace GreenMaster.Models.Plants
{
    public class Size
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Flower> Flowers { get; set; } = new HashSet<Flower>();
        public virtual ICollection<Leaf> Leaves { get; set; } = new HashSet<Leaf>();
    }
}
