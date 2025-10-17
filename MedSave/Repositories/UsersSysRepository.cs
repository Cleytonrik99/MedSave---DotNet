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
}