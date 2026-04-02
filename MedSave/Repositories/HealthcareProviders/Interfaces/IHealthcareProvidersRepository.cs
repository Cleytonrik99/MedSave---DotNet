using MedSave.Model;

namespace MedSave.Repositories.Healthcare_Providers.Interfaces;

public interface IHealthcareProvidersRepository
{
    Task<HealthcareProviders?> GetByIdAsync(long id);
    Task<IEnumerable<HealthcareProviders>> GetAllAsync();
    Task AddAsync(HealthcareProviders healthcareProviders);
    Task UpdateAsync(HealthcareProviders healthcareProviders);
    Task DeleteAsync(long id);
}