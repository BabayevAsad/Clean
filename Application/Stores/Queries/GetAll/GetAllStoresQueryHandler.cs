using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Queries.GetAll
{
    public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<StoreListDto>>
    {
        private readonly IStoreRepository _repo;

        public GetAllStoresQueryHandler(IStoreRepository repo)
        {
            _repo = repo;
        }
    
        public async Task<List<StoreListDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _repo.GetAllAsync();

            var dto = stores.Select(s => new StoreListDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Location = s.Location,
                    Count = s.Count
                }).ToList();
        
            return dto;
        }
    }
}