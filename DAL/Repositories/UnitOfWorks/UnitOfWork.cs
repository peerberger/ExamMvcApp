using DAL.IdentityData;
using DAL.Models;
using DAL.Repositories.ExamRipositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		//public ApplicationDbContext Context { get => _context; }

		public IExamRepository Exams { get; set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Exams = new ExamRepository(_context);
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
