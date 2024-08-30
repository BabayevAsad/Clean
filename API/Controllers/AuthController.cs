using Application;
using Application.Auth;
using Application.Auth.Login;
using Application.Token;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        var token = await _mediator.Send(registerCommand);
        
        return Ok(token);
     }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        var token = await _mediator.Send(loginCommand);
        
        return Ok(token);
    } 
}