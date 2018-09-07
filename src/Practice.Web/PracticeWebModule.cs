using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shelter;

namespace Practice
{
	public class PracticeWebModule : Module
	{
		public override void Configure(IServiceCollection services)
		{
			services.AddResponseCompression();
			services.AddResponseCaching();
			
			services.AddMvc();
			services.AddDateTime<UtcDateTime>();
			services.AddConfiguration<PracticeConfiguration>();
			services.AddRouter<PracticeRouterComponent>();
			services.AddValidation<PracticeValidationComponent>();
			
			services.AddSingleton<SaveChangesMiddleware>();
		}
	}
}