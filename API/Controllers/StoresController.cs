using Application.Books.Commands;
using Application.Books.Commands.Create;
using Application.Stores.Commands.AddBook;
using Application.Stores.Commands.Create;
using Application.Stores.Commands.Delete;
using Application.Stores.Commands.Update;
using Application.Stores.Queries.GetAll;
using Application.Stores.Queries.GetById;
using Domain.Books;
using Domain.Stores;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StoresController : Controller
{ 
    private readonly IMediator _mediator;

    public StoresController(IMediator mediator)
    {
        _mediator = mediator;
    }
  
    [HttpGet]
    public async Task<ActionResult<List<Store>>> GetAll()
    {
        var stores = await _mediator.Send(new GetAllStoresQuery());

        return Ok(stores);
    }

    [HttpGet("{id}")]
    public async Task<OkObjectResult> GetById([FromRoute] int id)
    {
        var store = await _mediator.Send(new GetByIdStoreQuery()
        {
            Id = id
        });
        
        return Ok(store);
    }

    [Authorize(Roles = "StoreAdmin")] // Restrict to StoreAdmin role
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStoreCommand command)
    {
        var storeId = await _mediator.Send(command);
        return Created("", storeId);
    }
    
    [HttpPut("{id}")]
    public async Task<NoContentResult> Update([FromRoute] int id, [FromBody] UpdateStoreCommand command) 
    { 
        command.Id = id;
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    [Authorize(Roles = "StoreAdmin")] // Restrict to StoreAdmin role
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteStoreCommand() { Id = id });
        return NoContent();
    }
    
    [HttpPost("{storeId}/books/{bookId}")]
    public async Task<IActionResult> AddBook([FromRoute] int storeId, [FromRoute] int bookId )
    {
       await _mediator.Send(new AddBookToStoreCommand() { Id = storeId, BookId = bookId});

       return NoContent();
    }
    
}
