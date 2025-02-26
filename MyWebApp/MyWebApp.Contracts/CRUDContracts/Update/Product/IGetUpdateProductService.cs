using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Update.Product;

public interface IGetUpdateProductService
{
    public Data.Models.Product? GetUpdateProduct(IUnitOfWork unitOfWork, int id);
}