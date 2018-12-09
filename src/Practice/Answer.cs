using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("answers")]
	public class Answer
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("questionId")]
		public int QuestionId { get; set; }

		[Column("text")]
		public string Text { get; set; }
		
		[Column("correct")]
		public bool Correct { get; set; }
		
		public virtual Question Question { get; set; }
	}
}