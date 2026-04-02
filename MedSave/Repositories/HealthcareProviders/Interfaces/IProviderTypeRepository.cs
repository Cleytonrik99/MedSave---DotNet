using MedSave.Model;

namespace MedSave.Repositories.Healthcare_Providers.Interfaces;

public interface IProviderTypeRepository
{
    Task<ProviderType?> GetByIdAsync(long id);
    Task<IEnumerable<ProviderType>> GetAllAsync();
    Task AddAsync(ProviderType providerType);
    Task UpdateAsync(ProviderType providerType);
    Task DeleteAsync(long id);
}