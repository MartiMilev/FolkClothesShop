using FolkClothesShop.Data;
using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Web.ViewModel.Category;
using Microsoft.EntityFrameworkCore;

namespace FolkClothesShop.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<ProductSelectViewModel>> AllCategoriesAsync()
        {
            IEnumerable<ProductSelectViewModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c=> new ProductSelectViewModel()
                {
                    Id= c.Id,
                    Name= c.Name,
                })
                .ToArrayAsync();
            return allCategories;
        }

        public async Task<bool> ExistingByIdAsync(int id)
        {
            bool result = await this.dbContext.Categories
                 .AnyAsync(c => c.Id == id);
            return result;
        }
    }
}
