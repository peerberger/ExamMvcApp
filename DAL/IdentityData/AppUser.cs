using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.IdentityData
{
	public class AppUser : IdentityUser
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string GovId { get; set; }
		//public ICollection<Exam> Exams { get; set; }
	}
}
