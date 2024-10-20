using Data.Data;
using Data.Models;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD;

public class DeleteCategoryService : IDeleteCategoryService
{
    public async Task<Category?> DeleteCategoryAsync(ApplicationDbContext dbContext, int? id)
    {
        return dbContext.Categories.Find(id);
    }
}