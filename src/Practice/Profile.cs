using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("profiles")]
	public class Profile
	{
		[Column("id")]
		public int Id { get; set; }
		
		[Column("name")]
		public string Name { get; set; }
		
		[Column("group")]
		public string Group { get; set; }
		
		[Column("session")]
		public string Session { get; set; }

		[Column("created")]
		public DateTime Created { get; set; }
		
		public virtual ICollection<Quiz> Quizzes { get; set; }
	}
}