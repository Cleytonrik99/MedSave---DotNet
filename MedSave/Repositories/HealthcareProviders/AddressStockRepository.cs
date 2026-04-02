using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories.Healthcare_Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories.Healthcare_Providers;

public class AddressStockRepository : IAddressStockRepository
{
    private readonly MedSaveContext _context;
    
    public class NotFoundException : Exception
    {
        public NotFoundException (string message) : base(message) {}
    }
    
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException (string message) : base(message) {}
    }

    public async Task<AddressStock?> GetByIdAsync(long id)
    {
        var search = await _context.AddressStock.FindAsync(id);

        return search;
    }
    
    public async Task<IEnumerable<AddressStock>> GetAllAsync()
    {
        var search = await _context.AddressStock.ToListAsync();

        return search;
    }

    public async Task AddAsync(AddressStock addressStock)
    {
        _context.AddressStock.AddAsync(addressStock);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AddressStock addressStock)
    {
        _context.AddressStock.Update(addressStock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.AddressStock.FindAsync(id);

        if (search == null)
        {
            throw new NotFoundException($"Address Stock with Id {id} not found.");
        }

        _context.AddressStock.Remove(search);
        await _context.SaveChangesAsync();
    }
}