using MedSave.Context;
using MedSave.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Repositories;

public class StockRepository : IStockRepository
{
    private readonly MedSaveContext _context;

    public StockRepository(MedSaveContext context)
    {
        _context = context;
    }
    
    public async Task<Stock?> GetByIdAsync(long id)
    {
        return await _context.Stock.FindAsync(id); // Funcionando
    }

    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _context.Stock.ToListAsync(); // Funcionando
    }

    public async Task UpdateAsync(Stock stock)
    {
        _context.Stock.Update(stock); // Funcionando mas com bug relacionado aos números
        await _context.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Stock> Items, int TotalItems)> SearchAsync(long? medicineId, long? locationIdStock, long? batchId, int page, int pageSize, string sortBy, string sortDir)
    {
        var query = _context.Stock.AsQueryable();

        if (medicineId.HasValue)
            query = query.Where(s => s.MedicineId == medicineId.Value);

        if (locationIdStock.HasValue)
            query = query.Where(s => s.LocationIdStock == locationIdStock.Value);
        
        if (batchId.HasValue)
            query = query.Where(s => s.BatchId == batchId.Value);

        var totalItems = await query.CountAsync();
        
        bool desc = string.Equals(sortDir, "desc", StringComparison.OrdinalIgnoreCase);
        query = sortBy?.ToLowerInvariant() switch
        {
            "medicineid" => desc ? query.OrderByDescending(s => s.MedicineId) : query.OrderBy(s => s.MedicineId),
            "locationidstock" => desc ? query.OrderByDescending(s => s.LocationIdStock) : query.OrderBy(s => s.LocationIdStock),
            "batchid" => desc ? query.OrderByDescending(s => s.BatchId) : query.OrderBy(s => s.BatchId),
            "quantity" => desc ? query.OrderByDescending(s => s.Quantity) : query.OrderBy(s => s.Quantity),
            "stockid" => desc ? query.OrderByDescending(s => s.StockId) : query.OrderBy(s => s.StockId),
            _ => desc ? query.OrderByDescending(s => s.StockId) : query.OrderBy(s => s.StockId)
        };
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var skip = (page - 1) * pageSize;

        var data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return (data, totalItems);
    }
}