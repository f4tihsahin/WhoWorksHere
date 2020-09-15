using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using WhoWorksHere.Models;

namespace WhoWorksHere.Controllers
{
    public class UserController : Controller
    {
        WhoWorksHereContext _context = new WhoWorksHereContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var result = _context.Admins.FirstOrDefault(u => u.Email == admin.Email && u.Password == admin.Password);

            if (result!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Email)
                };
                
                var userIdentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Employee");
            }
            

            return View();
        }
    }
}
