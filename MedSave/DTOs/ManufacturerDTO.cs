namespace MedSave.DTOs;

public class ManufacturerDTO
{
    public long ManufacId { get; set; }
    public string NameManu { get; set; }
    public int Cnpj { get; set; }
    public long ContactManuId { get; set; }
    public long AddressIdManufacturer { get; set; }
}