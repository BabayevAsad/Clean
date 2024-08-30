using System.Collections.Generic;
using MediatR;

namespace Application.Stores.Queries.GetAll;

public class GetAllStoresQuery : IRequest<List<StoreListDto>>
{
    
}