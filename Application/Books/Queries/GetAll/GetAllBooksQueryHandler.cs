﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Books;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Books.Queries.GetAll;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookListDto>>
{
    private readonly IBookRepository _repo;

    public GetAllBooksQueryHandler(IBookRepository repo, IConfiguration configuration)
    {
        _repo = repo;
    }

    public async Task<List<BookListDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _repo.GetAllAsync();

        var dto = books.Where(b => !b.IsDeleted)
            .Select(b => new BookListDto
            {
                Id = b.Id,
                Name = b.Name,
                Type = b.Type,
                PageCount = b.PageCount,
                Price = b.Price,
                PersonId = b.PersonId,
            }).ToList();
        
        return dto;
    }
}