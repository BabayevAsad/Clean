using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using MediatR;

namespace Application.People.Queries.GetAll
{
    public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, List<PersonListDto>>
    {
        private readonly IPersonRepository _repo;

        public GetAllPeopleQueryHandler(IPersonRepository repo)
        {
            _repo = repo;
        }
    
        public async Task<List<PersonListDto>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            var people = await _repo.GetAllAsync();
        
            var dto = people
                .Select(p => new PersonListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    FatherName = p.FatherName,
                    BirthDate = p.BirthDate,
                    GenderId = p.GenderId,
                    FinNumber = p.FinNumber
                }).ToList();
        
            return dto;
        }
    }
}