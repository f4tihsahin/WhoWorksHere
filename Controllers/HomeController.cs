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
    }
}
