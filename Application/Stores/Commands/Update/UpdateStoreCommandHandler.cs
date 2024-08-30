using System.Threading;
using System.Threading.Tasks;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Commands.Update;

public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand>
{
    private readonly IStoreRepository _repo;

    public UpdateStoreCommandHandler(IStoreRepository repo)
    {
        _repo = repo;
    }
    
    public async Task Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await _repo.GetByIdAsync(request.Id);
        
        store.Name = request.Name;
        store.Count = request.Count;
        store.Location = request.Location;

        await _repo.UpdateAsync(store);
    }
}