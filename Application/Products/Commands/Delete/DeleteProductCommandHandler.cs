using System.Threading;
using System.Threading.Tasks;
using Domain.Products;
using MediatR;

namespace Application.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repo;

    public DeleteProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }
    
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await  _repo.GetByIdAsync(request.Id);
        
        _repo.DeleteAsync(product);
    }
}