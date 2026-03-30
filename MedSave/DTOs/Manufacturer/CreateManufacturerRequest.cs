using MedSave.DTOs.Manufacturer;

namespace MedSave.DTOs;

public class CreateManufacturerRequest
{
    public ManufacturerDTO ManufacturerDto { get; set; } = default!;
    public ContactManufacturerDTO ContactManufacturerDto { get; set; } = default!;
    public AddressManufacturerDTO AddressManufacturerDto { get; set; } = default!;
}