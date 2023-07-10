using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Services.Data.Model.Product;
using FolkClothesShop.Web.Infrastructure.Extensions.Extensions;
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
        private readonly IProductService productService;
        private readonly IAdminService adminService;

        public ProductController(ICategoryService categoryService, IProductService productService, IAdminService adminService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.adminService = adminService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel queryModel)
        {
            AllProductFilteredAndPagedServiceModel serviceModel =
             await this.productService.AllAsync(queryModel);

            queryModel.Products=serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductCount;
            queryModel.Categories= await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
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
        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            bool categoryExists =
                await this.categoryService.ExistingByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }
            try
            {
                string? adminId = await this.adminService.AdminIdByUserIdAsync(this.User.GetId()!);
                this.productService.CreateAsync(model, adminId!);
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new product!");
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }
            return this.RedirectToAction("All", "Product");
        }
    }
}
