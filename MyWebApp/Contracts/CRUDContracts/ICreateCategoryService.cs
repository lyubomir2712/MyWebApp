using Data.Data;
using Data.Models;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface ICreateCategoryService
{
    public void CreateCategoryAsync(ApplicationDbContext dbContext, Category obj);
}