using DAL.Models;
using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.BLL
{
	public static class ExamToExamViewModelConverter
	{
		public static ExamViewModel Convert(Exam exam)
		{
			ExamViewModel examViewModel = new ExamViewModel();

			examViewModel.Subject = exam.Subject;
			examViewModel.Title = exam.Title;
			examViewModel.Duration = exam.Duration;
			examViewModel.Grade = exam.Grades.FirstOrDefault().Score;

			return examViewModel;
		}
	}
}
