namespace GreenMaster.Models.Plants.Properties
{
    public class HardinessZone
    {
        public string Id { get; set; } = null!;
        public double MinTemperature { get; set; }

        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
