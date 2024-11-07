using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IGetUpdateCategoryService
{
    public Task<Category?> GetUpdateCategoryAsync(ApplicationDbContext dbContext, int? id);
}