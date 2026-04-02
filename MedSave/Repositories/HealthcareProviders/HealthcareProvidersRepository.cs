using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories.Healthcare_Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories.Healthcare_Providers;

public class HealthcareProvidersRepository : IHealthcareProvidersRepository
{
    private readonly MedSaveContext _context;

    public async Task<HealthcareProviders?> GetByIdAsync(long id)
    {
        var search = await _context.HealthcareProviders.FindAsync(id);

        return search;
    }

    public async Task<IEnumerable<HealthcareProviders>> GetAllAsync()
    {
        var search = await _context.HealthcareProviders.ToListAsync();

        return search;
    }

    public async Task AddAsync(HealthcareProviders healthcareProviders)
    {
        _context.HealthcareProviders.AddAsync(healthcareProviders);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HealthcareProviders healthcareProviders)
    {
        _context.HealthcareProviders.Update(healthcareProviders);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.HealthcareProviders.FindAsync(id);

        _context.HealthcareProviders.Remove(search);
        await _context.SaveChangesAsync();
    }
}