using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("quizzes")]
	public class Quiz
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("lectureId")]
		public int LectureId { get; set; }

		[Column("profileId")]
		public int ProfileId { get; set; }

		[Column("result")]
		public int? Result { get; set; }
		
		public virtual Profile Profile { get; set; }
		public virtual Lecture Lecture { get; set; }
	}
}