namespace GreenMaster.Models.Plants.Properties
{
    public class LifeCycle
    {
        public string Type { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
