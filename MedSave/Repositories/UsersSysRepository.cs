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
        public NotFoundException(string message) : base(message) { }
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
        return await _context.UsersSys.ToListAsync(); // Funcionando
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
        var user = await _context.UsersSys.FindAsync(id); 
        if (user != null)
        {
            _context.UsersSys.Remove(user); // Funcionando
            await _context.SaveChangesAsync();
        }
    }
}