using MedSave.DTOs;

namespace MedSave.Services;

public interface IUsersSysService
{
    Task<IEnumerable<UsersSysDTO>> GetAllUsersAsync();
    Task<UsersSysDTO?> GetByIdAsync(long id);
    Task<UsersSysDTO> AddUserAsync(UsersSysDTO usersSysDto, ContactUserDTO contactUserDto);
    Task DeleteAsync(long id);
    
    Task<PagedResult<UsersSysDTO>> SearchAsync(
        string? name,
        string? login,
        long? roleUserId,
        long? profUserId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir
    );
}