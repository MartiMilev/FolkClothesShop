using FolkClothesShop.Data.Entity;
using FolkClothesShop.Models.ServiceModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolkClothesShop.Models.Products
{
	public class ProductFormModel
	{
		
		[Required]
		public string Name { get; set; } = null!;
		[StringLength(200, MinimumLength = 10)]
		[Required]
		public string Description { get; set; } = null!;
		[Required]
		[Display(Name= "Image URL")]
		public string Image { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int Stock { get; set; }
		[Display(Name="Category")]
		public int CategoryId { get; set; }
		public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }
		= new List<ProductCategoryServiceModel>();

	}
}
