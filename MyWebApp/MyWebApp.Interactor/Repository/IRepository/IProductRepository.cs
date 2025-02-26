using Data.Models;

namespace Data.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    public void Update(Product obj);
}