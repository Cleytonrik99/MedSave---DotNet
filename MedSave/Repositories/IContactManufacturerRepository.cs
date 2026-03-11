using MedSave.Model;

namespace MedSave.Repositories;

public interface IContactManufacturerRepository
{
    Task<ContactManufacturer?> GetByIdAsync(long id);
    Task<IEnumerable<ContactManufacturer>> GetAllAsync();
    Task AddAsync (ContactManufacturer contactManufacturer);
    Task UpdateAsync (ContactManufacturer contactManufacturer);
    Task DeleteAsync (long id);
}