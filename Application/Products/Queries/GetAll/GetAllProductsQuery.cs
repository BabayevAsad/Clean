using System.Collections.Generic;
using MediatR;

namespace Application.Products.Queries.GetAll;

public class GetAllProductsQuery : IRequest<List<ProductListDto>>
{
    
}   