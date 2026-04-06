using IdentityModel.Client;
using MedSave.DTOs;
using MedSave.DTOs.Hypermedia;
using MedSave.DTOs.Manufacturer;
using MedSave.Repositories;
using MedSave.Services.Manufacturer;
using Microsoft.AspNetCore.Mvc;

namespace MedSave.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;

    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var dtos = await _manufacturerService.GetAllAsync();

            return Ok(new
            {
                items = dtos,
                pageInfo = new
                {
                    page = 1,
                    pageSize = dtos.Count(),
                    totalItems = dtos.Count(),
                    totalPages = 1
                }
            });
        }
        catch (ManufacturerRepository.NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when searching for the manufacturers",
                details = ex.Message
            });
        }
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var dto = await _manufacturerService.GetByIdAsync(id);

            return Ok(dto);
        }

        catch (ManufacturerRepository.NotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when searching for the manufacturer",
                details = ex.Message
            });
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddManufacturer([FromBody] CreateManufacturerRequest req)
    {
        try
        {
            var created = await _manufacturerService.AddAsync(req.ManufacturerDto, req.AddressManufacturerDto, req.ContactManufacturerDto);
            
            return CreatedAtAction(nameof(GetById), new {id = created.ManufacId}, created);
        }

        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = "Invalid request body." });
        }

        catch (ManufacturerService.ConflictException ex)
        {
            return StatusCode(409, new { message = "CNPJ already registered." });
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when adding the manufacturer",
                details = ex.Message
            });
        }
        
        /*
         Exemplo de requisição
         
         { "manufacturerDto": { "nameManu": "manufacturerdasilva", "cnpj": 12345678912345 }, 
          "contactManufacturerDto": { "emailManu": "manufac@manufac.com", "phoneNumberManu": 11987760601 }, 
          "addressManufacturerDto": { "complement": "N/A", "numberManu": 1234, "addressDescription": "Rua Bloblis", "cep": 12345678, "neighId": 1 } }
         
         */
        
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateManufacturer(long id, [FromBody] ManufacturerDTO dto)
    {
        try
        {
            dto.ManufacId = id;

            await _manufacturerService.UpdateAsync(id, dto);
            return StatusCode(200, new { message = $"Manufacturer with id {id} updated" });
        }

        catch (ManufacturerService.NotFoundException ex)
        {
            return NotFound(new { message = $"Manufacturer with Id {id} not found" });
        }
        
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when adding the manufacturer",
                details = ex.Message
            });
        }
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteManufacturer(long id)
    {
        try
        {
            await _manufacturerService.DeleteAsync(id);

            return Ok(new { message = $"Manufacturer with Id {id} deleted" });
        }
        
        catch (ManufacturerService.NotFoundException ex)
        {
            return NotFound(new { message = $"Manufacturer with Id {id} not found" });
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when deleting the manufacturer",
                details = ex.Message
            });
        }
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Search(
        [FromQuery] int? cnpj,
        [FromQuery] long? contactManuId,
        [FromQuery] long? addressIdManufacturer,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "manufacId",
        [FromQuery] string sortDir = "asc"
    )
    {
        try
        {
            var result = await _manufacturerService.SearchAsync(cnpj, contactManuId, addressIdManufacturer, page, pageSize, sortBy, sortDir);

            return Ok(new { Items = result.Items, PageInfo = result.PageInfo });
        }

        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal error when searching the manufacturer",
                details = ex.Message
            });
        }
    }
}