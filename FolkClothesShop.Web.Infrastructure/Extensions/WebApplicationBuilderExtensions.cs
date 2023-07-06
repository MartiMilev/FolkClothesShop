using FolkClothesShop.Services.Data;
using FolkClothesShop.Services.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Web.Infrastructure.Extensions
{
	public static class WebApplicationBuilderExtensions
	{
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
			if (serviceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type provided");
			}
			Type[] serviceTypes = serviceAssembly
				.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
				.ToArray();
			foreach (Type implementationType in serviceTypes)
			{
				Type? interfaceType = implementationType.GetInterface($"I{implementationType.Name}");
				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No interface is provided for the service with name {implementationType.Name}");
				}
				services.AddScoped(interfaceType, implementationType);
			}
			services.AddScoped<IProductService, ProductService>();

		}
	}
}
