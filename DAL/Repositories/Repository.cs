using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly DbContext _context;

		public Repository(DbContext context)
		{
			_context = context;
		}

		// getting
		public TEntity GetById(object id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		//public TEntity GetById(object id, string includeProperty)
		//{
		//	return Context.Set<TEntity>().Include(includeProperty).quer.Find(id);
		//}

		public IEnumerable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().ToList();
		}

		// TODO: do this xml documentaion on all methods
		/// <summary>
		/// <para>Gets all the entities of type TEntity, with.</para>
		/// </summary>
		/// <param name="navigationPropertyPath"></param>
		/// <returns>fafa</returns>
		protected IEnumerable<TEntity> GetAllIncluding(string navigationPropertyPath = null)
		{
			if (navigationPropertyPath != null)
			{
				return _context.Set<TEntity>().Include(navigationPropertyPath).ToList(); 
			}

			return _context.Set<TEntity>().ToList();
		}

		// todo: when the project's finished delete all unused methods
		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate);
		}

		// adding
		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().AddRange(entities);
		}

		// removing
		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
		}
	}

}
