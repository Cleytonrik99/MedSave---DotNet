namespace MedSave.DTOs;

public class StockDTO
{
    public long StockId { get; set; }
    public int Quantity { get; set; }
    public long BatchId { get; set; }
    public long MedicineId { get; set; }
    public long LocationIdStock { get; set; }
}