using MediatR;

namespace Application.People.Queries.GetById;

public class GetByIdPersonQuery : PersonDto, IRequest<PersonDto>
{
}