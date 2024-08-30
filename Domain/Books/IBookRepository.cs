using Domain.Base;

namespace Domain.Books;

public interface IBookRepository : IBaseRepository<Book>
{
   Book GetByName(string name);
}