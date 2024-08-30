using System.Threading;
using System.Threading.Tasks;
using Domain.Products;
using MediatR;

namespace Application.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repo;

    public CreateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            Barcode = request.Barcode
        };
        
        await _repo.CreateAsync(product); 
        return product.Id; 
    }
}