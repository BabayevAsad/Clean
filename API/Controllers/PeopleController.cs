using Application.People.Commands.Create;
using Application.People.Commands.Delete;
using Application.People.Commands.Update;
using Application.People.Queries.GetAll;
using Application.People.Queries.GetById;
using Domain.People;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PeopleController : Controller
{
    private readonly IMediator _mediator;

    public PeopleController(IMediator mediator)
    {
        _mediator = mediator;
    }
  
    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAll()
    {
        var people = await _mediator.Send(new GetAllPeopleQuery());

        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<OkObjectResult> GetById([FromRoute] int id)
    {
        var person = await _mediator.Send(new GetByIdPersonQuery()
        {
            Id = id
        });
        
        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
    {
        var personId = await _mediator.Send(command);

        return Created("", personId);
    }
    
    [HttpPut("{id}")]
    public async Task<NoContentResult> Update([FromRoute] int id, [FromBody] UpdatePersonCommand command) 
    { 
        command.Id = id;
        
        await _mediator.Send(command);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeletePersonCommand() { Id = id });
        
        return NoContent();
    }
}