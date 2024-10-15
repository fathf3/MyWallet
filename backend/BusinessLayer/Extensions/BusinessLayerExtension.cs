using BusinessLayer.Services.Abstractions;
using BusinessLayer.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLayer.Extensions
{
	public static class BusinessLayerExtension
	{
		public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddAutoMapper(assembly);

			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<IIncomeService, IncomeManager>();
			services.AddScoped <IExpenseService, ExpenseManager>();

			return services;
		}
	}
}
