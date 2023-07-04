namespace FolkClothesShop.Contacts
{
	public interface IAdminServices
	{
		Task<bool> ExistingByAdmin(string userId);
		Task Create(string userId);

	}
}
