using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Areas.Admin.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}