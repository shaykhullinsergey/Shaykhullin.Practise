using Shelter;

namespace Practice
{
	public class PracticeValidationComponent : ValidationComponent
	{
		public PracticeValidationComponent()
		{
			Validation<
				CreateProfileRequestViewModel,
				CreateProfileRequestValidation,
				CreateProfileRequestValidationSection>();
		}
	}
}