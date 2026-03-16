using MedSave.Model;

namespace MedSave.Repositories;

public interface IManufacturerRepository
{
    Task<Manufacturer?> GetByIdAsync(long id);
    Task<IEnumerable<Manufacturer>> GetAllAsync();
    Task AddAsync(Manufacturer manufacturer);
    Task UpdateAsync(Manufacturer manufacturer);
    Task DeleteAsync(long id);

    Task<(IEnumerable<Manufacturer> Items, int TotalItems)> SearchAsync(
        int? cnpj,
        long? contactManuId,
        long? addressIdManufacturer,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}