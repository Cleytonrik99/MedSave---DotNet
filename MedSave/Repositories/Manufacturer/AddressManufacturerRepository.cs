using MedSave.Context;
using Microsoft.EntityFrameworkCore;
using MedSave.Model;

namespace MedSave.Repositories;

public class AddressManufacturerRepository : IAddressManufacturerRepository
{
    private readonly MedSaveContext _context;

    public AddressManufacturerRepository(MedSaveContext context)
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

    public async Task<AddressManufacturer?> GetByIdAsync(long id)
    {
        var search = await _context.AddressManufacturer.FindAsync(id);

        if (search == null)
        {
            throw new NotFoundException($"Address Manufacturer with Id {id} not found");
        }

        return search;
    }

    public async Task<IEnumerable<AddressManufacturer>> GetAllAsync()
    {
        var search = await _context.AddressManufacturer.ToListAsync();

        if (search.Count == 0)
        {
            throw new NotFoundException("Not Address Manufacturer found");
        }

        return search;
    }

    public async Task AddAsync(AddressManufacturer addressManufacturer)
    {
        _context.AddressManufacturer.Add(addressManufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AddressManufacturer addressManufacturer)
    {
        _context.AddressManufacturer.Update(addressManufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.AddressManufacturer.FindAsync(id);
        if (search != null)
        {
            _context.AddressManufacturer.Remove(search);
            await _context.SaveChangesAsync();
        }
    }
}