namespace MedSave.Model;

public class HealthcareProviders
{
    public long HealthcareProviderId { get; set; }
    public string ProviderName { get; set; }
    public string HealthcareProviderName { get; set; }
    public long ProviderTypeId { get; set; }
    public ProviderType ProviderType { get; set; }
    public long AddressIdStock { get; set; }
    public AddressStock AddressStock { get; set; }
}