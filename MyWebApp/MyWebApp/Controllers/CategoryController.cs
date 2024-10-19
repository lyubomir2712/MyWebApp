using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        // Category? categoryFromDb1 = _dbContext.Categories.FirstOrDefault(u=>u.Id==id);
        // Category? categoryFromDb2 = _dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();
        
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