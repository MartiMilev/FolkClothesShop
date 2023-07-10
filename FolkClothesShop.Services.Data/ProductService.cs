

using FolkClothesShop.Data;
using FolkClothesShop.Data.Entity;
using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Services.Data.Model.Product;
using FolkClothesShop.Web.ViewModel.Enum;
using FolkClothesShop.Web.ViewModel.Home;
using FolkClothesShop.Web.ViewModel.Product;
using Microsoft.EntityFrameworkCore;

namespace FolkClothesShop.Services.Data
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext dbContext;
		public ProductService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<AllProductFilteredAndPagedServiceModel> AllAsync(AllProductsQueryModel queryModel)
		{
			IQueryable<Product> productsQuery = this.dbContext
				  .Products
				  .Where(p => p.IsActive)
				  .AsQueryable();

			if (!string.IsNullOrWhiteSpace(queryModel.Category))
			{
				productsQuery = productsQuery
					.Where(p => p.Category.Name == queryModel.Category);
			}
			if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
			{
				string wildCard = $"%{queryModel.SearchString.ToLower()}%";

				productsQuery = productsQuery
					.Where(p => EF.Functions.Like(p.Title, wildCard) ||
								EF.Functions.Like(p.Description, wildCard));
			}
			productsQuery = queryModel.ProductSorting switch
			{
				ProductSorting.PriceAscending => productsQuery
				.OrderBy(p => p.Price),
				ProductSorting.PriceDescending => productsQuery
				.OrderByDescending(p => p.Price)
			};
			IEnumerable<ProductAllViewModel> allProducts = await productsQuery
			.Where(p => p.IsActive)
			.Skip((queryModel.CurrentPage - 1) * queryModel.ProductPerPage)
			.Take(queryModel.ProductPerPage)
			.Select(p => new ProductAllViewModel()
			{
				Id = p.Id,
				Title = p.Title,
				Description = p.Description,
				ImageUrl = p.ImageUrl,
				Price = p.Price,
			})
			.ToArrayAsync();
			int totalProduct = productsQuery.Count();
			return new AllProductFilteredAndPagedServiceModel()
			{
				TotalProductCount = totalProduct,
				Products = allProducts
			};
		}

		public async Task<IEnumerable<IndexViewModel>> AllProductsAsync()
		{
			IEnumerable<IndexViewModel> allProducts =
			   await this.dbContext.Products
				.Select(p => new IndexViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ImageUrl = p.ImageUrl,
					Price = p.Price,
				})
				.ToArrayAsync();

			return allProducts;
		}

		public async Task CreateAsync(ProductFormModel formModel, string adminId)
		{
			Product newProduct = new Product()
			{
				Title = formModel.Title,
				ImageUrl = formModel.ImageUrl,
				Description = formModel.Description,
				Price = formModel.Price,
				CategoryId = formModel.CategoryId,
				AdminId = int.Parse(adminId)
			};
			await dbContext.Products.AddAsync(newProduct);
			await dbContext.SaveChangesAsync();
		}
	}
}
