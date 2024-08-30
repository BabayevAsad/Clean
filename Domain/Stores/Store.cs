using System.Collections.Generic;
using Domain.Base;
using Domain.Books;

namespace Domain.Stores;

public class Store : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Count { get; set; }
    public List<Book> Books {get;set; } = new List<Book>();

}