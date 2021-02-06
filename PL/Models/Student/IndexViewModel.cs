using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models.Student
{
	public class IndexViewModel
	{
		public ICollection<SubjectViewModel> FutureExamsTable { get; set; }
			= new List<SubjectViewModel>();
		public ICollection<SubjectViewModel> PastExamsTable { get; set; }
			= new List<SubjectViewModel>();
	}
}
