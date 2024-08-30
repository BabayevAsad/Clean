using System.Threading;
using System.Threading.Tasks;
using Domain.Books;
using Domain.BookStores;
using Domain.Stores;
using MediatR;

namespace Application.Stores.Commands.AddBook;

public class AddBookToStoreCommandHandler : IRequestHandler<AddBookToStoreCommand>
{
    private readonly IBookRepository _bookRepo;
    private readonly IStoreRepository _storeRepo;
    private readonly IBookStoreRepository _bookStoreRepo;

    public AddBookToStoreCommandHandler(IBookRepository bookRepo, IStoreRepository storeRepo, IBookStoreRepository bookStoreRepository, IBookStoreRepository bookStoreRepo)
    {
        _bookRepo = bookRepo;
        _storeRepo = storeRepo;
        _bookStoreRepo = bookStoreRepo;
    }

    public async Task Handle(AddBookToStoreCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepo.GetByIdAsync(request.BookId);
        var store = await _storeRepo.GetByIdAsync(request.Id);

        var bookStore = new Domain.BookStores.BookStore()
        {
            BookId = request.BookId,
            StoreId = request.Id
        };
        
        await _bookStoreRepo.CreateAsync(bookStore);
    }
}