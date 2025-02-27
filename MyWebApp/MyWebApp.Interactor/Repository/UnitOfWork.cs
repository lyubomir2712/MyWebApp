using System.Net.Mime;
using Data.Data;
using Data.Repository.IRepository;

namespace Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public ICategoryRepository Category { get; private set; }
    public IProductRepository Product { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        Product = new ProductRepository(_db);
    }
    
    public void Save()
    {
        _db.SaveChanges();
    }
}