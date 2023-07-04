using FolkClothesShop.Contacts;
using FolkClothesShop.Data;

namespace FolkClothesShop.Services
{
	public class AdminService : IAdminServices
	{
		private readonly ApplicationDbContext data;
		public AdminService(ApplicationDbContext data)
		{
			this.data = data;
		}
		public Task Create(string userId)
		{
			var agent = new Product
		}

		public Task<bool> ExistingByAdmin(string userId)
		{
			throw new NotImplementedException();
		}
	}
}
