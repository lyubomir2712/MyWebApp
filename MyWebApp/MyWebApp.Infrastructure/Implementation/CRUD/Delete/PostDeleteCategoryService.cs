using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Implementation.CRUD.Delete;

public class PostDeleteCategoryService : IPostDeleteCategoryService
{
    public async Task PostDeleteCategoryAsync(ApplicationDbContext dbContext, Category obj)
    {
        dbContext?.Categories.Remove(obj);
        await dbContext.SaveChangesAsync();
    }
}