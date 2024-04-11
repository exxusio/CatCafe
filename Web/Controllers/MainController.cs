using BusinessLayer;
using PresentationLayer;
using PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    //[Authorize]
    public class MainController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public MainController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        [HttpGet]
        public async Task<IActionResult> Main()
        {
            return View(await _servicesManager.products.GetList());
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Workers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reviews()
        {
            return View();
        }

        [HttpGet]//[Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
