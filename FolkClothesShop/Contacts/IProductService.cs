using FolkClothesShop.Models.Products;
using FolkClothesShop.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace FolkClothesShop.Contacts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductIndexServiceModel>> GetProductsAsync();
		Task<IEnumerable<ProductCategoryServiceModel>> AllCategories ();
		Task Add (ProductFormModel model);
		Task<int> Create(string description, string name, string image, decimal price, int categoryId, int adminId,int stock);

	}
}
