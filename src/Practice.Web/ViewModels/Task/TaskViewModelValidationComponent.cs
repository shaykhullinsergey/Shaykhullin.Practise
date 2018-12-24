using Shelter;

namespace Practice
{
	public class TaskViewModelValidationComponent : ValidationSection
	{
		public TaskViewModelValidationComponent()
		{
			InvalidLecture = Register(() => "Указан несуществующий идентификатор лекции");
			LectureIsNotAPractice = Register(() => "Указанный идентификатор не относится к практике");
		}

		public ValidationMessage InvalidLecture { get; set; }
		public ValidationMessage LectureIsNotAPractice { get; set; }
	}
}