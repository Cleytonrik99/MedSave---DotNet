using MedSave.Context;
using MedSave.Repositories;
using MedSave.DTOs;

namespace MedSave.Services;

public class StockService : IStockService
{
    private readonly MedSaveContext _context;
    private readonly IStockRepository _stockRepository;
    
    public StockService(MedSaveContext context, IStockRepository stockRepository)
    {
        _context = context;
        _stockRepository = stockRepository;
    }
    
    public async Task<StockDTO?> GetByIdAsync(long id)
    {
        var stock = await _stockRepository.GetByIdAsync(id);

        if (stock == null)
        {
            throw new Exception($"Stock with ID {id} not founded.");
        }

        return new StockDTO
        {
            StockId = stock.StockId,
            MedicineId = stock.MedicineId,
            LocationIdStock = stock.LocationIdStock,
            BatchId = stock.BatchId,
            Quantity = stock.Quantity
        };
    }
    
    public async Task<IEnumerable<StockDTO>> GetAllAsync()
    {
        var stocks = await _stockRepository.GetAllAsync();
        
        return stocks.Select(stock => new StockDTO
        {
            StockId = stock.StockId,
            MedicineId = stock.MedicineId,
            LocationIdStock = stock.LocationIdStock,
            BatchId = stock.BatchId,
            Quantity = stock.Quantity
        }).ToList();
    }

    
    public async Task UpdateAsync(StockDTO stockDto)
    {
        if (stockDto == null)
        {
            throw new ArgumentNullException(nameof(stockDto), "Stock Object can't be null.");
        }

        var existingStock = await _stockRepository.GetByIdAsync(stockDto.StockId);

        if (existingStock == null)
        {
            throw new Exception($"Stock with ID {stockDto.StockId} not founded.");
        }

        existingStock.MedicineId = stockDto.MedicineId;
        existingStock.LocationIdStock = stockDto.LocationIdStock;
        existingStock.BatchId = stockDto.BatchId;
        existingStock.Quantity = stockDto.Quantity;

        await _stockRepository.UpdateAsync(existingStock);
    }
    
}