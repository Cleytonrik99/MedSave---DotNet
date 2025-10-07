namespace MedSave.Model;

public class Batch
{
    public long BatchId { get; set; }
    public string BatchNumber { get; set; }
    public int CurrentQuantity { get; set; }
    public DateTime ManufacturingDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    public long ManufacId { get; set; }
    public Manufacturer Manufacturer { get; set; }
}