using DAL.Models;
using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.BLL
{
	public static class SubjectParser
	{
		public static ICollection<SubjectViewModel> ParseSubjectViewModelsInOrder(IEnumerable<Exam> exams)
		{
			var subjectViewModels = new List<SubjectViewModel>();
			var subjectNames = ParseSubjectNames(exams);

			foreach (var subjectName in subjectNames)
			{
				var subjectViewModel = new SubjectViewModel { Name = subjectName };

				var subjectExams = exams.Where(e => e.Subject.Name == subjectName);
				var examViewModels = ExamParser.ConvertToExamViewModels(subjectExams);

				subjectViewModel.Exams.AddRange(examViewModels);

				subjectViewModels.Add(subjectViewModel);
			}

			return subjectViewModels.OrderBy(s => s.Name).ToList();
		}

		public static HashSet<string> ParseSubjectNames(IEnumerable<Exam> exams)
		{
			var subjectNames = new HashSet<string>();

			foreach (var exam in exams)
			{
				subjectNames.Add(exam.Subject.Name);
			}

			return subjectNames;
		}

		//public static HashSet<SubjectViewModel> ParseSubjectNames(IEnumerable<Exam> exams)
		//{
		//	var subjectViewModels = new HashSet<SubjectViewModel>(new SubjectViewModelEqualityComparer());

		//	foreach (var exam in exams)
		//	{
		//		var subjectViewModel = new SubjectViewModel { Name = exam.SubjectObj.Name };

		//		subjectViewModels.Add(subjectViewModel);
		//	}

		//	return subjectViewModels;
		//}
	}
}
