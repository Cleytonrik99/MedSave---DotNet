using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories.Healthcare_Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories.Healthcare_Providers;

public class ProviderTypeRepository : IProviderTypeRepository
{
    private readonly MedSaveContext _context;

    public async Task<ProviderType?> GetByIdAsync(long id)
    {
        var search = await _context.ProviderType.FindAsync(id);

        return search;
    }

    public async Task<IEnumerable<ProviderType>> GetAllAsync()
    {
        var search = await _context.ProviderType.ToListAsync();

        return search;
    }

    public async Task AddAsync(ProviderType providerType)
    {
        _context.ProviderType.AddAsync(providerType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProviderType providerType)
    {
        _context.ProviderType.Update(providerType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.ProviderType.FindAsync(id);

        _context.ProviderType.Remove(search);
        await _context.SaveChangesAsync();
    }
}