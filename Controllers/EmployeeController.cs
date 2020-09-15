using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhoWorksHere.Models;

namespace WhoWorksHere.Controllers
{
    public class EmployeeController : Controller
    {
        WhoWorksHereContext _context = new WhoWorksHereContext();

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
