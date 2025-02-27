using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface ICreateProductService
{
    public void CreateProduct(IUnitOfWork unitOfWork,Product obj);
}