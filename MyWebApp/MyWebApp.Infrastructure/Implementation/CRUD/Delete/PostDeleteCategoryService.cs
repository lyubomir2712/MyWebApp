using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Delete;

public class PostDeleteCategoryService : IPostDeleteCategoryService
{
    public void PostDeleteCategoryAsync(IUnitOfWork unitOfWork, Category obj)
    {
        unitOfWork.Category.Remove(obj);
        unitOfWork.Save();
    }
}