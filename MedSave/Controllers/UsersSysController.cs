using MedSave.Services;
using MedSave.DTOs;
using MedSave.DTOs.Hypermedia;
using MedSave.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace MedSave.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersSysController : ControllerBase
{
    private readonly IUsersSysService _usersSysService;
    private readonly LinkGenerator _links;

    public UsersSysController(IUsersSysService usersSysService, LinkGenerator links)
    {
        _usersSysService = usersSysService;
        _links = links;
    }
    
    private string Href(string actionName, object? values = null) =>
        _links.GetPathByAction(HttpContext, action: actionName, controller: "UsersSys", values: values) ?? "#";

    private IEnumerable<Link> UserItemLinks(long id) => new[]
    {
        new Link { Rel = "self",   Href = Href(nameof(GetUserById), new { id }), Method = "GET" },
        new Link { Rel = "delete", Href = Href(nameof(DeleteUser),  new { id }), Method = "DELETE" },
        new Link { Rel = "list",   Href = Href(nameof(GetAllUsers)),                Method = "GET" },
        new Link { Rel = "search", Href = Href(nameof(Search)),                     Method = "GET" },
        new Link { Rel = "create", Href = Href(nameof(AddUser)),                    Method = "POST" }
    };

    private IEnumerable<Link> UserCollectionLinks(int page, int pageSize, int totalPages, object? filters = null)
    {
        var baseValues = new Dictionary<string, object?>
        {
            ["page"] = page,
            ["pageSize"] = pageSize
        };

        if (filters is not null)
        {
            foreach (var prop in filters.GetType().GetProperties())
                baseValues[prop.Name] = prop.GetValue(filters);
        }

        var links = new List<Link>
        {
            new Link { Rel = "self",    Href = Href(nameof(Search), baseValues), Method = "GET" },
            new Link { Rel = "create",  Href = Href(nameof(AddUser)),            Method = "POST" },
            new Link { Rel = "all",     Href = Href(nameof(GetAllUsers)),        Method = "GET" }
        };

        if (page > 1)
        {
            var prev = new Dictionary<string, object?>(baseValues) { ["page"] = page - 1 };
            links.Add(new Link { Rel = "prev", Href = Href(nameof(Search), prev), Method = "GET" });
        }

        if (page < totalPages)
        {
            var next = new Dictionary<string, object?>(baseValues) { ["page"] = page + 1 };
            links.Add(new Link { Rel = "next", Href = Href(nameof(Search), next), Method = "GET" });
        }

        return links;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers() // Funcionando + HATEOAS
    {
        try
        {
            var users = await _usersSysService.GetAllUsersAsync();

            var items = users.Select(u => new Resource<UsersSysDTO>
            {
                Data = u,
                _links = UserItemLinks(u.UserId)
            });

            var collection = new CollectionResource<UsersSysDTO>
            {
                Items = items,
                PageInfo = new
                {
                    page = 1,
                    pageSize = users.Count(),
                    totalItems = users.Count(),
                    totalPages = 1
                },
                _links = new[]
                {
                    new Link { Rel = "self",   Href = Href(nameof(GetAllUsers)), Method = "GET" },
                    new Link { Rel = "search", Href = Href(nameof(Search)),      Method = "GET" },
                    new Link { Rel = "create", Href = Href(nameof(AddUser)),     Method = "POST" }
                }
            };

            return Ok(collection);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving users", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id) // Funcionando + HATEOAS
    {
        try
        {
            var user = await _usersSysService.GetByIdAsync(id);

            var resource = new Resource<UsersSysDTO>
            {
                Data = user!,
                _links = UserItemLinks(id)
            };

            return Ok(resource);
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
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest req) // Funcionando + HATEOAS
    {
        if (req?.UsersSysDto == null || req.ContactUserDto == null)
            return BadRequest(new { message = "Payload inválido. Envie usersSysDto e contactUserDto." });

        var created = await _usersSysService.AddUserAsync(req.UsersSysDto, req.ContactUserDto);

        var resource = new Resource<UsersSysDTO>
        {
            Data = created,
            _links = new[]
            {
                new Link { Rel = "self",   Href = Href(nameof(GetUserById), new { id = created.UserId }), Method = "GET" },
                new Link { Rel = "list",   Href = Href(nameof(GetAllUsers)),                              Method = "GET" },
                new Link { Rel = "search", Href = Href(nameof(Search)),                                   Method = "GET" },
                new Link { Rel = "delete", Href = Href(nameof(DeleteUser), new { id = created.UserId }),  Method = "DELETE" }
            }
        };

        return CreatedAtAction(nameof(GetUserById), new { id = created.UserId }, resource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id) // Funcionando
    {
        try
        {
            await _usersSysService.DeleteAsync(id);
            return Ok(new
            {
                message = $"User with id {id} deleted with success.",
                _links = new[]
                {
                    new Link { Rel = "list",   Href = Href(nameof(GetAllUsers)), Method = "GET" },
                    new Link { Rel = "search", Href = Href(nameof(Search)),      Method = "GET" },
                    new Link { Rel = "create", Href = Href(nameof(AddUser)),     Method = "POST" }
                }
            });
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

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? name,
        [FromQuery] string? login,
        [FromQuery] long? roleUserId,
        [FromQuery] long? profUserId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "userId",
        [FromQuery] string sortDir = "asc")
    {
        try
        {
            var result = await _usersSysService.SearchAsync(
                name, login, roleUserId, profUserId,
                page, pageSize, sortBy, sortDir
            );

            var items = result.Items.Select(u => new Resource<UsersSysDTO>
            {
                Data = u,
                _links = UserItemLinks(u.UserId)
            });

            var collection = new CollectionResource<UsersSysDTO>
            {
                Items = items,
                PageInfo = result.PageInfo,
                _links = UserCollectionLinks(
                    page: result.PageInfo.Page,
                    pageSize: result.PageInfo.PageSize,
                    totalPages: result.PageInfo.TotalPages,
                    filters: new { name, login, roleUserId, profUserId, sortBy, sortDir }
                )
            };

            return Ok(collection);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error when searching users.", details = ex.Message });
        }
    }
}

public class CreateUserRequest
{
    public UsersSysDTO UsersSysDto { get; set; } = default!;
    public ContactUserDTO ContactUserDto { get; set; } = default!;
}
