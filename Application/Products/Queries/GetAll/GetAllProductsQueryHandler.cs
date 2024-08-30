using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Products;
using MediatR;

namespace Application.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
{
    private readonly IProductRepository _repo;

    public GetAllProductsQueryHandler(IProductRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repo.GetAllAsync();

        var dto = products.Where(p => !p.IsDeleted)
            .Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Price = p.Price,
                Barcode = p.Barcode
                
            }).ToList();

        return dto;
    }
}