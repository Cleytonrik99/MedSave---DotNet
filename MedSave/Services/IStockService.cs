using MedSave.DTOs;

namespace MedSave.Services;

public interface IStockService
{
    Task<StockDTO?> GetByIdAsync(long id);
    Task<IEnumerable<StockDTO>> GetAllAsync();
    Task UpdateAsync(StockDTO stockDto);
}