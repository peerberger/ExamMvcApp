using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models.Student
{
	public class ExamViewModel
	{
		public string Subject { get; set; }
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		public double? Grade { get; set; }
	}
}
