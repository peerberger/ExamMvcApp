using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models.Student
{
	public class IndexViewModel
	{
		public ICollection<ExamViewModel> FututreExams { get; set; }
			= new List<ExamViewModel>();
		public ICollection<ExamViewModel> PastExams { get; set; }
			= new List<ExamViewModel>();
	}
}
