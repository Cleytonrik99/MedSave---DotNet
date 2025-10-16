using MedSave.DTOs;

namespace MedSave.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetByIdAsync(long id);
    Task<UserDTO> AddUserAsync();
}