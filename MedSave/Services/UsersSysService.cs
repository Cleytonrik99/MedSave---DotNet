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

    public async Task<UsersSysDTO> GetByIdAsync(long id)
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
        var usobj = new ContactUser
        {
            EmailUser = contactUserDto.EmailUser,
            PhoneNumberUser = contactUserDto.PhoneNumberUser
        };
        
        await _contactUserRepository.AddAsync(usobj);
        
        var contact = await _context.ContactUser
            .FirstOrDefaultAsync(c => c.EmailUser == contactUserDto.EmailUser);
        
        var user = new UsersSys
        {
            NameUser = usersSysDto.NameUser,
            Login = usersSysDto.Login,
            PasswordUser = usersSysDto.PasswordUser,
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

    /*
    C - Usuário se cadastrar
    -> Criar um contato
    -> Verificar se o email e/ou telefone já está sendo usado
    -> Criar o contato no banco de dados
    -> Verificar se o Login já existe, se já existir, retornar um exception
    -> Pegar o id do contato criado, jogar "dentro" do usuário
    -> Criar o usuário no banco de dados
    -> Retornar um DTO do usuário


        R - Login
    -> Fazer um select no bd, com where usando o login e a senha que foram fornecidos
    -> Se alguma informação não bater retornar uma exception "Login ou Senha Inválidos"
    -> Retornar o id, nome


        U - Update na quantidade do STOCK
        D - Usuário deletar a própria conta
    */
/*
DROP TABLE MEDICINE_DISPENSE CASCADE CONSTRAINT;
DROP TABLE STOCK CASCADE CONSTRAINT;
DROP TABLE MOVEMENT_TYPE CASCADE CONSTRAINT;
DROP TABLE BATCH CASCADE CONSTRAINT;
DROP TABLE BATCH_MEDICINE CASCADE CONSTRAINT;
DROP TABLE MEDICINES CASCADE CONSTRAINT;
DROP TABLE CATEGORY_MEDICINE CASCADE CONSTRAINT;
DROP TABLE UNIT_MEASURE CASCADE CONSTRAINT;
DROP TABLE PHARMACEUTICAL_FORM CASCADE CONSTRAINT;
DROP TABLE ACTIVE_INGREDIENT CASCADE CONSTRAINT;
DROP TABLE MANUFACTURER CASCADE CONSTRAINT;
DROP TABLE CONTACT_MANUFACTURER CASCADE CONSTRAINT;
DROP TABLE USERS_SYS CASCADE CONSTRAINT;
DROP TABLE PROFILE_USER CASCADE CONSTRAINT;
DROP TABLE ROLE_USER CASCADE CONSTRAINT;
DROP TABLE CONTACT_USER CASCADE CONSTRAINT;
DROP TABLE LOCATION_STOCK CASCADE CONSTRAINT;
DROP TABLE ADDRESS_STOCK CASCADE CONSTRAINT;
DROP TABLE ADDRESS_MANUFACTURER CASCADE CONSTRAINT;
DROP TABLE NEIGHBOURHOOD CASCADE CONSTRAINT;
DROP TABLE CITY CASCADE CONSTRAINT;
DROP TABLE STATES CASCADE CONSTRAINT;
DROP TABLE "__EFMigrationsHistory" CASCADE CONSTRAINT;
DROP TABLE STOCK_MOVEMENT CASCADE CONSTRAINT;
DROP TABLE MEDICINE_ACTIVE_INGR CASCADE CONSTRAINT;
DROP TABLE MEDICINE_PHARM_FORM CASCADE CONSTRAINT;

commit;
*/
}