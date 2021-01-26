using DAL.IdentityData;
using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
	public interface IExamRepository : IRepository<Exam>
	{
		Exam GetByIdIncludingUsers(object id);
		IEnumerable<Exam> GetAllIncludingUsers();
	}
}