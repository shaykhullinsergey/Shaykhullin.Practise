using System.ComponentModel.DataAnnotations.Schema;

namespace Practice
{
	[Table("chapters")]
	public class Chapter
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("lectureId")]
		public int LectureId { get; set; }
		
		[Column("title")]
		public string Title { get; set; }
		
		[Column("text")]
		public string Text { get; set; }

		public virtual Lecture Lecture { get; set; }
	}
}