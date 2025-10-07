using System.Configuration;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave;

public class MedSaveContext : DbContext
{
    public DbSet<ActiveIngredient> ActiveIngredient { get; set; }
    public DbSet<AddressManufacturer> AddressManufacturer { get; set; }
    public DbSet<AddressStock> AddressStock { get; set; }
    public DbSet<Batch> Batch { get; set; }
    public DbSet<CategoryMedicine> CategoryMedicine { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<ContactManufacturer> ContactManufacturer { get; set; }
    public DbSet<ContactUser> ContactUser { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
    public DbSet<MedicineDispense> MedicineDispense { get; set; }
    public DbSet<Medicines> Medicines { get; set; }
    public DbSet<MovementType> MovementType { get; set; }
    public DbSet<Neighbourhood> Neighbourhood { get; set; }
    public DbSet<PharmaceuticalForm> PharmaceuticalForm { get; set; }
    public DbSet<PositionUser> PositionUser { get; set; }
    public DbSet<ProfileUser> ProfileUser { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<UnitMeasure> UnitMeasure { get; set; }
    public DbSet<UsersSys> UsersSys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle(ConfigurationManager.ConnectionStrings["MedSave"]?.ConnectionString ?? "Data Source=//oracle.fiap.com.br:1521/orcl;User Id=rm560485; Password=fiap25;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveIngredient>(entity =>
        {
            entity.ToTable("ACTIVE_INGREDIENT");

            entity.HasKey(e => e.ActIngreId)
                  .HasName("PK_ACTIVE_INGREDIENT");

            entity.Property(e => e.ActIngreId)
                .HasColumnName("ACT_INGRE_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ActIngredient)
                .HasColumnName("ACT_INGREDIENT")
                .HasColumnType("VARCHAR2(200)")
                .IsRequired();
        });

        modelBuilder.Entity<AddressManufacturer>(entity =>
        {
            entity.ToTable("ADDRESS_MANUFACTURER");

            entity.HasKey(e => e.AddressIdManufacturer)
                .HasName("PK_ADDRESS_MANUFACTURER");

            entity.Property(e => e.AddressIdManufacturer)
                .HasColumnName("ADDRESS_ID_MANUFACTURER")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Complement)
                .HasColumnName("COMPLEMENT")
                .HasColumnType("VARCHAR2(255)");

            entity.Property(e => e.Number)
                .HasColumnName("NUMBER")
                .HasColumnType("NUMBER(7)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasColumnType("NUMBER(8)")
                .IsRequired();

            entity.Property(e => e.NeighId)
                .HasColumnName("NEIGH_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.Neighbourhood)
                .WithOne()
                .HasForeignKey<AddressManufacturer>(e => e.NeighId)
                .HasConstraintName("FK_NEIGHBOURHOOD_ADDRESS_MANUFACTURER");
        });

        modelBuilder.Entity<AddressStock>(entity =>
        {
            entity.ToTable("ADDRESS_STOCK");

            entity.HasKey(e => e.AddressIdStock)
                .HasName("PK_ADDRESS_STOCK");

            entity.Property(e => e.AddressIdStock)
                .HasColumnName("ADDRESS_ID_STOCK")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Complement)
                .HasColumnName("COMPLEMENT")
                .HasColumnType("VARCHAR2(255)");

            entity.Property(e => e.Number)
                .HasColumnName("NUMBER")
                .HasColumnType("NUMBER(7)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasColumnType("NUMBER(8)")
                .IsRequired();

            entity.Property(e => e.NeighId)
                .HasColumnName("NEIGH_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.Neighbourhood)
                .WithOne()
                .HasForeignKey<AddressStock>(e => e.NeighId)
                .HasConstraintName("FK_NEIGHBOURHOOD_ADDRESS_STOCK");
        });

        modelBuilder.Entity<Batch>(entity =>
        {
            entity.ToTable("BATCH");

            entity.HasKey(e => e.BatchId)
                .HasName("PK_BATCH");

            entity.Property(e => e.BatchId)
                .HasColumnName("BATCH_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CurrentQuantity)
                .HasColumnName("CURRENT_QUANTITY")
                .HasColumnType("NUMERIC")
                .IsRequired();

            entity.Property(e => e.ManufacturingDate)
                .HasColumnName("MANUFACTURING_DATE")
                .HasColumnType("DATE")
                .IsRequired();
            
            entity.Property(e => e.ExpirationDate)
                .HasColumnName("EXPIRATION_DATE")
                .HasColumnType("DATE")
                .IsRequired();

            entity.Property(e => e.ManufacId)
                .HasColumnName("MANUFAC_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.Manufacturer)
                .WithOne()
                .HasForeignKey<Batch>(e => e.ManufacId)
                .HasConstraintName("FK_MANUFACTURER_BATCH");
        });

        modelBuilder.Entity<CategoryMedicine>(entity =>
        {
            entity.ToTable("CATEGORY_MEDICINE");

            entity.HasKey(e => e.CategoryMedId)
                .HasName("PK_CATEGORY_MEDICINE");

            entity.Property(e => e.CategoryMedId)
                .HasColumnName("CATEGORY_MED_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Category)
                .HasColumnName("CATEGORY")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("CITY");

            entity.HasKey(e => e.CityId)
                .HasName("PK_CITY");

            entity.Property(e => e.CityId)
                .HasColumnName("CITY_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.NameCity)
                .HasColumnName("NAME_CITY")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();
        });

        /*
         1:1
         entity.Property(e => e.NeighId)
                .HasColumnName("NEIGH_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.Neighbourhood)
                .WithOne()
                .HasForeignKey<AddressStock>(e => e.NeighId)
                .HasConstraintName("FK_NEIGHBOURHOOD_ADDRESS_STOCK");
         */

    }
}