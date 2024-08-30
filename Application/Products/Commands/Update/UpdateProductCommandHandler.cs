using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Products;
using MediatR;

namespace Application.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repo;

    public UpdateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }
    
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.Id);
        
        
        product.Name = request.Name;
        product.Price = request.Price;

        // Save changes to the repository
        await _repo.UpdateAsync(product);
    }
}