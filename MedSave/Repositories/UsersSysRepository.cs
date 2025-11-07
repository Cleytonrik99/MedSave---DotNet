using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories;
using MedSave.Context;
using MedSave.Model;

public class UsersSysRepository : IUsersSysRepository
{
    private readonly MedSaveContext _context;

    public UsersSysRepository(MedSaveContext context)
    {
        _context = context;
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }

    public async Task<UsersSys?> GetByIdAsync(long id)
    {
        var search = await _context.UsersSys.FindAsync(id); // Funcionando

        if (search == null)
        {
            throw new NotFoundException($"User with Id {id} not found");
        }

        return search;
    }

    public async Task<IEnumerable<UsersSys>> GetAllAsync()
    {
        var search = await _context.UsersSys.ToListAsync(); // Funcionando

        if (search.Count == 0)
        {
            throw new NotFoundException("Not Users found");
        }

        return search;
    }

    public async Task AddAsync(UsersSys usersSys)
    {
        _context.UsersSys.Add(usersSys); // Funcionando
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(UsersSys usersSys)
    {
        _context.UsersSys.Update(usersSys); // Funcionando
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.UsersSys.FindAsync(id); // Funcionando

        if (search == null)
        {
            throw new NotFoundException($"User with Id {id} not found");
        }
        
        _context.UsersSys.Remove(search); // Funcionando
        await _context.SaveChangesAsync();
        
    }
    
    public async Task<(IEnumerable<UsersSys> Items, int TotalItems)> SearchAsync(
        string? name,
        string? login,
        long? roleUserId,
        long? profUserId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        var query = _context.UsersSys.AsQueryable();

        // Filtros (case-insensitive para texto)
        if (!string.IsNullOrWhiteSpace(name))
        {
            var n = name.Trim().ToLower();
            query = query.Where(u => u.NameUser.ToLower().Contains(n));
            // alternativa com LIKE:
            // query = query.Where(u => EF.Functions.Like(u.NameUser, $"%{name}%"));
        }

        if (!string.IsNullOrWhiteSpace(login))
        {
            var l = login.Trim().ToLower();
            query = query.Where(u => u.Login.ToLower().Contains(l));
        }

        if (roleUserId.HasValue)
            query = query.Where(u => u.RoleUserId == roleUserId.Value);

        if (profUserId.HasValue)
            query = query.Where(u => u.ProfUserId == profUserId.Value);

        var totalItems = await query.CountAsync();
        
        bool desc = string.Equals(sortDir, "desc", StringComparison.OrdinalIgnoreCase);
        query = (sortBy ?? "").ToLowerInvariant() switch
        {
            "nameuser"   => desc ? query.OrderByDescending(u => u.NameUser)   : query.OrderBy(u => u.NameUser),
            "login"      => desc ? query.OrderByDescending(u => u.Login)      : query.OrderBy(u => u.Login),
            "roleuserid" => desc ? query.OrderByDescending(u => u.RoleUserId) : query.OrderBy(u => u.RoleUserId),
            "profuserid" => desc ? query.OrderByDescending(u => u.ProfUserId) : query.OrderBy(u => u.ProfUserId),
            "userid"     => desc ? query.OrderByDescending(u => u.UserId)     : query.OrderBy(u => u.UserId),
            _            => desc ? query.OrderByDescending(u => u.UserId)     : query.OrderBy(u => u.UserId),
        };

        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var skip = (page - 1) * pageSize;

        var data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return (data, totalItems);
    }
}