using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;


namespace MyWebApp.Data.Implementation.CRUD;

public class ReadCategoriesService : IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(ApplicationDbContext _dbContext)
    {
        List<Category> objCategoryList = _dbContext.Categories.ToList();
        return objCategoryList;
    }
}