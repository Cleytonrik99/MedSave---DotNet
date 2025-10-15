using MedSave.Model;

namespace MedSave.Repositories;

public interface IContactUserRepository
{
    Task<ContactUser?> GetByIdAsync(long id);
    Task<IEnumerable<ContactUser>> GetAllAsync();
    Task AddAsync (ContactUser contactUser);
    Task UpdateAsync(ContactUser contactUser);
    Task DeleteAsync (long id);
}