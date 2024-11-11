using Data.Data;
using Data.Models;
using Data.Repository;

namespace Contracts.CRUDContracts.Delete;

public interface IGetDeleteCategoryService
{
    public Category? GetDeleteCategoryAsync(ICategoryRepository categoryRepo, int? id);
}