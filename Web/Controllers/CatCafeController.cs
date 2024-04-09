using BusinessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    //[Authorize]
    public class CatCafeController : Controller
    {
        private DataManager _dataManager;

        public CatCafeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Main()
        {
            List<Products> products = (await _dataManager.products.GetAll(true)).ToList();

            return View(products);
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
