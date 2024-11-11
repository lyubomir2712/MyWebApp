using Data.Data;
using Data.Models;
using Data.Repository;

namespace Contracts.CRUDContracts.Update;

public interface IPostUpdateCategoryService
{
    public void PostUpdateCategoryServiceAsync(ICategoryRepository categoryRepo, Category obj);
}