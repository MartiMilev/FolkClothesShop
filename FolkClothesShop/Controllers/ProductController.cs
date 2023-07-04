using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FolkClothesShop.Models.Home;
using FolkClothesShop.Models.Products;
using FolkClothesShop.Contacts;

namespace FolkClothesShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService product;
        public ProductController(IProductService products)
        {
            product= products;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View(new AllProductQueryModel());
        }
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            return View(new AllProductQueryModel());
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(new ProductDetailViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            return RedirectToAction(nameof(Details), new {id="1"});
        }

    }
}
