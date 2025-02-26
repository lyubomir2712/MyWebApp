using Contracts.CRUDContracts;
using Data.Models;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Read;

public class ReadProductsService : IReadProductsService
{
    public List<Product> GetAllProductsAsync(IUnitOfWork unitOfWork)
    {
        return unitOfWork.Product.GetAll().ToList();
    }
}