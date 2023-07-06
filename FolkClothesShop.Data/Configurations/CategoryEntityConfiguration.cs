using FolkClothesShop.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
          builder.HasData(this.GenerateCategories());
        }
        public Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();
            Category category;
            category= new Category()
            {
                Id=1,
                Name="Момче"
            };
            categories.Add(category);

             category= new Category()
            {
                Id=2,
                Name="Момиче"
            };
            categories.Add(category);

             category= new Category()
            {
                Id=3,
                Name="Аксесоари"
            };
            categories.Add(category);
            
            return categories.ToArray();
        }
    }
}
