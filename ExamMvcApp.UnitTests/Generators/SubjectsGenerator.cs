using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMvcApp.UnitTests.Generators
{
	public static class SubjectsGenerator
	{
		public static IEnumerable<SubjectViewModel> GenerateFutureSubjectViewModelsOrderedBySubject()
		{
			var futureSubjectViewModels = new List<SubjectViewModel>
			{
				new SubjectViewModel
				{
					Name = "math",
					Exams = new List<ExamViewModel>
					{
						new ExamViewModel { Title = "calculus", Duration = TimeSpan.FromMinutes(1)}
					}
				},
				new SubjectViewModel
				{
					Name = "pop",
					Exams = new List<ExamViewModel>
					{
						new ExamViewModel { Title = "blabla", Duration = TimeSpan.FromMinutes(3)},
						new ExamViewModel { Title = "lalala", Duration = TimeSpan.FromMinutes(4)}
					}
				}
			};

			return futureSubjectViewModels;
		}

		public static HashSet<string> GenerateFutureSubjectNames()
		{
			var subjectNames = new HashSet<string>
			{
				"math",
				"pop"
			};

			return subjectNames;
		}
	}
}
