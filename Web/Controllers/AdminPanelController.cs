using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer;
using BusinessLayer;

namespace Web.Controllers
{
    public class AdminPanelController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public AdminPanelController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        
    }
}
