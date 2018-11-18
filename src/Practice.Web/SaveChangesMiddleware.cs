using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public class SaveChangesMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await next(context);

			var databaseContext = context.RequestServices.GetRequiredService<PracticeDatabaseContext>();

			if (databaseContext.ChangeTracker.HasChanges())
			{
				await databaseContext.SaveChangesAsync();
			}
		}
	}
}