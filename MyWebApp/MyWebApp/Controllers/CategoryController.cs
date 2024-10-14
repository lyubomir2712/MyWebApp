using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}