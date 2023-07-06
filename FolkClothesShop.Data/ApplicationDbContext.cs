using FolkClothesShop.Data.Entity;
using FolkClothesShop.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace FolkClothesShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext))??
                Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}