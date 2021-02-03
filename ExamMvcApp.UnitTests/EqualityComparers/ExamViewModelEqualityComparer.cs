using PL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMvcApp.UnitTests.EqualityComparers
{
	public class ExamViewModelEqualityComparer : IEqualityComparer<ExamViewModel>
	{
		public bool Equals(ExamViewModel x, ExamViewModel y)
		{
			if (x == null || y == null || x.GetType() != y.GetType())
			{
				return false;
			}

			if (x.Subject != y.Subject)
			{
				return false;
			}

			if (x.Title != y.Title)
			{
				return false;
			}

			if (x.Duration != y.Duration)
			{
				return false;
			}

			if (x.Grade != y.Grade)
			{
				return false;
			}

			return true;
		}

		public int GetHashCode([DisallowNull] ExamViewModel obj)
		{
			return obj.GetHashCode();
		}
	}
}