using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Grade
	{
		[Required]
		public string StudentId { get; set; }
		public Student Student { get; set; }
		public int ExamId { get; set; }
		public Exam Exam { get; set; }
		public double? Score { get; set; }
	}
}
