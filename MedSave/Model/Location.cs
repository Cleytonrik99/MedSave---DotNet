namespace MedSave.Model;

public class Location
{
    public long LocationId { get; set; }
    public string NameLocation { get; set; }
    public string LocationStock { get; set; }
    
    public long AddressIdStock { get; set; }
    public AddressStock AddressStock { get; set; }
}