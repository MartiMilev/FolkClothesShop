using Microsoft.AspNetCore.Mvc;

namespace FolkClothesShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
