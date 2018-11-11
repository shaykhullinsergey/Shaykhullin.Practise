using Shelter;
using Practice.Web;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public class PracticeWebModule : Module
	{
		public override void Configure(IServiceCollection services)
		{
			services.AddMvc();
			services.AddDateTime<UtcDateTime>();
			services.AddConfiguration<PracticeConfiguration>();
			services.AddRouter<PracticeRouterComponent>();
			services.AddValidation<PracticeValidationComponent>();

			services.AddSingleton<ErrorHandlingMiddleware>();
			services.AddSingleton<SaveChangesMiddleware>();
		}
	}
}