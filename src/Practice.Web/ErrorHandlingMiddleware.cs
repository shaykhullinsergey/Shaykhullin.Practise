using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Practice
{
	public class ErrorHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception e)
			{
				var content = JsonConvert.SerializeObject(e.Data["ShelterData"]);
					
				context.Response.StatusCode = (int)e.Data["ShelterStatusCode"];
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(content);
			}
		}
	}
}