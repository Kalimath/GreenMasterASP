using System;
using System.Collections.Generic;

namespace GreenMaster.Models
{
    public partial class Specie
    {
        public int Id { get; set; }
        public string ScientificName { get; set; } = null!;
        public string CommonName { get; set; } = null!;
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

        public virtual WildlifeAttractant? AttractantNavigation { get; set; }
        public virtual FruitType? FruitNavigation { get; set; }
        public virtual Period? FruitingPeriodNavigation { get; set; }
        public virtual HardinessZone HardinessZoneNavigation { get; set; } = null!;
        public virtual LifeCycle LifeCycleNavigation { get; set; } = null!;
        public virtual Rating MaintenanceLevelNavigation { get; set; } = null!;
        public virtual Shape? ShapeNavigation { get; set; }
        public virtual Toxicity ToxicityNavigation { get; set; } = null!;
        public virtual PlantType TypeNavigation { get; set; } = null!;
    }
}
