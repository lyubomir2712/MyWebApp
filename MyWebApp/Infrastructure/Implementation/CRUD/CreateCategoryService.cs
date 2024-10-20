using Data.Data;
using Data.Models;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD;

public class CreateCategoryService : ICreateCategoryService
{
    public async void CreateCategoryAsync(ApplicationDbContext dbContext, Category obj)
    {
        await dbContext.Categories.AddAsync(obj);
        await dbContext.SaveChangesAsync();
    }
}