namespace MedSave.Model;

public class MedicinePharmForm
{
    public long MedPharmFormId { get; set; }
    
    public long MedicineId { get; set; }
    public Medicines Medicines { get; set; }
    
    public long PharmFormId { get; set; }
    public PharmaceuticalForm PharmaceuticalForm { get; set; }
}