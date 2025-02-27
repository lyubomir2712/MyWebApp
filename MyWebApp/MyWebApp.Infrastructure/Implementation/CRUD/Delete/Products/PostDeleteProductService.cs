using Contracts.CRUDContracts.Delete.Products;
using Data.Models;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Delete.Products;

public class PostDeleteProductService : IPostDeleteProductService
{

    public void PostDeleteProduct(IUnitOfWork unitOfWork, Product obj)
    {
        unitOfWork.Product.Remove(obj);
        unitOfWork.Save();
    }
}