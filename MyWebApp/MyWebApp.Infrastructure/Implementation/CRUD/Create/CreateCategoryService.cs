using Data.Data;
using Data.Models;
using Data.Repository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Create;

public class CreateCategoryService : ICreateCategoryService
{
    public void CreateCategoryAsync(ICategoryRepository? categoryRepo, Category obj)
    {
        categoryRepo.Add(obj);
        categoryRepo.Save();
    }
}