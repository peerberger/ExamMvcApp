using DAL.Models;
using DAL.Repositories.ExamRipositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.UnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		IExamRepository Exams { get; }

		int SaveChanges();
	}
}

