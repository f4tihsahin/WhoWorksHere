using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WhoWorksHere.Models;

namespace WhoWorksHere.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        WhoWorksHereContext _context = new WhoWorksHereContext();

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(d => d.Department).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentName", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
