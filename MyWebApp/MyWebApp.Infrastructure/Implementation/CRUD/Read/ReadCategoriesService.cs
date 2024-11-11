using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data.Implementation.CRUD.Read;

public class ReadCategoriesService : IReadCategoriesService
{
    public List<Category> GetAllCategoriesAsync(ICategoryRepository categoryRepo)
    {
        return categoryRepo.GetAll().ToList();
    }
}