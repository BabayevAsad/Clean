using Domain.BookStores;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookStoreRepository : BaseRepository<BookStore>, IBookStoreRepository
{
    private readonly DbSet<BookStore> _dbSet;

    public BookStoreRepository(DataContext dataContext) : base(dataContext)
    {
        _dbSet = dataContext.Set<BookStore>();
    }
}