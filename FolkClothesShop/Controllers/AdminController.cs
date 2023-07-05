using FolkClothesShop.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace FolkClothesShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices admin;

        public AdminController(IAdminServices admins)
        {
            admin= admins;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
