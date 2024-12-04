using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstractions;
using DataAccessLayer.Repositories.Concretes;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DataAccessLayer.UnitOfWorks.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessExtensions
{
	public static class DataLayerExtension
	{
		public static IServiceCollection LoadDataLayerEntension(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(opt => opt
			.UseSqlServer(configuration.GetConnectionString("SqlConnection2")));
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
