namespace FolkClothesShop.Contacts
{
	public interface IAdminServices
	{
		Task<bool> ExistingById(string userId);
		Task Create(string userId);

	}
}
