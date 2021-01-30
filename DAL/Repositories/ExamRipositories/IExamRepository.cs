using DAL.Models;
using DAL.Repositories.BaseRipositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace DAL.Repositories.ExamRipositories
{
	public interface IExamRepository : IBaseRepository<Exam>
	{
		Exam GetByIdIncludingUsers(object id);
		IEnumerable<Exam> GetAllIncludingStudents();
		IEnumerable<Exam> GetByStudentIncludingGradesAsNoTracking(ClaimsPrincipal user);
	}
}