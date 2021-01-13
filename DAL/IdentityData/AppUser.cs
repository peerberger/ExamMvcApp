using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.IdentityData
{
	public class AppUser : IdentityUser
	{
		public string GovId { get; set; }
	}
}
