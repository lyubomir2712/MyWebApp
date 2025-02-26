using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "C# in Depth",
                Description = "Comprehensive guide to C#",
                ISBN = "9781617294532",
                Author = "Jon Skeet",
                ListPrice = 49.99,
                Price = 45.99,
                Price50 = 39.99,
                Price100 = 34.99
            },
            new Product
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Description = "Classic software development book",
                ISBN = "9780135957059",
                Author = "Andrew Hunt, David Thomas",
                ListPrice = 59.99,
                Price = 54.99,
                Price50 = 49.99,
                Price100 = 44.99
            },
        new Product
            {
                Id = 3,
                Title = "Clean Code",
                Description = "A Handbook of Agile Software Craftsmanship",
                ISBN = "9780132350884",
                Author = "Robert C. Martin",
                ListPrice = 50.99,
                Price = 45.99,
                Price50 = 40.99,
                Price100 = 35.99
            }
        );
    }
}