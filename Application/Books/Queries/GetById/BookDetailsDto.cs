using System.Collections.Generic;
using Application.Stores.Queries;

namespace Application.Books.Queries.GetById;

public class BookDetailsDto : BookDto
{
    public List<StoreDto> Stores { get; set; }
}