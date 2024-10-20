using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IUpdateCategoryService
{
    public Task<Category?> UpdateCategoryAsync(ApplicationDbContext dbContext, int? id);
}