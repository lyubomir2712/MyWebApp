using Contracts.CRUDContracts;
using Data.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data.Implementation.CRUD;

namespace MyWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly IReadCategoriesService? _readCategoriesService;
    private readonly ApplicationDbContext? _dbContext;
    
    public CategoryController(ApplicationDbContext dbContext, IReadCategoriesService readCategoriesService)
    {
        _dbContext = dbContext;
        _readCategoriesService = readCategoriesService;
    }
    public async Task<IActionResult> Index()
    {
        List<Category> objCategoryList = _readCategoriesService.GetAllCategoriesAsync(_dbContext);
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFromDb = _dbContext.Categories.Find(id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Categories.Update(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFromDb = _dbContext.Categories.Find(id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? obj = _dbContext.Categories.Find(id);
        
        if (obj == null) return NotFound();
        
        _dbContext.Categories.Remove(obj);
        _dbContext.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}