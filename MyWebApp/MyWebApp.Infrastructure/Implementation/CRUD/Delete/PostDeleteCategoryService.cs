using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using Data.Repository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Delete;

public class PostDeleteCategoryService : IPostDeleteCategoryService
{
    public void PostDeleteCategoryAsync(ICategoryRepository categoryRepo, Category obj)
    {
        categoryRepo.Remove(obj);
        categoryRepo.Save();
    }
}