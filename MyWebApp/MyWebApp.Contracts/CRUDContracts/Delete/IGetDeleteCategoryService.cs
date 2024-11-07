using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts.Delete;

public interface IGetDeleteCategoryService
{
    public Task<Category?> GetDeleteCategoryAsync(ApplicationDbContext dbContext, int? id);
}