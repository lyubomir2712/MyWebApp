using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Implementation.CRUD;

public class UpdateCategoryService : IUpdateCategoryService
{
    public async Task<Category?> UpdateCategoryAsync(ApplicationDbContext dbContext, int? id)
    {
        return await dbContext.Categories.FindAsync(id);
    }
}