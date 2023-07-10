using FolkClothesShop.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder
                  .HasOne(c => c.Category)
                  .WithMany(p => p.Products)
                  .HasForeignKey(ci => ci.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);
            modelBuilder
                .HasOne(a => a.Admin)
                .WithMany()
                .HasForeignKey(ai => ai.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasData(this.GenereteProducts());
        }
        private Product[] GenereteProducts()
        {
            ICollection<Product> products = new HashSet<Product>();
            Product product;
            product = new Product()
            {
                Id = 1,
                Title = "Тракийска носия",
                Description = "Най-хубавата носия",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267074128_569156850818756_8705324827277707870_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=3aF7k0tMHR8AX8rR1kC&_nc_ht=scontent.fsof8-1.fna&oh=00_AfDjjNWBjjVAlfUH-4pRZC4FNu6hqh8OJ0B_O9Pvs1oKbg&oe=64AB134F",
                Price = 56.00M,
                CategoryId = 1,
                AdminId = 1,
            };
            products.Add(product);

            product = new Product()
            {
                Id = 2,
                Title = "Тракийска носия",
                Description = "Най-хубавата дамска носия",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/242844727_517782082622900_481886533923826782_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=E6ONkspewXsAX8tTOFH&_nc_ht=scontent.fsof8-1.fna&oh=00_AfAaV-sf-iIaP9RBpFb30yEaGtMgZb1c555Ab7X_J_QCiQ&oe=64AB6E19",
                Price = 78.00M,
                CategoryId = 2,
                AdminId = 1,
            };
            products.Add(product);
            
            product = new Product()
            {
                Id = 3,
                Title = "Родопска носия",
                Description = "Най-хубавата носия",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t1.6435-9/146874580_353052245762552_3031650708666144962_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=730e14&_nc_ohc=GAZN-Vz7d_MAX9jfRNN&_nc_ht=scontent.fsof8-1.fna&oh=00_AfBbpeg0Sn4CV_eEvg9Qm3uXhNKS1n3lq0dvC2hH51iq5w&oe=64CE4CFA",
                Price = 78.00M,
                CategoryId = 2,
                AdminId = 1,
            };
            products.Add(product);
             
            product = new Product()
            {
                Id = 4,
                Title = "Родопска носия",
                Description = "Най-хубавата носия",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t1.6435-9/147282029_353052235762553_8637670463306638015_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=730e14&_nc_ohc=ZhdcZIAVKckAX975rw7&_nc_ht=scontent.fsof8-1.fna&oh=00_AfCRtPxohx0G0dWYR6Tr8GwXQXGsPykLAgAf3aVIm1n5Vw&oe=64CE37DE",
                Price = 78.00M,
                CategoryId = 1,
                AdminId = 1,
            };
            products.Add(product);
             
            product = new Product()
            {
                Id = 5,
                Title = "Потури",
                Description = "Потурчета за малките сладурчета",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267565025_569157017485406_4196785183282386807_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=pvEtN8UWiv8AX_lCcE1&_nc_ht=scontent.fsof8-1.fna&oh=00_AfAvwr7GlR7KJAS2ZNAdejCMCIoynczLWR3BnskeRT08Zg&oe=64ABE6FA",
                Price = 12.00M,
                CategoryId = 1,
                AdminId = 1,
            };
            products.Add(product);
             
            product = new Product()
            {
                Id = 6,
                Title = "Калпак",
                Description = "Калпак за малкия юнак",
                ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/267325300_569156934152081_3269888927601348101_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=pQqNHetzV8wAX_zd8wl&_nc_ht=scontent.fsof8-1.fna&oh=00_AfD2VPZM7skYf3oNZ3_hJ1oezTTDuDwg4XUmtXEkwa4EHg&oe=64ABF1DE",
                Price = 11.00M,
                CategoryId = 1,
                AdminId = 1,
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
