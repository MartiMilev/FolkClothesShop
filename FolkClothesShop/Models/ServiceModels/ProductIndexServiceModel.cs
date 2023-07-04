namespace FolkClothesShop.Models.ServiceModels
{
    public class ProductIndexServiceModel
    {
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string Image { get; set; } = null!;

		public decimal Price { get; set; }
	}
}
