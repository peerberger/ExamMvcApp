using DAL.IdentityData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Exam
	{
		public int Id { get; set; }
		//public int SubjectId { get; set; }
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Subject { get; set; }
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		public ICollection<AppUser> Users { get; set; }





		//[Required]
		//public string TeacherId { get; set; }
		//public ICollection<Classroom> Classrooms { get; set; }
		//public ICollection<Question> Questions { get; set; }
		//public int? TotalPoints { get; set; }
	}
}
