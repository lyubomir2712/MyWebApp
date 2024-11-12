using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace MyWebApp.Data.Contracts.CRUDcontracts;

public interface ICreateCategoryService
{
    public void CreateCategoryAsync(IUnitOfWork? unitOfWork, Category obj);
}