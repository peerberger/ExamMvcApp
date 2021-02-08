using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMvcApp.UnitTests.Generators
{
	public static class ExamsGenerator
	{
		public static IEnumerable<Exam> GenerateExams()
		{
			var exams = new List<Exam>
			{
				new Exam { Subject = new Subject { Name="math"}, Title = "calculus",Duration = TimeSpan.FromMinutes(1), Grades = new List<Grade> { new Grade() }},
				new Exam { Subject = new Subject { Name="math"}, Title = "algebra",Duration = TimeSpan.FromMinutes(2), Grades = new List<Grade> { new Grade { Score = 95 } } },
				new Exam { Subject = new Subject { Name="pop"}, Title = "blabla",Duration = TimeSpan.FromMinutes(3), Grades = new List<Grade> { new Grade() }},
				new Exam { Subject = new Subject { Name="pop"}, Title = "lalala",Duration = TimeSpan.FromMinutes(4), Grades = new List<Grade> { new Grade() }}
			};

			return exams;
		}

		public static IEnumerable<Exam> GenerateFutureExams()
		{
			var exams = new List<Exam>
			{
				new Exam { Subject = new Subject { Name="math"}, Title = "calculus",Duration = TimeSpan.FromMinutes(1), Grades = new List<Grade> { new Grade() }},
				new Exam { Subject = new Subject { Name="pop"}, Title = "blabla",Duration = TimeSpan.FromMinutes(3), Grades = new List<Grade> { new Grade() }},
				new Exam { Subject = new Subject { Name="pop"}, Title = "lalala",Duration = TimeSpan.FromMinutes(4), Grades = new List<Grade> { new Grade() }}
			};

			return exams;
		}

		public static IEnumerable<Exam> GeneratePastExams()
		{
			var exams = new List<Exam>
			{
				new Exam { Subject = new Subject { Name="math"}, Title = "algebra",Duration = TimeSpan.FromMinutes(2), Grades = new List<Grade> { new Grade { Score = 95 } } },
			};

			return exams;
		}
	}
}
