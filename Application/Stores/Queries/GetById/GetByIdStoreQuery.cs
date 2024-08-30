using MediatR;

namespace Application.Stores.Queries.GetById;

public class GetByIdStoreQuery : StoreDto, IRequest<StoreDetailDto>
{
}