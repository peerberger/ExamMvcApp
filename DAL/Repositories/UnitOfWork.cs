using DAL.IdentityData;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IRepository<Exam> Exams { get; set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Exams = new Repository<Exam>(_context);
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
