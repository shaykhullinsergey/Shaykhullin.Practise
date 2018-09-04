namespace Practice
{
	public interface IQuestionService : IService<Question>
	{
		
	}
	
	internal class QuestionService : Service<Question>, IQuestionService
	{
		public QuestionService(PracticeContext context) : base(context.Questions)
		{
		}
	}
}