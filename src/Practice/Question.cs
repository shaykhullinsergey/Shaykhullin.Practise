using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("quiestions")]
	public class Question
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("quizId")]
		public int QuizId { get; set; }

		[Column("text")]
		public string Text { get; set; }
		
		public virtual ICollection<Answer> Answers { get; set; }
	}
}