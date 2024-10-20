using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface IDeleteCategoryService
{
    public Task<Category?> DeleteCategoryAsync(ApplicationDbContext dbContext, int? id);
}