using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Token;
using Domain.User;
using MediatR;

namespace Application.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly IUserRepository _userRepo;
    private readonly TokenHandler _tokenHandler;

    public RegisterCommandHandler(IUserRepository userRepository, TokenHandler tokenHandler)
    {
        _userRepo = userRepository;
        _tokenHandler = tokenHandler;
    }
    
    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepo.GetByNameAsync(request.Username);

        if (existingUser is not null)
            throw new Exception("User exists");
        
        
        var newUser = new User
        {
            UserName = request.Username,
            PasswordHash =  BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        
        await _userRepo.CreateAsync(newUser);
        var token = _tokenHandler.CreateToken(newUser);
       
        return token.AccessToken;
    }
}