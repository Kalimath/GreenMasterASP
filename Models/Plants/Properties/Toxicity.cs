namespace GreenMaster.Models.Plants.Properties
{
    public class Toxicity
    {
        public string Description { get; set; } = null!;

        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
