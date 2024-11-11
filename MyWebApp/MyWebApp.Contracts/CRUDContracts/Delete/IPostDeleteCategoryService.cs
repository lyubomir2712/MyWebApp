using Data.Data;
using Data.Models;
using Data.Repository;

namespace Contracts.CRUDContracts.Delete;

public interface IPostDeleteCategoryService
{
    public void PostDeleteCategoryAsync(ICategoryRepository categoryRepo, Category obj);
}