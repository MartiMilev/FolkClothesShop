using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Services.Data.Model.Product;
using FolkClothesShop.Web.Infrastructure.Extensions.Extensions;
using FolkClothesShop.Web.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;
using Xunit;

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

			queryModel.Products = serviceModel.Products;
			queryModel.TotalProducts = serviceModel.TotalProductCount;
			queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

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
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(string id)
		{
			bool productExists = await this.productService
				.ExistByIdAsync(id);
			if (!productExists)
			{
				return this.RedirectToAction("All", "Product");

			}
			ProductDetailsViewModel viewModel = await this.productService
				.GetByIdDetailsAsync(id);

			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			bool productExists = await this.productService
				.ExistByIdAsync(id);
			if (!productExists)
			{
				return this.RedirectToAction("All", "Product");
			}

			ProductDetailsViewModel viewModel = await this.productService
				.GetByIdDetailsAsync(id);


			ProductFormModel formModel = await this.productService
				.GetProductForEditByIdAsync(id);
			formModel.Categories = await this.categoryService.AllCategoriesAsync();
			return this.View(formModel);
		}

		[HttpGet]
		public async Task<IActionResult> Cart()
		{
			List<ProductAllViewModel> myCart =
				new List<ProductAllViewModel>();

			return View(Cart);
			string? userId = this.User.GetId();

		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if(await productService.ExistByIdAsync(id.ToString())==false)
			{
				return BadRequest();
			}
			try
			{
				ProductPreDeleteDetailsViewModel viewModel =
				await this.productService.GetProductForDeleteByIdAsync(id.ToString());

				return View(viewModel);
			}

			catch (Exception)
			{

				throw;
			}
			
		}
		[HttpPost]
		public async Task<IActionResult> Edit(string id, ProductFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = await this.categoryService.AllCategoriesAsync();

				return this.View(model);
			}
			try
			{
				await this.productService.EditProductByIdAndFormModelAsync(id, model);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update the product.");
				model.Categories = await this.categoryService.AllCategoriesAsync();
				return this.View(model);
			}
			return this.RedirectToAction("Details", "Product", new { id });
		}
	}
}
