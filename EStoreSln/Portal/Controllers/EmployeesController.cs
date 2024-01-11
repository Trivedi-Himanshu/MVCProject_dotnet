using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SAL;
using BOL;
using DAL;
namespace Portal;
public class EmployeesController : Controller
{
    private readonly IEmployeeService _svc;
    public EmployeesController(IEmployeeService svc)
    {
        Console.WriteLine("Employee Controller Constructor is being Invoked..");
        this._svc = svc;
    }

    [HttpGet]
    public IActionResult Index()
    {
        Console.WriteLine("Employee Index Action Method is called...");
        List<Employee> employees = _svc.GetAll();
        //ViewData["employees"]=employees;
        //ViewBag.empList=employees;
        TempData["allEmployees"] = employees;
        return View();
    }


    public IActionResult List()
    {
        Console.WriteLine("Employee Index Action Method is called...");
        List<Employee> employees = _svc.GetAll();
        //ViewData["employees"]=employees;
        //ViewBag.empList=employees;
        //TempData["allEmployees"]=employees;
        //model transfer
        return View(employees);
    }
    public IActionResult Details(int id)
    {
        //List<Employee> retrivedEmployees=(List<Employee>)TempData["allEmployees"];
        Employee emp = _svc.GetById(id);
        return View(emp);
    }

    public IActionResult Edit(int id)
    {
        DBDisconnect mgr = new DBDisconnect();
        mgr.update(id);


        Console.WriteLine("************************2222222222222222222222222222222222222222222222222222222222222222222222222222222222222");
        List<Employee> employees = _svc.GetAll();
        var e = employees.Find((emp) => emp.Id == id);
        return View(e);
    }



    [HttpPost]
    public IActionResult Edit(Employee emp)
    {

        DBDisconnect mgr = new DBDisconnect();
        if (emp != null && ModelState.IsValid)
        {
            // _svc.Delete(emp.Id);
            // _svc.Insert(emp);
            // return RedirectToAction("Insert");

            Console.WriteLine("************************2222222222222222222222222222222222222222222222222222222222222222222222222222222222222");
            mgr.update(emp.Id);
            return RedirectToAction("Insert");

        }
        else
        {
            return View();
        }
    }

    public IActionResult Delete(int id)
    {
        DBRepository mgr = new DBRepository();

        _svc.Delete(id);
        Console.WriteLine("deleted successfully...!");
        return View();
    }

    public IActionResult Insert(Employee emp)
    {
        _svc.Insert(emp);
        return View();
    }
}
