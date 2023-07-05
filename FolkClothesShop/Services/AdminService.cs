using FolkClothesShop.Contacts;
using FolkClothesShop.Data;
using Microsoft.EntityFrameworkCore;

namespace FolkClothesShop.Services
{
	public class AdminService : IAdminServices
	{
		private readonly ApplicationDbContext data;
		public AdminService(ApplicationDbContext data)
		{
			this.data = data;
		}
		public async Task Create(string userId)
		{
			var agent = new FolkClothesShop.Data.Entity.Admin()
			{
				UserId = userId
			};
			await data.AddAsync(agent);
			await data.SaveChangesAsync();
		}

		public async Task<bool> ExistingById(string userId)
		{
			return await data.Admins.AnyAsync(a=>a.UserId == userId);
		}
	}
}
