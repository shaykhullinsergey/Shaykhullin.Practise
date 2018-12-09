using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("questions")]
	public class Question
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("text")]
		public string Text { get; set; }
		
		public virtual ICollection<Answer> Answers { get; set; }
	}
}