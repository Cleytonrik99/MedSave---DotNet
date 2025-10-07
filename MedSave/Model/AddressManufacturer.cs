namespace MedSave.Model;

public class Address
{
    public long AddressId { get; set; }
    public string Complement { get; set; }
    public int Number { get; set; }
    public int Cep { get; set; }
    
    public long NeighId { get; set; }
    public Neighbourhood Neighbourhood { get; set; }
}