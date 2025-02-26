using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts;

public interface IGetUpdateCategoryService
{
    public Category? GetUpdateCategory(IUnitOfWork unitOfWork, int? id);
}