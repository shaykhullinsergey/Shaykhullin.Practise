using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module = Shelter.Module;

namespace Practice
{
	public class PracticeDataModule : Module
	{
		public override void Configure(IServiceCollection services)
		{
			services.AddScoped<IProfileService, ProfileService>();
			services.AddScoped<ILectureService, LectureService>();
			services.AddScoped<IChapterService, ChapterService>();
			services.AddScoped<IQuizService, QuizService>();
			services.AddScoped<IQuestionService, QuestionService>();
			services.AddScoped<IAnswerService, AnswerService>();
			
			services.AddDbContext<PracticeDatabaseContext>(
				options =>
				{
					using (var provider = services.BuildServiceProvider())
					{
						var configuration = provider.GetRequiredService<PostgresConfiguration>();
						
						options.UseLazyLoadingProxies()
							.UseNpgsql(configuration.GetConnectionString(), o =>
							{
								o.MigrationsHistoryTable("migrations");
								o.MigrationsAssembly("Practice.Data");
							});
					}
				});
		}
	}
}