using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
