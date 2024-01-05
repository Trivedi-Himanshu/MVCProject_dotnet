using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStoreWebApp.Models;
using EStoreWebApp.Services;

namespace EStoreWebApp.Controllers;

public class ProductsController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ProductRegister()
    {
        return View();
    }
    public IActionResult GetAll()
    {
        
        return View();
    }
}
