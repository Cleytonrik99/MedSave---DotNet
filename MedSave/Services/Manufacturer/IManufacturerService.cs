using MedSave.DTOs;

namespace MedSave.Services.Manufacturer;

public interface IManufacturerService
{
    Task<ManufacturerDTO?> GetByIdAsync(long id);
    Task<IEnumerable<ManufacturerDTO>> GetAllAsync();
    Task<ManufacturerDTO?> AddAsync(ManufacturerDTO manufacturerDto);
    Task UpdateAsync(ManufacturerDTO manufacturerDto, AddressManufacturerDTO addressManufacturerDto, ContactManufacturerDTO contactManufacturerDto);
    Task DeleteAsync(long id);
    Task<PagedResult<ManufacturerDTO>> SearchAsync(
        string? nameManu,
        int? cnpj,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}