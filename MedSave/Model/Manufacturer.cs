namespace MedSave.Model;

public class Manufacturer
{
    public long ManufacId { get; set; }
    public string NameManu { get; set; }
    public int Cnpj { get; set; }
    
    public long AddressId { get; set; }
    public Address Address { get; set; }
    
    public long ContactManuId { get; set; }
    public ContactManufacturer ContactManufacturer { get; set; }
}