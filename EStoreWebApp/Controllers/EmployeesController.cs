using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStoreWebApp.Models;
using   HRAPP.Services;
using HRAPP.Entities;
namespace EStoreWebApp.Controllers;
public class EmployeesController : Controller
{
    private readonly IEmployeeService _svc;
    public EmployeesController(IEmployeeService svc){
        this._svc=svc;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Employee> employees=_svc.GetAll();
        ViewData["employees"]=employees;
        return View();
    }
    public IActionResult Details(int id)
    {
        Employee emp=_svc.GetById(id);
        return View();
    }
}
