using MedSave.DTOs;

namespace MedSave.Services;

public interface IUsersSysService
{
    Task<IEnumerable<UsersSysDTO>> GetAllUsersAsync();
    Task<UsersSysDTO?> GetByIdAsync(long id);
    Task<UsersSysDTO> AddUserAsync(UsersSysDTO usersSysDto, ContactUserDTO contactUserDto);
}