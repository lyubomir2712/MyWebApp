using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class PostUpdateCategoryService : IPostUpdateCategoryService
{
    public async Task PostUpdateCategoryServiceAsync(ApplicationDbContext dbContext, Category obj)
    {
        dbContext?.Categories.Update(obj);
        await dbContext.SaveChangesAsync();
    }
}