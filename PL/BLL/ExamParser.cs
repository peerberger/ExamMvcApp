using DAL.Models;
using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.BLL
{
	public static class ExamParser
	{
		public static void ParseFutureAndPastExams(IEnumerable<Exam> exams, ref List<Exam> futureExams, ref List<Exam> pastExams)
		{
			foreach (var exam in exams)
			{
				if (exam.Grades.FirstOrDefault().Score == null)
				{
					futureExams.Add(exam);
				}
				else
				{
					pastExams.Add(exam);
				}
			}
		}

		public static ExamViewModel ConvertToExamViewModel(Exam exam)
		{
			ExamViewModel examViewModel = new ExamViewModel();

			//examViewModel.Subject = exam.Subject;
			examViewModel.Title = exam.Title;
			examViewModel.Duration = exam.Duration;
			examViewModel.Grade = exam.Grades.FirstOrDefault().Score;

			return examViewModel;
		}

		public static IEnumerable<ExamViewModel> ConvertToExamViewModels(IEnumerable<Exam> exams)
		{
			foreach (var exam in exams)
			{
				yield return ConvertToExamViewModel(exam);
			}
		}
	}
}
