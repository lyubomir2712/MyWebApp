using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Update;
using Data.Data;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class PostUpdateCategoryService : IPostUpdateCategoryService
{
    public void PostUpdateCategoryServiceAsync(ICategoryRepository categoryRepo, Category obj)
    {
        categoryRepo.Update(obj);
        categoryRepo.Save();
    }
}