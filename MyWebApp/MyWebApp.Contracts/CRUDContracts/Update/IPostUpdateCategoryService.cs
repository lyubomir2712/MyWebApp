using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts.Update;

public interface IPostUpdateCategoryService
{
    public void PostUpdateCategory(IUnitOfWork unitOfWork, Category obj);
}