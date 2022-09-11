namespace GreenMaster.Models.Plants.Properties
{
    public class Rating
    {
        public int Score { get; set; }

        public virtual ICollection<Specie> Species { get; set; } = new HashSet<Specie>();
    }
}
