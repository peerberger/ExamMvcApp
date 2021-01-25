using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IExamRepository Exams { get; }

		int SaveChanges();
	}
}

