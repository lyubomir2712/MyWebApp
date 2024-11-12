using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class GetUpdateCategoryService : IGetUpdateCategoryService
{
    public Category? GetUpdateCategoryAsync(IUnitOfWork unitOfWork, int? id)
    {
        return unitOfWork.Category.Get(u => u.Id == id);
    }
}