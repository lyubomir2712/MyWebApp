using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD;

public class GetDeleteCategoryService : IGetDeleteCategoryService
{
    public async Task<Category?> GetDeleteCategoryAsync(ApplicationDbContext dbContext, int? id)
    {
        return await dbContext.Categories.FindAsync(id);
    }
}