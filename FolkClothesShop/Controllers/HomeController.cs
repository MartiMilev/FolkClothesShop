using FolkClothesShop.Contacts;
using FolkClothesShop.Models;
using FolkClothesShop.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FolkClothesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService products;

        public HomeController(IProductService products)
        {
			this.products = products;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await products.GetProductsAsync();
            return View(allProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}