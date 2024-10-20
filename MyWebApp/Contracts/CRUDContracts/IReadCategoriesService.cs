using Contracts.ModelContracts;
using Data.Data;
using Data.Models;

namespace Contracts.CRUDContracts;

public interface IReadCategoriesService
{
    public Task<List<Category>> GetAllCategoriesAsync(ApplicationDbContext _dbContext);
}