using DAL.IdentityData;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

		// getting
		public Exam GetByIdIncludingUsers(object id)
		{
			return GetByIdIncluding(id, nameof(Exam.Users), e => e.Id == (int)id);
		}

		public IEnumerable<Exam> GetAllIncludingUsers()
		{
			return GetAllIncluding(nameof(Exam.Users));
		}

		public IEnumerable<Exam> GetByUser(ClaimsPrincipal user)
		{
			var id = user.FindFirst(ClaimTypes.NameIdentifier).Value;

			// eagerly load only the related Users who match the id
			var examsWithLoadedUsers = Context.Exams
					.Include(e => e.Users
						.Where(u => u.Id == id))
					//.Where(e => e.Users.Count == 1)
					.ToList();

			// filter out the exams that weren't assigned to the user
			var filteredExams = examsWithLoadedUsers.Where(e => e.Users.Count > 0).ToList();
				
				// project a collection of { exam, userId } tuples
				//.SelectMany(e => e.Users,
				//	(exam, user) => new { exam, userId = user.Id })

				// filter out the tuples the userId of which doesn't match the given id
				// (whose User wasn't even actually loaded)
				//.Where(examUser => examUser.userId == id)

				// of the remaining tuples, project only the exam property,
				// and convert to a list
				//.Select(examUser => examUser.exam)

			return filteredExams;
		}
	}
}
