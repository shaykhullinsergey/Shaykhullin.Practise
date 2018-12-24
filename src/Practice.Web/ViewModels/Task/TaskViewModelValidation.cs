using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Shelter;

namespace Practice
{
	public class TaskViewModelValidation : Validation<TaskCompleteViewModel>
	{
		protected override void Validate(IValidationContext validationContext, TaskCompleteViewModel model)
		{
			var lecture = validationContext.GetRequiredService<ILectureService>()
				.FirstOrDefault(x => x.Id == model.LectureId);
			
			validationContext.Validate(model, m => m.LectureId)
				.If(() => lecture == null)
				.Add<TaskViewModelValidationComponent>(c => c.InvalidLecture);

			validationContext.Validate(model, m => m.LectureId)
				.When(() => !lecture.IsPractice)
				.Add<TaskViewModelValidationComponent>(c => c.LectureIsNotAPractice);
		}
	}
}