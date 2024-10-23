using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete;
using Data.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext? _dbContext;
    private readonly IReadCategoriesService? _readCategoriesService;
    private readonly ICreateCategoryService? _createCategoryService;
    private readonly IGetUpdateCategoryService? _getUpdateCategoryService;
    private readonly IPostUpdateCategoryService? _postUpdateCategoryService;
    private readonly IGetDeleteCategoryService? _getDeleteCategoryService;
    private readonly IPostDeleteCategoryService? _postDeleteCategoryService;
    public CategoryController(ApplicationDbContext dbContext, IReadCategoriesService readCategoriesService,
        ICreateCategoryService createCategoryService, IGetUpdateCategoryService getUpdateCategoryService,
        IPostUpdateCategoryService postUpdateCategoryService,IGetDeleteCategoryService getDeleteCategoryService,
        IPostDeleteCategoryService postDeleteCategoryService)
    {
        _dbContext = dbContext;
        _readCategoriesService = readCategoriesService;
        _createCategoryService = createCategoryService;
        _getUpdateCategoryService = getUpdateCategoryService;
        _postUpdateCategoryService = postUpdateCategoryService;
        _getDeleteCategoryService = getDeleteCategoryService;
        _postDeleteCategoryService = postDeleteCategoryService;
    }
    public async Task<IActionResult> Index()
    {
        var objCategoryList = await _readCategoriesService?.GetAllCategoriesAsync(_dbContext);
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            await _createCategoryService?.CreateCategoryAsync(_dbContext, obj);
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = await _getUpdateCategoryService?.GetUpdateCategoryAsync(_dbContext, id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            await _postUpdateCategoryService?.PostUpdateCategoryServiceAsync(_dbContext, obj);
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = await _getDeleteCategoryService.GetDeleteCategoryAsync(_dbContext, id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int? id)
    {
        var obj = await _getDeleteCategoryService.GetDeleteCategoryAsync(_dbContext, id);
        
        if (obj == null) return NotFound();

        await _postDeleteCategoryService.PostDeleteCategoryAsync(_dbContext, obj);
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}