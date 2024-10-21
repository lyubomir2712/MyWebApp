using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IPostUpdateCategoryService
{
    public Task PostUpdateCategoryServiceAsync(ApplicationDbContext dbContext, Category obj);
}