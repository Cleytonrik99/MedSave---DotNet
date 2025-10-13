namespace MedSave.Model;

public class Medicines
{
    public long MedicineId { get; set; }
    public string NameMedication { get; set; }
    public string StatusMed { get; set; }
    
    public long CategoryMedId { get; set; }
    public CategoryMedicine CategoryMedicine { get; set; }
    
    public long UnitMeaId { get; set; }
    public UnitMeasure UnitMeasure { get; set; }
}