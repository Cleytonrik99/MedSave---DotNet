using System.Globalization;
using MedSave.Context;
using MedSave.DTOs;
using MedSave.Model;
using MedSave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Services;

public class UsersSysService : IUsersSysService 
{
    private readonly UsersSysRepository _usersSysRepository;
    private readonly ContactUserRepository _contactUserRepository;
    private readonly MedSaveContext _context;

    public UsersSysService(UsersSysRepository usersSysRepository, ContactUserRepository contactUserRepository, MedSaveContext context)
    {
        _usersSysRepository = usersSysRepository;
        _contactUserRepository = contactUserRepository;
        _context = context;
    }

    public async Task<IEnumerable<UsersSysDTO>> GetAllUsersAsync()
    {
        var users = await _usersSysRepository.GetAllAsync();

        return users.Select(user => new UsersSysDTO
        {
            UserId = user.UserId,
            NameUser = user.NameUser,
            Login = user.Login,
            PasswordUser = user.PasswordUser,
            RoleUserId = user.RoleUserId,
            ProfUserId = user.ProfUserId,
            ContactUserId = user.ContactUserId
        }).ToList();
    }

    public async Task<UsersSysDTO?> GetByIdAsync(long id)
    {
        var user = await _usersSysRepository.GetByIdAsync(id);

        return new UsersSysDTO
        {
            UserId = user.UserId,
            NameUser = user.NameUser,
            Login = user.Login,
            RoleUserId = user.RoleUserId,
            ProfUserId = user.ProfUserId,
            ContactUserId = user.ContactUserId
        };
    }
    
    public async Task<UsersSysDTO> AddUserAsync(UsersSysDTO usersSysDto, ContactUserDTO contactUserDto)
    {
        if (usersSysDto == null) throw new ArgumentNullException(nameof(usersSysDto));
        if (contactUserDto == null) throw new ArgumentNullException(nameof(contactUserDto));

        var contact = new ContactUser
        {
            EmailUser = contactUserDto.EmailUser,
            PhoneNumberUser = contactUserDto.PhoneNumberUser
        };

        await _contactUserRepository.AddAsync(contact); // após SaveChanges, contact.ContactUserId está preenchido

        var user = new UsersSys
        {
            NameUser = usersSysDto.NameUser,
            Login = usersSysDto.Login,
            PasswordUser = usersSysDto.PasswordUser, // ideal: hashear
            RoleUserId = usersSysDto.RoleUserId,
            ProfUserId = usersSysDto.ProfUserId,
            ContactUserId = contact.ContactUserId
        };

        await _usersSysRepository.AddAsync(user);

        return new UsersSysDTO
        {
            UserId = user.UserId,
            NameUser = user.NameUser,
            Login = user.Login,
            PasswordUser = "***",
            RoleUserId = user.RoleUserId,
            ProfUserId = user.ProfUserId,
            ContactUserId = user.ContactUserId
        };
    }


    public async Task DeleteAsync(long id)
    {
        try
        {
            await _usersSysRepository.DeleteAsync(id);
        }
        catch (UsersSysRepository.NotFoundException ex)
        {
            throw new UsersSysRepository.NotFoundException($"User with ID {id} not founded.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error when Trying to delete the user with id {id}: {ex.Message}");
        }
    }

    public async Task<PagedResult<UsersSysDTO>> SearchAsync(
        string? name,
        string? login,
        long? roleUserId,
        long? profUserId,
        int page,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;
        sortBy ??= "userId";
        sortDir ??= "asc";

        var (items, total) = await _usersSysRepository.SearchAsync(
            name, login, roleUserId, profUserId,
            page, pageSize, sortBy, sortDir
        );

        var dtoItems = items.Select(user => new UsersSysDTO
        {
            UserId = user.UserId,
            NameUser = user.NameUser,
            Login = user.Login,
            PasswordUser = "***",
            RoleUserId = user.RoleUserId,
            ProfUserId = user.ProfUserId,
            ContactUserId = user.ContactUserId
        }).ToList();

        var totalPages = (int)Math.Ceiling(total / (double)pageSize);

        return new PagedResult<UsersSysDTO>
        {
            Items = dtoItems,
            PageInfo = new PageInfo
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = total,
                TotalPages = totalPages
            }
        };
    }
}