using System.ComponentModel.DataAnnotations;

namespace GreenMaster.Models
{
    public class Specie
    {
        
        public string ScientificName { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please define if specie is resistant against frost")]
        public bool FrostResistant { get; set; }

        [Required(ErrorMessage = "Please define months when specie is flowering")]
        public int[] FlowerPeriod { get; set; }

        [Required(ErrorMessage = "Please define the location towards the sun")]
        public SunRequirement Location { get; set; }

        [Required(ErrorMessage = "Please define if specie is evergreen")]
        public bool Evergreen { get; set; }

        public Specie(string scientificName, string name, string description, bool frostResistant, int[] flowerPeriod, SunRequirement location, bool evergreen)
        {
            ScientificName = scientificName;
            Name = name;
            Description = description;
            FrostResistant = frostResistant;
            FlowerPeriod = flowerPeriod;
            Location = location;
            Evergreen = evergreen;
        }
    }
}
