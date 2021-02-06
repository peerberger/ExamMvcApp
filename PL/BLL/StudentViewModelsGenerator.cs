using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using PL.Models.Shared;
using PL.Models.Student;

namespace PL.BLL
{
	public static class StudentViewModelsGenerator
	{
		public static IndexViewModel GenerateIndexViewModel(IEnumerable<Exam> exams)
		{
			// separating the passed exams to future and past exams
			var futureExams = new List<Exam>();
			var pastExams = new List<Exam>();
			ExamParser.ParseFutureAndPastExams(exams, ref futureExams, ref pastExams);

			// creating the IndexViewModel object
			var indexViewModel = new IndexViewModel();

			// converting the above exam lists to collections of SubjectViewModels,
			// and assigning them to the IndexViewModel's exam tables
			indexViewModel.FutureExamsTable = SubjectParser.ParseSubjectViewModels(futureExams);
			indexViewModel.PastExamsTable = SubjectParser.ParseSubjectViewModels(pastExams);

			// returning the IndexViewModel
			return indexViewModel;
		}
	}
}
