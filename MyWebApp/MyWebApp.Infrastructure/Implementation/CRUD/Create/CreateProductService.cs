using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Create;

public class CreateProductService : ICreateProductService
{
    public void CreateProduct(IUnitOfWork unitOfWork, Product obj)
    {
        unitOfWork.Product.Add(obj);
    }
}