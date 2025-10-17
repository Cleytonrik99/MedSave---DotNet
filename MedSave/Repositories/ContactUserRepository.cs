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
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }
    
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message) : base(message) { }
    }

    
    public async Task<ContactUser?> GetByIdAsync(long id)
    {
        var search = await _context.ContactUser.FindAsync(id); // Funcionando

        if (search == null)
        {
            throw new NotFoundException($"Contact User with Id {id} not found");
        }

        return search; // Funcionando
    }

    public async Task<IEnumerable<ContactUser>> GetAllAsync()
    {
        var search = await _context.ContactUser.ToListAsync(); // Funcionando

        if (search.Count == 0)
        {
            throw new NotFoundException("Not Contact Users found");
        }

        return search;
    }

    public async Task AddAsync (ContactUser contactUser)
    {
        var search = await GetAllAsync();

        foreach (var cont in search)
        {
            if (cont.EmailUser == contactUser.EmailUser)
            {
                throw new DuplicateRecordException("Email or phone number already exists.");
            }

            else if(cont.PhoneNumberUser == contactUser.PhoneNumberUser)
            {
                throw new DuplicateRecordException("Email or phone number already exists.");
            }
        }
        
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