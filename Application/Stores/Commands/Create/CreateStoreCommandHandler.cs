using System.Threading;
using System.Threading.Tasks;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Commands.Create
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, int>
    {
        private readonly IStoreRepository _repo;
 
        public CreateStoreCommandHandler(IStoreRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store
            {
                Id = request.Id,
                Name = request.Name,
                Location = request.Location,
                Count = request.Count,
            };
        
            await _repo.CreateAsync(store); 
            return store.Id; 
        }
    }
}