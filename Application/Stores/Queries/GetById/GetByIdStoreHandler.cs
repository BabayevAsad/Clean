using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Books.Queries;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Queries.GetById;

public class GetByIdStoreHandler : IRequestHandler<GetByIdStoreQuery, StoreDetailDto>
{
    private readonly IStoreRepository _repo;

    public GetByIdStoreHandler(IStoreRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<StoreDetailDto> Handle(GetByIdStoreQuery request, CancellationToken cancellationToken)
    {
        var store = await _repo.GetByIdAsync(request.Id);
        
        var storeDto = new StoreDetailDto()
        {
            Id = store.Id,
            Name = store.Name,
            Location = store.Location,
            Count = store.Count,
            Books = store.Books.Select(b=> new BookDto()
            {
                Id = b.Id,
                Name = b.Name,
                Type = b.Type,
                PageCount = b.PageCount,
                Price = b.Price,
                PersonId = b.PersonId
            }).ToList()
        };
        
        return storeDto;
    } 
}