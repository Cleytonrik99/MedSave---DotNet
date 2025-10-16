namespace MedSave.DTOs;

public class UserDTO
{
    public long UserId { get; set; }
    public string NameUser { get; set; }
    public string Login { get; set; }
    public string PasswordUser { get; set; }
    public long RoleUserId { get; set; }
    public long ProfUserId { get; set; }
    public long ContactUserId { get; set; } 
}