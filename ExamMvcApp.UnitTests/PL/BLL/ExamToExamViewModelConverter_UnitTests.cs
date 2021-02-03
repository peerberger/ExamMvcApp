using DAL.Models;
using ExamMvcApp.UnitTests.EqualityComparers;
using PL.BLL;
using PL.Models.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExamMvcApp.UnitTests.PL.BLL
{
	public class ExamToExamViewModelConverter_UnitTests
	{
		[Theory]
		[InlineData("math", "calc", 0.5, 95)]
		[InlineData(null, "calc", 0.5, 95)]
		public void Convert_SimpleValues_ShouldWork(
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
			var actual = ExamToExamViewModelConverter.Convert(exam);

			// assert
			Assert.Equal(expected, actual, new ExamViewModelEqualityComparer());
		}
	}
}
