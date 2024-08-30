using Application.Products.Commands.Create;
using Application.Products.Commands.Delete;
using Application.Products.Commands.Update;
using Application.Products.Queries.GetAll;
using Application.Products.Queries.GetById;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{ 
    private readonly IMediator _mediator;

     public ProductsController(IMediator mediator)
     {
         _mediator = mediator;
     }
  
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
      var products = await _mediator.Send(new GetAllProductsQuery());

      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<OkObjectResult> GetById([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetByIdProductQuery
        {
            Id = id
        });
        
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);

        return Created("", productId);
    }
    
    [HttpPut("{id}")]
    public async Task<NoContentResult> Update([FromRoute] int id, [FromBody] UpdateProductCommand command) 
    { 
        command.Id = id;
        
        await _mediator.Send(command);
        return NoContent();
       }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProductCommand() { Id = id });
        return NoContent();
    }
}
