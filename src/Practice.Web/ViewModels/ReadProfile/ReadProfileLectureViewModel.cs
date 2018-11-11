using System.Runtime.Serialization;

namespace Practice
{
	public class ReadProfileLectureViewModel
	{
		public ReadProfileLectureViewModel(Quiz quiz)
		{
			Id = quiz.LectureId;
			Title = quiz.Lecture.Title;
			Result = quiz.Result;
		}

		[DataMember(Name = "id")]
		public int Id { get; }

		[DataMember(Name = "title")]
		public string Title { get; }
		
		[DataMember(Name = "result")]
		public int? Result { get; }
	}
}