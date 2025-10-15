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

    public async Task<UsersSys?> GetByIdAsync(long id)
    {
        return await _context.UsersSys.FindAsync(id); // Funcionando
    }

    public async Task<IEnumerable<UsersSys>> GetAllAsync()
    {
        return await _context.UsersSys.ToListAsync(); // Funcionando
    }

    public async Task AddAsync(UsersSys usersSys)
    {
        _context.UsersSys.Add(usersSys);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var user = await _context.UsersSys.FindAsync(id);
        if (user != null)
        {
            _context.UsersSys.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}