using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module = Shelter.Module;

namespace Practice
{
	public interface IConfiguration
	{
	}
	
	public static class ConfigurationExtensions
	{
		public static IWebHostBuilder AddConfiguration<TConfiguration>(this IWebHostBuilder builder)
			where TConfiguration : IConfiguration, new()
		{
			builder.ConfigureAppConfiguration((context, config) =>
			{
				builder.ConfigureServices(services =>
				{
					var configuration = new TConfiguration();
					context.Configuration.Bind(configuration);
					RegisterRecursive(services, configuration);
				});
			});
			
			return builder;
		}
		
		private static void RegisterRecursive(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration.GetType(), configuration);
			
			foreach (var innerConfiguration in GetInnerConfigurations(configuration))
			{
				RegisterRecursive(services, innerConfiguration);
			}
		}

		private static IEnumerable<IConfiguration> GetInnerConfigurations(IConfiguration configuration)
		{
			return configuration.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.Where(x => x.CanRead)
				.Where(x => typeof(IConfiguration).IsAssignableFrom(x.PropertyType))
				.Select(x => (IConfiguration)x.GetValue(configuration));
		}
	}
	
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