using Shelter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Practice.Web
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddModule<PracticeDataModule>();
			services.AddModule<PracticeWebModule>();
			
			services.ConfigureComponents();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.ApplicationServices.ConfigureComponents();

			app.UseMiddleware<ErrorHandlingMiddleware>();
			app.UseValidation();
			app.UseMiddleware<SaveChangesMiddleware>();
			
			app.UseMvc();
		}
	}
}