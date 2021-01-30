using DAL.HelperClasses;
using DAL.IdentityData;
using DAL.Models;
using DAL.Repositories.BaseRipositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ExamRipositories
{
	public class ExamRepository : BaseRepository<Exam>, IExamRepository
	{
		protected ApplicationDbContext Context { get => _context as ApplicationDbContext; }

		public ExamRepository(ApplicationDbContext context) : base(context)
		{
		}

		// getting
		public Exam GetByIdIncludingUsers(object id)
		{
			return GetByIdIncluding(id, nameof(Exam.Students), e => e.Id == (int)id);
		}

		public IEnumerable<Exam> GetAllIncludingUsers()
		{
			return GetAllIncluding(nameof(Exam.Students));
		}

		public IEnumerable<Exam> GetByUserAsNoTracking(ClaimsPrincipal user)
		{
			var id = ClaimsUserParser.GetNameIdentifier(user);

			// eagerly load only the related Users who match the id
			var examsWithLoadedUsers = Context.Exams.AsNoTracking()
					.Include(e => e.Students
						.Where(u => u.Id == id))
					//.Where(e => e.Users.Count == 1)
					.ToList();

			// filter out the exams that weren't assigned to the user
			var filteredExams = examsWithLoadedUsers.Where(e => e.Students.Count > 0).ToList();

			return filteredExams;
		}
	}
}
