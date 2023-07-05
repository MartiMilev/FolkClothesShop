using FolkClothesShop.Contacts;
using FolkClothesShop.Data;
using FolkClothesShop.Models.Products;
using FolkClothesShop.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;
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

		public async Task<int> Create(string description, string name, string image, decimal price, int categoryId, int adminId, int stock)
		{
			var product = new FolkClothesShop.Data.Entity.Product()
			{
				Description = description,
				Name = name,
				Image = image,
				Price = price,
				Stock = stock,
				CategoryId = categoryId,
				AdmintId = adminId
			};
			await data.Products.AddAsync(product);
			await data.SaveChangesAsync();
			return product.Id;
		}

		public async Task<IEnumerable<ProductIndexServiceModel>> GetProductsAsync()
		{
			return await data
				.Products
				.Select(p => new ProductIndexServiceModel
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Description = p.Description,
					Image = p.Image
				}).ToListAsync();
		}
	}
}
