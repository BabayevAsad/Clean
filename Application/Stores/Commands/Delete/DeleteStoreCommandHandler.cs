using System.Threading;
using System.Threading.Tasks;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Commands.Delete;

public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand>
{
    private readonly IStoreRepository _repo;

    public DeleteStoreCommandHandler(IStoreRepository repo)
    {
        _repo = repo;
    }
    
    public async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await  _repo.GetByIdAsync(request.Id);
        
        await _repo.DeleteAsync(store);
    }
}