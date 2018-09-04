using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public static class ServiceExtensions
	{
		public static void AddDataServices(this IServiceCollection services)
		{
			services.AddScoped<IProfileService, ProfileService>();
			services.AddScoped<ILectureService, LectureService>();
			services.AddScoped<IChapterService, ChapterService>();
			services.AddScoped<IQuizService, QuizService>();
			services.AddScoped<IQuestionService, QuestionService>();
			services.AddScoped<IAnswerService, AnswerService>();
		}
	}
}