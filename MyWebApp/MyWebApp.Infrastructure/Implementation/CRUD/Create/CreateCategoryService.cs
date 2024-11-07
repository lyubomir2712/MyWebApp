using Data.Data;
using Data.Models;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Create;

public class CreateCategoryService : ICreateCategoryService
{
    public async Task CreateCategoryAsync(ApplicationDbContext? dbContext, Category obj)
    {
        await dbContext.Categories.AddAsync(obj);
        await dbContext.SaveChangesAsync();
    }
}