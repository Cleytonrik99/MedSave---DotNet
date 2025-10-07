namespace MedSave.Model;

public class AddressManufacturer
{
    public long AddressIdManufacturer { get; set; }
    public string Complement { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public int Cep { get; set; }
    
    public long NeighId { get; set; }
    public Neighbourhood Neighbourhood { get; set; }
}