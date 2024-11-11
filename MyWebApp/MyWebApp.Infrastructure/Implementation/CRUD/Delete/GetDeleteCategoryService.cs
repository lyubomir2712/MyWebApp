using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using Data.Repository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD;

public class GetDeleteCategoryService : IGetDeleteCategoryService
{
    public Category? GetDeleteCategoryAsync(ICategoryRepository categoryRepo, int? id)
    {
        return categoryRepo.Get(u => u.Id == id);
    }
}