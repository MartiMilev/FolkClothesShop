

using FolkClothesShop.Data;
using FolkClothesShop.Data.Entity;
using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Web.ViewModel.Home;
using FolkClothesShop.Web.ViewModel.Product;
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

        public async Task CreateAsync(ProductFormModel formModel,string adminId)
        {
            Product newProduct = new Product()
            {
                Title = formModel.Title,
                ImageUrl = formModel.ImageUrl,
                Description = formModel.Description,
                Price = formModel.Price,
                CategoryId = formModel.CategoryId,
                AdminId = int.Parse(adminId)
            };
            await dbContext.Products.AddAsync(newProduct);
            await dbContext.SaveChangesAsync();
        }
    }
}
