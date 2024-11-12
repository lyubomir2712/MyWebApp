using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Delete;

public interface IGetDeleteCategoryService
{
    public Category? GetDeleteCategoryAsync(IUnitOfWork unitOfWork, int? id);
}