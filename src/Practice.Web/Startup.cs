using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shelter;

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
			
//			app.UseResponseCompression();
//			app.UseResponseCaching();
			app.UseValidation();
			
			app.UseMiddleware<SaveChangesMiddleware>();
			
			app.UseMvc();
		}
	}
}