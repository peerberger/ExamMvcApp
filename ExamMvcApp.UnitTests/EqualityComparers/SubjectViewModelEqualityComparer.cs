using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMvcApp.UnitTests.EqualityComparers
{
	public class SubjectViewModelEqualityComparer : IEqualityComparer<SubjectViewModel>
	{
		public bool Equals(SubjectViewModel x, SubjectViewModel y)
		{
			if (x == null || y == null || x.GetType() != y.GetType())
			{
				return false;
			}

			if (!string.Equals(x.Name, y.Name))
			{
				return false;
			}

			if (!Enumerable.SequenceEqual(x.Exams, y.Exams, new ExamViewModelEqualityComparer()))
			{
				return false;
			}

			return true;
		}

		public int GetHashCode([DisallowNull] SubjectViewModel obj)
		{
			return obj.GetHashCode();
		}
	}
}
