namespace Practice
{
	public interface IAnswerService : IService<Answer>
	{
	}
	
	internal class AnswerService : Service<Answer>, IAnswerService
	{
		public AnswerService(PracticeContext context) : base(context.Answers)
		{
		}
	}
}