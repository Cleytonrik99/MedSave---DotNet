using MedSave.Context;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly MedSaveContext _context;

    public ManufacturerRepository(MedSaveContext context)
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

    public async Task<Manufacturer?> GetByIdAsync(long id)
    {
        var search = await _context.Manufacturer.FindAsync(id);

        if (search == null)
        {
            throw new NotFoundException($"Manufacturer with Id {id} not found.");
        }

        return search;
    }

    public async Task<IEnumerable<Manufacturer>> GetAllAsync()
    {
        var search = await _context.Manufacturer.ToListAsync();

        if (search.Count == 0)
        {
            throw new NotFoundException("Not Manufacturers found");
        }

        return search;
    }

    public async Task AddAsync(Manufacturer manufacturer)
    {
        _context.Manufacturer.Add(manufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Manufacturer manufacturer)
    {
        _context.Manufacturer.Update(manufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var search = await _context.Manufacturer.FindAsync(id);

        if (search != null)
        {
            _context.Manufacturer.Remove(search);
            await _context.SaveChangesAsync();
        }
    }
}