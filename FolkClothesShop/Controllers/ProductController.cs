using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FolkClothesShop.Models.Home;
using FolkClothesShop.Models.Products;
using FolkClothesShop.Contacts;
using FolkClothesShop.Data.Entity;

namespace FolkClothesShop.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService product;
		private readonly IAdminServices admins;

		public ProductController(IProductService products, IAdminServices admin)
		{
			product = products;
			this.admins = admin;
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
		public async Task<IActionResult> Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(ProductFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}
		public async Task<IActionResult> Edit(int id)
		{
			return View(new ProductFormModel());
		}
		public async Task<IActionResult>Edit(int id, ProductFormModel product)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}
		public async Task<IActionResult>Delete( ProductFormModel product)
		{
			return RedirectToAction(nameof(All));
		}
		

	}
}
