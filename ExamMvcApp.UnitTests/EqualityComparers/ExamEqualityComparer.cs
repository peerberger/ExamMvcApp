using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMvcApp.UnitTests.EqualityComparers
{
	public class ExamEqualityComparer : IEqualityComparer<Exam>
	{
		public bool Equals(Exam x, Exam y)
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
			
			if (x.Grades.FirstOrDefault().Score != y.Grades.FirstOrDefault().Score)
			{
				return false;
			}

			return true;
		}

		public int GetHashCode([DisallowNull] Exam obj)
		{
			return obj.GetHashCode();
		}
	}
}
