using DAL.IdentityData;
using System.Collections.Generic;

namespace DAL.Models
{
	public class Student : AppUser
	{
		//public int ClassroomId { get; set; }
		public ICollection<Exam> Exams { get; set; }
		public ICollection<Grade> Grades { get; set; }
	}
}