using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IPostDeleteCategoryService
{
    public Task PostDeleteCategoryAsync(ApplicationDbContext dbContext, Category obj);
}