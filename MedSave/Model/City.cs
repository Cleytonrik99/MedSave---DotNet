namespace MedSave.Model;

public class City
{
    public long CityId { get; set; }
    public string NameCity { get; set; }
    
    public long StateId { get; set; }
    public State State { get; set; }
}