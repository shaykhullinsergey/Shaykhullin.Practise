using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Practice.Web
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			
			services.AddDbContext<PracticeContext>(
				options => options
					.UseLazyLoadingProxies()
					.UseInMemoryDatabase(nameof(PracticeContext)));
				
			services.AddDataServices();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				await next();
				
				await context.RequestServices
					.GetRequiredService<PracticeContext>()
					.SaveChangesAsync();
			});
			app.UseMvc();
		}
	}
}