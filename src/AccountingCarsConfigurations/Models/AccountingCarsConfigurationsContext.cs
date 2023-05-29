using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Models;

public partial class AccountingCarsConfigurationsContext : DbContext
{
    public AccountingCarsConfigurationsContext()
    {
    }

    public AccountingCarsConfigurationsContext(DbContextOptions<AccountingCarsConfigurationsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchiveBodyType> ArchiveBodyTypes { get; set; }

    public virtual DbSet<ArchiveCar> ArchiveCars { get; set; }

    public virtual DbSet<ArchiveCategory> ArchiveCategories { get; set; }

    public virtual DbSet<ArchiveConfiguration> ArchiveConfigurations { get; set; }

    public virtual DbSet<ArchiveConfigurationComposition> ArchiveConfigurationCompositions { get; set; }

    public virtual DbSet<ArchiveConfigurationSet> ArchiveConfigurationSets { get; set; }

    public virtual DbSet<ArchiveLog> ArchiveLogs { get; set; }

    public virtual DbSet<ArchiveManufacturer> ArchiveManufacturers { get; set; }

    public virtual DbSet<ArchiveModel> ArchiveModels { get; set; }

    public virtual DbSet<ArchiveModification> ArchiveModifications { get; set; }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<ConfigurationComposition> ConfigurationCompositions { get; set; }

    public virtual DbSet<ConfigurationSet> ConfigurationSets { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Modification> Modifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<ArchiveBodyType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_body_types", "archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ArchiveCar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_cars", "archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBodyType).HasColumnName("id_body_type");
            entity.Property(e => e.IdModel).HasColumnName("id_model");
            entity.Property(e => e.ProductionYear).HasColumnName("production_year");
        });

        modelBuilder.Entity<ArchiveCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_categories", "archive");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ArchiveConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_configurations", "archive");

            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<ArchiveConfigurationComposition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_configuration_compositions", "archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdConfiguration).HasColumnName("id_configuration");
            entity.Property(e => e.IdModification).HasColumnName("id_modification");
        });

        modelBuilder.Entity<ArchiveConfigurationSet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_configuration_sets", "archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.IdConfiguration).HasColumnName("id_configuration");
        });

        modelBuilder.Entity<ArchiveLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_logs", "archive");

            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.ActionsDate).HasColumnName("actions_date");
            entity.Property(e => e.Actor).HasColumnName("actor");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<ArchiveManufacturer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_manufacturers", "archive");

            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Info)
                .HasColumnType("jsonb")
                .HasColumnName("info");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ArchiveModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_models", "archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ArchiveModification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("archive_modifications", "archive");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("body_types_pkey");

            entity.ToTable("body_types");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cars_pkey");

            entity.ToTable("cars");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.IdBodyType).HasColumnName("id_body_type");
            entity.Property(e => e.IdModel).HasColumnName("id_model");
            entity.Property(e => e.ProductionYear).HasColumnName("production_year");

            entity.HasOne(d => d.IdBodyTypeNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdBodyType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cars_id_body_type_fkey");

            entity.HasOne(d => d.IdModelNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdModel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cars_id_model_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'Описание отсутствует'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("configurations_pkey");

            entity.ToTable("configurations");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Availability)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("availability");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'Описание отсутствует'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<ConfigurationComposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("configuration_compositions_pkey");

            entity.ToTable("configuration_compositions");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.IdConfiguration).HasColumnName("id_configuration");
            entity.Property(e => e.IdModification).HasColumnName("id_modification");

            entity.HasOne(d => d.IdConfigurationNavigation).WithMany(p => p.ConfigurationCompositions)
                .HasForeignKey(d => d.IdConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("configuration_compositions_id_configuration_fkey");

            entity.HasOne(d => d.IdModificationNavigation).WithMany(p => p.ConfigurationCompositions)
                .HasForeignKey(d => d.IdModification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("configuration_compositions_id_modification_fkey");
        });

        modelBuilder.Entity<ConfigurationSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("configuration_sets_pkey");

            entity.ToTable("configuration_sets");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.IdConfiguration).HasColumnName("id_configuration");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.ConfigurationSets)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("configuration_sets_id_car_fkey");

            entity.HasOne(d => d.IdConfigurationNavigation).WithMany(p => p.ConfigurationSets)
                .HasForeignKey(d => d.IdConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("configuration_sets_id_configuration_fkey");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logs_pkey");

            entity.ToTable("logs");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.ActionsDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("actions_date");
            entity.Property(e => e.Actor)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("actor");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufacturers_pkey");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Info)
                .HasColumnType("jsonb")
                .HasColumnName("info");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("models_pkey");

            entity.ToTable("models");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("models_id_manufacturer_fkey");
        });

        modelBuilder.Entity<Modification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modifications_pkey");

            entity.ToTable("modifications");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'Описание отсутсвует'::text")
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modifications_id_category_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
