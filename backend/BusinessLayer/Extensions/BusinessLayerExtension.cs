using BusinessLayer.FluentValidations;
using BusinessLayer.Services.Abstractions;
using BusinessLayer.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
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
			services.AddScoped <IPaymentService, PaymentManager>();
			services.AddScoped <ICustomerService, CustomerManager>();
			services.AddScoped <IActivityService, ActivityManager>();
			services.AddScoped <ISeansService, SeansManager>();
			

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<CategoryValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
		}
	}
}
