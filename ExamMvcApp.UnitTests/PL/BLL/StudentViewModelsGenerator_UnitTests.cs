using DAL.Models;
using ExamMvcApp.UnitTests.EqualityComparers;
using ExamMvcApp.UnitTests.Generators;
using PL.BLL;
using PL.Models.Shared;
using PL.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExamMvcApp.UnitTests.PL.BLL
{
	public class StudentViewModelsGenerator_UnitTests
	{
		[Fact]
		public void GenerateIndexViewModel_ShouldWork()
		{
			// arrange
			var exams = ExamsGenerator.GenerateExams();
			var expected = GenerateIndexViewModel();

			// act
			var actual = StudentViewModelsGenerator.GenerateIndexViewModel(exams);

			// assert
			Assert.Equal(
				expected.FutureExamsTable,
				actual.FutureExamsTable,
				new SubjectViewModelEqualityComparer());

			Assert.Equal(
				expected.PastExamsTable,
				actual.PastExamsTable,
				new SubjectViewModelEqualityComparer());
		}

		public IndexViewModel GenerateIndexViewModel()
		{
			var indexViewModel = new IndexViewModel();

			indexViewModel.FutureExamsTable = new List<SubjectViewModel>
			{
				new SubjectViewModel
				{
					Name = "math",
					Exams = new List<ExamViewModel>
					{
						new ExamViewModel { Title = "calculus",Duration = TimeSpan.FromMinutes(1)},
					}
				},
				new SubjectViewModel
				{
					Name = "pop",
					Exams = new List<ExamViewModel>
					{
						new ExamViewModel { Title = "blabla",Duration = TimeSpan.FromMinutes(3)},
						new ExamViewModel { Title = "lalala",Duration = TimeSpan.FromMinutes(4)}
					}
				}
			};

			indexViewModel.PastExamsTable = new List<SubjectViewModel>
			{
				new SubjectViewModel
				{
					Name = "math",
					Exams = new List<ExamViewModel>
					{
						new ExamViewModel { Title = "algebra",Duration = TimeSpan.FromMinutes(2), Grade =  95 }
					}
				}
			};

			return indexViewModel;
		}
	}
}
