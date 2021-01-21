using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Question
	{
		public int Id { get; set; }
		[Required]
		public string QuestionText { get; set; }
		public double Points { get; set; }
		[Required]
		public string Answer { get; set; }
		[Required]
		public string Option2 { get; set; }
		public string Option3 { get; set; }
		public string Option4 { get; set; }
		public string Option5 { get; set; }
		public string Option6 { get; set; }
	}
}