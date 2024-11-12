using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data.Implementation.CRUD.Read;

public class ReadCategoriesService : IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(IUnitOfWork unitOfWork)
    {
        return unitOfWork.Category.GetAll().ToList();
    }
}