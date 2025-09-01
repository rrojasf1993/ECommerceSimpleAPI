using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using ECommerce.TechnicalTest.Domain.Products.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTechnicalTest.ProductsService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IMediator _mediator;

    public ProductsController(IMediator mediatorInstance)
    {
        this._mediator = mediatorInstance;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto dto)
    {
        var result = await _mediator.Send(new CreateProductCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
    {
        if (id != dto.Id) return BadRequest("ID mismatch");

        var success = await _mediator.Send(new UpdateProductCmd(dto));
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteProductCmd(id));
        return success ? NoContent() : NotFound();
    }
}
