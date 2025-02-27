using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD;

public class GetDeleteCategoryService : IGetDeleteCategoryService
{
    public Category? GetDeleteCategory(IUnitOfWork unitOfWork, int? id)
    {
        return unitOfWork.Category.Get(u => u.Id == id);
    }
}