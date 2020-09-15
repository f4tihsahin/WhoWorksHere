using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhoWorksHere.Models;

namespace WhoWorksHere.Controllers
{
    public class HomeController : Controller
    {
        WhoWorksHereContext _context = new WhoWorksHereContext();

        public IActionResult Index()
        {
            var result = _context.Departments.ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDepartment(int id)
        {
            var deleteDepartment = _context.Departments.Find(id);
            _context.Departments.Remove(deleteDepartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateDepartment(int id)
        {
            var updateDepartment = _context.Departments.Find(id);
            return View("UpdateDepartment",updateDepartment);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            var updateDepartment = _context.Departments.Find(department.Id);
            updateDepartment.DepartmentName = department.DepartmentName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}