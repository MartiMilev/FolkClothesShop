

using FolkClothesShop.Data;
using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Web.ViewModel.Home;
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
    }
}
