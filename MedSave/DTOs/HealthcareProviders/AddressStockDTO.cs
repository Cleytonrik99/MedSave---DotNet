namespace MedSave.DTOs.HealthcareProviders;

public class AddressStockDTO
{
    public long AddressIdStock { get; set; }
    public string Complement { get; set; }
    public int NumberStock { get; set; }
    public string AddressDescription { get; set; }
    public int Cep { get; set; }
    public long NeighId { get; set; }
}