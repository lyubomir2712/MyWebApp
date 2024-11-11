using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete;
using Contracts.CRUDContracts.Update;
using Data.Data;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository? _categoryRepo;
    private readonly IReadCategoriesService? _readCategoriesService;
    private readonly ICreateCategoryService? _createCategoryService;
    private readonly IGetUpdateCategoryService? _getUpdateCategoryService;
    private readonly IPostUpdateCategoryService? _postUpdateCategoryService;
    private readonly IGetDeleteCategoryService? _getDeleteCategoryService;
    private readonly IPostDeleteCategoryService? _postDeleteCategoryService;
    public CategoryController(ICategoryRepository categoryRepo, IReadCategoriesService readCategoriesService,
        ICreateCategoryService createCategoryService, IGetUpdateCategoryService getUpdateCategoryService,
        IPostUpdateCategoryService postUpdateCategoryService,IGetDeleteCategoryService getDeleteCategoryService,
        IPostDeleteCategoryService postDeleteCategoryService)
    {
        _categoryRepo = categoryRepo;
        _readCategoriesService = readCategoriesService;
        _createCategoryService = createCategoryService;
        _getUpdateCategoryService = getUpdateCategoryService;
        _postUpdateCategoryService = postUpdateCategoryService;
        _getDeleteCategoryService = getDeleteCategoryService;
        _postDeleteCategoryService = postDeleteCategoryService;
    }
    public IActionResult Index()
    {
        var objCategoryList = _readCategoriesService?.GetAllCategoriesAsync(_categoryRepo);
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
            _createCategoryService?.CreateCategoryAsync(_categoryRepo, obj);
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

        var categoryFromDb = _getUpdateCategoryService?.GetUpdateCategoryAsync(_categoryRepo, id);
        
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
            _postUpdateCategoryService?.PostUpdateCategoryServiceAsync(_categoryRepo, obj);
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

        var categoryFromDb = _getDeleteCategoryService.GetDeleteCategoryAsync(_categoryRepo, id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        var obj = _getDeleteCategoryService.GetDeleteCategoryAsync(_categoryRepo, id);
        
        if (obj == null) return NotFound();

        _postDeleteCategoryService.PostDeleteCategoryAsync(_categoryRepo, obj);
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}