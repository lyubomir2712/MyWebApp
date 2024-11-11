using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Data.Repository;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class GetUpdateCategoryService : IGetUpdateCategoryService
{
    public Category? GetUpdateCategoryAsync(ICategoryRepository dbContext, int? id)
    {
        return dbContext.Get(u => u.Id == id);
    }
}