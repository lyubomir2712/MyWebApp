using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

public class CategoryController : Controller
{

    private readonly ApplicationDbContext _dbContext;
    public CategoryController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = _dbContext.Categories.ToList();
        return View(objCategoryList);
    }
}