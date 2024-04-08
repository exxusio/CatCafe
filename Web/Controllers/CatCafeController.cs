using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Authorize]
    public class CatCafeController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Workers()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
