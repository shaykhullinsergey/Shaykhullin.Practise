using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("lectures")]
	public class Lecture
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("title")]
		public string Title { get; set; }

		public virtual ICollection<Chapter> Chapters { get; set; }
		public virtual ICollection<Quiz> Quizzes { get; set; }
		public virtual ICollection<Question> Questions { get; set; }
	}
}