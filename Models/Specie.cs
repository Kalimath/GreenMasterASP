using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace GreenMaster.Models
{
    [Table("Specie")]
    public class Specie
    {
        [Key]
        [Column("scientific_name", TypeName = "nvarchar")]
        public string ScientificName { get; set; }

        [Column("trivial_name", TypeName = "nvarchar")]
        [Required(ErrorMessage = "Please enter the trivial name")]
        public string TrivialName { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string? Description { get; set; }

        [Column("frost_resistance")]
        [Required(ErrorMessage = "Please define if specie's resistance against frost")]
        public FrostResistance FrostResistance { get; set; }

        [Column("flower_period")]
        [Required(ErrorMessage = "Please define months when specie is flowering")]
        public ICollection<Month> FlowerPeriod { get; set; }

        [Required(ErrorMessage = "Please define the location towards the sun")]
        public SunRequirement Location { get; set; }

        [Required(ErrorMessage = "Please define if specie is evergreen")]
        public bool Evergreen { get; set; }

        [Column("image")]
        public string Image { get; set; }
        



        public Specie(string scientificName, string trivialName, string description, FrostResistance frostResistance, ICollection<Month> flowerPeriod, SunRequirement location, bool evergreen, string image)
        {
            ScientificName = scientificName;
            TrivialName = trivialName;
            Description = description;
            this.FrostResistance = frostResistance;
            FlowerPeriod = flowerPeriod;
            Location = location;
            Evergreen = evergreen;
            Image = image;
        }
    }
}
