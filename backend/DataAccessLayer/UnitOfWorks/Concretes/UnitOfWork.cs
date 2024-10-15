using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstractions;
using DataAccessLayer.Repositories.Concretes;
using DataAccessLayer.UnitOfWorks.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorks.Concretes
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _appDbContext;
		public UnitOfWork(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async ValueTask DisposeAsync()
		{
			await _appDbContext.DisposeAsync();
		}

		public int Save()
		{
			return _appDbContext.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _appDbContext.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(_appDbContext);
		}
	}
}
