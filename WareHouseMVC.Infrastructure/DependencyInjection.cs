using System;
using Microsoft.Extensions.DependencyInjection;
using WareHouseMVC.Domain.Interface;
using WareHouseMVC.Infrastructure.Repositories;

namespace WareHouseMVC.Infrastructure
{
	public static class DependencyInjection
	{

		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{

			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IItemRepository, ItemRepository>();
			return services;

		}





	}
	
}

