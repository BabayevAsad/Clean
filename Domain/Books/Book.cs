using System.Collections.Generic;
using Domain.Base;
using Domain.BookStores;
using Domain.Stores;

namespace Domain.Books;

public class 
    Book : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int PageCount { get; set; }  
    public int Price { get; set; }
    public int PersonId { get; set; }
    public List<Store> Stores { get; set; } = [];
}