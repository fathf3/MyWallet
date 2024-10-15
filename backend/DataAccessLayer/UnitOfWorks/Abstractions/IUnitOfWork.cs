using CoreLayer.Entites;
using DataAccessLayer.Repositories.Abstractions;

namespace DataAccessLayer.UnitOfWorks.Abstractions
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();

		Task<int> SaveAsync();
		int Save();
	}
}
