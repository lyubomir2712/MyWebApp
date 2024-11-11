using Contracts.ModelContracts;
using Data.Data;
using Data.Models;
using Data.Repository;

namespace Contracts.CRUDContracts;

public interface IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(ICategoryRepository categoryRepo);
}