namespace Practice
{
	public interface IQuizService : IService<Quiz>
	{
	}
	
	internal class QuizService : Service<Quiz>, IQuizService
	{
		public QuizService(PracticeContext context) : base(context.Quizzes)
		{
		}
	}
}