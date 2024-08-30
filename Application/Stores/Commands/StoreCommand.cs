using System.Collections.Generic;
using Domain.Books;

namespace Application.Stores.Commands;

public class StoreCommand : BaseCommand
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Count { get; set; }
    public ICollection<int> BookId { get; set; } = new List<int>();
}