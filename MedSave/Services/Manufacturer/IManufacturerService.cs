using MedSave.DTOs;

namespace MedSave.Services.Manufacturer;

public interface IManufacturerService
{
    Task<ManufacturerDTO?> GetByIdAsync(long id);
    Task<IEnumerable<ManufacturerDTO>> GetAllAsync();
    Task<ManufacturerDTO?> AddAsync(ManufacturerDTO manufacturerDto, AddressManufacturerDTO addressManufacturerDto, ContactManufacturerDTO contactManufacturerDto);
    Task UpdateAsync(long id, ManufacturerDTO manufacturerDto);
    Task DeleteAsync(long id);
    Task<PagedResult<ManufacturerDTO>> SearchAsync(
        int? cnpj,
        long? contactManuId,
        long? addressIdManufacturer,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}