using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Update.Product;
using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Areas.Admin.Controllers;

public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadProductsService _readProductsService;
    private readonly IGetUpdateProductService _getUpdateProductService;
    private readonly IPostUpdateProductService _postUpdateProductService;
    public ProductController(IUnitOfWork unitOfWork, IReadProductsService productsService,
        IReadProductsService readProductsService, IGetUpdateProductService getUpdateProductService,
        IPostUpdateProductService postUpdateProductService)
    {
        _unitOfWork = unitOfWork;
        _readProductsService = readProductsService;
        _postUpdateProductService = postUpdateProductService;
        _getUpdateProductService = getUpdateProductService;
        _postUpdateProductService = postUpdateProductService;
    }
    // GET
    public IActionResult Index()
    {
        var objProductList = _readProductsService.GetAllProductsAsync(_unitOfWork);
        return View(objProductList);
    }

    [HttpPost]
    public void Create(Product obj)
    {
        _unitOfWork.Product.Add(obj);
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var categoryFromDb = _getUpdateProductService.GetUpdateProduct(_unitOfWork, id);
        
        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    public IActionResult Edit(Product obj)
    {
        if (ModelState.IsValid)
        {
            _postUpdateProductService.PostUpdateProduct(_unitOfWork, obj);
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
        
        
    }
}