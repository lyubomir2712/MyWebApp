using Data.Data;
using Data.Models;
using Data.Repository;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface ICreateCategoryService
{
    public void CreateCategoryAsync(ICategoryRepository? categoryRepo, Category obj);
}