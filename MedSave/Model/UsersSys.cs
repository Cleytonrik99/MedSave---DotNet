namespace MedSave.Model;

public class UsersSys
{
    public long UserId { get; set; }
    public string NameUser { get; set; }
    public string Login { get; set; }
    public string PasswordUser { get; set; }
    
    public long PosUserId { get; set; }
    public PositionUser PositionUser { get; set; }
    
    public long ProfUserId { get; set; }
    public ProfileUser ProfileUser { get; set; }
    
    public long ContactUserId { get; set; }
    public ContactUser ContactUser { get; set; }
}