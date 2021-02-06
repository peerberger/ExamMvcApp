using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models.Shared
{
	public class SubjectViewModel
	{
		public string Name { get; set; }
		public List<ExamViewModel> Exams { get; set; }
			= new List<ExamViewModel>();
	}
}
