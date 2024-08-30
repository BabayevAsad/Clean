using System;
using System.Linq;
using Domain.Products;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DbSet<Product> _dbSet;  
    
    public ProductRepository(DataContext dataContext) : base(dataContext)
    {
        _dbSet = dataContext.Set<Product>();
    }

    public Product GetByName(string name)
    {
        var result = _dbSet.FirstOrDefault(p => p.Name.Equals(name));
        
        return result ?? throw new InvalidOperationException("Product not found.");
    }
}
    
    
