namespace MedSave.Model;

public class LocationStock
{
    public long LocationIdStock { get; set; }
    public string NameLocation { get; set; }
    public string LocationStockName { get; set; }
    
    public long AddressIdStock { get; set; }
    public AddressStock AddressStock { get; set; }
}