namespace MedSave.Model;

public class Stock
{
    public long StockId { get; set; }
    public int Quantity { get; set; }
    
    public long BatchId { get; set; }
    public Batch Batch { get; set; }
    
    public long MedicineId { get; set; }
    public Medicines Medicines { get; set; }
    
    public long LocationId { get; set; }
    public Location Location { get; set; }
}