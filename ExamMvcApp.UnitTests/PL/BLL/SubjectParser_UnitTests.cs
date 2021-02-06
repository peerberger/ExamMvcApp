using ExamMvcApp.UnitTests.EqualityComparers;
using ExamMvcApp.UnitTests.Generators;
using PL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SubjectViewModelEqualityComparer = ExamMvcApp.UnitTests.EqualityComparers.SubjectViewModelEqualityComparer;

namespace ExamMvcApp.UnitTests.PL.BLL
{
	public class SubjectParser_UnitTests
	{
		[Fact]
		public void ParseSubjectViewModels_ShouldWork()
		{
			// arrange
			var exams = ExamsGenerator.GenerateFutureExams();
			var expected = SubjectsGenerator.GenerateFutureSubjectViewModelsOrderedBySubject();

			// act
			var actual = SubjectParser.ParseSubjectViewModels(exams);

			// assert
			Assert.Equal(expected, actual, new SubjectViewModelEqualityComparer());
		}

		[Fact]
		public void ParseSubjectNames_ShouldWork()
		{
			// arrange
			var exams = ExamsGenerator.GenerateFutureExams();
			var expected = SubjectsGenerator.GenerateFutureSubjectNames();

			// act
			var actual = SubjectParser.ParseSubjectNames(exams);

			// assert
			Assert.Equal(expected, actual);
		}
	}
}
