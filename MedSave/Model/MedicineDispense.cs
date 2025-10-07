namespace MedSave.Model;

public class MedicineDispense
{
    public long DispensationId { get; set; }
    public DateTime DateDispensation { get; set; }
    public int QuantityDispensed { get; set; }
    public string Destination { get; set; }
    public string Observation { get; set; }
    
    public long UserId { get; set; }
    public UsersSys UsersSys { get; set; }
    
    public long MovementTypeId { get; set; }
    public MovementType MovementType { get; set; }
    
    public long StockId { get; set; }
    public Stock Stock { get; set; }
}