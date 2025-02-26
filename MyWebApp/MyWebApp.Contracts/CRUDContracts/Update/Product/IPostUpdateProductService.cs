using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Update.Product;

public interface IPostUpdateProductService
{
    public void PostUpdateProduct(IUnitOfWork _unitOfWork, Data.Models.Product obj);
}