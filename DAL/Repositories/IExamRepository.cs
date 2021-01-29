using DAL.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace DAL.Repositories
{
	public interface IExamRepository : IRepository<Exam>
	{
		Exam GetByIdIncludingUsers(object id);
		IEnumerable<Exam> GetAllIncludingUsers();
		IEnumerable<Exam> GetByUserAsNoTracking(ClaimsPrincipal user);
	}
}