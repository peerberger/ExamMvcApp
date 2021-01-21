using DAL.IdentityData;

namespace DAL.Models
{
	public class Student : AppUser
	{
		public int ClassroomId { get; set; }
	}
}