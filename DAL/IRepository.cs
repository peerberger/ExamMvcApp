//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Text;

//namespace DAL
//{
//	public interface IRepository<TEntity> where TEntity : class
//	{
//		// getting
//		TEntity GetById(object id);
//		IEnumerable<TEntity> GetAll();
//		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

//		// adding
//		void Add(TEntity entity);
//		void AddRange(IEnumerable<TEntity> entities);

//		// removing
//		void Remove(TEntity entity);
//		void RemoveRange(IEnumerable<TEntity> entities);
//	}

//}
