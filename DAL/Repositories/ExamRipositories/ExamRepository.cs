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

		public IEnumerable<Exam> GetAllIncludingStudents()
		{
			return GetAllIncluding(nameof(Exam.Students));
		}

		public IEnumerable<Exam> GetByStudentIncludingGradesAndSubjectsAsNoTracking(ClaimsPrincipal user)
		{
			var id = ClaimsUserParser.GetNameIdentifier(user);
			//var id = "e46f70c1-7913-4faf-a763-1061adb12eb0";

			// eagerly load only the related Users who match the id
			var examsWithLoadedStudents = Context.Exams.AsNoTracking()
				.Include(e => e.Grades
					.Where(u => u.StudentId == id))
				.Include(e => e.SubjectObj)
				//.Where(e => e.Grades.Count > 0)
				.ToList();

			// filter out the exams that weren't assigned to the user
			var filteredExams = examsWithLoadedStudents
				.Where(e => e.Grades.Count > 0)
				.ToList();

			return filteredExams;
		}
	}
}
