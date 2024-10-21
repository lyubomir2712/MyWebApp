using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface IGetDeleteCategoryService
{
    public Task<Category?> GetDeleteCategoryAsync(ApplicationDbContext dbContext, int? id);
}