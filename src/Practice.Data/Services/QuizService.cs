namespace Practice
{
	public interface IQuizService : IService<Quiz>
	{
	}
	
	internal class QuizService : Service<Quiz>, IQuizService
	{
		public QuizService(PracticeDatabaseContext databaseContext) : base(databaseContext.Quizzes)
		{
		}
	}
}