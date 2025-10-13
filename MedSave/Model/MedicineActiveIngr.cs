namespace MedSave.Model;

public class MedicineActiveIngr
{
    public long MedActiveIngrId { get; set; }
    
    public long MedicineId { get; set; }
    public Medicines Medicines { get; set; }
    
    public long ActIngreId { get; set; }
    public ActiveIngredient ActiveIngredient { get; set; }
}