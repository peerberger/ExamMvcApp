using DAL.Models;
using ExamMvcApp.UnitTests.EqualityComparers;
using ExamMvcApp.UnitTests.Generators;
using PL.BLL;
using PL.Models.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExamMvcApp.UnitTests.PL.BLL
{
	public class ExamParser_UnitTests
	{
		[Fact]
		public void ParseFutureAndPastExams_ShouldWork()
		{
			// arrange
			var exams = ExamsGenerator.GenerateExams();
			var expectedFutureExams = ExamsGenerator.GenerateFutureExams();
			var expectedPastExams = ExamsGenerator.GeneratePastExams();

			var actualFutureExams = new List<Exam>();
			var actualPastExams = new List<Exam>();

			// act
			ExamParser.ParseFutureAndPastExams(exams, ref actualFutureExams, ref actualPastExams);

			// assert
			Assert.Equal(expectedFutureExams, actualFutureExams, new ExamEqualityComparer());
			Assert.Equal(expectedPastExams, actualPastExams, new ExamEqualityComparer());
		}


		[Theory]
		[InlineData("math", "calc", 0.5, 95)]
		[InlineData(null, "calc", 0.5, 95)]
		public void ConvertToExamViewModel_SimpleValues_ShouldWork(
			string subject,
			string title,
			double duration,
			double? grade
			)
		{
			// arrange
			Exam exam = new Exam
			{
				Subject = subject,
				Title = title,
				Duration = TimeSpan.FromHours(duration),
				Grades = new List<Grade>
				{
					new Grade { Score = grade }
				}
			};

			ExamViewModel expected = new ExamViewModel
			{
				Subject = subject,
				Title = title,
				Duration = TimeSpan.FromHours(duration),
				Grade = grade
			};

			// act
			var actual = ExamParser.ConvertToExamViewModel(exam);

			// assert
			Assert.Equal(expected, actual, new ExamViewModelEqualityComparer());
		}
	}
}
