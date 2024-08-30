using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using MediatR;

namespace Application.People.Queries.GetById;

public class GetByIdPersonHandler : IRequestHandler<GetByIdPersonQuery, PersonDto>
{
    private readonly IPersonRepository _repo;

    public GetByIdPersonHandler(IPersonRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<PersonDto> Handle(GetByIdPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await _repo.GetByIdAsync(request.Id);

        var personDto = new PersonDto
        {
            Id = person.Id,
            Name = person.Name,
            Surname = person.Surname,
            FatherName = person.FatherName,
            BirthDate = person.BirthDate,
            GenderId = person.GenderId,
            FinNumber = person.FinNumber,
        };
        
        return personDto;
    } 
}