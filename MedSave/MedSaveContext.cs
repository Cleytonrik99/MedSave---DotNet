using System.Configuration;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave;

public class MedSaveContext : DbContext
{
    public DbSet<ActiveIngredient> ActiveIngredient { get; set; }
    public DbSet<Address> Address { get; set; }
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
}