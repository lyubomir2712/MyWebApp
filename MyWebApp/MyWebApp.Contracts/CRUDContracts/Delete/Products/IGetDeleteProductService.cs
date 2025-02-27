using Data.Models;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Delete.Products;

public interface IGetDeleteProductService
{
 public Product? GetDeleteProducts(IUnitOfWork unitOfWork, int? id);
}