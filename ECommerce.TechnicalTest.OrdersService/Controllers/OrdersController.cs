using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IService<OrderDto> _ordersService;

    public OrdersController(IService<OrderDto> ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _ordersService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _ordersService.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderDto dto)
    {
        var result = await _ordersService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] OrderDto dto)
    {
        var success = await _ordersService.UpdateAsync(dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _ordersService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}