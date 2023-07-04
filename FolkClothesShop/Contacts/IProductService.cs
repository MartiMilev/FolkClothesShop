using FolkClothesShop.Models.ServiceModels;

namespace FolkClothesShop.Contacts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductIndexServiceModel>> GetProductsAsync();
		Task<IEnumerable<ProductCategoryServiceModel>> AllCategories ();
		Task<IEnumerable<ProductCategoryServiceModel>> Add ();

	}
}
