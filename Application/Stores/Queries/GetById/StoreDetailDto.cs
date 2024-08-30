using System.Collections.Generic;
using Application.Books.Queries;
using Domain.Books;

namespace Application.Stores.Queries.GetById;

public class StoreDetailDto : StoreDto
{
    public List<BookDto> Books { get; set; }
}