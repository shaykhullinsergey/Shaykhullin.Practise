using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Shelter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
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
			if (DatabaseConfiguration.ShouldUpdateDatabase)
			{
				using (var scope = app.ApplicationServices.CreateScope())
				{
					DatabaseConfiguration.Configure(scope.ServiceProvider.GetRequiredService<PracticeDatabaseContext>());
				}
			}
			
			app.ApplicationServices.ConfigureComponents();

			app.UseMiddleware<ErrorHandlingMiddleware>();
			app.UseValidation();
			app.UseMiddleware<SaveChangesMiddleware>();
			
			app.UseMvc();
			
			PopulateDb(app.ApplicationServices);
		}
	}
}