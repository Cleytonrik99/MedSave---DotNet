namespace MedSave.Model;

public class StockMovement
{
    public long StockMovementId { get; set; }
    public int QuantityDispensed { get; set; }
    public DateTime DateMoviment { get; set; }
    
    public long MovementTypeId { get; set; }
    public MovementType MovementType { get; set; }
    
    public long StockId { get; set; }
    public Stock Stock { get; set; }
    
    public long DispensationId { get; set; }
    public MedicineDispense MedicineDispense { get; set; }
    
    public long UserId { get; set; }
    public UsersSys UsersSys { get; set; }
}