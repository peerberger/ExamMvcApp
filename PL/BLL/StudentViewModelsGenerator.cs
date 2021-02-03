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
			var viewModel = new IndexViewModel();

			foreach (var exam in exams)
			{
				var examViewModel = ExamToExamViewModelConverter.Convert(exam);

				if (examViewModel.Grade == null)
				{
					viewModel.FututreExams.Add(examViewModel);
				}
				else
				{
					viewModel.PastExams.Add(examViewModel);
				}
			}

			return viewModel;
		}
	}
}
