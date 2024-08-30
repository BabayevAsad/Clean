using MediatR;

namespace Application.Products.Queries.GetById;

public class GetByIdProductQuery : BaseDto, IRequest<ProductDto>
{
    
}