using MedSave.DTOs;

namespace MedSave.Services;

public interface IUserService
{
    Task<UserDTO> AddUserAsync();
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> UpdateUser
}