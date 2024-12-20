﻿using CoreLayer.Entites;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstractions;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDbContext _appDbContext;
		public Repository(AppDbContext dbContext)
		{
			_appDbContext = dbContext;
		}

		private DbSet<T> Table { get => _appDbContext.Set<T>(); }


		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = Table;
			if (predicate != null)
				query = query.Where(predicate);

			if (includeProperties.Any())
				foreach (var item in includeProperties)
					query = query.Include(item);

			return await query.ToListAsync();
		}
		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = Table;
			query = query.Where(predicate);

			if (includeProperties.Any())
				foreach (var item in includeProperties)
					query = query.Include(item);

			return await query.SingleAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await Table.FindAsync(id);
		}

		public async Task<T> UpdateAsync(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await Table.AnyAsync(predicate);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
		{
			if (predicate is not null)
				return await Table.CountAsync(predicate);
			return await Table.CountAsync();
		}

        public async Task<decimal> SumAsync(Expression<Func<T, bool>> predicates, Expression<Func<T, decimal>> predicate)
        {
			return await Table
				.Where(predicates)
				.SumAsync(predicate);
        }

       
    }
}
