using System.Collections;
using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete.Products;
using Contracts.CRUDContracts.Update.Product;
using Data.Models;
using Data.Repository.IRepository;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Data.Contracts.CRUDcontracts;

namespace MyWebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadProductsService _readProductsService;
    private readonly ICreateProductService _createProductService;
    private readonly IGetUpdateProductService _getUpdateProductService;
    private readonly IPostUpdateProductService _postUpdateProductService;
    private readonly IGetDeleteProductService _getDeleteProductService;
    private readonly IPostDeleteProductService _postDeleteProductService;
    public ProductController(IUnitOfWork unitOfWork, ICreateProductService createProductService,
        IReadProductsService readProductsService, IGetUpdateProductService getUpdateProductService,
        IPostUpdateProductService postUpdateProductService, IGetDeleteProductService getDeleteProductService,
        IPostDeleteProductService postDeleteProductService)
    {
        _unitOfWork = unitOfWork;
        _readProductsService = readProductsService;
        _postUpdateProductService = postUpdateProductService;
        _getUpdateProductService = getUpdateProductService;
        _postUpdateProductService = postUpdateProductService;
        _getDeleteProductService = getDeleteProductService;
        _postDeleteProductService = postDeleteProductService;
        _createProductService = createProductService;
    }
    // GET
    public IActionResult Index()
    {
        var objProductList = _readProductsService.GetAllProductsAsync(_unitOfWork);
        IEnumerable<SelectListItem> CategoryList= _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        return View(objProductList);
    }

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> CategoryList= _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ProductVM productVM = new()
        {
            CategoryList = CategoryList,
            Product = new Product()
        };

        if (id == null || id == 0)
        {
            return View(productVM);
        }
        else
        {
            productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(productVM);
        }
        return View(productVM);
    }

    [HttpPost]
    public IActionResult Upsert(ProductVM productVm, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            _createProductService.CreateProduct(_unitOfWork, productVm.Product);
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        else
        {
            productVm.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem() 
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(productVm);
        }

        return View();
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

    [HttpPost]
    public IActionResult Edit(Product obj)
    {
        if (ModelState.IsValid)
        {
            _postUpdateProductService.PostUpdateProduct(_unitOfWork, obj);
            TempData["success"] = "Product updated successfully";
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
        
        var productFromDb = _getDeleteProductService.GetDeleteProducts(_unitOfWork, id);
        if (productFromDb == null)
        {
            return View();
        }
        return View(productFromDb);
    }

    [HttpPost]
    public IActionResult Delete(Product obj)
    {
        if (ModelState.IsValid)
        {
            _postDeleteProductService.PostDeleteProduct(_unitOfWork, obj);
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

        return View();
    }
}