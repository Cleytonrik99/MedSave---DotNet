using System.Configuration;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave;

public class MedSaveContext : DbContext
{
    public DbSet<ActiveIngredient> ActiveIngredient { get; set; }
    public DbSet<AddressManufacturer> AddressManufacturer { get; set; }
    public DbSet<AddressStock> AddressStock { get; set; }
    public DbSet<BatchMedicine> BatchMedicine { get; set; }
    public DbSet<CategoryMedicine> CategoryMedicine { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<ContactManufacturer> ContactManufacturer { get; set; }
    public DbSet<ContactUser> ContactUser { get; set; }
    public DbSet<LocationStock> LocationStock { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
    public DbSet<MedicineDispense> MedicineDispense { get; set; }
    public DbSet<Medicines> Medicines { get; set; }
    public DbSet<MovementType> MovementType { get; set; }
    public DbSet<Neighbourhood> Neighbourhood { get; set; }
    public DbSet<PharmaceuticalForm> PharmaceuticalForm { get; set; }
    public DbSet<PositionUser> PositionUser { get; set; }
    public DbSet<ProfileUser> ProfileUser { get; set; }
    public DbSet<States> States { get; set; }
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

            entity.Property(e => e.NumberManu)
                .HasColumnName("NUMBER_MANU")
                .HasColumnType("NUMBER(7)")
                .IsRequired();

            entity.Property(e => e.AddressDescription)
                .HasColumnName("ADDRESS_DESCRIPTION")
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

            entity.Property(e => e.NumberStock)
                .HasColumnName("NUMBER_STOCK")
                .HasColumnType("NUMBER(7)")
                .IsRequired();

            entity.Property(e => e.AddressDescription)
                .HasColumnName("ADDRESS_DESCRIPTION")
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

        modelBuilder.Entity<BatchMedicine>(entity =>
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
                .WithMany()
                .HasForeignKey(e => e.ManufacId)
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
            
            entity.Property(e => e.StateId)
                .HasColumnName("STATE_ID")
                .HasColumnType("NUMBER")
                .IsRequired();
            
            entity.HasOne(e => e.States)
                .WithMany()
                .HasForeignKey(e => e.StateId)
                .HasConstraintName("FK_STATES_CITY");
        });

        modelBuilder.Entity<ContactManufacturer>(entity =>
        {
            entity.ToTable("CONTACT_MANUFACTURER");

            entity.HasKey(e => e.ContactManuId)
                .HasName("PK_CONTACT_MANUFACTURER");

            entity.Property(e => e.ContactManuId)
                .HasColumnName("CONTACT_MANU_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.EmailManu)
                .HasColumnName("EMAIL_MANU")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.HasIndex(e => e.EmailManu)
                .IsUnique()
                .HasDatabaseName("UK_CONTACT_MANU_EMAIL");

            entity.Property(e => e.PhoneNumberManu)
                .HasColumnName("PHONE_NUMBER_MANU")
                .HasColumnType("NUMBER(11)")
                .IsRequired();

            entity.HasIndex(e => e.PhoneNumberManu)
                .IsUnique()
                .HasDatabaseName("UK_CONTACT_MANU_PHONE");
        });

        modelBuilder.Entity<ContactUser>(entity =>
        {
            entity.ToTable("CONTACT_USER");

            entity.HasKey(e => e.ContactUserId)
                .HasName("PK_CONTACT_USER");

            entity.Property(e => e.ContactUserId)
                .HasColumnName("CONTACT_USER_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.EmailUser)
                .HasColumnName("EMAIL_USER")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.HasIndex(e => e.EmailUser)
                .IsUnique()
                .HasDatabaseName("UK_CONTACT_USER_EMAIL");

            entity.Property(e => e.PhoneNumberUser)
                .HasColumnName("PHONE_NUMBER_USER")
                .HasColumnType("NUMBER(11)")
                .IsRequired();

            entity.HasIndex(e => e.PhoneNumberUser)
                .IsUnique()
                .HasDatabaseName("UK_CONTACT_USER_PHONE");
        });

        modelBuilder.Entity<LocationStock>(entity =>
        {
            entity.ToTable("LOCATION_STOCK");

            entity.HasKey(e => e.LocationId)
                .HasName("PK_LOCATION_STOCK");

            entity.Property(e => e.LocationId)
                .HasColumnName("LOCATION_ID_STOCK")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.NameLocation)
                .HasColumnName("NAME_LOCATION")
                .HasColumnType("VARCHAR2(30)")
                .IsRequired();

            entity.Property(e => e.LocationStockName)
                .HasColumnName("LOCATION_STOCK_NAME")
                .HasColumnType("VARCHAR2(100)")
                .IsRequired();
            
            entity.Property(e => e.AddressIdStock)
                .HasColumnName("ADDRESS_ID_STOCK")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.AddressStock)
                .WithOne()
                .HasForeignKey<LocationStock>(e => e.AddressIdStock)
                .HasConstraintName("FK_ADDRESS_STOCK_LOCATION_STOCK");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("MANUFACTURER");

            entity.HasKey(e => e.ManufacId)
                .HasName("PK_MANUFACTURER");

            entity.Property(e => e.ManufacId)
                .HasColumnName("MANUFAC_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.NameManu)
                .HasColumnName("NAME_MANU")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasColumnType("NUMBER(14)")
                .IsRequired();

            entity.HasIndex(e => e.Cnpj)
                .IsUnique()
                .HasDatabaseName("UK_MANUFACTURER_CNPJ");

            entity.Property(e => e.ContactManuId)
                .HasColumnName("CONTACT_MANU_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.ContactManufacturer)
                .WithOne()
                .HasForeignKey<Manufacturer>(e => e.ContactManuId)
                .HasConstraintName("FK_CONTACT_MANUFACTURER_MANUFACTURER");

            entity.Property(e => e.AddressIdManufacturer)
                .HasColumnName("ADDRESS_ID_MANUFACTURER")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.AddressManufacturer)
                .WithOne()
                .HasForeignKey<Manufacturer>(e => e.AddressIdManufacturer)
                .HasConstraintName("FK_ADDRESS_MANUFACTURER_MANUFACTURER");
        });

        modelBuilder.Entity<MedicineDispense>(entity =>
        {
            entity.ToTable("MEDICINE_DISPENSE");

            entity.HasKey(e => e.DispensationId)
                .HasName("PK_MEDICINE_DISPENSE");

            entity.Property(e => e.DispensationId)
                .HasColumnName("DATE_DISPENSATION")
                .HasColumnType("DATE")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.DateDispensation)
                .HasColumnName("DATE_DISPENSATION")
                .HasColumnType("DATE")
                .IsRequired();

            entity.Property(e => e.QuantityDispensed)
                .HasColumnName("QUANTITY_DISPENSED")
                .HasColumnType("NUMBER(5)")
                .IsRequired();

            entity.Property(e => e.Destination)
                .HasColumnName("DESTINATION")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.Observation)
                .HasColumnName("OBSERVATION")
                .HasColumnType("VARCHAR2(255)");

            entity.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.UsersSys)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_USERS_SYS_MEDICINE_DISPENSE");

            entity.Property(e => e.MovementTypeId)
                .HasColumnName("MOVEMENT_TYPE_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.MovementType)
                .WithMany()
                .HasForeignKey(e => e.MovementTypeId)
                .HasConstraintName("FK_MOVEMENT_TYPE_MEDICINE_DISPENSE");

            entity.Property(e => e.StockId)
                .HasColumnName("STOCK_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.Stock)
                .WithMany()
                .HasForeignKey(e => e.StockId)
                .HasConstraintName("FK_STOCK_MEDICINE_DISPENSE");
        });

        modelBuilder.Entity<Medicines>(entity =>
        {
            entity.ToTable("MEDICINES");

            entity.HasKey(e => e.MedicineId)
                .HasName("PK_MEDICINES");

            entity.Property(e => e.MedicineId)
                .HasColumnName("MEDICINE_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.NameMedication)
                .HasColumnName("NAME_MEDICATION")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.StatusMed)
                .HasColumnName("STATUS_MED")
                .HasColumnType("VARCHAR2(20)")
                .IsRequired();

            entity.Property(e => e.CategoryMedId)
                .HasColumnName("CATEGORY_MED_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.CategoryMedicine)
                .WithMany()
                .HasForeignKey(e => e.CategoryMedId)
                .HasConstraintName("FK_CATEGORY_MEDICINE_MEDICINES");

            entity.Property(e => e.UnitMeaId)
                .HasColumnName("UNIT_MEA_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.UnitMeasure)
                .WithMany()
                .HasForeignKey(e => e.UnitMeaId)
                .HasConstraintName("FK_UNIT_MEASURE_MEDICINES");

            entity.Property(e => e.PharmFormId)
                .HasColumnName("PHARM_FORM_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.PharmaceuticalForm)
                .WithMany()
                .HasForeignKey(e => e.PharmFormId)
                .HasConstraintName("FK_PHARMACEUTICAL_FORM_MEDICINES");

            entity.Property(e => e.ActIngreId)
                .HasColumnName("ACT_INGRE_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.ActiveIngredient)
                .WithMany()
                .HasForeignKey(e => e.ActIngreId)
                .HasConstraintName("FK_ACTIVE_INGREDIENT_MEDICINES");
        });

        modelBuilder.Entity<MovementType>(entity =>
        {
            entity.ToTable("MOVEMENT_TYPE");

            entity.HasKey(e => e.MovementTypeId)
                .HasName("PK_MOVEMENT_TYPE");

            entity.Property(e => e.MovementTypeId)
                .HasColumnName("MOVEMENT_TYPE_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.TypeName)
                .HasColumnName("TYPE_NAME")
                .HasColumnType("VARCHAR2(30)")
                .IsRequired();
        });

        modelBuilder.Entity<Neighbourhood>(entity =>
        {
            entity.ToTable("NEIGHBOURHOOD");

            entity.HasKey(e => e.NeighId)
                .HasName("PK_NEIGHBOURHOOD");

            entity.Property(e => e.NeighId)
                .HasColumnName("NEIGH_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.NeighName)
                .HasColumnName("NEIGH_NAME")
                .HasColumnType("VARCHAR2(255)")
                .IsRequired();

            entity.Property(e => e.CityId)
                .HasColumnName("CITY_ID")
                .HasColumnType("NUMBER")
                .IsRequired();

            entity.HasOne(e => e.City)
                .WithMany()
                .HasForeignKey(e => e.CityId)
                .HasConstraintName("FK_CITY_NEIGHBOURHOOD");
        });

        modelBuilder.Entity<PharmaceuticalForm>(entity =>
        {
            entity.ToTable("PHARMACEUTICAL_FORM");

            entity.HasKey(e => e.PharmFormId)
                .HasName("PK_PHARMACEUTICAL_FORM");

            entity.Property(e => e.PharmFormId)
                .HasColumnName("PHARM_FORM_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.PharmaForm)
                .HasColumnName("PHARMA_FORM")
                .HasColumnType("VARCHAR2(100)")
                .IsRequired();
        });

        modelBuilder.Entity<PositionUser>(entity =>
        {
            entity.ToTable("POSITION_USER");

            entity.HasKey(e => e.PosUserId)
                .HasName("PK_POSITION_USER");

            entity.Property(e => e.PosUserId)
                .HasColumnName("POS_USER_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserPosition)
                .HasColumnName("USER_POSITION")
                .HasColumnType("VARCHAR2(100)")
                .IsRequired();
        });

        modelBuilder.Entity<ProfileUser>(entity =>
        {
            entity.ToTable("POSITION_USER");

            entity.HasKey(e => e.ProfUserId)
                .HasName("PK_PROFILE_USER");

            entity.Property(e => e.ProfUserId)
                .HasColumnName("PROF_USER_ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserProfile)
                .HasColumnName("USER_PROFILE")
                .HasColumnType("VARCHAR2(50)")
                .IsRequired();
        });

        /*

         // Índice único (garante que o e-mail não se repita)
        entity.HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("UK_USERS_SYS_EMAIL");

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