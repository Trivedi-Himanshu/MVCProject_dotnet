using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOL;

namespace Portal;

public class ProductsController : Controller
{
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();

    } 
}
