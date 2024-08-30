using MediatR;

namespace Application.Stores.Commands.AddBook;

public class AddBookToStoreCommand : BaseCommand, IRequest
{
    public int BookId { get; set; }
}