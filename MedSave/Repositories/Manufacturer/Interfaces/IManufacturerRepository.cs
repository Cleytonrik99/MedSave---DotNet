using MedSave.Model;

namespace MedSave.Repositories;

public interface IManufacturerRepository
{
    Task<Manufacturer?> GetByIdAsync(long id);
    Task<IEnumerable<Manufacturer>> GetAllAsync();
    Task AddAsync(Manufacturer manufacturer);
    Task UpdateAsync(Manufacturer manufacturer);
    Task DeleteAsync(long id);
}