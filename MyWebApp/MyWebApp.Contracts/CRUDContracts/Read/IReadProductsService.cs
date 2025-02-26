using Data.Models;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts;

public interface IReadProductsService
{
    public List<Product> GetAllProductsAsync(IUnitOfWork unitOfWork);

}