using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Exam> Exams { get; }

		int SaveChanges();
	}
}

