using System.Text.RegularExpressions;
using Shelter;

namespace Practice
{
	public class CreateProfileRequestValidation : Validation<CreateProfileRequestViewModel>
	{
		protected override void Validate(IValidationContext validationContext, CreateProfileRequestViewModel model)
		{
			validationContext.Validate(model, m => m.Name)
				.If(() => string.IsNullOrWhiteSpace(model.Name))
				.Add<CreateProfileRequestValidationSection>(x => x.NameMustBeSet);
			
			validationContext.Validate(model, m => m.Name)
				.When(() => model.Name.Length < 2)
				.Add<CreateProfileRequestValidationSection>(x => x.TooShortName);
			
			validationContext.Validate(model, m => m.Name)
				.When(() => model.Name.Length > 30)
				.Add<CreateProfileRequestValidationSection>(x => x.TooLongName);
			
			validationContext.Validate(model, m => m.Group)
				.If(() => string.IsNullOrWhiteSpace(model.Group))
				.Add<CreateProfileRequestValidationSection>(x => x.GroupMustBeSet);
			
			validationContext.Validate(model, m => m.Group)
				.When(() => !Regex.IsMatch(model.Group, @"^[аисбоАИСБО]{4}-\d\d-\d\d"))
				.Add<CreateProfileRequestValidationSection>(x => x.GroupPattern);
		}
	}
	
	public class CreateProfileRequestValidationSection : ValidationSection
	{
		public CreateProfileRequestValidationSection()
		{
			NameMustBeSet = Register(() => "Укажите свое имя");
			TooShortName = Register(() => "Слишком короткое имя");
			TooLongName = Register(() => "Слишком длинное имя");
			GroupMustBeSet = Register(() => "Укажите свою группу");
			GroupPattern = Register(() => "Название группы должно быть в формате 'ХХХХ-11-11'");
			QuestionsMustBeUnique = Register(() => "Вопросы должны быть уникальными");
		}

		public ValidationMessage NameMustBeSet { get; }
		public ValidationMessage TooShortName { get; }
		public ValidationMessage TooLongName { get; }
		public ValidationMessage GroupMustBeSet { get; }
		public ValidationMessage GroupPattern { get; }
		public ValidationMessage QuestionsMustBeUnique { get; }
	}
}