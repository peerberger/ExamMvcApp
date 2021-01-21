using DAL.IdentityData;
using System.Collections.Generic;

namespace DAL.Models
{
	public class Teacher : AppUser
	{
		public int ClassroomId { get; set; }
		public ICollection<Classroom> Classrooms { get; set; }
		public ICollection<Subject> Subjects { get; set; }
	}
}