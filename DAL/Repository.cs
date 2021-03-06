﻿//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace DAL
//{
//	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//	{
//		protected readonly DbContext Context;

//		public Repository(DbContext context)
//		{
//			Context = context;
//		}

//		// getting
//		public TEntity GetById(object id)
//		{
//			return Context.Set<TEntity>().Find(id);
//		}

//		public IEnumerable<TEntity> GetAll()
//		{
//			return Context.Set<TEntity>().ToList();
//		}

//		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
//		{
//			return Context.Set<TEntity>().Where(predicate);
//		}

//		// adding
//		public void Add(TEntity entity)
//		{
//			Context.Set<TEntity>().Add(entity);
//		}

//		public void AddRange(IEnumerable<TEntity> entities)
//		{
//			Context.Set<TEntity>().AddRange(entities);
//		}

//		// removing
//		public void Remove(TEntity entity)
//		{
//			Context.Set<TEntity>().Remove(entity);
//		}

//		public void RemoveRange(IEnumerable<TEntity> entities)
//		{
//			Context.Set<TEntity>().RemoveRange(entities);
//		}
//	}

//}
