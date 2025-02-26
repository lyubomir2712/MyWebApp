using Contracts.CRUDContracts.Update.Product;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Update.Product;

public class GetUpdateProductService : IGetUpdateProductService
{
    public global::Data.Models.Product? GetUpdateProduct(IUnitOfWork unitOfWork, int id)
    {
        return unitOfWork.Product.Get(u => u.Id == id);
    }
}