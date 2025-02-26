using Contracts.CRUDContracts.Update.Product;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Update.Product;

public class PostUpdateProductService : IPostUpdateProductService
{
    public void PostUpdateProduct(IUnitOfWork _unitOfWork, global::Data.Models.Product obj)
    {
          _unitOfWork.Product.Update(obj);
          _unitOfWork.Save();
    }
}