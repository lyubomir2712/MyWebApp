using Contracts.ModelContracts;
using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(ApplicationDbContext _dbContext);
}