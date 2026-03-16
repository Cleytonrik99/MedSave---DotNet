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

    public async Task<(IEnumerable<Manufacturer> Items, int TotalItems)> SearchAsync(int? cnpj, long? contactManuId, long? addressIdManufacturer, int page, int pageSize, string sortBy, string sortDir)
    {
        var query = _context.Manufacturer.AsQueryable();

        if (cnpj.HasValue)
            query = query.Where(m => m.Cnpj == cnpj.Value);

        if (contactManuId.HasValue)
            query = query.Where(m => m.ContactManuId == contactManuId.Value);

        if (addressIdManufacturer.HasValue)
            query = query.Where(m => m.AddressIdManufacturer == addressIdManufacturer.Value);

        var totalItems = await query.CountAsync();
        
        bool desc = string.Equals(sortDir, "desc", StringComparison.OrdinalIgnoreCase);
        query = sortBy?.ToLowerInvariant() switch
        {
            "cnpj" => desc ? query.OrderByDescending(m => m.Cnpj) : query.OrderBy(m => m.Cnpj),
            "contactManuId" => desc ? query.OrderByDescending(m => m.ContactManuId) : query.OrderBy(m => m.ContactManuId),
            "addressIdManufacturer" => desc ? query.OrderByDescending(m => m.AddressIdManufacturer) : query.OrderBy(m => m.AddressIdManufacturer),
            _ => desc ? query.OrderByDescending(m => m.ManufacId) : query.OrderBy(m => m.ManufacId)
        };
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var skip = (page - 1) * pageSize;

        var data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return (data, totalItems);
    }
}