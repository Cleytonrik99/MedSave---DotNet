using MedSave.Services;
using MedSave.DTOs;
using MedSave.Repositories;
using MedSave.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedSave.Controllers;

[Route("api/[controller]")]
public class UsersSysController : ControllerBase
{
    private readonly IUsersSysService _usersSysService;

    public UsersSysController(IUsersSysService usersSysService)
    {
        _usersSysService = usersSysService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers() //Funcionando
    {
        var users = await _usersSysService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id) //Funcionando
    {
        try
        {
            var user = await _usersSysService.GetByIdAsync(id);
            return Ok(user);
        }
        catch (UsersSysRepository.NotFoundException ex)
        {
            var errorResponse = new
            {
                StatusCode = 404,
                ErrorType = "UserNotFound",
                Message = $"User with Id {id} not found. Details: {ex.Message}"
            };
            return NotFound(errorResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });  // Retorna 500
        }
        
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest req) //Funcionando
    {
        if (req?.UsersSysDto == null || req.ContactUserDto == null)
            return BadRequest(new { message = "Payload inválido. Envie usersSysDto e contactUserDto." });

        var newUser = await _usersSysService.AddUserAsync(req.UsersSysDto, req.ContactUserDto);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
    }

    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id) //Funcionando
    {
        try
        {
            await _usersSysService.DeleteAsync(id);
            return Ok(new { message = $"User with id {id} deleted with sucess." });
        }
        catch (UsersSysRepository.NotFoundException ex)
        {
            var errorResponse = new
            {
                StatusCode = 404,
                ErrorType = "UserNotFound",
                Message = $"User with Id {id} not found. Details: {ex.Message}"
            };
            return NotFound(errorResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}