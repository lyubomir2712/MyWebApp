using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Update;
using Data.Data;
using Data.Models;
using Data.Repository;
using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Data.Implementation.CRUD.Update;

public class PostUpdateCategoryService : IPostUpdateCategoryService
{
    public void PostUpdateCategory(IUnitOfWork unitOfWork, Category obj)
    {
        unitOfWork.Category.Update(obj);
        unitOfWork.Save();
    }
}