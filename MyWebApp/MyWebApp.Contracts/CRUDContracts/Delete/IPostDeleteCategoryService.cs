using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Delete;

public interface IPostDeleteCategoryService
{
    public void PostDeleteCategoryAsync(IUnitOfWork unitOfWork, Category obj);
}