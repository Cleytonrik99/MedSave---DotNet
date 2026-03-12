using MedSave.Model;

namespace MedSave.Repositories;

public interface IUsersSysRepository
{
    Task<UsersSys?> GetByIdAsync(long id);
    Task<IEnumerable<UsersSys>> GetAllAsync();
    Task AddAsync(UsersSys usersSys);
    Task UpdateAsync(UsersSys usersSys);
    Task DeleteAsync(long id);
    
    Task<(IEnumerable<UsersSys> Items, int TotalItems)> SearchAsync(
        string? name,
        string? login,
        long? roleUserId,
        long? profUserId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}