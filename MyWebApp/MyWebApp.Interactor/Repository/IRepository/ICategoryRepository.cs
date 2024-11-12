using Data.Models;
using Data.Repository.IRepository;

namespace Data.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    // void Save();
}