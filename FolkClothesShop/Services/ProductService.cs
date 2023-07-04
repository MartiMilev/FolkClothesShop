using FolkClothesShop.Contacts;
using FolkClothesShop.Data;
using FolkClothesShop.Models.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace FolkClothesShop.Services
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext data;
		public ProductService(ApplicationDbContext data)
		{
			this.data = data;
		}

		public async Task<IEnumerable<ProductCategoryServiceModel>> Add()
		{

		}

		public async Task<IEnumerable<ProductCategoryServiceModel>> AllCategories()
		{
			return await data
				.Categories
				.Select(c => new ProductCategoryServiceModel
				{
					Id = c.Id,
					Name = c.Name
				}).ToListAsync();
		}

		public async Task<IEnumerable<ProductIndexServiceModel>> GetProductsAsync()
		{
			return await data
				.Products
				.Select(p=>new ProductIndexServiceModel
				{
					Id= p.Id,
					Name = p.Name,
					Price= p.Price,
					Description= p.Description,
					Image = p.Image
				}).ToListAsync();
		}
	}
}
