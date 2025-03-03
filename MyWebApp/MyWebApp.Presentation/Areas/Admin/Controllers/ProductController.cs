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
    private readonly IGetDeleteProductService _getDeleteProductService;
    private readonly IPostDeleteProductService _postDeleteProductService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ProductController(IUnitOfWork unitOfWork, ICreateProductService createProductService,
        IReadProductsService readProductsService, IGetDeleteProductService getDeleteProductService,
        IPostDeleteProductService postDeleteProductService, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _readProductsService = readProductsService;
        _getDeleteProductService = getDeleteProductService;
        _postDeleteProductService = postDeleteProductService;
        _createProductService = createProductService;
        _webHostEnvironment = webHostEnvironment;
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
        
        productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
        return View(productVM);
    }

    [HttpPost]
    public IActionResult Upsert(ProductVM productVm, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images/product");

                if (!string.IsNullOrEmpty(productVm.Product.ImageUrl))
                {
                    var oldImagePath = 
                        Path.Combine(wwwRootPath, productVm.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                productVm.Product.ImageUrl = @"\images\product" + fileName;
            }

            if (productVm.Product.Id == 0)
            {
                _createProductService.CreateProduct(_unitOfWork, productVm.Product);
            }
            else
            {
                _unitOfWork.Product.Update(productVm.Product);
            }
            
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        
        
        productVm.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem() 
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(productVm);
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