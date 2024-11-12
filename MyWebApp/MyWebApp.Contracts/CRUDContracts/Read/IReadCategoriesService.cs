using Contracts.ModelContracts;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;

namespace Contracts.CRUDContracts;

public interface IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(IUnitOfWork unitOfWork);
}