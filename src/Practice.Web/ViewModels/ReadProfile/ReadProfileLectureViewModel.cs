using System.Runtime.Serialization;

namespace Practice
{
	public class ReadProfileLectureViewModel
	{
		public ReadProfileLectureViewModel(Quiz quiz)
		{
			Id = quiz.LectureId;
			Result = quiz.Result;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "result")]
		public int? Result { get; }
	}
}