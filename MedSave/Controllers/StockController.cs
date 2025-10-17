using MedSave.DTOs;
using MedSave.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedSave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        /*
        [HttpGet]
    public async Task<IActionResult> GetAllUsers() //Funcionando
    {
        var users = await _usersSysService.GetAllUsersAsync();
        return Ok(users);
    }
        */
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var stock = await _stockService.GetByIdAsync(id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not founded", StringComparison.OrdinalIgnoreCase))
                    return NotFound(new { message = ex.Message });

                return StatusCode(500, new { message = "Error when searching for the stock", details = ex.Message });
            }
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] StockDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Invalid Payload." });

            if (dto.StockId != 0 && dto.StockId != id)
                return BadRequest(new { message = "The path ID differs from the body ID." });

            dto.StockId = id;

            try
            {
                await _stockService.UpdateAsync(dto);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not founded", StringComparison.OrdinalIgnoreCase))
                    return NotFound(new { message = ex.Message });

                return StatusCode(500, new { message = "Error when updating stock.", details = ex.Message });
            }
        }
    }
}
