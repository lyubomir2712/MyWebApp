using Data.Models;

namespace Data.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    // void Save();
}