using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOL;

namespace Portal;

public class ShoppingCartController : Controller
{
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();

    } 
}
