using System.Linq.Expressions;
using Data.Data;
using Data.Models;

namespace Data.Repository;

public class CategoryRepository : Repository<Category>,  ICategoryRepository
{

    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}