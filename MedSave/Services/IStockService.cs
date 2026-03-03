using MedSave.DTOs;

namespace MedSave.Services;

public interface IStockService
{
    Task<StockDTO?> GetByIdAsync(long id);
    Task<IEnumerable<StockDTO>> GetAllAsync();
    Task UpdateAsync(StockDTO stockDto);
    
    Task<PagedResult<StockDTO>> SearchAsync(
        long? medicineId,
        long? HealthcareProviderId,
        long? batchId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}