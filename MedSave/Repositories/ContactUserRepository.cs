using MedSave.Context;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories;

public class ContactUserRepository : IContactUserRepository
{
    private readonly MedSaveContext _context;

    public ContactUserRepository(MedSaveContext context)
    {
        _context = context;
    }
    
    public async Task<ContactUser?> GetByIdAsync(long id)
    {
        return await _context.ContactUser.FindAsync(id); // Funcionando
    }

    public async Task<IEnumerable<ContactUser>> GetAllAsync()
    {
        return await _context.ContactUser.ToListAsync(); // Funcionando
    }

    public async Task AddAsync (ContactUser contactUser)
    {
        _context.ContactUser.Add(contactUser); // Funcionando
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(ContactUser contactUser)
    {
        _context.ContactUser.Update(contactUser); // Funcionando
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(long id)
    {
        var contact = await _context.ContactUser.FindAsync(id); // Funcionando
        if (contact != null)
        {
            _context.ContactUser.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}