using Contracts.CRUDContracts.Delete.Products;
using Data.Models;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Delete.Products;

public class GetDeleteProductService : IGetDeleteProductService
{
    
    public Product? GetDeleteProducts(IUnitOfWork unitOfWork, int? id)
    {
        return unitOfWork.Product.Get(u => u.Id == id);
    }
}