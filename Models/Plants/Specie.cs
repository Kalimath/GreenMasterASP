using System.ComponentModel;
using GreenMaster.Models.Plants.Properties;

namespace GreenMaster.Models.Plants
{
    public class Specie
    {
        private string _scientificName = "";
        private string _commonName = "";
        public int Id { get; set; }

        [DisplayName("Scientific name")]
        public string ScientificName
        {
            get => _scientificName;
            set => _scientificName = value ?? throw new ArgumentNullException(nameof(value));
        }

        [DisplayName("Common name")]
        public string CommonName
        {
            get => _commonName;
            set
            {
                if (!AtLeastOneNameNotNullOrEmpty(ScientificName,CommonName))
                    throw new ArgumentException("Scientific- or Common name needs to be filled in", nameof(value));
                _commonName = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public string? Shape { get; set; }
        public string? FruitingPeriod { get; set; }
        public string HardinessZone { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string LifeCycle { get; set; } = null!;
        public string Toxicity { get; set; } = null!;
        public string? Fruit { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string? Attractant { get; set; }
        public int MaintenanceLevel { get; set; }

        [DisplayName("Attractant")]
        public virtual WildlifeAttractant? AttractantNavigation { get; set; }
        [DisplayName("Fruittype")]
        public virtual FruitType? FruitNavigation { get; set; }
        [DisplayName("Fruiting period")]
        public virtual Period? FruitingPeriodNavigation { get; set; }
        [DisplayName("Hardiness zone")]
        public virtual HardinessZone HardinessZoneNavigation { get; set; } = null!;
        [DisplayName("Lifecycle")]
        public virtual LifeCycle LifeCycleNavigation { get; set; } = null!;
        [DisplayName("maintenance-level")]
        public virtual Rating MaintenanceLevelNavigation { get; set; } = null!;
        [DisplayName("Shape")]
        public virtual Shape? ShapeNavigation { get; set; }
        [DisplayName("Toxicity")]
        public virtual Toxicity ToxicityNavigation { get; set; } = null!;
        [DisplayName("Type")]
        public virtual PlantType TypeNavigation { get; set; } = null!;

        public bool AtLeastOneNameNotNullOrEmpty(string? name1, string? name2)
        {
            return !(string.IsNullOrEmpty(name1) && string.IsNullOrEmpty(name2));
        }
    }
}
