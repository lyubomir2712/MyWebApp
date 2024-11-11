using Data.Data;
using Data.Models;
using Data.Repository;

namespace Contracts.CRUDContracts;

public interface IGetUpdateCategoryService
{
    public Category? GetUpdateCategoryAsync(ICategoryRepository categoryRepo, int? id);
}