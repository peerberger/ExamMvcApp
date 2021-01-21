using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Exam
	{
		public int Id { get; set; }
		public int SubjectId { get; set; }
		[Required]
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		[Required]
		public string TeacherId { get; set; }
		public ICollection<Classroom> Classrooms { get; set; }
		public ICollection<Question> Questions { get; set; }
		public int? TotalPoints { get; set; }
	}
}
