using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Web.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;

namespace FolkClothesShop.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ICategoryService categoryService;
        public ProductController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {


            ProductFormModel formModel = new ProductFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };
            return View(formModel);
        }
    }
}
