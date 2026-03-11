namespace MedSave.Repositories;
using MedSave.Model;
public interface IAddressManufacturerRepository
{
    Task<AddressManufacturer?> GetByIdAsync(long id);
    Task<IEnumerable<AddressManufacturer>> GetAllAsync();
    Task AddAsync (AddressManufacturer addressManufacturer);
    Task UpdateAsync (AddressManufacturer addressManufacturer);
    Task DeleteAsync(long id);
}