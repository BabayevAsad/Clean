using MediatR;

namespace Application.Stores.Commands.Create;

public class CreateStoreCommand : StoreCommand, IRequest<int> 
{
}