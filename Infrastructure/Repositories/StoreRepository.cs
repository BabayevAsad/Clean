using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Stores;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StoreRepository: BaseRepository<Store>, IStoreRepository
{
    private readonly DbSet<Store> _dbSet;  
    
    public StoreRepository(DataContext dataContext) : base(dataContext)
    {
        _dbSet = dataContext.Set<Store>();
    }

    public Store GetByName(string name)
    {
        var result = _dbSet.FirstOrDefault(p => p.Name.Equals(name));
        
        return result ?? throw new InvalidOperationException("Store not found.");
    }
    
    public new async Task<Store> GetByIdAsync(int id)
    {
        return await _dbSet.Where(p => !p.IsDeleted && p.Id == id).Include(s => s.Books).
            FirstOrDefaultAsync() ?? throw new InvalidOperationException();
    }
}

    
