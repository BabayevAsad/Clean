using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Books;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly DbSet<Book> _dbSet;

    public BookRepository(DataContext dataContext) : base(dataContext)
    {
        _dbSet = dataContext.Set<Book>();
    }
    
    public Book GetByName(string name)
    {
        var result = _dbSet.FirstOrDefault(p => p.Name.Equals(name));
        
        return result ?? throw new InvalidOperationException("Book not found.");
    }
    
    public new async Task<Book> GetByIdAsync(int id)
    {
        return await _dbSet.Where(p => !p.IsDeleted && p.Id == id).Include(s => s.Stores).
            FirstOrDefaultAsync() ?? throw new InvalidOperationException();
    }
}