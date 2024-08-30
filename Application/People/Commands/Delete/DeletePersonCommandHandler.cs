using System.Threading;
using System.Threading.Tasks;
using Domain.Books;
using Domain.People;
using MediatR;

namespace Application.People.Commands.Delete;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRepository _repo;
    private readonly IBookRepository _bookRepo;

    public DeletePersonCommandHandler(IPersonRepository repo, IBookRepository brepo)
    {
        _repo = repo;
        _bookRepo = brepo;
    }
    
    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _repo.GetByIdAsync(request.Id);
        
        await _repo.DeleteAsync(person);
        
        var books = await _bookRepo.GetAllAsync(p => p.PersonId == request.Id && !p.IsDeleted);

        foreach (var book in books)
        {
            await _bookRepo.DeleteAsync(book);
        }
    }
}