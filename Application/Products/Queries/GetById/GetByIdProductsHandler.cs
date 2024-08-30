using System.Threading;
using System.Threading.Tasks;
using Domain.Products;
using MediatR;

namespace Application.Products.Queries.GetById;

public class GetByIdProductsHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
{
    private readonly IProductRepository _repo;

    public GetByIdProductsHandler(IProductRepository repo)
    {
        _repo = repo;

    }
    
    public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.Id);
        
        var productDto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Price = product.Price,
            Barcode = product.Barcode
        };

        return productDto;
    }
}