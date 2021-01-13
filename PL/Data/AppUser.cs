using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Data
{
	public class AppUser : IdentityUser
	{
		public string GovId { get; set; }
	}
}
