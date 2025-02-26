using Data.Data;
using Data.Models;
using Data.Repository.IRepository;

namespace Data.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Product obj)
    {
        _db.Update(obj);
    }
}