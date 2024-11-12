using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Create;

public class CreateCategoryService : ICreateCategoryService
{
    public void CreateCategoryAsync(IUnitOfWork? unitOfWork, Category obj)
    {
        unitOfWork.Category.Add(obj);
        unitOfWork.Save();
    }
}