namespace MedSave.Model;

public class Stock
{
    public long StockId { get; set; }
    public int Quantity { get; set; }
    
    public long BatchId { get; set; }
    public BatchMedicine BatchMedicine { get; set; }
    
    public long MedicineId { get; set; }
    public Medicines Medicines { get; set; }
    
    public long LocationIdStock { get; set; }
    public LocationStock LocationStock { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(StockId)}: {StockId}, {nameof(Quantity)}: {Quantity}, {nameof(BatchId)}: {BatchId}, {nameof(MedicineId)}: {MedicineId},  {nameof(LocationIdStock)}: {LocationIdStock}";
    }
}