using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhoWorksHere.Models;

namespace WhoWorksHere.Controllers
{
    public class EmployeeController : Controller
    {
        WhoWorksHereContext _context = new WhoWorksHereContext();

        [Authorize]
        public IActionResult Index()
        {
            var employees = _context.Employees.Include(d => d.Department).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> departments = (from department in _context.Departments.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = department.DepartmentName,
                                                    Value = department.Id.ToString(),
                                                }).ToList();
            ViewBag.value = departments;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var employeeDepartment = _context.Departments.Where(d => d.Id == employee.Department.Id).FirstOrDefault();
            employee.Department = employeeDepartment;
            
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
