using Microsoft.AspNetCore.Mvc;
using MVCSite.Models;

namespace MVCSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login", new LoginViewModel() { Login = HttpContext.Request.Protocol, Password = HttpContext.Request.Path });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }
            return View("Account", model);
        }
    }
}
