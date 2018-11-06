using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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

			app.Use(async (context, next) =>
			{
				try
				{
					await next();
				}
				catch (Exception e)
				{
					var content = JsonConvert.SerializeObject(e.Data["ShelterData"]);
					
					context.Response.StatusCode = (int)e.Data["ShelterStatusCode"];
					await context.Response.WriteAsync(content);
				}
			});
			
			app.UseValidation();
			
			app.UseMiddleware<SaveChangesMiddleware>();
			
			app.UseMvc();
		}
	}
}