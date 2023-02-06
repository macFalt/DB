using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WareHouseMVC.Application.Interfaces;
using WareHouseMVC.Application.Services;

namespace WareHouseMVC.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddTransient<ICustomerService, CustomerService>();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());



			return services;
		}





	}
}

