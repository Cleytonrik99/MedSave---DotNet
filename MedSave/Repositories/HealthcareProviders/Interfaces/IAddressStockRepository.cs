using MedSave.Model;

namespace MedSave.Repositories.Healthcare_Providers.Interfaces;

public interface IAddressStockRepository
{
    Task<AddressStock?> GetByIdAsync(long id);
    Task<IEnumerable<AddressStock>> GetAllAsync();
    Task AddAsync(AddressStock addressStock);
    Task UpdateAsync(AddressStock addressStock);
    Task DeleteAsync(long id);
}