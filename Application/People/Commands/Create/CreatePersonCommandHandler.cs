using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using MediatR;

namespace Application.People.Commands.Create;

internal class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IPersonRepository _repo;

    public CreatePersonCommandHandler(IPersonRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Id = request.Id,
            Name = request.Name,
            Surname = request.Surname,
            FatherName = request.FatherName,
            BirthDate = request.BirthDate,
            GenderId = (int)GenderHelper.GetById(request.GenderId),
            FinNumber = request.FinNumber,
        };

         await _repo.CreateAsync(person);
         
         return person.Id;
    }
}