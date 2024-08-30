using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Stores.Queries;
using Domain.Books;
using MediatR;

namespace Application.Books.Queries.GetById;

public class GetByIdBookHandler : IRequestHandler<GetByIdBookQuery, BookDetailsDto>
{
    private readonly IBookRepository _repo;

    public GetByIdBookHandler(IBookRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<BookDetailsDto> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _repo.GetByIdAsync(request.Id);

        var bookDetails = new BookDetailsDto()
        {
            Id = book.Id,
            Name = book.Name,
            Type = book.Type,
            PageCount = book.PageCount,
            Price = book.Price,
            PersonId = book.PersonId,
            Stores = book.Stores.Select(t => new StoreDto()
            {
                Id = t.Id,
                Name = t.Name,
                Location = t.Location,
                Count = t.Count
            }).ToList()
        };
        
        return bookDetails;
    } 
}