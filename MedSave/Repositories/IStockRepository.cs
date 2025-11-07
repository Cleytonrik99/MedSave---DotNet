using MedSave.Model;

namespace MedSave.Repositories;

public interface IStockRepository
{
    Task<Stock?> GetByIdAsync(long id);
    Task<IEnumerable<Stock>> GetAllAsync();
    Task UpdateAsync(Stock stock);

    Task<(IEnumerable<Stock> Items, int TotalItems)> SearchAsync(
        long? medicineId,
        long? locationIdStock,
        long? batchId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}