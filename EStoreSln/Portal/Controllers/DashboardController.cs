using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOL;

namespace Portal;

public class DashboardController : Controller
{


    [HttpGet]
    public IActionResult Pie()
    {
        return View();

    }
    public IActionResult Bar()
    {
        return View();
    }

    public IActionResult Line(){
        return View();
    }
    
}
