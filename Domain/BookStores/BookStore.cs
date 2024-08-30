using Domain.Base;
using Domain.Books;
using Domain.Stores;

namespace Domain.BookStores;

public class BookStore : BaseEntity
{
    public int BookId { get; set; }
    public int StoreId { get; set; }
    
    public Book Book { get; set; }
    public Store Store { get; set; }
    
}