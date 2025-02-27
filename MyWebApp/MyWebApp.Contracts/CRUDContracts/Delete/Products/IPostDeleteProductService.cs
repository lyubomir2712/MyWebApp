using Data.Models;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Delete.Products;

public interface IPostDeleteProductService
{
    public void PostDeleteProduct(IUnitOfWork unitOfWork, Product obj);
}