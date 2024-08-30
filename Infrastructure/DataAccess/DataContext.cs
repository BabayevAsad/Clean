using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Books;
using Domain.BookStores;
using Domain.People;
using Domain.Products;
using Domain.Stores;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;
            var baseEntity = (BaseEntity)entity.Entity;

            if (entity.State == EntityState.Added)
            {
                baseEntity.CreatedDate = now;
            }

            baseEntity.UpdatedDate = now;
        }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<BookStore> BookStores { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("products");
        });
        
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("people");
            
            entity.HasMany<Book>()
                .WithOne()
                .HasForeignKey(b => b.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });
        
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("books");
            
            entity.HasMany(e => e.Stores)
                .WithMany(e => e.Books)
                .UsingEntity<BookStore>();
        });
        
        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("stores");
        });
        
        modelBuilder.Entity<BookStore>(entity =>
        {
            entity.HasKey(bs => new { bs.BookId, bs.StoreId });
            entity.ToTable("book_stores");
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("user");
        });
        
        base.OnModelCreating(modelBuilder);
    }
}
