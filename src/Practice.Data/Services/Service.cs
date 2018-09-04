using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Practice
{
	public interface IService<TEntity> : IQueryable<TEntity>
		where TEntity : class
	{
		Task Add(TEntity entity);
		Task Remove(TEntity entity);
	}
	
	internal class Service<TEntity> : IService<TEntity>
		where TEntity : class
	{
		private readonly DbSet<TEntity> set;

		protected Service(DbSet<TEntity> set)
		{
			this.set = set;
		}

		private IQueryable<TEntity> Queryable => set;
		
		public IEnumerator<TEntity> GetEnumerator()
		{
			return Queryable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Type ElementType => Queryable.ElementType;
		public Expression Expression => Queryable.Expression;
		public IQueryProvider Provider => Queryable.Provider;

		public async Task Add(TEntity entity)
		{
			await set.AddAsync(entity);
		}

		public Task Remove(TEntity entity)
		{
			set.Remove(entity);
			return Task.CompletedTask;
		}
	}
}