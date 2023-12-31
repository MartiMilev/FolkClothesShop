using FolkClothesShop.Data;
using FolkClothesShop.Services.Data;
using FolkClothesShop.Services.Data.Interfaces;
using FolkClothesShop.Web.Infrastructure.Extensions;
using FolkClothesShop.Web.Infrastructure.Extensions.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FolkClothesShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(connectionString, b => b.MigrationsAssembly("FolkClothesShop")));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			builder.Services.AddApplicationServices(typeof(ProductService));

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
			});
			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options=>
				{
					options.ModelBinderProviders.Insert(0,new DecimalModelBinderProvider());

                });



			WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}