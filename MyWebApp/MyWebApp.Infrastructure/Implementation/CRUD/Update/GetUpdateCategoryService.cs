using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class GetUpdateCategoryService : IGetUpdateCategoryService
{
    public async Task<Category?> GetUpdateCategoryAsync(ApplicationDbContext dbContext, int? id)
    {
        return await dbContext.Categories.FindAsync(id);
    }
}