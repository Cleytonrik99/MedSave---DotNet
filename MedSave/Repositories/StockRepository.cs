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
}