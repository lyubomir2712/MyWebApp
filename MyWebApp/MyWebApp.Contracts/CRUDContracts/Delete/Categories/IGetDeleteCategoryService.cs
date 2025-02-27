using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Delete;

public interface IGetDeleteCategoryService
{
    public Category? GetDeleteCategory(IUnitOfWork unitOfWork, int? id);
}