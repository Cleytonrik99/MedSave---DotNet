using MedSave.Context;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories;

public class ContactManufacturerRepository : IContactManufacturerRepository
{
    private readonly MedSaveContext _context;

    public ContactManufacturerRepository(MedSaveContext context)
    {
        _context = context;
    }

    public class NotFoundException : Exception
    {
        public NotFoundException (string message) : base(message) {}
    }
    
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException (string message) : base(message) {}
    }

    public async Task<ContactManufacturer?> GetByIdAsync(long id)
    {
        var search = await _context.ContactManufacturer.FindAsync(id);

        if (search == null)
        {
            throw new NotFoundException($"Contact Manufacturer with Id {id} not found");
        }

        return search;
    }

    public async Task<IEnumerable<ContactManufacturer>> GetAllAsync()
    {
        var search = await _context.ContactManufacturer.ToListAsync();

        if (search.Count == 0)
        {
            throw new NotFoundException("Not Contact Manufacturers found");
        }

        return search;
    }

    public async Task AddAsync(ContactManufacturer contactManufacturer)
    {
        var search = await GetAllAsync();

        foreach (var cont in search)
        {
            if (cont.EmailManu == contactManufacturer.EmailManu || cont.PhoneNumberManu == contactManufacturer.PhoneNumberManu)
            {
                throw new DuplicateRecordException("Email or phone number already exists.");
            }
        }

        _context.ContactManufacturer.Add(contactManufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ContactManufacturer contactManufacturer)
    {
        _context.ContactManufacturer.Update(contactManufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var contact = await _context.ContactManufacturer.FindAsync(id);
        if (contact != null)
        {
            _context.ContactManufacturer.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}