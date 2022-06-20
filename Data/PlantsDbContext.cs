using System;
using System.Collections.Generic;
using GreenMaster.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GreenMaster.Data
{
    public partial class PlantsDbContext : DbContext
    {
        public PlantsDbContext()
        {
        }

        public PlantsDbContext(DbContextOptions<PlantsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Container> Containers { get; set; } = null!;
        public virtual DbSet<Flower> Flowers { get; set; } = null!;
        public virtual DbSet<FruitType> FruitTypes { get; set; } = null!;
        public virtual DbSet<Function> Functions { get; set; } = null!;
        public virtual DbSet<HardinessZone> HardinessZones { get; set; } = null!;
        public virtual DbSet<Leaf> Leaves { get; set; } = null!;
        public virtual DbSet<LifeCycle> LifeCycles { get; set; } = null!;
        public virtual DbSet<Period> Periods { get; set; } = null!;
        public virtual DbSet<PhPreference> PhPreferences { get; set; } = null!;
        public virtual DbSet<PlantPart> PlantParts { get; set; } = null!;
        public virtual DbSet<PlantType> PlantTypes { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Resistance> Resistances { get; set; } = null!;
        public virtual DbSet<Shape> Shapes { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Specie> Species { get; set; } = null!;
        public virtual DbSet<SuitableLocation> SuitableLocations { get; set; } = null!;
        public virtual DbSet<Toxicity> Toxicities { get; set; } = null!;
        public virtual DbSet<WildlifeAttractant> WildlifeAttractants { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("color_pk");

                entity.ToTable("color", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("container", "properties");

                entity.Property(e => e.SizeFk)
                    .HasColumnType("character varying")
                    .HasColumnName("size_fk");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.HasOne(d => d.SizeFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SizeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("container_size_name_fk");
            });

            modelBuilder.Entity<Flower>(entity =>
            {
                entity.ToTable("flower", "encyclopedia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BloomingPeriod)
                    .HasColumnType("character varying")
                    .HasColumnName("blooming_period");

                entity.Property(e => e.Color)
                    .HasColumnType("character varying")
                    .HasColumnName("color");

                entity.Property(e => e.Size)
                    .HasColumnType("character varying")
                    .HasColumnName("size");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.HasOne(d => d.BloomingPeriodNavigation)
                    .WithMany(p => p.Flowers)
                    .HasForeignKey(d => d.BloomingPeriod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flower_period_name_fk");

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Flowers)
                    .HasForeignKey(d => d.Color)
                    .HasConstraintName("flower_color_name_fk");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Flowers)
                    .HasForeignKey(d => d.Size)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flower_size_name_fk");
            });

            modelBuilder.Entity<FruitType>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("fruit_type_pk");

                entity.ToTable("fruit_type", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.HasKey(e => e.Column1)
                    .HasName("function_pk");

                entity.ToTable("function", "properties");

                entity.Property(e => e.Column1).HasColumnName("column_1");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HardinessZone>(entity =>
            {
                entity.ToTable("hardiness_zone", "encyclopedia");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.MinTemperature).HasColumnName("min_temperature");
            });

            modelBuilder.Entity<Leaf>(entity =>
            {
                entity.ToTable("leaf", "properties");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasColumnType("character varying")
                    .HasColumnName("color");

                entity.Property(e => e.Size)
                    .HasColumnType("character varying")
                    .HasColumnName("size");

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.Color)
                    .HasConstraintName("leaf_color_name_fk");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("leaf_size_name_fk");
            });

            modelBuilder.Entity<LifeCycle>(entity =>
            {
                entity.HasKey(e => e.Type)
                    .HasName("life_cycle_pk");

                entity.ToTable("life_cycle", "properties");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("period_pk");

                entity.ToTable("period", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PhPreference>(entity =>
            {
                entity.ToTable("ph_preference", "properties");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PhMax).HasColumnName("ph_max");

                entity.Property(e => e.PhMin).HasColumnName("ph_min");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<PlantPart>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("plant_part_pk");

                entity.ToTable("plant_part", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PlantType>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("plant_type_pk");

                entity.ToTable("plant_type", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.Score)
                    .HasName("rating_pk");

                entity.ToTable("rating", "properties");

                entity.Property(e => e.Score)
                    .ValueGeneratedNever()
                    .HasColumnName("score");
            });

            modelBuilder.Entity<Resistance>(entity =>
            {
                entity.HasKey(e => e.Type)
                    .HasName("resistance_pk");

                entity.ToTable("resistance", "properties");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Shape>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("shape_pk");

                entity.ToTable("shape", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("size_pk");

                entity.ToTable("size", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.ToTable("specie", "encyclopedia");

                entity.HasIndex(e => e.ScientificName, "specie_scientific_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attractant)
                    .HasColumnType("character varying")
                    .HasColumnName("attractant");

                entity.Property(e => e.CommonName)
                    .HasColumnType("character varying")
                    .HasColumnName("common_name");

                entity.Property(e => e.Fruit)
                    .HasColumnType("character varying")
                    .HasColumnName("fruit");

                entity.Property(e => e.FruitingPeriod)
                    .HasColumnType("character varying")
                    .HasColumnName("fruiting_period");

                entity.Property(e => e.HardinessZone)
                    .HasColumnType("character varying")
                    .HasColumnName("hardiness_zone")
                    .HasDefaultValueSql("'8a'::character varying");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.LifeCycle)
                    .HasColumnType("character varying")
                    .HasColumnName("life_cycle");

                entity.Property(e => e.MaintenanceLevel).HasColumnName("maintenance_level");

                entity.Property(e => e.ScientificName)
                    .HasColumnType("character varying")
                    .HasColumnName("scientific_name");

                entity.Property(e => e.Shape)
                    .HasColumnType("character varying")
                    .HasColumnName("shape");

                entity.Property(e => e.Toxicity)
                    .HasColumnType("character varying")
                    .HasColumnName("toxicity");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.AttractantNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Attractant)
                    .HasConstraintName("specie_wildlife_attractant_name_fk");

                entity.HasOne(d => d.FruitNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Fruit)
                    .HasConstraintName("specie_fruit_type_name_fk");

                entity.HasOne(d => d.FruitingPeriodNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.FruitingPeriod)
                    .HasConstraintName("specie_period_name_fk");

                entity.HasOne(d => d.HardinessZoneNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.HardinessZone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_hardiness_zone_id_fk");

                entity.HasOne(d => d.LifeCycleNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.LifeCycle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_life_cycle_type_fk");

                entity.HasOne(d => d.MaintenanceLevelNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.MaintenanceLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_rating_score_fk");

                entity.HasOne(d => d.ShapeNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Shape)
                    .HasConstraintName("specie_shape_name_fk");

                entity.HasOne(d => d.ToxicityNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Toxicity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_toxicity_description_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_plant_type_name_fk");
            });

            modelBuilder.Entity<SuitableLocation>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("suitable_location_pk");

                entity.ToTable("suitable_location", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Toxicity>(entity =>
            {
                entity.HasKey(e => e.Description)
                    .HasName("toxicity_pk");

                entity.ToTable("toxicity", "properties");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");
            });

            modelBuilder.Entity<WildlifeAttractant>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("wildlife_attractant_pk");

                entity.ToTable("wildlife_attractant", "properties");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
