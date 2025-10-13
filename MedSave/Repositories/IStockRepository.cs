using MedSave.Model;

namespace MedSave.Repositories;

public interface IStockRepository
{
    Task<Stock?> GetByIdAsync(long id);
    Task<IEnumerable<Stock>> GetAllAsync();
    Task UpdateAsync(Stock stock);
}