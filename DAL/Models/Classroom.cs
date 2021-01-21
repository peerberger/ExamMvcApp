using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Classroom
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string TeacherId { get; set; }
		public ICollection<Student> Students { get; set; }
		public ICollection<Subject> Subjects { get; set; }
		public ICollection<Exam> Exams { get; set; }
	}
}