using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace MyWebApp.Data.Implementation.CRUD;

public class ReadCategoriesService : IReadCategoriesService
{
    public async Task<List<Category>> GetAllCategoriesAsync(ApplicationDbContext _dbContext)
    {
        List<Category> objCategoryList = await _dbContext.Categories.ToListAsync();
        return objCategoryList;
    }
}