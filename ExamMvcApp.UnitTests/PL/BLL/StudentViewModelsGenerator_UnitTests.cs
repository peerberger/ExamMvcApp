using DAL.Models;
using ExamMvcApp.UnitTests.EqualityComparers;
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
			var exams = GenerateExams();
			var expected = GenerateIndexViewModel();

			// act
			var actual = StudentViewModelsGenerator.GenerateIndexViewModel(exams);

			// assert
			Assert.Equal(
				expected.FututreExams,
				actual.FututreExams,
				new ExamViewModelEqualityComparer());
			Assert.Equal(
				expected.PastExams,
				actual.PastExams,
				new ExamViewModelEqualityComparer());
		}

		public IEnumerable<Exam> GenerateExams()
		{
			var exams = new List<Exam>
			{
				new Exam {Subject = "math",Title = "calculus",Duration = TimeSpan.FromMinutes(1), Grades = new List<Grade> { new Grade() }},
				new Exam {Subject = "math",Title = "algebra",Duration = TimeSpan.FromMinutes(2), Grades = new List<Grade> { new Grade { Score = 95 } } },
				new Exam {Subject = "math",Title = "blabla",Duration = TimeSpan.FromMinutes(3), Grades = new List<Grade> { new Grade() }}
			};

			return exams;
		}

		public IndexViewModel GenerateIndexViewModel()
		{
			var indexViewModel = new IndexViewModel();

			indexViewModel.FututreExams = new List<ExamViewModel>
			{
				new ExamViewModel {Subject = "math",Title = "calculus",Duration = TimeSpan.FromMinutes(1)},
				new ExamViewModel {Subject = "math",Title = "blabla",Duration = TimeSpan.FromMinutes(3)}
			};

			indexViewModel.PastExams = new List<ExamViewModel>
			{
				new ExamViewModel {Subject = "math",Title = "algebra",Duration = TimeSpan.FromMinutes(2), Grade =  95 }
			};

			return indexViewModel;
		}
	}
}
