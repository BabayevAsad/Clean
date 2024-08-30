using System;
using System.Linq;
using Domain.People;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    private readonly DbSet<Person> _dbSet;
    
    public PersonRepository(DataContext dataContext) : base(dataContext)
    {
        _dbSet = dataContext.Set<Person>();
    }
    
    public Person GetByName(string name)
    {
        var result = _dbSet.FirstOrDefault(p => p.Name.Equals(name));
        
        return result ?? throw new InvalidOperationException("Person not found.");
    }
}