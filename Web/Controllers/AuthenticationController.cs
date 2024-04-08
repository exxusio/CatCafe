using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[AllowAnonymous]
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        //[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(Account model)
        //{
            
        //}
    }
}
