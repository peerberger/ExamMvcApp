using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Subject
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		//public ICollection<Teacher> Teachers { get; set; }
		public ICollection<Exam> Exams { get; set; }
		//public ICollection<Classroom> Classrooms { get; set; }
	}
}