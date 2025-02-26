using Contracts.CRUDContracts;
using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Areas.Admin.Controllers;

public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadProductsService _readProductsService;
    public ProductController(IUnitOfWork unitOfWork, IReadProductsService productsService, IReadProductsService readProductsService)
    {
        _unitOfWork = unitOfWork;
        _readProductsService = readProductsService;
    }
    // GET
    public IActionResult Index()
    {
        var allEntities = _readProductsService.GetAllProductsAsync(_unitOfWork);
        return View(allEntities);
    }

    [HttpPost]
    public IActionResult Create(Product obj)
    {
        _unitOfWork.Product.Add(obj);
    }
}