namespace MedSave.Model;

public class Neighbourhood
{
    public long NeighId { get; set; }
    public string NeighName { get; set; }
    
    public long CityId { get; set; }
    public City City { get; set; }
}