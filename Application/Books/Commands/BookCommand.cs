using System.Collections.Generic;
using Domain.Stores;

namespace Application.Books.Commands;

public class BookCommand : BaseCommand
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int PageCount { get; set; }
    public int Price { get; set; }
    public int PersonId { get; set; }
    public List<int> StoresId { get; set; } = new List<int>();
}