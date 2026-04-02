using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories.Healthcare_Providers.Interfaces;

namespace MedSave.Repositories.Healthcare_Providers;

public class ProviderTypeRepository : IProviderTypeRepository
{
    private readonly MedSaveContext _context;

    public async Task<ProviderType?> GetByIdAsync(long id)
    {
        var search = await _context.
    }

    public Task<IEnumerable<ProviderType>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(ProviderType providerType)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProviderType providerType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
}