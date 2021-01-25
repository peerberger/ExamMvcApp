using DAL.IdentityData;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class ExamRepository : Repository<Exam>, IExamRepository
	{
		protected ApplicationDbContext Context { get => _context as ApplicationDbContext; }

		public ExamRepository(ApplicationDbContext context) : base(context)
		{
		}

		public IEnumerable<Exam> GetAllIncludingUsers()
		{
			return GetAllIncluding(nameof(Exam.Users));
		}
	}
}
